// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommentaire.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace BwaniaProject.Entities
{
    public interface ICommentaire : IEntity
    {
        /// <summary>
        ///     Gets or sets the designation.
        /// </summary>
        /// <value>
        ///     The designation.
        /// </value>
        string designation { get; set; }

        /// <summary>
        ///     Gets or sets the date ajout.
        /// </summary>
        /// <value>
        ///     The date ajout.
        /// </value>
        DateTime dateAjout { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>
        ///     The user identifier.
        /// </value>
        string userId { get; set; }
    }
}