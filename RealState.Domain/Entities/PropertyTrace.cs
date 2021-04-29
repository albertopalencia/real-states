// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-28-2021
// ***********************************************************************
// <copyright file="PropertyTrace.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace RealState.Domain.Entities
{
	/// <summary>
	/// Class PropertyTrace.
	/// </summary>
	public class PropertyTrace
	{
		public string Name { get; set; }
		public DateTime DateSale { get; set; }
		public decimal Value { get; set; }
		public decimal Tax { get; set; }
		public int IdProperty { get; set; }
	}
}