// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 03-25-2021
// ***********************************************************************
// <copyright file="IPasswordService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Application.Abstract.General
{
	/// <summary>
	/// Interface IPasswordService
	/// </summary>
	public interface IPasswordService
	{
		/// <summary>
		/// Hashes the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>System.String.</returns>
		string Hash(string password);

		/// <summary>
		/// Checks the specified hash.
		/// </summary>
		/// <param name="hash">The hash.</param>
		/// <param name="password">The password.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		bool Check(string hash, string password);
	}
}