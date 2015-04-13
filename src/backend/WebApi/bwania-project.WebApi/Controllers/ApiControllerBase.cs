// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiControllerBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.WebApi.Controllers
{
    public class ApiControllerBase<TEngine> : ApiController where TEngine : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase{TEngine}" /> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="engine" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ApiControllerBase(TEngine engine, IExceptionService exceptionService)
        {
            Argument.IsNotNull("engine", engine);
            Argument.IsNotNull("exceptionService", exceptionService);

            Engine = engine;
            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the engine.
        /// </summary>
        /// <value>
        ///     The engine.
        /// </value>
        protected TEngine Engine { get; private set; }

        /// <summary>
        /// Gets the exception service.
        /// </summary>
        /// <value>
        /// The exception service.
        /// </value>
        protected IExceptionService ExceptionService { get; private set; }

        #endregion
    }
}