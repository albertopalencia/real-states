// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="Startup.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using Microsoft.AspNetCore.ResponseCompression;
using RealState.Application.Abstract;
using RealState.Application.Implements;
using RealState.Domain.Entities;

namespace RealState.Api
{
	using Application.Abstract.General;
	using Application.Implements.General;
	using Filters;
	using FluentValidation.AspNetCore;
	using Infrastructure.Extensions;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Reflection;
	using System.Text;

	/// <summary>
	/// Class Startup.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup" /> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add<ValidatorActionFilter>();
			}).AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			});

			services.AddControllers(options =>
			{
				options.Filters.Add<GlobalExceptionFilter>();
			}).AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
				options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
			})
			.ConfigureApiBehaviorOptions(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			ConfigureServiceAdd(services);
		}

		/// <summary>
		/// Configures the service add.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServiceAdd(IServiceCollection services)
		{
			services.AddOptions(Configuration);

			services.AddDbContexts(Configuration);

			AddApplicationService(services);

			services.AddServices();
			services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
			AddAuthentication(services);

			services.AddCors(o => o.AddPolicy("AllowClientApp", builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));

			services.AddResponseCompression(c =>
			{
				c.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
				{
					"image/svg+xml"
				});

			});


			services.AddResponseCaching();
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
				options.RoutePrefix = string.Empty;
				options.DefaultModelsExpandDepth(-1);
			});

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseResponseCaching();

			app.UseResponseCompression();

			app.Use(async (context, next) =>
			{
				context.Response.GetTypedHeaders().CacheControl =
					new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
					{
						Public = true,
						MaxAge = TimeSpan.FromSeconds(5)
					};
				context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
					new string[] { "Accept-Encoding" };

				await next();
			});

			app.UseCors("AllowClientApp");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Adds the application service.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public void AddApplicationService(IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddSingleton<IPasswordService, PasswordService>();
			services.AddScoped<IPropertyImageService, PropertyImageService>();
			services.AddScoped<IPropertyService, PropertyService>();
			services.AddScoped<IPropertyTraceService, PropertyTraceService>();
			services.AddScoped<IOwnerService, OwnerService>();
		}

		/// <summary>
		/// Adds the authentication.
		/// </summary>
		/// <param name="services">The services.</param>
		public void AddAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["Authentication:Issuer"],
					ValidAudience = Configuration["Authentication:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
				};
			});
		}
	}
}