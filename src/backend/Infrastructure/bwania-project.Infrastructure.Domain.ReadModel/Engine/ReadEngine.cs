// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using BwaniaProject.Data;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Domain.Engine
{
    public class ReadEngine<TRepository> : IReadEngine<TRepository> 
        where TRepository : IReadRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEngine{TRepository}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="repository" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ReadEngine(TRepository repository, IExceptionService exceptionService)
        {
            Argument.IsNotNull("repository", repository);
            Argument.IsNotNull("exceptionService", exceptionService);

            Repository = repository;
            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public TRepository Repository{ get; set; }

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