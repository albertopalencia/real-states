// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 04-21-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="RolController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Domain.DTO.Permiso;

namespace RealState.Api.V1.Controllers
{
	using Domain.DTO.Usuario;
	using Microsoft.AspNetCore.Mvc;
	using RealState.Application.Abstract.Rol;
	using RealState.Domain.DTO.Rol;
	using System.Net;
	using System.Threading.Tasks;

	/// <summary>
	/// Class RolController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class RolController : ControllerBase
	{
		/// <summary>
		/// The rol service
		/// </summary>
		private readonly IRolService _rolService;

		/// <summary>
		/// Initializes a new instance of the <see cref="RolController"/> class.
		/// </summary>
		/// <param name="rolService">The rol service.</param>
		public RolController(IRolService rolService)
		{
			_rolService = rolService;
		}

		/// <summary>
		/// Listas the roles por filtro.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(ListaRolesPorFiltro))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaUsuarioDto))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ListaRolesPorFiltro([FromQuery] FiltroRolDto filtro)
		{
			var listado = await _rolService.ListarRolPorFiltro(filtro);
			return Ok(listado);
		}

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(BuscarPorId))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> BuscarPorId(int rolId)
		{
			var rol = await _rolService.BuscarPorId(rolId);
			return Ok(rol);
		}

		/// <summary>
		/// Crears the rol.
		/// </summary>
		/// <param name="rol">The rol.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(nameof(CrearRol))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreatedAtActionResult))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CrearRol([FromBody] CrearRolDto rol)
		{
			await _rolService.Crear(rol);
			return Ok();
		}

		/// <summary>
		/// Actualizars the rol.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <param name="rol">The rol.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut(nameof(ActualizarRol))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ActualizarRol([FromQuery] int rolId, [FromBody] ActualizarRolDto rol)
		{
			await _rolService.Actualizar(rolId, rol);
			return Ok();
		}

		/// <summary>
		/// Eliminars the rol.
		/// </summary>
		/// <param name="rolId">The rol identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpDelete(nameof(EliminarRol))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> EliminarRol(int rolId)
		{
			await _rolService.Eliminar(rolId);
			return Ok();
		}
	}
}