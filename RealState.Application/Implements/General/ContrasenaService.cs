// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-27-2021
// ***********************************************************************
// <copyright file="ContrasenaService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace RealState.Application.Implements.General
{
	using Infrastructure.Options;
	using Microsoft.Extensions.Options;
	using RealState.Application.Abstract.General;
	using System;
	using System.Linq;
	using System.Security.Cryptography;

	/// <summary>
	/// Class PasswordService.
	/// Implements the <see cref="IContrasenaService" />
	/// Implements the <see cref="IContrasenaService" />
	/// Implements the <see cref="RealState.Application.Abstract.General.IContrasenaService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.General.IContrasenaService" />
	/// <seealso cref="IContrasenaService" />
	/// <seealso cref="IContrasenaService" />
	public class ContrasenaService : IContrasenaService
	{
		/// <summary>
		/// The options
		/// </summary>
		private readonly ContrasenaOpcion _contrasenaOpcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContrasenaService" /> class.
		/// </summary>
		/// <param name="contrasenaOpcion">The options.</param>
		public ContrasenaService(IOptions<ContrasenaOpcion> contrasenaOpcion)
		{
			_contrasenaOpcion = contrasenaOpcion.Value;
		}

		/// <summary>
		/// Checks the specified hash.
		/// </summary>
		/// <param name="hash">The hash.</param>
		/// <param name="password">The password.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		/// <exception cref="FormatException">Unexpected hash format</exception>
		public bool Check(string hash, string password)
		{
			var parts = hash.Split('.');
			if (parts.Length != 3)
			{
				throw new FormatException("Unexpected hash format");
			}

			var iterations = Convert.ToInt32(parts[0]);
			var salt = Convert.FromBase64String(parts[1]);
			var key = Convert.FromBase64String(parts[2]);

			using var algorithm = new Rfc2898DeriveBytes(
				password,
				salt,
				iterations
				);
			var keyToCheck = algorithm.GetBytes(_contrasenaOpcion.KeySize);
			return keyToCheck.SequenceEqual(key);
		}

		/// <summary>
		/// Hashes the specified password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>System.String.</returns>
		public string Hash(string password)
		{
			using var algorithm = new Rfc2898DeriveBytes(
				password,
				_contrasenaOpcion.SaltSize,
				_contrasenaOpcion.Iterations
				);
			var key = Convert.ToBase64String(algorithm.GetBytes(_contrasenaOpcion.KeySize));
			var salt = Convert.ToBase64String(algorithm.Salt);

			return $"{_contrasenaOpcion.Iterations}.{salt}.{key}";
		}
	}
}