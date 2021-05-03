// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="RealStateContext.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.DataAccess
{
	/// <summary>
	/// Class RealStateContext.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class RealStateContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RealStateContext"/> class.
		/// </summary>
		public RealStateContext()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RealStateContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public RealStateContext(DbContextOptions<RealStateContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// Gets or sets the owner.
		/// </summary>
		/// <value>The owner.</value>
		public virtual DbSet<Owner> Owner { get; set; }
		/// <summary>
		/// Gets or sets the property.
		/// </summary>
		/// <value>The property.</value>
		public virtual DbSet<Property> Property { get; set; }
		/// <summary>
		/// Gets or sets the property image.
		/// </summary>
		/// <value>The property image.</value>
		public virtual DbSet<PropertyImage> PropertyImage { get; set; }
		/// <summary>
		/// Gets or sets the property trace.
		/// </summary>
		/// <value>The property trace.</value>
		public virtual DbSet<PropertyTrace> PropertyTrace { get; set; }
		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>The user.</value>
		public virtual DbSet<User> User { get; set; }



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