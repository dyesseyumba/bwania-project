using System;
using System.Runtime.Serialization;
using Couchbase;

namespace bwaniaProject.Data.Exceptions
{
    public class DocumentNotFoundException : CouchbaseDataException
    {
        public DocumentNotFoundException()
        {
        }

        public DocumentNotFoundException(string message)
            : base(message)
        {
        }

        public DocumentNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DocumentNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DocumentNotFoundException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public DocumentNotFoundException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}
