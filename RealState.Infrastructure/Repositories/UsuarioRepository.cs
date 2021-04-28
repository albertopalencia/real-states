// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-17-2021
// ***********************************************************************
// <copyright file="UsuarioRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Repositories.Usuarios
{
	using Microsoft.EntityFrameworkCore;
	using RealState.Infrastructure.DataAccessEntityFrameWork;
	using RealState.Infrastructure.Interfaces.Repository;
	using System.Threading.Tasks;

	/// <summary>
	/// Class UsuarioRepository.
	/// Implements the <see cref="GenericRepository{T}.Domain.Entities.Usuarios}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IUsuarioRepository" />
	/// </summary>
	/// <seealso cref="GenericRepository{T}.Domain.Entities.Usuarios}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IUsuarioRepository" />
	public class UsuarioRepository : GenericRepository<Domain.Entities.Usuarios>, IUsuarioRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UsuarioRepository(RealStateContext context) : base(context)
		{
		}

		/// <summary>
		/// Validars the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;Usuarios&gt;.</returns>
		public async Task<Domain.Entities.Usuarios> ValidarUsuario(string usuario)
		{
			return await _entities.Include(s => s.IdNavigation)
					    .FirstOrDefaultAsync(x => x.Usuario == usuario); 
		}
	}
}