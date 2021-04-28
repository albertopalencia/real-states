// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-22-2021
// ***********************************************************************
// <copyright file="RolService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.Implements.Rol
{
	using RealState.Application.Abstract.Rol;
	using RealState.Application.Abstract.Usuario;
	using RealState.Domain.DTO.Permiso;
	using RealState.Domain.DTO.Rol;
	using RealState.Domain.Entities;
	using RealState.Infrastructure.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	/// <summary>
	/// Class UsuarioService.
	/// Implements the <see cref="IUsuarioService" />
	/// Implements the <see cref="RealState.Application.Abstract.Rol.IRolService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.Rol.IRolService" />
	/// <seealso cref="IUsuarioService" />
	public class RolService : IRolService
	{
		/// <summary>
		/// The unit of work
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// Initializes a new instance of the <see cref="RolService"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public RolService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		/// <summary>
		/// Crears the specified rol.
		/// </summary>
		/// <param name="rol">The rol.</param>
		/// <returns>Task.</returns>
		public async Task Crear(CrearRolDto rol)
		{
			await _unitOfWork.RolRepository.AddAsync(rol);
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Actualizars the specified rol identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <param name="rol">The rol.</param>
		/// <returns>Task.</returns>
		public async Task Actualizar(int rolId, ActualizarRolDto rol)
		{
			var existeRol = await BuscarPorId(rolId);
			_unitOfWork.RolRepository.Update(existeRol);
			_unitOfWork.DetectChanges();
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task&lt;ConsultaRolDto&gt;.</returns>
		/// <exception cref="ArgumentNullException">No se encontro informacion con el id rol: {rolId}</exception>
		public async Task<ConsultaRolDto> BuscarPorId(int rolId)
		{
			var rol = await _unitOfWork.RolRepository.FirstOrDefaultAsync(s => s.Id == rolId);
			if (rol is null)
			{
				throw new ArgumentNullException($"No se encontro informacion con el id rol: {rolId}");
			}

			return rol;
		}

		/// <summary>
		/// Eliminars the specified rol identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task.</returns>
		public async Task Eliminar(int rolId)
		{
			var rol = await BuscarPorId(rolId);
			_unitOfWork.RolRepository.Remove(rol);
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Listas the roles por filtro.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns>Task&lt;ListarRolDto&gt;.</returns>
		public async Task<List<ListarRolDto>> ListarRolPorFiltro(FiltroRolDto filtro)
		{
			var roles = await _unitOfWork.RolRepository.GetAllAsync();
			var rolesPorFiltro = roles.Select<Roles, ListarRolDto>(s => s).ToList();
			return rolesPorFiltro;
		}
	}
}