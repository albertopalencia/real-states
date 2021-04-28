// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="UsuarioConfiguration.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.DataAccessEntityFrameWork.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using RealState.Domain.Entities;

	/// <summary>
	/// Class UsuarioConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Usuarios}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Usuarios}" />
	public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Usuarios> builder)
		{
			builder.Property(e => e.Id).ValueGeneratedOnAdd();

			builder.Property(e => e.Apellidos)
				.IsRequired()
				.HasMaxLength(150)
				.IsUnicode(false);

			builder.Property(e => e.Contrasena)
				.IsRequired()
				.HasMaxLength(1000)
				.IsUnicode(false);

			builder.Property(e => e.Direccion)
				.HasMaxLength(500)
				.IsUnicode(false);

			builder.Property(e => e.Email)
				.HasMaxLength(350)
				.IsUnicode(false);

			builder.Property(e => e.Nombres)
				.IsRequired()
				.HasMaxLength(150)
				.IsUnicode(false);

			builder.Property(e => e.Telefono)
				.HasMaxLength(12)
				.IsUnicode(false);

			builder.Property(e => e.Usuario)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(false);

			builder.HasOne(d => d.IdNavigation)
				.WithOne(p => p.Usuarios)
				.HasForeignKey<Usuarios>(d => d.Id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Usuarios_Roles");
		}
	}
}