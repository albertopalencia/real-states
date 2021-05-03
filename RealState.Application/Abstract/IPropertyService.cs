// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="IPropertyService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Application.DTO.Property;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealState.Application.Abstract
{
	/// <summary>
	/// Interface IPropertyService
	/// </summary>
	public interface IPropertyService
	{
		/// <summary>
		/// Gets all properties.
		/// </summary>
		/// <returns>Task&lt;IEnumerable&lt;Property&gt;&gt;.</returns>
		Task<IEnumerable<PropertyListDto>> GetAllProperties();
	}
}