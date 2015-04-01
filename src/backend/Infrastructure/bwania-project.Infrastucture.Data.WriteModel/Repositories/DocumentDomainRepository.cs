using bwaniaProject.Entities;
using Couchbase;

namespace bwaniaProject.Data
{
    public class DocumentDomainRepository : DomainRepositoryBase<Document>, IDocumentDomainRepository
    {
        public DocumentDomainRepository()
            : base(ClusterHelper.GetBucket(BucketNames.DocumentBucketName))
        {
        }
    }
}