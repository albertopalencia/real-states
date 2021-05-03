// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="OwnerConfiguration.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.DataAccess.Configurations
{
	/// <summary>
	/// Class OwnerConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Owner}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Owner}" />
	public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Owner> builder)
		{
				builder.Property(e => e.Id)
				.HasColumnName("IdOwner");
			 

				builder.Property(e => e.Address)
					.HasMaxLength(100)
					.IsUnicode(false);

				builder.Property(e => e.Birthday).HasColumnType("date");

				builder.Property(e => e.Name)
					.HasMaxLength(70)
					.IsUnicode(false);

				builder.Property(e => e.Photo)
					.HasMaxLength(200)
					.IsUnicode(false);
			

		}
	}
}