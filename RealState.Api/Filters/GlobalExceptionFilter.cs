// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-08-2021
// ***********************************************************************
// <copyright file="GlobalExceptionFilter.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RealState.Api.Filters
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using System.Diagnostics.CodeAnalysis;
	using System.Net;

	/// <summary>
	/// Class GlobalExceptionFilter.
	/// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
	[ExcludeFromCodeCoverage]
	public class GlobalExceptionFilter : IExceptionFilter
	{
		/// <summary>
		/// Called after an action has thrown an <see cref="T:System.Exception" />.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
		public void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
			var validation = new
			{
				Status = 500,
				Title = "Error",
				Detail = exception.Message
			};

			var json = new
			{
				errors = new[] { validation }
			};

			context.Result = new BadRequestObjectResult(json);
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			context.ExceptionHandled = true;
		}
	}
}