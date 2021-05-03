// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyTraceRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RealState.Domain.Entities;
using RealState.Infrastructure.DataAccess;
using RealState.Infrastructure.Interfaces.Repository;

namespace RealState.Infrastructure.Repository
{
	/// <summary>
	/// Class PropertyTraceRepository.
	/// Implements the <see cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.PropertyTrace}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IPropertyTraceRepository" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.PropertyTrace}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IPropertyTraceRepository" />
	public class PropertyTraceRepository : GenericRepository<PropertyTrace>, IPropertyTraceRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyTraceRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PropertyTraceRepository(RealStateContext context) : base(context)
		{
		}
	}
}