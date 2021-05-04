// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="PropertyRequestDto.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Application.DTO.Property
{
	/// <summary>
	/// Class PropertyRequestDto.
	/// Implements the <see cref="RealState.Application.DTO.QueryParamDto" />
	/// </summary>
	/// <seealso cref="RealState.Application.DTO.QueryParamDto" />
	public class PropertyRequestDto  
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int Year { get; set; }
	 
		/// <summary>
		/// Gets or sets the code internal.
		/// </summary>
		/// <value>The code internal.</value>
		public string CodeInternal { get; set; }
	}
}