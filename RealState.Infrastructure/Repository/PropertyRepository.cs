// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="PropertyRepository.cs" company="RealState.Infrastructure">
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
	/// Class PropertyRepository.
	/// Implements the <see cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.Property}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IPropertyRepository" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.Property}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IPropertyRepository" />
	public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PropertyRepository(RealStateContext context) : base(context)
		{
			
		}
	}
}