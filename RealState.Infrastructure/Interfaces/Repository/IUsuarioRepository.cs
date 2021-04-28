// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-14-2021
// ***********************************************************************
// <copyright file="IUsuarioRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Interfaces.Repository
{
	using Domain.Entities;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IUsuarioRepository
	/// Implements the <see cref="IReadRepository{T}.Domain.Entities.Usuarios}" />
	/// Implements the <see cref="ICreateRepository{T}.Domain.Entities.Usuarios}" />
	/// </summary>
	/// <seealso cref="IReadRepository{T}.Domain.Entities.Usuarios}" />
	/// <seealso cref="ICreateRepository{T}.Domain.Entities.Usuarios}" />
	public interface IUsuarioRepository : IPagedRepository<Usuarios>, IReadRepository<Usuarios>, ICreateRepository<Usuarios>, IUpdateRepository<Usuarios>, IRemoveRepository<Usuarios>
	{

		/// <summary>
		/// Validars the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;Usuarios&gt;.</returns>
		Task<Usuarios> ValidarUsuario(string usuario);
	}
}