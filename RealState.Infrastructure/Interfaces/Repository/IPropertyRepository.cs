// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="IPropertyRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Generic;

namespace RealState.Infrastructure.Interfaces.Repository
{

	/// <summary>
	/// Interface IPropertyRepository
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.Property}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Generic.IPagedRepository{RealState.Domain.Entities.Property}" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.Property}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Generic.IPagedRepository{RealState.Domain.Entities.Property}" />
	public interface IPropertyRepository : IReadRepository<Property>, IPagedRepository<Property>
	{
	}
}