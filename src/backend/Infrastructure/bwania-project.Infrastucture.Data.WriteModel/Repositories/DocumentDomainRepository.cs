// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentDomainRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Entities;
using Couchbase;

namespace bwaniaProject.Data
{
    public class DocumentDomainRepository : DomainRepositoryBase<Document>, IDocumentDomainRepository
    {
        public DocumentDomainRepository()
            : base(ClusterHelper.GetBucket(BucketNames.DocumentBucketName))
        {
        }
    }
}