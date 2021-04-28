// ***********************************************************************
// Assembly         : RealState.Api
// Author           : Alberto Palencia
// Created          : 03-25-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 02-09-2021
// ***********************************************************************
// <copyright file="ApiResponse.cs" company="RealState.Api">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RealState.Infrastructure.Pages;

namespace RealState.Api.Response
{
	/// <summary>
	/// Class ApiResponse.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ApiResponse<T>
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiResponse{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public ApiResponse(T data)
		{
			Data = data;
		}


		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public T Data { get; set; }

		/// <summary>
		/// Gets or sets the meta.
		/// </summary>
		/// <value>The meta.</value>
		public Metadata Meta { get; set; }
	}
}
