// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Interfaces
{
	using Microsoft.EntityFrameworkCore.Storage;
	using Repository;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IUnitOfWork
	/// </summary>
	public interface IUnitOfWork
	{
		/// <summary>
		/// Gets the usuario repository.
		/// </summary>
		/// <value>The usuario repository.</value>
		IUsuarioRepository UsuarioRepository { get; }

		/// <summary>
		/// Gets the rol repository.
		/// </summary>
		/// <value>The rol repository.</value>
		IRolRepository RolRepository { get; }

		/// <summary>
		/// Gets the permiso repository.
		/// </summary>
		/// <value>The permiso repository.</value>
		IPermisoRepository PermisoRepository { get; }

		/// <summary>
		/// Saves the changes.
		/// </summary>
		void SaveChanges();

		/// <summary>
		/// Saves the changes asynchronous.
		/// </summary>
		/// <returns>Task.</returns>
		Task SaveChangesAsync();

		/// <summary>
		/// Detects the changes.
		/// </summary>
		void DetectChanges();

		/// <summary>
		/// Begins the transaction.
		/// </summary>
		/// <returns>IDbContextTransaction.</returns>
		IDbContextTransaction BeginTransaction();

		/// <summary>
		/// Begins the transaction asynchronous.
		/// </summary>
		/// <returns>Task&lt;IDbContextTransaction&gt;.</returns>
		Task<IDbContextTransaction> BeginTransactionAsync();

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		void CommitTransaction();

		/// <summary>
		/// Rollbacks the transaction.
		/// </summary>
		void RollbackTransaction();
	}
}