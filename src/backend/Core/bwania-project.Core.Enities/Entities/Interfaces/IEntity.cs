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
        /// The unique identifier for the document
        /// 
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The "Check and Set" value for enforcing optimistic concurrency
        /// 
        /// </summary>
        ulong Cas { get; set; }

        /// <summary>
        /// The time-to-live or TTL for the document before it's evicated from disk
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Setting this to zero or less will give the document infinite lifetime
        /// </remarks>
        uint Expiry { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        string Type { get; set; }
    }
}