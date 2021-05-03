// ***********************************************************************
// Assembly         : 
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="TokenController.cs" company="AlbertPalencia">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealState.Application.Enumerations;
using RealState.Domain.DTO.User;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RealState.Application.Abstract;
using RealState.Domain.Entities;

namespace RealState.Api.Controllers
{
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
		private readonly IUserService _userService;

		/// <summary>
		/// The configuracion
		/// </summary>
		private readonly IConfiguration _configuracion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TokenController" /> class.
		/// </summary>
		/// <param name="userService">The security service.</param>
		/// <param name="configuracion">The configuracion.</param>
		public TokenController(IUserService userService, IConfiguration configuracion)
		{
			_userService = userService;
			_configuracion = configuracion;
		}

		/// <summary>
		/// Authentications the specified login.
		/// </summary>
		/// <param name="login">The login.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost(Name = nameof(Authenticate))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> Authenticate(UserDto login)
		{
			var userEntity = await _userService.ValidateUser(login);
			if (userEntity == null)
			{
				return NotFound();
			}

			var token = GenerateToken(userEntity);
			return Ok(token);
		}

		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>System.String.</returns>
		private string GenerateToken(User user)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion[AutenticacionEnum.LlaveSecreta.Name]));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(signingCredentials);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.UserName)
			};

			var minutes = Convert.ToDouble(_configuracion[AutenticacionEnum.MinutosToken.Name]);
			var payload = new JwtPayload
			(
				_configuracion[AutenticacionEnum.Editor.Name],
				_configuracion[AutenticacionEnum.Audiencia.Name],
				claims,
				DateTime.Now,
				DateTime.UtcNow.AddMinutes(minutes)
			);

			var token = new JwtSecurityToken(header, payload);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}