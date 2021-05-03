// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="IOwnerService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using RealState.Application.DTO.Owner;

namespace RealState.Application.Abstract
{
	/// <summary>
	/// Interface IOwnerService
	/// </summary>
	public interface IOwnerService
	{
		/// <summary>
		/// Gets all owner.
		/// </summary>
		/// <returns>Task&lt;IEnumerable&lt;OwnerList&gt;&gt;.</returns>
		Task<IEnumerable<OwnerList>> GetAllOwner();
	}
}