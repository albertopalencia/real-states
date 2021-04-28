// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IUsuarioService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.Abstract.Usuario
{
	using Domain.Entities;
	using RealState.Domain.DTO.Usuario;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IUsuarioService
	/// </summary>
	public interface IUsuarioService
	{
		/// <summary>
		/// Validars the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;Usuario&gt;.</returns>
		Task<Usuarios> ValidarUsuario(UsuarioDto usuario);

		/// <summary>
		/// Crears the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task.</returns>
		Task CrearUsuario(CrearUsuarioDto usuario);

		/// <summary>
		/// Actualizars the usuario.
		/// </summary>
		/// <param name="usuarioId">The usuario identifier.</param>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task.</returns>
		Task ActualizarUsuario(int usuarioId, ActualizarUsuarioDto usuario);

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="usuarioId">The identifier usuario.</param>
		/// <returns>Task&lt;Usuario&gt;.</returns>
		Task<ConsultaUsuarioDto> BuscarPorId(int usuarioId);

		/// <summary>
		/// Eliminars the usuario.
		/// </summary>
		/// <param name="idUsuario">The identifier usuario.</param>
		/// <returns>Task.</returns>
		Task EliminarUsuario(int idUsuario);

		Task<List<ListarUsuarioDto>> ListarUsuarioPorFiltro(FiltroUsuarioDto filtro);
	}
}