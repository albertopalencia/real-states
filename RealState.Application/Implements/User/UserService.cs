// ***********************************************************************
// Assembly         :
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="UserService.cs" company="AlbertPalencia">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using RealState.Application.Abstract.General;
using RealState.Application.Abstract.User;
using RealState.Domain.DTO.User;
using RealState.Infrastructure.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace RealState.Application.Implements.User
{
	/// <summary>
	/// Class UserService.
	/// Implements the <see cref="RealState.Application.Abstract.User.IUserService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.User.IUserService" />
	public class UserService : IUserService
	{
		/// <summary>
		/// The user repository
		/// </summary>
		private readonly IUserRepository _userRepository;

		/// <summary>
		/// The password service
		/// </summary>
		private readonly IPasswordService _passwordService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService"/> class.
		/// </summary>
		/// <param name="passwordService">The password service.</param>
		/// <param name="userRepository">The user repository.</param>
		public UserService(IPasswordService passwordService, IUserRepository userRepository)
		{
			_passwordService = passwordService;
			_userRepository = userRepository;
		}

		/// <summary>
		/// Validates the user.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;Domain.Entities.User&gt;.</returns>
		/// <exception cref="ArgumentNullException">The username: {user.UserName} or password: {user.Password} is incorrect</exception>
		public async Task<Domain.Entities.User> ValidateUser(UserDto user)
		{
			var exitsUser = await _userRepository.ValidateUser(user.UserName);
			
			if (exitsUser == null)
			{
				throw new ArgumentNullException($" The username: {user.UserName} or password: {user.Password} is incorrect ");
			}
			
			var valid = _passwordService.Check(exitsUser.Password, user.Password);
			return valid ? exitsUser : null;
		}
	}
}