// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data;
using BwaniaProject.Entities;

namespace BwaniaProject.Domain.Engines
{
    public interface IDocumentDomainEngine : IDomainEngine<IDocument, IDocumentDomainRepository>
    {
    }
}