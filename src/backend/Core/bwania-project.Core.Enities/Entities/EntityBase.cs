// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EntityBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace BwaniaProject.Entities
{
    public class EntityBase : IEntity
    {
        #region Fields

        private static string _typeName;

        #endregion

        #region Constructors

        protected EntityBase()
        {
            if (_typeName == null)
            {
                _typeName = GetType().Name;
            }
            Type = _typeName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The unique identifier for the document
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The "Check and Set" value for enforcing optimistic concurrency
        /// 
        /// </summary>
        public ulong Cas { get; set; }

        /// <summary>
        /// The time-to-live or TTL for the document before it's evicated from disk
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Setting this to zero or less will give the document infinite lifetime
        /// </remarks>
        public uint Expiry { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        #endregion
    }
}