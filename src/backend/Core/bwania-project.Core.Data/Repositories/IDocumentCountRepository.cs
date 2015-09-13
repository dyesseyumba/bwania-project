// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentCountRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BwaniaProject.Domain.Entities.Common;
using BwaniaProject.Entities;

namespace BwaniaProject.Data.Repositories
{
    public interface IDocumentCountRepository : IReadRepository<IDocument>
    {
        /// <summary>
        /// Counts the the result of view document asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<NbPage> CountGetTenDocumentAsync();

        /// <summary>
        /// Counts the filtered document by domain or by niveau.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="domains">The domains.</param>
        /// <param name="niveaux">The niveaux.</param>
        /// <returns></returns>
        Task<NbPage> CountFilteredDocumentByDomainOrByNiveau(int nbPage, List<string> domains, List<string> niveaux);
    }
}