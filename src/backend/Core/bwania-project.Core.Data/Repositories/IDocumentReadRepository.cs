﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// Gets the file asynchronous from couch base.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        Task<IDictionary<string, dynamic>> GetFileAsync(string entityId);

        /// <summary>
        /// Gets the filtered document by domain or by niveau.
        /// </summary>
        /// <param name="nbPage"></param>
        /// <param name="domains">The domains.</param>
        /// <param name="niveaux">The niveau.</param>
        /// <returns></returns>
        Task<IEnumerable<IDocument>> GetFilteredDocumentByDomainOrByNiveau(int nbPage, List<string> domains, List<string> niveaux);

        /// <summary>
        /// Searches the document by title.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        Task<IEnumerable<IDocument>> SearchDocumentByTitle(int nbPage, string title);

        /// <summary>
        /// Filters the document search result by domain or niveau.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="title">The title.</param>
        /// <param name="domains">The domains.</param>
        /// <param name="niveaux">The niveaux.</param>
        /// <returns></returns>
        Task<IEnumerable<IDocument>> SearchFilterdDocumentByDomainOrNiveau(int nbPage, string title, 
            List<string> domains, List<string> niveaux);
    }
}