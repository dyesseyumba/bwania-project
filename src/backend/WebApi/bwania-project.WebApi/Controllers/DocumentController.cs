// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentController.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using System.Web.Http;
using BwaniaProject.Data;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;

namespace BwaniaProject.WebApi.Controllers
{
    public class DocumentController : ApiControllerBase<IDocumentReadRepository>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="exceptionService">The exception service.</param>
        public DocumentController(IDocumentReadRepository repository, IExceptionService exceptionService) 
            : base(repository, exceptionService)
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
        #endregion
    }
}