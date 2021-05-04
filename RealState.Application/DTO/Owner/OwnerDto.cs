// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="OwnerDto.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
 

namespace RealState.Application.DTO.Owner
{
	/// <summary>
	/// Class OwnerDto.
	/// </summary>
	public class OwnerDto
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; set; }

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
		/// Performs an implicit conversion from <see cref="Domain.Entities.Owner" /> to <see cref="OwnerList" />.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator OwnerDto(Domain.Entities.Owner owner) =>
			new OwnerDto
			{
				Id = owner.Id,
				Address = owner.Address, 
				Name = owner.Name

			};
	}
}