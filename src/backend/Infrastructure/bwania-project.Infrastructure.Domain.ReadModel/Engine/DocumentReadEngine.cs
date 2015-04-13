// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using BwaniaProject.Data;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;

namespace BwaniaProject.Domain.Engine
{
    public class DocumentReadEngine : ReadEngine<IDocumentReadRepository>, IDocumentReadEngine
    {
        #region Constructors
        public DocumentReadEngine(IDocumentReadRepository repository) : base(repository)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets ten document in elasticsearch.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        public IEnumerable<IDocument> GetTenDocument(int nbPage)
        {
            return Repository.GetTenDocument(nbPage);
        }
        #endregion
    }
}