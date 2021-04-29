// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="ContrasenaOpcion.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Options
{
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class ContrasenaOpcion.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class ContrasenaOpcion
	{
		/// <summary>
		/// Gets or sets the size of the salt.
		/// </summary>
		/// <value>The size of the salt.</value>
		public int SaltSize { get; set; }

		/// <summary>
		/// Gets or sets the size of the key.
		/// </summary>
		/// <value>The size of the key.</value>
		public int KeySize { get; set; }

		/// <summary>
		/// Gets or sets the iterations.
		/// </summary>
		/// <value>The iterations.</value>
		public int Iterations { get; set; }
	}
}