// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 04-21-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-22-2021
// ***********************************************************************
// <copyright file="PermisoController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Api.V1.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using RealState.Application.Abstract.Permiso;
	using RealState.Domain.DTO.Permiso;
	using System.Net;
	using System.Threading.Tasks;

	/// <summary>
	/// Class PermisoController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class PermisoController : ControllerBase
	{
		/// <summary>
		/// The seguridad service
		/// </summary>
		private readonly IPermisoService _permisoService;

		/// <summary>
		/// Initializes a new instance of the <see cref="PermisoController"/> class.
		/// </summary>
		/// <param name="permisoService">The permiso service.</param>
		public PermisoController(IPermisoService permisoService)
		{
			_permisoService = permisoService;
		}

		/// <summary>
		/// Listars the permiso por filtro.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(ListarPermisoPorFiltro))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ListarPermisoDto))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ListarPermisoPorFiltro([FromQuery] FiltroPermisoDto filtro)
		{
			var listado = await _permisoService.ListarPermisoPorFiltro(filtro);
			return Ok(listado);
		}

		/// <summary>
		/// Buscars the por identifier.
		/// </summary>
		/// <param name="permisoId">The permiso identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(BuscarPorId))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> BuscarPorId(int permisoId)
		{
			var usuario = await _permisoService.BuscarPorId(permisoId);
			return Ok(usuario);
		}

		/// <summary>
		/// Crears the permiso.
		/// </summary>
		/// <param name="permiso">The permiso.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(nameof(CrearPermiso))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CrearPermiso([FromBody] CrearPermisoDto permiso)
		{
			await _permisoService.Crear(permiso);
			return Ok();
		}

		/// <summary>
		/// Actualizars the permiso.
		/// </summary>
		/// <param name="permisoId">The permiso identifier.</param>
		/// <param name="permiso">The permiso.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPut(nameof(ActualizarPermiso))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> ActualizarPermiso([FromQuery] int permisoId, [FromBody] ActualizarPermisoDto permiso)
		{
			await _permisoService.Actualizar(permisoId, permiso);
			return Ok();
		}

		/// <summary>
		/// Eliminars the permiso.
		/// </summary>
		/// <param name="permisoId">The permiso identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpDelete(nameof(EliminarPermiso))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Task))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> EliminarPermiso(int permisoId)
		{
			await _permisoService.Eliminar(permisoId);
			return Ok();
		}
	}
}