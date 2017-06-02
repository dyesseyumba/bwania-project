using Catel;
using Couchbase.Core;

namespace BwaniaProject.Data.Buckets
{
    public interface IDocumentBucket
    {
        IBucket Default { get; }
    }


    public class DocumentBucket : IDocumentBucket
    {

        public DocumentBucket(IBucket bucket)
        {
            Argument.IsNotNull(() => bucket);

            Default = bucket;
        }

        public IBucket Default { get; private set; }
    }
}