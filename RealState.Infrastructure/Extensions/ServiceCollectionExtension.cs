// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="ServiceCollectionExtension.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RealState.Infrastructure.DataAccess;
using RealState.Infrastructure.Interfaces.Repository;
using RealState.Infrastructure.Repository;

namespace RealState.Infrastructure.Extensions
{
	using Domain.Enumerations;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.OpenApi.Models;
	using Options;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.IO;

	/// <summary>
	/// Class ServiceCollectionExtension.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public static class ServiceCollectionExtension
	{
		/// <summary>
		/// Adds the database contexts.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RealStateContext>(options =>
				options.UseSqlServer(configuration[ConnectionDomainEnum.RealState.Name],
				
				 sqlOptions =>
			   {
				   sqlOptions.EnableRetryOnFailure(
				   10,
				   TimeSpan.FromSeconds(30),
				   null);
			   }).EnableSensitiveDataLogging()
		   );

			return services;
		}

		/// <summary>
		/// Adds the options.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<PaginationOption>(options => configuration.GetSection("PaginationOption").Bind(options));
			services.Configure<PasswordOption>(options => configuration.GetSection("PasswordOption").Bind(options));
			return services;
		}

		/// <summary>
		/// Adds the services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IPropertyRepository, PropertyRepository>();
			services.AddTransient<IOwnerRepository, OwnerRepository>();
			services.AddTransient<IPropertyTraceRepository, PropertyTraceRepository>();
			services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();
			return services;
		}

		/// <summary>
		/// Adds the swagger.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="xmlFileName">Name of the XML file.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
		{
			services.AddSwaggerGen(doc =>
			{
				doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices Property ", Version = "v1" });

				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
				doc.IncludeXmlComments(xmlPath);

				var securitySchema = new OpenApiSecurityScheme
				{
					Description = "Authorization ",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				};
				doc.AddSecurityDefinition("Bearer", securitySchema);

				var securityRequirement = new OpenApiSecurityRequirement
				{
					{ securitySchema, new[] { "Bearer" } }
				};
				doc.AddSecurityRequirement(securityRequirement);
			});

			return services;
		}
	}
}