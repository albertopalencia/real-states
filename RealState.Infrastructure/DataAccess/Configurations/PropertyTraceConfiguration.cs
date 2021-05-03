// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyTraceConfiguration.cs" company="RealState.Infrastructure">
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
	/// Class PropertyTraceConfiguration.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PropertyTrace}" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RealState.Domain.Entities.PropertyTrace}" />
	public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
	{
		/// <summary>
		/// Configures the entity of type <typeparamref name="TEntity" />.
		/// </summary>
		/// <param name="builder">The builder to be used to configure the entity type.</param>
		public void Configure(EntityTypeBuilder<PropertyTrace> builder)
		{
			builder.HasKey(e => e.Id)
				.HasName("PK_PropertyTrace_IdPropertyTrace");

			builder.Property(e => e.Id).HasColumnName("IdPropertyTrace");

			builder.Property(e => e.DateSale).HasColumnType("datetime");

			builder.Property(e => e.Name)
				.HasMaxLength(100)
				.IsUnicode(false);

			builder.Property(e => e.Tax)
				.HasMaxLength(50)
				.IsUnicode(false);

			builder.Property(e => e.Value).HasColumnType("numeric(18, 2)");

			builder.HasOne(d => d.IdPropertyNavigation)
				.WithMany(p => p.PropertyTrace)
				.HasForeignKey(d => d.IdProperty)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_PropertyTrace_IdProperty");
		}
	}
}