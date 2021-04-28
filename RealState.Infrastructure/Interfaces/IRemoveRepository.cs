// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IRemoveRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Interfaces
{
	using System.Collections.Generic;

	/// <summary>
	/// Interface IRemoveRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRemoveRepository<in T> where T : class
	{
		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Remove(T t);

		/// <summary>
		/// Removes the specified t.
		/// </summary>
		/// <param name="t">The t.</param>
		void Remove(IEnumerable<T> t);
	}
}