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
<<<<<<< HEAD
using System.Web.Http.Results;
using BwaniaProject.Data;
=======
using BwaniaProject.Data.Repositories;
>>>>>>> d2cd42d9858ea062b1242819ce2231077c08604a
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

<<<<<<< HEAD
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
=======
        [HttpPost, Route(Constants.RouteNames.Document.Insert)]
>>>>>>> d2cd42d9858ea062b1242819ce2231077c08604a
        public async Task<IHttpActionResult> Post(Document document)
        {
            Argument.IsNotNull("document", document);

<<<<<<< HEAD
            var result = await ExceptionService.Process(() => Engine.SaveAsync(document).ConfigureAwait(false));
=======
            document.id = string.Format("document-{0}", Guid.NewGuid());
            var result = await ExceptionService.Process(() => DocumentEngine.SaveAsync(document));
>>>>>>> d2cd42d9858ea062b1242819ce2231077c08604a

            return Created(Constants.RouteNames.Document.Insert, result);
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