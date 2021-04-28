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
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class UsuarioDto.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class UsuarioDto
	{
		public string Usuario { get; set; }
		public string Contrasena { get; set; }
	}
}