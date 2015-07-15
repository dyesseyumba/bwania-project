// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentFilterParameter.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace BwaniaProject.Web.Api.Models
{
    public class DocumentFilterParameter
    {
        /// <summary>
        /// Gets or sets the niveaux.
        /// </summary>
        /// <value>
        /// The niveaux.
        /// </value>
        public List<string> Niveaux { get; set; }

        /// <summary>
        /// Gets or sets the domaines.
        /// </summary>
        /// <value>
        /// The domaines.
        /// </value>
        public List<string> Domaines { get; set; }
    }
}