// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-14-2021
// ***********************************************************************
// <copyright file="PermisoRolConfiguration.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.DataAccessEntityFrameWork.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Domain.Entities;

	/// <summary>
	/// Class PermisoRolConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PermisosRol}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PermisosRol}" />
	public class PermisoRolConfiguration : IEntityTypeConfiguration<PermisosRol>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<PermisosRol> builder)
		{
			builder.HasOne(d => d.Permiso)
				.WithMany(p => p.PermisosRol)
				.HasForeignKey(d => d.PermisoId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_PermisosRol_Permisos");

			builder.HasOne(d => d.Rol)
				.WithMany(p => p.PermisosRol)
				.HasForeignKey(d => d.RolId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_PermisosRol_Roles");
		}
	}
}