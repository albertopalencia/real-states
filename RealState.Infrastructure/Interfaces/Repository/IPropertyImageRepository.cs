// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="IPropertyImageRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Generic;

namespace RealState.Infrastructure.Interfaces.Repository
{
	/// <summary>
	/// Interface IPropertyImageRepository
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.PropertyImage}" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.PropertyImage}" />
	public interface IPropertyImageRepository : IReadRepository<PropertyImage>
	{
		
	}
}