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
    public class DocumentReadRepository : ReadRepositoryBase<IDocument>, IDocumentReadRepository
    {
        #region Constructors

        public DocumentReadRepository(IExceptionService exceptionService)
            : base(new Cluster(Constants.ClusterConfig).OpenBucket(), exceptionService)
        {
        }

        #endregion

        #region Methods

        public Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        
    }
}