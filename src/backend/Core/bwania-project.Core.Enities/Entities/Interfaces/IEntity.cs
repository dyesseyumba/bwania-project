// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEntity.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject.Entities
{
    public interface IEntity
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        string id { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        string Type { get; set; }

        /// <summary>
        ///     Gets or sets the cas.
        /// </summary>
        /// <value>
        ///     The cas.
        /// </value>
        ulong Cas { get; set; }
    }
}