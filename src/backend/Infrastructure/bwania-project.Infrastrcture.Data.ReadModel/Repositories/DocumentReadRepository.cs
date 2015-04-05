using System.Collections.Generic;
using bwaniaProject.Data.Exceptions;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public class DocumentReadRepository : ReadRepositoryBase, IDocumentReadRepository
    {
        public DocumentReadRepository()
            : base(ElasticSearchIndexNames.DocumentBucketName)
        {
        }

        public IEnumerable<Document> GetTenDocument(int nbPage)
        {
            var results = Client.Search<Document>(s => s
                .From(nbPage)
                .Size(10));

            if (results.IsValid) return results.Documents;

            throw new SearchRequestException(results.RequestInformation);
        }
    }
}