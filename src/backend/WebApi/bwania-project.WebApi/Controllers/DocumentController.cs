// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;
using BwaniaProject.Web.Api.Models;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Web.Api.Controllers
{
    public class DocumentController
        : ApiControllerBase
    {
       #region Fields

        private readonly IDocumentEngine _documentEngine;
        private readonly IDocumentReadRepository _documentReadRepository;
        private readonly IDocumentCountRepository _documentCountRepository;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentController" /> class.
        /// </summary>
        /// <param name="repositoryProvider"></param>
        /// <param name="documentCountRepository">The document coune repository</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <param name="engineProvider"></param>
        public DocumentController(IEngineProvider engineProvider, IRepositoryProvider repositoryProvider, 
            IDocumentCountRepository documentCountRepository, IExceptionService exceptionService)
            : base(exceptionService)
        {
            Argument.IsNotNull(() => engineProvider);
            Argument.IsNotNull(() => repositoryProvider);

            _documentEngine = engineProvider.GetEngine<IDocumentEngine>();
            _documentCountRepository = repositoryProvider.GetRepository<IDocumentCountRepository>(); ;
            _documentReadRepository = repositoryProvider.GetRepository<IDocumentReadRepository>();
        }

        #endregion

        #region Actions

        /// <summary>
        ///     Gets the ten documents from couchbase view.
        /// </summary>
        /// <param name="nbPage">The page number.</param>
        /// <returns></returns>
        [HttpGet, Route(Constants.RouteNames.Document.GetTen)]
        public async Task<IHttpActionResult> GetTen(int nbPage)
        {
            var documents = await ExceptionService.Process(()
                => _documentReadRepository.GetTenDocumentAsync(nbPage));

            return Ok(documents);
        }

        /// <summary>
        /// Gets the ten documents from couchbase view.
        /// </summary>
        /// <param name="nbPage">The page number.</param>
        /// <param name="filterParameter">The filter parameter.</param>
        /// <returns></returns>
        [HttpPost, Route(Constants.RouteNames.Document.GetFiltered1St)]
        public async Task<IHttpActionResult> GetFilteredByDomainOrByNiveau(int nbPage, DocumentFilterParameter filterParameter)
        {
            var documents = await ExceptionService.Process(()
                => _documentReadRepository.GetFilteredDocumentByDomainOrByNiveau(nbPage, filterParameter.Domaines, 
                filterParameter.Niveaux));

            return Ok(documents);
        }

        /// <summary>
        ///     Gets the specified document by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet, Route(Constants.RouteNames.Document.GetById)]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var document = await ExceptionService.Process(()
                => _documentReadRepository.GetByIdAsync(id));

            return Ok(document);
        }


        /// <summary>
        ///     Uploads directly document.
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route(Constants.RouteNames.Document.Upload)]
        public async Task<IHttpActionResult> Upload()
        {
            var document = new Document();
            var file = HttpContext.Current.Request.Files[0];

            if (!Infile(file)) return BadRequest("No file has been uploaded");

            var documentId = HttpContext.Current.Request.Form["documentId"];

            if (documentId != null)
            {
                document.Id = documentId;

                var fileStream = file.InputStream;
                var fileRecord = new byte[file.ContentLength];

                fileStream.Read(fileRecord, 0, file.ContentLength);

                document.Expiry = 1800000; //The document will expire in next 30 minutes
                document.Fichier = fileRecord;
            }

            var result = await ExceptionService.Process(() => _documentEngine.SaveAsync(document).ConfigureAwait(false));

            return Created(Constants.RouteNames.Document.Insert, result);
        }


        /// <summary>
        ///     Posts the document's data.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns></returns>
        [HttpPost, Route(Constants.RouteNames.Document.Insert)]
        public async Task<IHttpActionResult> Post(Document document)
        {
            var result = await ExceptionService.Process(() =>
            {
                return _documentReadRepository.GetByIdAsync(document.Id)
                    .ContinueWith(t =>
                    {
                        document.Fichier = t.Result.Fichier;
                        document.Expiry = 0; //Disable the expiration
                        return _documentEngine.SaveAsync(document).Result;
                    });
            }).ConfigureAwait(false);

            return Created(Constants.RouteNames.Document.Insert, result);
        }


        /// <summary>
        ///     Posts the comment in a document.
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route(Constants.RouteNames.Document.InsertComment)]
        public async Task<IHttpActionResult> PostComment(string id, Commentaire comment)
        {
            var result = await ExceptionService.Process(() =>
            {
                return _documentReadRepository.GetByIdAsync(id)
                    .ContinueWith(t =>
                    {
                        t.Result.Commentaires.Add(comment);
                        return _documentEngine.SaveAsync(t.Result).Result;
                    });
            }).ConfigureAwait(false);

            return Created(Constants.RouteNames.Document.Insert, result);
        }

        /// <summary>
        ///     Downloads the file from couchbase.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <returns></returns>
        [HttpGet, Route(Constants.RouteNames.Document.GetFileById)]
        public async Task<HttpResponseMessage> DownloadFile(string id)
        {
            var response = Request.CreateResponse();
            var result = await ExceptionService.Process(() =>
            {
                return _documentReadRepository.GetFileAsync(id)
                    .ContinueWith(file =>
                    {
                        if (file.Result == null)
                        {
                            response = Request.CreateResponse(HttpStatusCode.NotFound,
                                "Document doesn't exist in database");
                        }
                        else
                        {
                            response.Headers.AcceptRanges.Add("bytes");
                            response.StatusCode = HttpStatusCode.OK;
                            response.Content = new StreamContent(new MemoryStream(file.Result["file"]));
                            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                            response.Content.Headers.ContentDisposition.FileName = file.Result["fileName"];
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            response.Content.Headers.ContentLength = file.Result["file"].Length;
                        }
                        return response;
                    });
            });

            return result;
        }

        /// <summary>
        ///     Counts total number of documents.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(Constants.RouteNames.Document.CountTotalDoc)]
        public async Task<IHttpActionResult> CountTotalDocument()
        {
            var result = await ExceptionService.Process(() =>
                _documentCountRepository.CountGetTenDocumentAsync());

            return Ok(result);
        }

        [HttpPost, Route(Constants.RouteNames.Document.CountTotalFilteredDoc)]
        public async Task<IHttpActionResult> CountTotalFilterdDocument(int nbPage, DocumentFilterParameter filterParameter)
        {
            var nbpage = await ExceptionService.Process(()
                => _documentCountRepository.CountFilteredDocumentByDomainOrByNiveau(nbPage, filterParameter.Domaines, 
                filterParameter.Niveaux));

            return Ok(nbpage);
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