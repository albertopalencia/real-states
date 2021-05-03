// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-27-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-30-2021
// ***********************************************************************
// <copyright file="User.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RealState.Domain.Entities
{
    /// <summary>
    /// Class User.
    /// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="RealState.Domain.Entities.BaseEntity" />
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}
