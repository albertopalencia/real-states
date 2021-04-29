// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="OwnerRepository.cs" company="RealState.Infrastructure">
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
	/// Class OwnerRepository.
	/// Implements the <see cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.Owner}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IOwnerRepository" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Repository.GenericRepository{RealState.Domain.Entities.Owner}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IOwnerRepository" />
	public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OwnerRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public OwnerRepository(RealStateContext context) : base(context)
		{
			
		}
	}
}