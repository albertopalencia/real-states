// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 03-25-2021
// ***********************************************************************
// <copyright file="ConfigureSwaggerOptions.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Api.Filters
{
	using Microsoft.AspNetCore.Mvc.ApiExplorer;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;
	using Microsoft.OpenApi.Models;
	using Swashbuckle.AspNetCore.SwaggerGen;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class ConfigureSwaggerOptions.
	/// Implements the <see cref="Microsoft.Extensions.Options.IConfigureOptions{Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions}" />
	/// </summary>
	/// <seealso cref="Microsoft.Extensions.Options.IConfigureOptions{Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions}" />
	[ExcludeFromCodeCoverage]
	public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		/// <summary>
		/// The provider
		/// </summary>
		private readonly IApiVersionDescriptionProvider _provider;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigureSwaggerOptions" /> class.
		/// </summary>
		/// <param name="provider">The provider.</param>
		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this._provider = provider;

		/// <summary>
		/// Invoked to configure a <typeparamref name="TOptions" /> instance.
		/// </summary>
		/// <param name="options">The options instance to configure.</param>
		public void Configure(SwaggerGenOptions options)
		{
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
			}
		}

		/// <summary>
		/// Creates the information for API version.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <returns>OpenApiInfo.</returns>
		[ExcludeFromCodeCoverage]
		private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
		{
			var info = new OpenApiInfo()
			{
				Title = "Prueba Tecnica Alberto Palencia",
				Version = description.ApiVersion.ToString(),
				Description = "Prueba tecnica ",
			};
			if (description.IsDeprecated)
			{
				info.Description += " This API version has been deprecated.";
			}
			return info;
		}
	}
}