// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="IUserRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Interfaces.Repository
{
	using Domain.Entities;
	using System.Threading.Tasks;

	/// <summary>
	/// Interface IUserRepository
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.IReadRepository{RealState.Domain.Entities.User}" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Interfaces.IReadRepository{RealState.Domain.Entities.User}" />
	public interface IUserRepository : IReadRepository<User>
	{
		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <returns>Task&lt;User&gt;.</returns>
		Task<User> ValidateUser(string userName);
	}
}