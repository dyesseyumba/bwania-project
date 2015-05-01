// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Nest;

namespace BwaniaProject.Data
{
    public class ReadRepositoryBase<T> : IReadRepository<T> where T : class, IEntity
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReadRepositoryBase" /> class.
        /// </summary>
        /// <param name="indexName">Name of the index.</param>
        /// <param name="exceptionService">The exception service</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="indexName" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public ReadRepositoryBase(string indexName, IExceptionService exceptionService)
        {
            Argument.IsNotNull("indexName", indexName);

            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearchUri"]);
            var settings = new ConnectionSettings(node, indexName);

            Client = new ElasticClient(settings);
            ExceptionService = exceptionService;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the alastic search client.
        /// </summary>
        /// <value>
        ///     The client.
        /// </value>
        public ElasticClient Client { get; set; }

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
            var results = Client.Search<T>(s => s
                .From(0)
                .Size(1)
                .Query(q => q.Term(d => d.Id, entityId)));

            if (results.IsValid)
            {
                return await ExceptionService.ProcessAsync(() => results.Documents.FirstOrDefault()).ConfigureAwait(false);
            }
            throw new SearchRequestException(results.RequestInformation);
        }

        #endregion
    }
}