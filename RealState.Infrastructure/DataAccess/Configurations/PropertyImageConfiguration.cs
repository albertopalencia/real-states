// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyImageConfiguration.cs" company="RealState.Infrastructure">
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
	/// Class PropertyImageConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PropertyImage}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PropertyImage}" />
	public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void Configure(EntityTypeBuilder<PropertyImage> builder)
		{

			builder.HasKey(e => e.Id)
					.HasName("PK_Property_IdPropertyImage");

			builder.Property(e => e.Id).HasColumnName("IdPropertyImage"); 
 

			builder.Property(e => e.Enabled).HasDefaultValueSql("((1))");

				builder.Property(e => e.File)
					.IsRequired()
					.HasMaxLength(500)
					.IsUnicode(false);

				builder.HasOne(d => d.IdPropertyNavigation)
					.WithMany(p => p.PropertyImage)
					.HasForeignKey(d => d.IdProperty)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_PropertyImage_IdProperty");
			 

		}
	}
}