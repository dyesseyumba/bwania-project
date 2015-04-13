// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using BwaniaProject.Data;
using BwaniaProject.Entities;

namespace BwaniaProject.Domain.Engines
{
    public interface IDocumentReadEngine : IReadEngine<IDocumentReadRepository>
    {
        IEnumerable<IDocument> GetTenDocument(int nbPage);
    }
}