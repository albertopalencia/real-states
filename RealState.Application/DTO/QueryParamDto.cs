// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="QueryParamDto.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Application.DTO
{
	/// <summary>
	/// Class QueryParamDto.
	/// </summary>
	public class QueryParamDto
	{
		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize { get; set; }
		/// <summary>
		/// Gets or sets the page number.
		/// </summary>
		/// <value>The page number.</value>
		public int PageNumber { get; set; }
	}
}