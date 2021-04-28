// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="PermisoConfiguration.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace RealState.Infrastructure.DataAccessEntityFrameWork.Configurations
{
	using Domain.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Class PermisoConfiguration.
	/// Implements the <see cref="Permisos" />
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Permisos}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Permisos}" />
	/// <seealso cref="Permisos" />
	public class PermisoConfiguration : IEntityTypeConfiguration<Permisos>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void Configure(EntityTypeBuilder<Permisos> builder)
		{
			builder.Property(e => e.Nombre)
				   .IsRequired()
				   .HasMaxLength(100)
				   .IsUnicode(false);
		}
	}
}