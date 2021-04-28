// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="UsuarioController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Api.V1.Controllers
{
	using Application.Abstract.Usuario;
	using Domain.DTO.Usuario;
	using Microsoft.AspNetCore.Mvc;
	using System.Net;
	using System.Threading.Tasks;

	/// <summary>
	/// Class UsuarioController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		/// <summary>
		/// The seguridad service
		/// </summary>
		private readonly IUsuarioService _permisoService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UsuarioController" /> class.
		/// </summary>
		/// <param name="permisoService">The usuario service.</param>
		public UsuarioController(IUsuarioService permisoService)
		{
			_permisoService = permisoService;
		}

		/// <summary>
		/// Crears the usuario.
		/// </summary>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(ListarUsuarioPorFiltro))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ListarUsuarioDto))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ListarUsuarioPorFiltro([FromQuery] FiltroUsuarioDto filtro)
		{
			var listado = await _permisoService.ListarUsuarioPorFiltro(filtro);
			return Ok(listado);
		}

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="usuarioId">The usuario identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>

		[HttpGet(nameof(BuscarPorId))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> BuscarPorId(int usuarioId)
		{
			var usuario = await _permisoService.BuscarPorId(usuarioId);
			return Ok(usuario);
		}

		/// <summary>
		/// Actualizars the usuario.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut(nameof(ActualizarUsuario))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ActualizarUsuario(CrearUsuarioDto usuario)
		{
			await _permisoService.CrearUsuario(usuario);
			return Ok();
		}

		/// <summary>
		/// Eliminars the usuario.
		/// </summary>
		/// <param name="usuarioId">The usuario identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpDelete(nameof(EliminarUsuario))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> EliminarUsuario(int usuarioId)
		{
			await _permisoService.EliminarUsuario(usuarioId);
			return Ok();
		}
	}
}