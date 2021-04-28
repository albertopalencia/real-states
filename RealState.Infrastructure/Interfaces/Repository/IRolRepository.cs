// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-18-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="IRolRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Interfaces.Repository
{
	using Domain.Entities; 


	/// <summary>
	/// Interface IRolRepository
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IPagedRepository{RealState.Domain.Entities.Roles}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IReadRepository{RealState.Domain.Entities.Roles}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.ICreateRepository{RealState.Domain.Entities.Roles}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IUpdateRepository{RealState.Domain.Entities.Roles}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IRemoveRepository{RealState.Domain.Entities.Roles}" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.IPagedRepository{RealState.Domain.Entities.Roles}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.IReadRepository{RealState.Domain.Entities.Roles}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.ICreateRepository{RealState.Domain.Entities.Roles}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.IUpdateRepository{RealState.Domain.Entities.Roles}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.IRemoveRepository{RealState.Domain.Entities.Roles}" />
	public interface IRolRepository : IPagedRepository<Roles>, IReadRepository<Roles>, ICreateRepository<Roles>, IUpdateRepository<Roles>, IRemoveRepository<Roles>
	{
		 
	}
}