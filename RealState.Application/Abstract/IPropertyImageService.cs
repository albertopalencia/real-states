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
using RealState.Domain.Entities;

namespace RealState.Application.Abstract
{
	/// <summary>
	/// Interface IPropertyImageService
	/// </summary>
	public interface IPropertyImageService
	{
		/// <summary>
		/// Gets all properties images.
		/// </summary>
		/// <returns>Task&lt;IEnumerable&lt;PropertyImage&gt;&gt;.</returns>
		Task<IEnumerable<PropertyImage>> GetAllPropertiesImages();
	}
}