// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="IPropertyService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Application.DTO;
using RealState.Application.DTO.Property;
using RealState.Infrastructure.Pages;
using System.Threading.Tasks;

namespace RealState.Application.Abstract
{
	/// <summary>
	/// Interface IPropertyService
	/// </summary>
	public interface IPropertyService
	{
		/// <summary>
		/// Gets the paged properties.
		/// </summary>
		/// <param name="paginate">The paginate.</param>
		/// <param name="propertyRequest">The property request.</param>
		/// <returns>Task&lt;PagedList&lt;PropertyListDto&gt;&gt;.</returns>
		Task<PagedList<PropertyListDto>> GetPagedProperties(QueryParamDto paginate, PropertyRequestDto propertyRequest);
	}
}