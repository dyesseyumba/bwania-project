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
using Couchbase;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentReadRepository : ReadRepositoryBase<Document>, IDocumentReadRepository
    {
        #region Constructors

        public DocumentReadRepository(IExceptionService exceptionService)
            : base(new Cluster(Constants.ClusterConfig).OpenBucket(), exceptionService)
        {
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            //TODO : add document name and view name
            var query = Bucket.CreateQuery("", "", true)
                .Skip(nbPage)
                .Limit(10);

            var results = await ExceptionService.ProcessAsync(() => Bucket.Query<Document>(query))
                .ConfigureAwait(false) ;

            if (results.Success) return results.Values;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        #endregion

        
    }
}