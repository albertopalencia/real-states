

using Microsoft.EntityFrameworkCore;
using RealState.Domain.Entities;
using System.Reflection;

namespace RealState.Infrastructure.DataAccess
{
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
		
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Property> Property { get; set; }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}