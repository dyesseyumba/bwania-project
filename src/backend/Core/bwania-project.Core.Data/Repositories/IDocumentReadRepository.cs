// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BwaniaProject.Domain.Entities.Common;
using BwaniaProject.Entities;

namespace BwaniaProject.Data.Repositories
{
    public interface IDocumentReadRepository : IReadRepository<IDocument>
    {
        /// <summary>
        ///     Gets the ten document.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage);

        /// <summary>
        /// Counts the the result of view document asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<NbPage> CountGetTenDocumentAsync();

        /// <summary>
        /// Gets the file asynchronous from couch base.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        Task<IDictionary<string, dynamic>> GetFileAsync(string entityId);
    }
}