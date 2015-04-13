// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using System.Web.Http;
using BwaniaProject.Domain.Engines;
using Catel.ExceptionHandling;

namespace BwaniaProject.WebApi.Controllers
{
    public class DocumentController : ApiControllerBase<IDocumentReadEngine>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="exceptionService">The exception service.</param>
        public DocumentController(IDocumentReadEngine engine, IExceptionService exceptionService) 
            : base(engine, exceptionService)
        {
        }
        #endregion

        #region Actions
        [Route(RouteNames.Document.GetTen), HttpGet]
        public async Task<IHttpActionResult> GetTen(int nbPage)
        {
            var documents = await ExceptionService.ProcessAsync(()
                => Engine.GetTenDocumentAsync(nbPage)).ConfigureAwait(true);

            return Ok(documents);
        }
        #endregion
    }
}