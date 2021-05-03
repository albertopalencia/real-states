// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="IPropertyImageService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using RealState.Application.Abstract;
using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Repository;

namespace RealState.Application.Implements
{
	/// <summary>
	/// Interface IPropertyImageService
	/// </summary>
	public class PropertyImageService  : IPropertyImageService
	{
		private readonly IPropertyImageRepository _repository
			;
		public PropertyImageService(IPropertyImageRepository propertyImageRepository)
		{
			_repository = propertyImageRepository;
		}

		public async Task<IEnumerable<PropertyImage>> GetAllPropertiesImages()
		{
			return await _repository.GetAllAsync();
		}
		
	}
}