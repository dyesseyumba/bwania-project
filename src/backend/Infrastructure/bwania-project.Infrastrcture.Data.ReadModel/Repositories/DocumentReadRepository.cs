using System.Collections.Generic;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Entities;

namespace BwaniaProject.Data
{
    public class DocumentReadRepository : ReadRepositoryBase, IDocumentReadRepository
    {
        #region Constructors
        public DocumentReadRepository()
            : base(Constants.DocumentBucketName)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the ten indexed document.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        /// <exception cref="SearchRequestException"></exception>
        public IEnumerable<IDocument> GetTenDocument(int nbPage)
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