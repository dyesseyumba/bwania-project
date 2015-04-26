// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using Catel;
using Catel.ExceptionHandling;
using Nest;

// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject.Data
{
    public class ReadRepositoryBase
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
    }
}