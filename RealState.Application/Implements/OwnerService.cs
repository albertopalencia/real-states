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
using System.Linq;
using System.Threading.Tasks;
using RealState.Application.Abstract;
using RealState.Application.DTO.Owner;
using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Repository;

namespace RealState.Application.Implements
{
	/// <summary>
	/// Interface IOwnerService
	/// </summary>
	public class OwnerService : IOwnerService
	{
		private readonly IOwnerRepository _repository;

		public OwnerService(IOwnerRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<OwnerList>> GetAllOwner()
		{
			var ownerList = await _repository.GetAllAsync();
			return ownerList.Select<Owner, OwnerList>(o => o);
		}
	}
}