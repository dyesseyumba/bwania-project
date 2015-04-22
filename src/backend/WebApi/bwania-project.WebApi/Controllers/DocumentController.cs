// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
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

        [Route(RouteNames.Document.Upload), HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            var document = new Document();
            var file = HttpContext.Current.Request.Files[0];

            if (!Infile(file)) return BadRequest("No file has been uploaded");

            var documentId = HttpContext.Current.Request.Files["documentId"];
            if (documentId != null)
                document.id = documentId.ToString();

            var fileStream = file.InputStream;
            var fileRecord = new byte[file.ContentLength];

            fileStream.Read(fileRecord, 0, file.ContentLength);

            document.Fichier = fileRecord;

            var result = await ExceptionService.Process(() => Engine.SaveAsync(document).ConfigureAwait(false));

            return Created(RouteNames.Document.Insert, result);
        }

        [Route(RouteNames.Document.Insert), HttpPost]
        public async Task<IHttpActionResult> Post(Document document)
        {
            Argument.IsNotNull("document", document);

            var result = await ExceptionService.Process(() => Engine.SaveAsync(document).ConfigureAwait(false));

            return Created(RouteNames.Document.Insert, result);
        }
        #endregion

        #region Methods

        public bool Infile(HttpPostedFile file)
        {
            return file != null && file.ContentLength > 0;
        }

        #endregion
    }
}