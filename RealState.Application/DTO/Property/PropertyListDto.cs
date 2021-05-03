// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyListDto.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.DTO.Property
{
	/// <summary>
	/// Class PropertyListDto.
	/// </summary>
	public class PropertyListDto
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>The address.</value>
		public string Address { get; set; }

		/// <summary>
		/// Gets or sets the price.
		/// </summary>
		/// <value>The price.</value>
		public decimal Price { get; set; }

		/// <summary>
		/// Gets or sets the code internal.
		/// </summary>
		/// <value>The code internal.</value>
		public string CodeInternal { get; set; }

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public int? Year { get; set; }

		/// <summary>
		/// Gets or sets the identifier owner.
		/// </summary>
		/// <value>The identifier owner.</value>
		public int IdOwner { get; set; }

		public static implicit operator PropertyListDto(Domain.Entities.Property property) =>
		   new PropertyListDto
		   {
			   Address = property.Address,
			   Price = property.Price,
			   CodeInternal = property.CodeInternal,
			   Year = property.Year,
			   Name = property.Name
		   };
	}
}