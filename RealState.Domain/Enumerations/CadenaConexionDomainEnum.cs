// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="CadenaConexionDomainEnum.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Enumerations
{
	using System.Diagnostics.CodeAnalysis;


	/// <summary>
	/// Class CadenaConexionDomainEnum.
	/// Implements the <see cref="RealState.Domain.Enumerations.EnumerationDomain" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Enumerations.EnumerationDomain" />
	[ExcludeFromCodeCoverage]
	public class CadenaConexionDomainEnum : EnumerationDomain
	{

		/// <summary>
		/// The prueba tecnica
		/// </summary>
		private static readonly CadenaConexionDomainEnum _RealState = new CadenaConexionDomainEnum(1, "ConnectionStrings:RealState");


		/// <summary>
		/// Gets the prueba tecnica.
		/// </summary>
		/// <value>The prueba tecnica.</value>
		public static CadenaConexionDomainEnum RealState { get => _RealState; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CadenaConexionDomainEnum"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public CadenaConexionDomainEnum(int id, string name) : base(id, name)
		{
		}
	}
}