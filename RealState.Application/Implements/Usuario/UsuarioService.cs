// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="UsuarioService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.Implements.Usuario
{
	using Domain.Entities;
	using RealState.Application.Abstract.General;
	using RealState.Application.Abstract.Usuario;
	using RealState.Domain.DTO.Usuario;
	using RealState.Infrastructure.Interfaces;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	/// <summary>
	/// Class UsuarioService.
	/// Implements the <see cref="IUsuarioService" />
	/// Implements the <see cref="RealState.Application.Abstract.Usuario.IUsuarioService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.Usuario.IUsuarioService" />
	/// <seealso cref="IUsuarioService" />
	public class UsuarioService : IUsuarioService
	{
		/// <summary>
		/// The unit of work
		/// </summary>
		private readonly IUnitOfWork _unitOfWork;

		/// <summary>
		/// The contrasena service
		/// </summary>
		private readonly IContrasenaService _contrasenaService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioService" /> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		/// <param name="contrasenaService">The contrasena service.</param>
		public UsuarioService(IUnitOfWork unitOfWork, IContrasenaService contrasenaService)
		{
			_unitOfWork = unitOfWork;
			_contrasenaService = contrasenaService;
		}

		/// <summary>
		/// Validars the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;Usuario&gt;.</returns>
		public async Task<Usuarios> ValidarUsuario(UsuarioDto usuario)
		{
			var usuarioValidado = await _unitOfWork.UsuarioRepository.ValidarUsuario(usuario.Usuario);
			var valido = _contrasenaService.Check(usuarioValidado.Contrasena, usuario.Contrasena);
			return valido ? usuarioValidado : null;
		}

		/// <summary>
		/// Crears the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task.</returns>
		public async Task CrearUsuario(CrearUsuarioDto usuario)
		{
			usuario.Contrasena = cifrarContrasena(usuario.Contrasena);
			await _unitOfWork.UsuarioRepository.AddAsync(usuario);
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Actualizars the usuario.
		/// </summary>
		/// <param name="usuarioId">The usuario identifier.</param>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task ActualizarUsuario(int usuarioId, ActualizarUsuarioDto usuario)
		{
			var usuarioDto = await BuscarPorId(usuarioId);
			_unitOfWork.UsuarioRepository.Update(usuarioDto);
			_unitOfWork.DetectChanges();
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="usuarioId">The identifier usuario.</param>
		/// <returns>Task&lt;Usuario&gt;.</returns>
		/// <exception cref="ArgumentNullException">No se encontro informacion con el id usuario: {usuarioId}</exception>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<ConsultaUsuarioDto> BuscarPorId(int usuarioId)
		{
			var usuario = await _unitOfWork.UsuarioRepository.FirstOrDefaultAsync(s => s.Id == usuarioId);
			if (usuario is null)
			{
				throw new ArgumentNullException($"No se encontro informacion con el id usuario: {usuarioId}");
			}

			return usuario;
		}

		/// <summary>
		/// Eliminars the usuario.
		/// </summary>
		/// <param name="idUsuario">The identifier usuario.</param>
		/// <returns>Task.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task EliminarUsuario(int idUsuario)
		{
			var usuario = await BuscarPorId(idUsuario);
			_unitOfWork.UsuarioRepository.Remove(usuario);
			await _unitOfWork.SaveChangesAsync();
		}

		/// <summary>
		/// Listars the usuarios.
		/// </summary>
		/// <returns>Task&lt;List&lt;ConsultaUsuarioDto&gt;&gt;.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public async Task<List<ListarUsuarioDto>> ListarUsuarioPorFiltro(FiltroUsuarioDto filtro)
		{
			var usuarios = await _unitOfWork.UsuarioRepository.GetAllAsync();
			var listaUsuario = usuarios.Select<Usuarios, ListarUsuarioDto>(s => s).ToList();
			return listaUsuario;
		}

		/// <summary>
		/// Cifrars the contrasena.
		/// </summary>
		/// <param name="contrasena">The contrasena.</param>
		/// <returns>System.String.</returns>
		private string cifrarContrasena(string contrasena)
		{
			return _contrasenaService.Hash(contrasena);
		}
	}
}