// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="OwnerController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Abstract;
using RealState.Application.DTO.Owner;

namespace RealState.Api.Controllers
{
	/// <summary>
	/// Class OwnerController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Route("api/[controller]")]
	[ApiController]
	public class OwnerController : ControllerBase
	{
		/// <summary>
		/// The owner service
		/// </summary>
		private readonly IOwnerService _ownerService;

		/// <summary>
		/// Initializes a new instance of the <see cref="OwnerController"/> class.
		/// </summary>
		/// <param name="ownerService">The owner service.</param>
		public OwnerController(IOwnerService ownerService)
		{
			_ownerService = ownerService;
		}


		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(GetAll))]
		[ProducesResponseType( (int) HttpStatusCode.OK, Type = typeof(IEnumerable<OwnerList>))]
		[ProducesResponseType( (int) HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetAll()
		{
			var result = await _ownerService.GetAllOwner();
			return Ok(result);
		}

	}
}