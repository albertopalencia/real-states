// ***********************************************************************
// Assembly         : RealState.Domain
// Author           : Alberto Palencia
// Created          : 04-28-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 04-30-2021
// ***********************************************************************
// <copyright file="PropertyImage.cs" company="RealState.Domain">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace RealState.Domain.Entities
{
    /// <summary>
    /// Class PropertyImage.
    /// Implements the <see cref="RealState.Domain.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="RealState.Domain.Entities.BaseEntity" />
    public class PropertyImage : BaseEntity
    {
         
        /// <summary>
        /// Gets or sets the identifier property.
        /// </summary>
        /// <value>The identifier property.</value>
        public int IdProperty { get; set; }
        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        public string File { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PropertyImage"/> is enabled.
        /// </summary>
        /// <value><c>null</c> if [enabled] contains no value, <c>true</c> if [enabled]; otherwise, <c>false</c>.</value>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the identifier property navigation.
        /// </summary>
        /// <value>The identifier property navigation.</value>
        public virtual Property IdPropertyNavigation { get; set; }
    }
}
