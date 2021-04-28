// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="ValidatorActionFilter.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Api.Filters
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Class ValidatorActionFilter.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IActionFilter" />
	[ExcludeFromCodeCoverage]
	public class ValidatorActionFilter : IActionFilter
	{


		/// <summary>
		/// Called before the action executes, after model binding is complete.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}



		/// <summary>
		/// Called when [action executed].
		/// </summary>
		/// <param name="context">The context.</param>
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}