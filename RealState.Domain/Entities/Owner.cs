// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="Owner.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace RealState.Domain.Entities
{
	/// <summary>
	/// Class Owner.
	/// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Entities.BaseEntity" />
	public class Owner : BaseEntity
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
		public DateTime Birthday { get; set; }
	}
}