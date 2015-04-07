// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RepositoryFactsBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using bwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Couchbase.Core;
using FizzWare.NBuilder;
using LightInject;

namespace bwaniaProject.Data.Test.RepositoryFacts
{
    public class RepositoryDomainFactsBase<TRepository, TEntity>
        where TEntity : IEntity
        where TRepository : IDomainRepository<TEntity>
    {
        #region Constructors

        public RepositoryDomainFactsBase(TRepository repository)
        {
            var container = new ServiceContainer();

            Bucket = container.GetInstance<IBucket>();
            Repository = repository;
            ExceptionService = container.GetInstance<IExceptionService>();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the bucket.
        /// </summary>
        /// <value>
        ///     The bucket.
        /// </value>
        protected IBucket Bucket { get; private set; }

        /// <summary>
        ///     Gets the repository.
        /// </summary>
        /// <value>
        ///     The repository.
        /// </value>
        protected TRepository Repository { get; private set; }

        /// <summary>
        ///     Gets the exception service.
        /// </summary>
        /// <value>
        ///     The exception service.
        /// </value>
        protected IExceptionService ExceptionService { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Builds the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        // ReSharper disable once CSharpWarnings::CS0693
        protected TEntity BuildEntity<TEntity>()
        {
            return Builder<TEntity>.CreateNew().Build();
        }

        /// <summary>
        ///     Builds the entities.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="size" /> is out of the expected range.</exception>
        // ReSharper disable once CSharpWarnings::CS0693
        protected IEnumerable<TEntity> BuildEntities<TEntity>(int size = 2)
        {
            Argument.IsMinimal("size", size, 2);

            return Builder<TEntity>.CreateListOfSize(size).Build();
        }

        #endregion
    }
}