// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiControllerBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Web.Api.Controllers
{
    public class ApiControllerBase : ApiController
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiControllerBase" /> class.
        /// </summary>
        /// <param name="exceptionService">The exception service.</param>
        public ApiControllerBase(IExceptionService exceptionService)
        {
            Argument.IsNotNull("exceptionService", exceptionService);

            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the exception service.
        /// </summary>
        /// <value>
        ///     The exception service.
        /// </value>
        protected IExceptionService ExceptionService { get; private set; }

        #endregion
    }
}