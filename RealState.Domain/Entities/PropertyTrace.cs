// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-30-2021
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
    /// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="RealState.Domain.Entities.BaseEntity" />
    public class PropertyTrace : BaseEntity
    {
        /// <summary>
        /// Gets or sets the date sale.
        /// </summary>
        /// <value>The date sale.</value>
        public DateTime? DateSale { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal? Value { get; set; }
        /// <summary>
        /// Gets or sets the tax.
        /// </summary>
        /// <value>The tax.</value>
        public string Tax { get; set; }
        /// <summary>
        /// Gets or sets the identifier property.
        /// </summary>
        /// <value>The identifier property.</value>
        public int IdProperty { get; set; }

        /// <summary>
        /// Gets or sets the identifier property navigation.
        /// </summary>
        /// <value>The identifier property navigation.</value>
        public virtual Property IdPropertyNavigation { get; set; }
    }
}
