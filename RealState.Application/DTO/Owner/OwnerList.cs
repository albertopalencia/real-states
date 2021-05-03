// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="OwnerList.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace RealState.Application.DTO.Owner
{
	/// <summary>
	/// Class OwnerList.
	/// </summary>
	public class OwnerList
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
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public string Photo { get; set; }

		/// <summary>
		/// Gets or sets the birthday.
		/// </summary>
		/// <value>The birthday.</value>
		public DateTime? Birthday { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="Domain.Entities.Owner"/> to <see cref="OwnerList"/>.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator OwnerList(Domain.Entities.Owner owner) =>
			new OwnerList
			{
				Address = owner.Address,
				Birthday = owner.Birthday,
				Name = owner.Name,
				Photo = owner.Photo
			};
	}
}