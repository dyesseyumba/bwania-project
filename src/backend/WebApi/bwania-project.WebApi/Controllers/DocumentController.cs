// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Web.Http;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Web.Api.Controllers
{
    public class DocumentController
        : ApiControllerBase<IDocumentReadRepository, IDocumentEngine>
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentController" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="documentEngine"></param>
        /// <param name="exceptionService">The exception service.</param>
        public DocumentController(IDocumentReadRepository repository, IDocumentEngine documentEngine,
            IExceptionService exceptionService)
            : base(repository, documentEngine, exceptionService)
        {
        }

        #endregion

        #region Actions

        [HttpGet, Route(Constants.RouteNames.Document.GetTen)]
        public async Task<IHttpActionResult> GetTen(int nbPage)
        {
            var documents = await ExceptionService.Process(()
                => Repository.GetTenDocumentAsync(nbPage));

            return Ok(documents);
        }

        [HttpPost, Route(Constants.RouteNames.Document.Insert)]
        public async Task<IHttpActionResult> Post(Document document)
        {
            Argument.IsNotNull("document", document);

            document.id = string.Format("document-{0}", Guid.NewGuid());
            var result = await ExceptionService.Process(() => DocumentEngine.SaveAsync(document));

            return Created(Constants.RouteNames.Document.Insert, result);
        }

        #endregion
    }
}