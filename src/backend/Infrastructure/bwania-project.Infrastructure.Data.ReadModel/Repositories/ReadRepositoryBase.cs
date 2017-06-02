// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Couchbase.Core;
using Elasticsearch.Net;
using Nest;

namespace BwaniaProject.Data
{
    public abstract class ReadRepositoryBase<T> : IReadRepository<T> where T : class, IEntity
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see>
        ///         <cref>ReadRepositoryBase</cref>
        ///     </see>
        ///     class.
        /// </summary>
        /// <param name="bucket">the couchbase Bucket.</param>
        /// <param name="elasticClient">The elastic search client</param>
        /// <param name="exceptionService">The exception service</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="bucket" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="elasticClient" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ReadRepositoryBase(IDocumentBucket bucket, IElasticClient elasticClient, IExceptionService exceptionService)
        {
            Argument.IsNotNull("bucket", bucket);
            Argument.IsNotNull("elasticsearchClient", elasticClient);
            Argument.IsNotNull("exceptionService", exceptionService);

            Bucket = bucket.Default;
            ElasticClient = elasticClient;
            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the bucket.
        /// </summary>
        /// <value>
        /// The bucket.
        /// </value>
        protected IBucket Bucket { get; private set; }

        /// <summary>
        ///     Gets the exception service.
        /// </summary>
        /// <value>
        ///     The exception service.
        /// </value>
        protected IExceptionService ExceptionService { get; private set; }

        /// <summary>
        /// Gets the elasticsearch client.
        /// </summary>
        /// <value>
        /// The elasticsearch client.
        /// </value>
        protected IElasticClient ElasticClient { get; private set; }

        #endregion

        #region Methods

        protected async Task<TEntity> GetByIdAsync<TEntity>(string entityId)
            where TEntity : class 
        {
            var result = await ExceptionService.ProcessAsync(() => Bucket.GetDocument<TEntity>(entityId)).ConfigureAwait(false);

            if (result.Success)
            {
                return result.Content;
            }
            throw new SearchRequestException(result.Message);
        }

         public abstract Task<T> GetByIdAsync(string entityId);

        #endregion

       
    }
}