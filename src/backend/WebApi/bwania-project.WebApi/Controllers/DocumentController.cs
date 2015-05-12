// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Entities;
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
        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentController" /> class.
        /// </summary>
        /// <param name="repositoryProvider"></param>
        /// <param name="exceptionService">The exception service.</param>
        /// <param name="engineProvider"></param>
        public DocumentController(IEngineProvider engineProvider, IRepositoryProvider repositoryProvider,
            IExceptionService exceptionService)
            : base(exceptionService)
        {
            Argument.IsNotNull(() => engineProvider);
            Argument.IsNotNull(() => repositoryProvider);

            _documentEngine = engineProvider.GetEngine<IDocumentEngine>();
            _documentReadRepository = repositoryProvider.GetRepository<IDocumentReadRepository>();
        }

        #endregion

        #region Actions

        [HttpGet, Route(Constants.RouteNames.Document.GetTen)]
        public async Task<IHttpActionResult> GetTen(int nbPage)
        {
            var documents = await ExceptionService.Process(()
                => _documentReadRepository.GetTenDocumentAsync(nbPage));

            return Ok(documents);
        }

        [HttpGet, Route(Constants.RouteNames.Document.GetById)]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var document = await ExceptionService.Process(()
                => _documentReadRepository.GetByIdAsync(id));

            return Ok(document);
        }


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

                document.Expiry = 3600000; //The document will expire in next 60 minutes
                document.Fichier = fileRecord;
            }

            var result = await ExceptionService.Process(() => _documentEngine.SaveAsync(document).ConfigureAwait(false));

            return Created(Constants.RouteNames.Document.Insert, result);
        }


        [HttpPost, Route(Constants.RouteNames.Document.Insert)]
        public async Task<IHttpActionResult> Post(Document document)
        {
          var result = await ExceptionService.Process( () =>
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

        #endregion

        #region Methods

        public bool Infile(HttpPostedFile file)
        {
            return file != null && file.ContentLength > 0;
        }

        #endregion
    }
}