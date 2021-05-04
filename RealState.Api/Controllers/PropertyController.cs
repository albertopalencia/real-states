// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="PropertyController.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Abstract;
using RealState.Application.DTO;
using RealState.Application.DTO.Property;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RealState.Api.Response;
using RealState.Infrastructure.Pages;

namespace RealState.Api.Controllers
{
	/// <summary>
	/// Class PropertyController.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[Authorize]
	[Produces("application/json")]
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
		/// Gets the paged properties.
		/// </summary>
		/// <param name="paginate">The paginate.</param>
		/// <param name="request">The request.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet(nameof(GetPagedProperties))]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<List<PropertyListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> GetPagedProperties([FromQuery] QueryParamDto paginate, [FromQuery] PropertyRequestDto request)
		{
			var result = await _propertyService.GetPagedProperties(paginate, request);
			var response = new ApiResponse<List<PropertyListDto>>(result)
			{
				Meta = new Metadata
				{
					PageSize = result.PageSize,
					CurrentPage = result.CurrentPage,
					HasNextPage = result.HasNextPage,
					HasPreviousPage = result.HasPreviousPage,
					TotalCount = result.TotalCount,
					TotalPages = result.TotalPages
				}
			};

			return Ok(response);
		}
	}
}