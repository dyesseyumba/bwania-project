// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Couchbase.Core;

namespace BwaniaProject.Data
{
    public class ReadRepositoryBase<T> : IReadRepository<T> where T : class, IEntity
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see>
        ///         <cref>ReadRepositoryBase</cref>
        ///     </see>
        ///     class.
        /// </summary>
        /// <param name="bucket">the couchbase Bucket.</param>
        /// <param name="exceptionService">The exception service</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="bucket" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ReadRepositoryBase(IBucket bucket, IExceptionService exceptionService)
        {
            Argument.IsNotNull("indexName", bucket);

            Bucket = bucket;
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

        #endregion

        #region Methods

        public async Task<T> GetOneByIdAsync(string entityId)
        {
            var result = await ExceptionService.ProcessAsync(() => Bucket.GetDocument<T>(entityId));

            if (result.Success)
            {
                return result.Content;
            }
            throw new SearchRequestException(result.Message);
        }

        #endregion
    }
}