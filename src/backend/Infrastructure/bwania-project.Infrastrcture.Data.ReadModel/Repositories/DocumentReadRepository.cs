using System.Collections.Generic;
using bwaniaProject.Data.Exceptions;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public class DocumentReadRepository : ReadRepositoryBase, IDocumentReadRepository
    {
        #region Constructors
        public DocumentReadRepository()
            : base(ElasticSearchIndexNames.DocumentBucketName)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the ten indexed document.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        /// <exception cref="bwaniaProject.Data.Exceptions.SearchRequestException"></exception>
        public IEnumerable<Document> GetTenDocument(int nbPage)
        {
            var results = Client.Search<Document>(s => s
                .From(nbPage)
                .Size(10));

            if (results.IsValid) return results.Documents;

            throw new SearchRequestException(results.RequestInformation);
        }
        #endregion
    }
}