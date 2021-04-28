namespace RealState.Infrastructure.Extensions
{
	using DataAccessEntityFrameWork;
	using Domain.Enumerations;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.OpenApi.Models;
	using Options;
	using Repositories;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.IO;

	[ExcludeFromCodeCoverage]
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RealStateContext>(options =>
			 options.UseSqlServer(configuration[CadenaConexionDomainEnum.RealState.Name],
			   sqlOptions =>
			   {
				   sqlOptions.EnableRetryOnFailure(
				   10,
				   TimeSpan.FromSeconds(30),
				   null);
			   })
		   );

			return services;
		}

		public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<PaginacionOpcion>(options => configuration.GetSection("PaginacionOpcion").Bind(options));
			services.Configure<ContrasenaOpcion>(options => configuration.GetSection("ContrasenaOpcion").Bind(options));
			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
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