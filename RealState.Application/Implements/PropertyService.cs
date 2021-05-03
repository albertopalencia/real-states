// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealState.Application.Abstract;
using RealState.Application.DTO.Property;
using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Repository;

namespace RealState.Application.Implements
{
	/// <summary>
	/// Interface IPropertyService
	/// Implements the <see cref="RealState.Application.Abstract.IPropertyService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.IPropertyService" />
	public class PropertyService : IPropertyService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IPropertyRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyService"/> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		public PropertyService(IPropertyRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Gets all properties.
		/// </summary>
		/// <returns>Task&lt;IEnumerable&lt;Property&gt;&gt;.</returns>
		public async Task<IEnumerable<PropertyListDto>> GetAllProperties()
		{
			var propertyList = await _repository.GetAllAsync();
			return propertyList.Select< Property, PropertyListDto>(p => p);
		}
	}
}