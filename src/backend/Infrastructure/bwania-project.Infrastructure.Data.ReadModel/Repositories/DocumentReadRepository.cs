// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Domain.Entities.Common;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Couchbase;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentReadRepository : ReadRepositoryBase<IDocument>, IDocumentReadRepository
    {
        #region Constructors

        public DocumentReadRepository(IDocumentBucket documentBucket, IExceptionService exceptionService)
            : base(documentBucket.Default, exceptionService)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets ten document from Couchbase.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        /// <exception cref="ViewRequestException"></exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="nbPage" /> is <c>null</c>.</exception>
        public async Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            Argument.IsNotNull("nbPage", nbPage);

            var query = Bucket.CreateQuery(Constants.DesignDocumentNameGet10Doc, Constants.ViewNameGet10Doc, true)
                .Skip(nbPage)
                .Limit(10)
                .Desc();

            var results = await ExceptionService.ProcessAsync(() => Bucket.Query<Document>(query))
                .ConfigureAwait(false) ;

            if (results.Success) return results.Values;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        /// <summary>
        /// Counts the the result of view document asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<NbPage> CountGetTenDocumentAsync()
        {
            var query = Bucket.CreateQuery(Constants.DesignDocumentNameGet10Doc, Constants.ViewNameGet10Doc, true);

            var results = await ExceptionService.ProcessAsync(() => Bucket.Query<Document>(query))
                .ConfigureAwait(false);

            var nbPage = new NbPage()
            {
                TotalDoc = (int) results.TotalRows
            };

            if (results.Success) return nbPage;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        /// <summary>
        /// Gets the file asynchronous from couch base.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entityId" /> is <c>null</c>.</exception>
        /// <returns></returns>
        public async Task<IDictionary<string, dynamic>> GetFileAsync(string entityId)
        {
            Argument.IsNotNull("entityID", entityId);

            var document = await GetByIdAsync(entityId).ConfigureAwait(false);
            var dictionary = new Dictionary<string, dynamic>();
            dictionary["file"] = document.Fichier;
            dictionary["fileName"] = "bwania-" + document.NomFichier;

            return dictionary;
        }

        /// <summary>
        /// Gets document by identifier asynchronous from Couchbase.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entityId" /> is <c>null</c>.</exception>
        /// <returns></returns>
        public override async Task<IDocument> GetByIdAsync(string entityId)
        {
            Argument.IsNotNull("entityID", entityId);

            return await GetByIdAsync<Document>(entityId).ConfigureAwait(false);
        }

        #endregion
    }
}