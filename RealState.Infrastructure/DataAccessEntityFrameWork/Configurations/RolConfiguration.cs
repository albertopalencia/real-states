// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-14-2021
// ***********************************************************************
// <copyright file="RolConfiguration.cs" company="RealState.Infrastructure">
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
	/// Class RolConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Roles}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Roles}" />
	public class RolConfiguration : IEntityTypeConfiguration<Roles>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Roles> builder)
		{
			builder.Property(e => e.Estado)
				.IsRequired()
				.HasDefaultValueSql("((1))");

			builder.Property(e => e.Rol)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(false);
		}
	}
}