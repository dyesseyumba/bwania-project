// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentReadRepository : ReadRepositoryBase<IDocument>, IDocumentReadRepository
    {
        #region Constructors

        public DocumentReadRepository(IExceptionService exceptionService)
            : base(Constants.DocumentIndexName, exceptionService)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the ten indexed document.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        /// <exception cref="SearchRequestException"></exception>
        public async Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            var results = Client.Search<IDocument>(s => s
                .From(nbPage)
                .Size(10));

            if (results.IsValid)
            {
                return await ExceptionService.ProcessAsync(() => results.Documents).ConfigureAwait(false);
            }
            throw new SearchRequestException(results.RequestInformation);
        }

        #endregion
    }
}