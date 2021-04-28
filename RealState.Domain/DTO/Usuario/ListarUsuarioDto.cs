// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-17-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="ConsultaUsuarioDto.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.DTO.Usuario
{
	using Entities;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class ConsultaUsuarioDto.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class ListarUsuarioDto
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the usuario.
		/// </summary>
		/// <value>The usuario.</value>
		public string Usuario { get; set; }
		/// <summary>
		/// Gets or sets the nombres.
		/// </summary>
		/// <value>The nombres.</value>
		public string Nombres { get; set; }
		/// <summary>
		/// Gets or sets the apellidos.
		/// </summary>
		/// <value>The apellidos.</value>
		public string Apellidos { get; set; }
		/// <summary>
		/// Gets or sets the direccion.
		/// </summary>
		/// <value>The direccion.</value>
		public string Direccion { get; set; }
		/// <summary>
		/// Gets or sets the telefono.
		/// </summary>
		/// <value>The telefono.</value>
		public string Telefono { get; set; }
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email { get; set; }
		/// <summary>
		/// Gets or sets the edad.
		/// </summary>
		/// <value>The edad.</value>
		public int Edad { get; set; }

		/// <summary>
		/// Gets or sets the rol identifier.
		/// </summary>
		/// <value>The rol identifier.</value>
		public int RolId { get; set; }

		/// <summary>
		/// Gets or sets the name of the rol.
		/// </summary>
		/// <value>The name of the rol.</value>
		public string RolName { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="Usuarios"/> to <see cref="ConsultaUsuarioDto"/>.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ListarUsuarioDto(Usuarios usuario) => new ListarUsuarioDto
		{
			Id = usuario.Id,
			Apellidos = usuario.Apellidos,
			Usuario = usuario.Usuario,
			Nombres = usuario.Nombres,
			Direccion = usuario.Direccion,
			Telefono = usuario.Telefono,
			Email = usuario.Email,
			Edad = usuario.Edad ?? 0,
			RolName = usuario.IdNavigation?.Rol,
			RolId = usuario.RolId
		};

		/// <summary>
		/// Performs an implicit conversion from <see cref="ConsultaUsuarioDto"/> to <see cref="Usuarios"/>.
		/// </summary>
		/// <param name="usuario">The usuario.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Usuarios(ListarUsuarioDto usuario) => new Usuarios
		{
			Id = usuario.Id,
			Apellidos = usuario.Apellidos,
			Usuario = usuario.Usuario,
			Nombres = usuario.Nombres,
			Direccion = usuario.Direccion,
			Telefono = usuario.Telefono,
			Email = usuario.Email,
			Edad = usuario.Edad,
			RolId = usuario.RolId
		};
	}
}