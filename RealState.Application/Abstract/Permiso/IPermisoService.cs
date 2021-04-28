// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 04-21-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="IPermisoService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.Abstract.Permiso
{
	using RealState.Domain.DTO.Permiso;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IPermisoService
	/// </summary>
	public interface IPermisoService
	{
		Task<List<ListarPermisoDto>> ListarPermisoPorFiltro(FiltroPermisoDto filtro);

		Task<ConsultaPermisoDto> BuscarPorId(int permisoId);

		Task Actualizar(int permisoId, ActualizarPermisoDto permiso);

		Task Crear(CrearPermisoDto permiso);

		Task Eliminar(int permisoId);
	}
}