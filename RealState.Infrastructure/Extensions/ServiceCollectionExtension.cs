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

	[ExcludeFromCodeCoverage]
	public static class ServiceCollectionExtension
	{
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
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IPropertyRepository, PropertyRepository>();
			services.AddTransient<IOwnerRepository, OwnerRepository>();
			services.AddTransient<IOwnerRepository, OwnerRepository>();
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