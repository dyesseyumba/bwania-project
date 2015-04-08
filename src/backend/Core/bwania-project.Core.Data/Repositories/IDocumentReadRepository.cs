// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using BwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface IDocumentReadRepository : IReadRepository
    {
        IEnumerable<Document> GetTenDocument(int nbPage);
    }
}