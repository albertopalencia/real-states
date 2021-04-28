// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 03-25-2021
// ***********************************************************************
// <copyright file="TokenController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Domain.DTO.Usuario;

namespace RealState.Api.V1.Controllers
{
	using Application.Abstract.Usuario;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;
	using Application.Enumerations;
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Net;
	using System.Security.Claims;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// Class TokenController.
	/// Implements the <see cref="ControllerBase" />
	/// Implements the <see cref="ControllerBase" />
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// <seealso cref="ControllerBase" />
	/// <seealso cref="ControllerBase" />
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		/// <summary>
		/// The security service
		/// </summary>
		private readonly IUsuarioService _permisoService;

		/// <summary>
		/// The configuracion
		/// </summary>
		private readonly IConfiguration _configuracion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TokenController" /> class.
		/// </summary>
		/// <param name="permisoService">The security service.</param>
		/// <param name="configuracion">The configuracion.</param>
		public TokenController(IUsuarioService permisoService, IConfiguration configuracion)
		{
			_permisoService = permisoService;
			_configuracion = configuracion;
		}

		/// <summary>
		/// Authentications the specified login.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(Name = nameof(Autenticacion))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> Autenticacion(UsuarioDto login)
		{
			var usuario = await _permisoService.ValidarUsuario(login);
			if (usuario == null)
			{
				return NotFound();
			}

			var token = GenerarToken(usuario);
			return Ok(new { token, respuesta = usuario });
		}

		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>System.String.</returns>
		private string GenerarToken(ConsultaUsuarioDto usuario)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion[AutenticacionEnum.LlaveSecreta.Name]));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(signingCredentials);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, string.Join(",", usuario.Nombres, usuario.Apellidos ) ),
				new Claim(AutenticacionEnum.Usuario.Name, usuario.Usuario),
				new Claim(ClaimTypes.Role, usuario.RolName  )
				 
			};

			var minutos = Convert.ToDouble(_configuracion[AutenticacionEnum.MinutosToken.Name]);
			var payload = new JwtPayload
			(
				_configuracion[AutenticacionEnum.Editor.Name],
				_configuracion[AutenticacionEnum.Audiencia.Name],
				claims,
				DateTime.Now,
				DateTime.UtcNow.AddMinutes(minutos)
			);

			var token = new JwtSecurityToken(header, payload);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}