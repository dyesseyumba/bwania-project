// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using BwaniaProject.Data;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using FluentValidation;

namespace BwaniaProject.Domain.Engines
{
    public class DomainEngineBase<TEntity, TRepository> : IDomainEngine<TEntity, TRepository>
        where TEntity : IEntity
        where TRepository : IDomainRepository<TEntity>
    {
        #region  Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEngineBase{TEntity,TRepository}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="exceptionService">The exception service.</param>
        /// <param name="validatorFactory">The validator factory.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="repository" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="validatorFactory" /> is <c>null</c>.</exception>
        public DomainEngineBase(TRepository repository, IExceptionService exceptionService)
            //,IValidatorFactory validatorFactory)
        {
            Argument.IsNotNull("repository", repository);
            Argument.IsNotNull("exceptionService", exceptionService);
            //Argument.IsNotNull("validatorFactory", validatorFactory);

            Repository = repository;
            ExceptionService = exceptionService;
            //Validator = validatorFactory.GetValidator<TEntity>();
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
        /// Gets the validator.
        /// </summary>
        /// <value>
        /// The validator.
        /// </value>
        //public IValidator<TEntity> Validator { get; private set; }

        #endregion

        #region Methods
        public async Task<bool> SaveAsync(TEntity entity)
        {
            Argument.IsNotNull("entity", entity);

            //await Validator.ValidateAndThrowAsync(entity).ConfigureAwait(false);

            return await ExceptionService.Process(() => Repository.SaveAsync(entity).ConfigureAwait(false));
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
            Argument.IsNotNull("entity", entity);

            //await Validator.ValidateAndThrowAsync(entity).ConfigureAwait(false);

            return await ExceptionService.Process(() => Repository.RemoveAsync(entity).ConfigureAwait(false));
        }
        #endregion
    }
}