// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="Property.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Entities
{
	/// <summary>
	/// Class Property.
	/// </summary>
	public class Property : BaseEntity
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
		public int Year { get; set; }

		/// <summary>
		/// Gets or sets the identifier owner.
		/// </summary>
		/// <value>The identifier owner.</value>
		public int IdOwner { get; set; }
	}
}