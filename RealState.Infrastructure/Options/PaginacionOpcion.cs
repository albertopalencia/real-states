// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-09-2021
// ***********************************************************************
// <copyright file="PaginacionOpcion.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Options
{
	using System.Diagnostics.CodeAnalysis;


	/// <summary>
	/// Class PaginacionOpcion.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class PaginacionOpcion
	{

		/// <summary>
		/// Gets or sets the default size of the page.
		/// </summary>
		/// <value>The default size of the page.</value>
		public int DefaultPageSize { get; set; }


		/// <summary>
		/// Gets or sets the default page number.
		/// </summary>
		/// <value>The default page number.</value>
		public int DefaultPageNumber { get; set; }
	}
}