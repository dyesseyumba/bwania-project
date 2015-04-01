using bwaniaProject.Entities;
using Couchbase;
using Couchbase.Core;

namespace bwaniaProject.Data
{
    public class CommentaireDomainRepository : DomainRepositoryBase<Commentaire>, ICommentaireDomainRepository
    {
        public CommentaireDomainRepository()
            : base(ClusterHelper.GetBucket(BucketNames.CommentaireBucketName))
        {
        }
    }
}