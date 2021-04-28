// ***********************************************************************
// Assembly         : RealState.Infrastructure
// Author           : Alberto Palencia
// Created          : 04-14-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-18-2021
// ***********************************************************************
// <copyright file="PermisoRepository.cs" company="RealState.Infrastructure">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Infrastructure.Repositories
{
	using Microsoft.EntityFrameworkCore;
	using RealState.Infrastructure.DataAccessEntityFrameWork;
	using RealState.Infrastructure.Interfaces.Repository;
	using RealState.Infrastructure.Repositories.Usuarios;
	using System.Threading.Tasks;


	/// <summary>
	/// Class PermisoRepository.
	/// Implements the <see cref="RealState.Infrastructure.Repositories.GenericRepository{RealState.Domain.Entities.Usuarios}" />
	/// Implements the <see cref="RealState.Infrastructure.Interfaces.Repository.IUsuarioRepository" />
	/// </summary>
	/// <seealso cref="RealState.Infrastructure.Repositories.GenericRepository{RealState.Domain.Entities.Usuarios}" />
	/// <seealso cref="RealState.Infrastructure.Interfaces.Repository.IUsuarioRepository" />
	public class PermisoRepository : GenericRepository<Domain.Entities.Permisos>, IPermisoRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PermisoRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public PermisoRepository(RealStateContext context) : base(context)
		{
		}
  
	}
}