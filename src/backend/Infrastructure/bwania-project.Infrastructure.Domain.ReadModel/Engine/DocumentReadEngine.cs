// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using BwaniaProject.Data;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;

namespace BwaniaProject.Domain.Engine
{
    public class DocumentReadEngine : ReadEngine<IDocumentReadRepository>, IDocumentReadEngine
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentReadEngine"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="exceptionService">The exception service.</param>
        public DocumentReadEngine(IDocumentReadRepository repository, IExceptionService exceptionService)
            : base(repository, exceptionService)
        {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets ten document in elasticsearch.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        public Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            return Repository.GetTenDocumentAsync(nbPage);
        }
        #endregion
    }
}