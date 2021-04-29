// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="ConnectionDomainEnum.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Enumerations
{
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class ConnectionDomainEnum.
	/// Implements the <see cref="RealState.Domain.Enumerations.EnumerationDomain" />
	/// </summary>
	/// <seealso cref="RealState.Domain.Enumerations.EnumerationDomain" />
	[ExcludeFromCodeCoverage]
	public class ConnectionDomainEnum : EnumerationDomain
	{
		/// <summary>
		/// The real state
		/// </summary>
		private static readonly ConnectionDomainEnum _realState = new ConnectionDomainEnum(1, "ConnectionStrings:RealState");

		/// <summary>
		/// Gets the state of the real.
		/// </summary>
		/// <value>The state of the real.</value>
		public static ConnectionDomainEnum RealState { get => _realState; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ConnectionDomainEnum"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		public ConnectionDomainEnum(int id, string name) : base(id, name)
		{
		}
	}
}