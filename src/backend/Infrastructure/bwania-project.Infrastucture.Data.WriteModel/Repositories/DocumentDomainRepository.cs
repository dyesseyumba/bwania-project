// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentDomainRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------


using BwaniaProject;
using BwaniaProject.Entities;
using Couchbase;

namespace BwaniaProject.Data
{
    public class DocumentDomainRepository : DomainRepositoryBase<IDocument>, IDocumentDomainRepository
    {
        public DocumentDomainRepository()
            : base(ClusterHelper.GetBucket(Constants.DocumentBucketName))
        {
        }
    }
}