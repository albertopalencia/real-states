// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-18-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="RolEnum.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Enumerations
{
	/// <summary>
	/// Class RolEnum.
	/// Implements the <see cref="RealState.Domain.Enumerations.EnumerationDomain" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Enumerations.EnumerationDomain" />
	public class RolEnum : EnumerationDomain
	{

		/// <summary>
		/// The visitante
		/// </summary>
		private static   RolEnum _visitante = new RolEnum(1, "Visitante");
		/// <summary>
		/// The asistente
		/// </summary>
		private static   RolEnum _asistente = new RolEnum(2, "Asistente");
		/// <summary>
		/// The editor
		/// </summary>
		private static   RolEnum _editor = new RolEnum(3, "Editor");
		/// <summary>
		/// The administrador
		/// </summary>
		private static   RolEnum _administrador = new RolEnum(4, "Administrador");

		/// <summary>
		/// Gets the vistante.
		/// </summary>
		/// <value>The vistante.</value>
		public static RolEnum Visitante
		{
			get => _visitante;
		}

		/// <summary>
		/// Gets the asistente.
		/// </summary>
		/// <value>The asistente.</value>
		public static RolEnum Asistente
		{
			get => _asistente;
		}

		/// <summary>
		/// Gets the editor.
		/// </summary>
		/// <value>The editor.</value>
		public static RolEnum Editor
		{
			get => _editor;
		}

		/// <summary>
		/// Gets the administrador.
		/// </summary>
		/// <value>The administrador.</value>
		public static RolEnum Administrador
		{
			get => _administrador;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RolEnum"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public RolEnum(int id, string name) : base(id, name)
		{

		}
	}

}