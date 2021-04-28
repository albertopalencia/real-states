// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="UnitOfWork.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Repositories
{
	using DataAccessEntityFrameWork;
	using Interfaces;
	using Microsoft.EntityFrameworkCore.Storage;
	using RealState.Infrastructure.Interfaces.Repository;
	using RealState.Infrastructure.Repositories.Usuarios;
	using System.Diagnostics.CodeAnalysis;
	using System.Threading.Tasks;

	/// <summary>
	/// Class UnitOfWork.
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IUnitOfWork" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.IUnitOfWork" />
	[ExcludeFromCodeCoverage]
	public class UnitOfWork : IUnitOfWork
	{
		#region Propiedades privadas

		/// <summary>
		/// The context
		/// </summary>
		private readonly RealStateContext _context;

		/// <summary>
		/// The usuario repository
		/// </summary>
		private IUsuarioRepository _usuarioRepository;

		/// <summary>
		/// The rol repository
		/// </summary>
		private IRolRepository _rolRepository;

		/// <summary>
		/// The permiso repository
		/// </summary>
		private IPermisoRepository _permisoRepository;

		#endregion Propiedades privadas

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(RealStateContext context)
		{
			_context = context;
		}

		#endregion Constructor

		#region Propiedades Publicas

		/// <summary>
		/// Gets the usuario repository.
		/// </summary>
		/// <value>The usuario repository.</value>
		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (_usuarioRepository == null)
				{
					_usuarioRepository = new UsuarioRepository(_context);
				}

				return _usuarioRepository;
			}
		}

		/// <summary>
		/// Gets the rol repository.
		/// </summary>
		/// <value>The rol repository.</value>
		public IRolRepository RolRepository
		{
			get
			{
				if (_rolRepository == null)
				{
					_rolRepository = new RolRepository(_context);
				}

				return _rolRepository;
			}
		}

		/// <summary>
		/// Gets the permiso repository.
		/// </summary>
		/// <value>The permiso repository.</value>
		public IPermisoRepository PermisoRepository
		{
			get
			{
				if (_permisoRepository == null)
				{
					_permisoRepository = new PermisoRepository(_context);
				}

				return _permisoRepository;
			}
		}

		#endregion Propiedades Publicas

		/// <summary>
		/// Begins the transaction.
		/// </summary>
		/// <returns>IDbContextTransaction.</returns>
		public IDbContextTransaction BeginTransaction()
		{
			return _context.Database.BeginTransaction();
		}

		/// <summary>
		/// begin transaction as an asynchronous operation.
		/// </summary>
		/// <returns>Task&lt;IDbContextTransaction&gt;.</returns>
		public async Task<IDbContextTransaction> BeginTransactionAsync()
		{
			return await _context.Database.BeginTransactionAsync();
		}

		/// <summary>
		/// Commits the transaction.
		/// </summary>
		public void CommitTransaction()
		{
			_context.Database.CommitTransaction();
		}

		/// <summary>
		/// Detects the changes.
		/// </summary>
		public void DetectChanges()
		{
			_context.ChangeTracker.DetectChanges();
		}

		/// <summary>
		/// Rollbacks the transaction.
		/// </summary>
		public void RollbackTransaction()
		{
			_context.Database.RollbackTransaction();
		}

		/// <summary>
		/// Saves the changes.
		/// </summary>
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// save changes as an asynchronous operation.
		/// </summary>
		/// <returns>Task.</returns>
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}