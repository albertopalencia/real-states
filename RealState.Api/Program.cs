// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="Program.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Api
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Hosting;
	using System.Diagnostics.CodeAnalysis;


	/// <summary>
	/// Class Program.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public static class Program
	{

		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Creates the host builder.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns>IHostBuilder.</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}