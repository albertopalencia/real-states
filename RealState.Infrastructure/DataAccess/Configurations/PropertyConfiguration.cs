// ***********************************************************************
// Assembly         : 
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="PropertyConfiguration.cs" company="AlbertPalencia">
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
	/// Class PropertyConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Property}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.Property}" />
	public class PropertyConfiguration : IEntityTypeConfiguration<Property>
	{

		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<Property> builder)
		{
			builder.ToTable("Property");

			builder.Property(e => e.Id)
				.HasColumnName("IdProperty");

			builder.Property(e => e.Name)
				   .IsRequired()
				   .HasMaxLength(150)
				   .IsUnicode(false);

			builder.Property(e => e.Address)
				.IsRequired()
				.HasMaxLength(150)
				.IsUnicode(false);


			builder.Property(e => e.Price)
				.IsRequired();

			builder.Property(e => e.CodeInternal)
				.HasMaxLength(50);


			builder.Property(e => e.Year);

			builder.Property(e => e.IdOwner);

		}
	}
}