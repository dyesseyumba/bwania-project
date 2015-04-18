// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiControllerBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using BwaniaProject.Data;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.WebApi.Controllers
{
    public class ApiControllerBase<TRepository, TEngine> : ApiController
        where TRepository : IReadRepository
        where TEngine : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase{TRepository, TEngine}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="engine">The engine.</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="repository" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ApiControllerBase(TRepository repository, TEngine engine, IExceptionService exceptionService)
        {
            Argument.IsNotNull("repository", repository);
            Argument.IsNotNull("engine", engine);
            Argument.IsNotNull("exceptionService", exceptionService);

            Repository = repository;
            Engine = engine;
            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        protected TRepository Repository { get; private set; }

        /// <summary>
        /// Gets the exception service.
        /// </summary>
        /// <value>
        /// The exception service.
        /// </value>
        protected IExceptionService ExceptionService { get; private set; }

        /// <summary>
        /// Gets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        protected TEngine Engine { get; private set; }

        #endregion
    }
}