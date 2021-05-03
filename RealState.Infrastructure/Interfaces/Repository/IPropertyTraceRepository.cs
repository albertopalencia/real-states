// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="IPropertyTraceRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Generic;

namespace RealState.Infrastructure.Interfaces.Repository
{
	/// <summary>
	/// Interface IPropertyTraceRepository
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.PropertyTrace}" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.Generic.IReadRepository{RealState.Domain.Entities.PropertyTrace}" />
	public interface IPropertyTraceRepository : IReadRepository<PropertyTrace>
	{
	}
}