using System;
using System.Configuration;
using bwaniaProject.Entities;
using Catel;
using Nest;

namespace bwaniaProject.Data.Repositories
{
    public class ReadRepositoryBase<T> : IReadRepository<T> where T : IEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadRepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="indexName">Name of the index.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="indexName" /> is <c>null</c>.</exception>
        public ReadRepositoryBase(string indexName)
        {
            Argument.IsNotNull("indexName", indexName);

            var node = new Uri(ConfigurationManager.AppSettings["ElasticSearchUri"]);
            var settings = new ConnectionSettings(node, indexName);

            Client = new ElasticClient(settings);
        }
        #endregion

        #region Properties

        public ElasticClient Client { get; set; }
        #endregion
    }
}