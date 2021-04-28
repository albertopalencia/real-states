// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="RealStateContext.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.DataAccessEntityFrameWork
{
	using Microsoft.EntityFrameworkCore;
	using Domain.Entities;
	using System.Reflection;

	/// <summary>
	/// Class RealStateContext.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public partial class RealStateContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RealStateContext" /> class.
		/// </summary>
		public RealStateContext()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RealStateContext" /> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public RealStateContext(DbContextOptions<RealStateContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// Gets or sets the permisos.
		/// </summary>
		/// <value>The permisos.</value>
		public virtual DbSet<Permisos> Permisos { get; set; }
		/// <summary>
		/// Gets or sets the permisos rol.
		/// </summary>
		/// <value>The permisos rol.</value>
		public virtual DbSet<PermisosRol> PermisosRol { get; set; }
		/// <summary>
		/// Gets or sets the roles.
		/// </summary>
		/// <value>The roles.</value>
		public virtual DbSet<Roles> Roles { get; set; }
		/// <summary>
		/// Gets or sets the usuarios.
		/// </summary>
		/// <value>The usuarios.</value>
		public virtual DbSet<Usuarios> Usuarios { get; set; }


		/// <summary>
		/// Override this method to further configure the model that was discovered by convention from the entity types
		/// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
		/// and re-used for subsequent instances of your derived context.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
		/// define extension methods on this object that allow you to configure aspects of the model that are specific
		/// to a given database.</param>
		/// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
		/// then this method will not be run.</remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}