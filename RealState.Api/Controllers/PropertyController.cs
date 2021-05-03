// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-02-2021
// ***********************************************************************
// <copyright file="PropertyController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Abstract;
using RealState.Application.DTO.Property;

namespace RealState.Api.Controllers
{
	/// <summary>
	/// Class PropertyController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Route("api/[controller]")]
	[ApiController]
	public class PropertyController : ControllerBase
	{
		/// <summary>
		/// The property service
		/// </summary>
		private readonly IPropertyService _propertyService;

		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyController" /> class.
		/// </summary>
		/// <param name="propertyService">The property service.</param>
		public PropertyController(IPropertyService propertyService)
		{
			_propertyService = propertyService;
		}


		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(GetAll))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PropertyListDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetAll()
		{
			var result = await _propertyService.GetAllProperties();
			return Ok(result);
		}
	}
}