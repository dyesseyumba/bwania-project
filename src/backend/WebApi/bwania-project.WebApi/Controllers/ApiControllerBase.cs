﻿// --------------------------------------------------------------------------------------------------------------------
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
    public class ApiControllerBase<TRepository> : ApiController where TRepository : class
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiControllerBase{TEngine}" /> class.
        /// </summary>
        /// <param name="repository">The engine.</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="repository" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ApiControllerBase(TRepository repository, IExceptionService exceptionService)
        {
            Argument.IsNotNull("engine", repository);
            Argument.IsNotNull("exceptionService", exceptionService);

            Repository = repository;
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

        #endregion
    }
}