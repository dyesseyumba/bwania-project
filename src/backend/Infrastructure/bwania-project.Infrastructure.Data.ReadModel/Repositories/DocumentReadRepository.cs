// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Entities;
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

        public async Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
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

        #endregion

        public override async Task<IDocument> GetByIdAsync(string entityId)
        {
            return await GetByIdAsync<Document>(entityId).ConfigureAwait(false);
        }
    }
}