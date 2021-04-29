// ***********************************************************************
// Assembly         :
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="UserRepository.cs" company="AlbertPalencia">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Domain.Entities;
using RealState.Infrastructure.DataAccess;
using RealState.Infrastructure.Interfaces.Repository;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UserRepository(RealStateContext context) : base(context)
		{
		}

		/// <summary>
		/// Validate the user.
		/// </summary>
		/// <param name="userName">Name of the user.</param>
		/// <returns>Task&lt;User&gt;.</returns>
		public async Task<User> ValidateUser(string userName)
		{
			return await FirstOrDefaultAsync(user => user.UserName == userName);
		}
	}
}