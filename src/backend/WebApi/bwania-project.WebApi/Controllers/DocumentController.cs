// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Web.Http;
using BwaniaProject.Data;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.WebApi.Controllers
{
    public class DocumentController 
        : ApiControllerBase<IDocumentReadRepository, IDocumentDomainEngine>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="exceptionService">The exception service.</param>
        public DocumentController(IDocumentReadRepository repository, IDocumentDomainEngine engine,
            IExceptionService exceptionService) 
            : base(repository, engine, exceptionService)
        {
        }
        #endregion

        #region Actions
        [Route(RouteNames.Document.GetTen), HttpGet]
        public async Task<IHttpActionResult> GetTen(int nbPage)
        {
            var documents = await ExceptionService.ProcessAsync(()
                => Repository.GetTenDocumentAsync(nbPage));

            return Ok(documents);
        }

        [Route(RouteNames.Document.Insert), HttpPost]
        public async Task<IHttpActionResult> Post(Document document)
        {
            Argument.IsNotNull("document", document);

            document.id = string.Format("document-{0}", Guid.NewGuid());
            var result = await ExceptionService.Process(() => Engine.SaveAsync(document));

            return Created(RouteNames.Document.Insert, result);
        }
        #endregion
    }
}