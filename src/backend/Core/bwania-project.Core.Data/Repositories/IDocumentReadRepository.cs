// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using BwaniaProject.Entities;

namespace BwaniaProject.Data
{
    public interface IDocumentReadRepository : IReadRepository
    {
        /// <summary>
        /// Gets the ten document.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        IEnumerable<IDocument> GetTenDocument(int nbPage);
    }
}