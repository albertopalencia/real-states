// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="RolRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Repositories
{
	using RealState.Infrastructure.DataAccessEntityFrameWork;
	using RealState.Infrastructure.Interfaces.Repository;

	public class RolRepository : GenericRepository<Domain.Entities.Roles>, IRolRepository
	{
		public RolRepository(RealStateContext context) : base(context)
		{
		}
	}
}