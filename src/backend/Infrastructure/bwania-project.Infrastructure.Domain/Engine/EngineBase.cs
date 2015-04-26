// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EngineBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Domain.Engines
{
    public abstract class EngineBase<TEntity> : IEngine<TEntity>
        where TEntity : IEntity
    {
        #region  Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EngineBase{TEntity}" /> class.
        /// </summary>
        /// <param name="exceptionService">The exception service.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        protected EngineBase(IExceptionService exceptionService)
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

        #region Methods

        public abstract Task<bool> SaveAsync(TEntity entity);

        public abstract Task<bool> RemoveAsync(TEntity entity);

        #endregion
    }
}