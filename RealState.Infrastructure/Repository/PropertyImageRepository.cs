// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="PropertyImageRepository.cs" company="RealState.Infrastructure">
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
	/// Class PropertyImageRepository.
	/// Implements the <see cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.PropertyImage}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IPropertyImageRepository" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.PropertyImage}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IPropertyImageRepository" />
	public class PropertyImageRepository : GenericRepository<PropertyImage>, IPropertyImageRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyImageRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PropertyImageRepository(RealStateContext context) : base(context)
		{
		}
	}
}