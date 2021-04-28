// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 04-17-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-17-2021
// ***********************************************************************
// <copyright file="AutenticacionEnum.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Application.Enumerations
{
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class AutenticacionEnum.
	/// Implements the <see cref="Analisis.ProximosPublicar.Application.Enumerations.Enumeration" />
	/// Implements the <see cref="Enumeration" />
	/// </summary>
	/// <seealso cref="Enumeration" />
	/// <seealso cref="Analisis.ProximosPublicar.Application.Enumerations.Enumeration" />
	[ExcludeFromCodeCoverage]
	public class AutenticacionEnum : Enumeration
	{
		/// <summary>
		/// The editor
		/// </summary>
		private static readonly AutenticacionEnum _editor = new AutenticacionEnum(0, "Authentication:Issuer");

		/// <summary>
		/// The llave secreta
		/// </summary>
		private static readonly AutenticacionEnum _llaveSecreta = new AutenticacionEnum(1, "Authentication:SecretKey");

		/// <summary>
		/// The audiencia
		/// </summary>
		private static readonly AutenticacionEnum _audiencia = new AutenticacionEnum(2, "Authentication:Audience");

		/// <summary>
		/// The minutos token
		/// </summary>
		private static readonly AutenticacionEnum _minutosToken = new AutenticacionEnum(3, "Authentication:MinutosToken");

		/// <summary>
		/// The usuario
		/// </summary>
		private static readonly AutenticacionEnum _usuario = new AutenticacionEnum(4, "User");

		/// <summary>
		/// Gets the editor.
		/// </summary>
		/// <value>The editor.</value>
		public static AutenticacionEnum Editor { get => _editor; }

		/// <summary>
		/// Gets the llave secreta.
		/// </summary>
		/// <value>The llave secreta.</value>
		public static AutenticacionEnum LlaveSecreta { get => _llaveSecreta; }

		/// <summary>
		/// Gets the audiencia.
		/// </summary>
		/// <value>The audiencia.</value>
		public static AutenticacionEnum Audiencia { get => _audiencia; }

		/// <summary>
		/// Gets the minutos token.
		/// </summary>
		/// <value>The minutos token.</value>
		public static AutenticacionEnum MinutosToken { get => _minutosToken; }

		/// <summary>
		/// Gets the usuario.
		/// </summary>
		/// <value>The usuario.</value>
		public static AutenticacionEnum Usuario { get => _usuario; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutenticacionEnum" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public AutenticacionEnum(int id, string name) : base(id, name)
		{
		}
	}
}