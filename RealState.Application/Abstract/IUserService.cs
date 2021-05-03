// ***********************************************************************
// Assembly         :
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="IUserService.cs" company="AlbertPalencia">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using RealState.Domain.DTO.User;

namespace RealState.Application.Abstract
{
	/// <summary>
	/// Interface IUserService
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;Domain.Entities.User&gt;.</returns>
		Task<Domain.Entities.User> ValidateUser(UserDto user);
	}
}