// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="Roles.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Entities
{
	using System.Collections.Generic;

	/// <summary>
	/// Class Roles.
	/// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Entities.BaseEntity" />
	public partial class Roles : BaseEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Roles"/> class.
		/// </summary>
		public Roles()
		{
			PermisosRol = new HashSet<PermisosRol>();
		}
		 

		/// <summary>
		/// Gets or sets the rol.
		/// </summary>
		/// <value>The rol.</value>
		public string Rol { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Roles"/> is estado.
		/// </summary>
		/// <value><c>null</c> if [estado] contains no value, <c>true</c> if [estado]; otherwise, <c>false</c>.</value>
		public bool? Estado { get; set; }

		/// <summary>
		/// Gets or sets the usuarios.
		/// </summary>
		/// <value>The usuarios.</value>
		public virtual Usuarios Usuarios { get; set; }

		/// <summary>
		/// Gets or sets the permisos rol.
		/// </summary>
		/// <value>The permisos rol.</value>
		public virtual ICollection<PermisosRol> PermisosRol { get; set; }
	}
}