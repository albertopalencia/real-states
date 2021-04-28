// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="Permisos.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Entities
{
	using System.Collections.Generic;

	/// <summary>
	/// Class Permisos.
	/// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Entities.BaseEntity" />
	public partial class Permisos : BaseEntity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Permisos"/> class.
		/// </summary>
		public Permisos()
		{
			PermisosRol = new HashSet<PermisosRol>();
		}
 
		/// <summary>
		/// Gets or sets the nombre.
		/// </summary>
		/// <value>The nombre.</value>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the permisos rol.
		/// </summary>
		/// <value>The permisos rol.</value>
		public virtual ICollection<PermisosRol> PermisosRol { get; set; }
	}
}