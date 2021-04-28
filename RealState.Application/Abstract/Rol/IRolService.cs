// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 04-21-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="IRolService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace RealState.Application.Abstract.Rol
{
	using RealState.Domain.DTO.Rol;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IRolService
	/// </summary>
	public interface IRolService
	{
		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task&lt;ConsultaRolDto&gt;.</returns>
		Task<ConsultaRolDto> BuscarPorId(int rol);

		/// <summary>
		/// Actualizars the specified rol identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <param name="rol">The rol.</param>
		/// <returns>Task.</returns>
		Task Actualizar(int rolId, ActualizarRolDto rol);

		/// <summary>
		/// Crears the specified rol.
		/// </summary>
		/// <param name="rol">The rol.</param>
		/// <returns>Task.</returns>
		Task Crear(CrearRolDto rol);

		/// <summary>
		/// Eliminars the specified rol identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task.</returns>
		Task Eliminar(int rolId);

		/// <summary>
		/// Listas the roles por filtro.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns>Task&lt;ListarRolDto&gt;.</returns>
		Task<List<ListarRolDto>> ListarRolPorFiltro(FiltroRolDto filtro);
	}
}