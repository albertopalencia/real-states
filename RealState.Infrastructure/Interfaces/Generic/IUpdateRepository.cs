// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IUpdateRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace RealState.Infrastructure.Interfaces.Generic
{
	/// <summary>
	/// Interface IUpdateRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IUpdateRepository<in T> where T : class
	{
		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(T t);

		/// <summary>
		/// Updates the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Update(IEnumerable<T> t);
	}
}