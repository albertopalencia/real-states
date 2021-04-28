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
	public class CrearUsuarioDto
	{
		public string Usuario { get; set; }
		public string Contrasena { get; set; }

		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public int Edad { get; set; }

		public int RolId { get; set; }

		public static implicit operator Usuarios(CrearUsuarioDto usuario)
		{
			return new Usuarios
			{
				Apellidos = usuario.Apellidos,
				Contrasena = usuario.Contrasena,
				Usuario = usuario.Usuario,
				Nombres = usuario.Nombres,
				Direccion = usuario.Direccion,
				Telefono = usuario.Telefono,
				Edad = usuario.Edad,
				Email = usuario.Email,
				RolId = usuario.RolId
			};
		}
		 
	}
}