// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IPagedRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Infrastructure.Interfaces
{
	using Microsoft.EntityFrameworkCore.Query;
	using Pages;
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IPagedRepository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IPagedRepository<T> where T : class
	{
		/// <summary>
		/// Gets the paged asynchronous.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>Task&lt;PagedList&lt;T&gt;&gt;.</returns>
		Task<PagedList<T>> GetPagedAsync(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		);

		/// <summary>
		/// Gets the paged.
		/// </summary>
		/// <param name="page">The page.</param>
		/// <param name="take">The take.</param>
		/// <param name="orderBy">The order by.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="include">The include.</param>
		/// <returns>PagedList&lt;T&gt;.</returns>
		PagedList<T> GetPaged(
			int page,
			int take,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
		);
	}
}