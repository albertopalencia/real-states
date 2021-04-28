// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 03-25-2021
// ***********************************************************************
// <copyright file="UsuarioDto.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Domain.DTO.Usuario
{
	using Entities;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class UsuarioDto.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class ActualizarUsuarioDto
	{
		public int Id { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public int Edad { get; set; }

		public static explicit operator Usuarios(ActualizarUsuarioDto usuario)
		{
			return new Usuarios
			{
				Id = usuario.Id,
				Apellidos = usuario.Apellidos,
				Nombres = usuario.Nombres,
				Direccion = usuario.Direccion,
				Telefono = usuario.Telefono,
				Edad = usuario.Edad,
				Email = usuario.Email
			};
		}
	}
}