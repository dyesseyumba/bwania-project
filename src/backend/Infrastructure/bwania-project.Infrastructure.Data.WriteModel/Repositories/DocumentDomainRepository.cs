// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentDomainRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Entities;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentDomainRepository : DomainRepositoryBase<IDocument>, IDocumentDomainRepository
    {
        public DocumentDomainRepository(IDocumentBucket documentBucket)
            : base(documentBucket.Default)
        {
        }
    }
}