using System;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace bwaniaProject.Data.Exceptions
{
    public class SearchRequestException : Exception
    {
        public SearchRequestException()
        {
        }

        public SearchRequestException(IElasticsearchResponse connectionStatus)
            : base(connectionStatus.OriginalException.Message)
        {
            ConnectionStatus = connectionStatus;
        }

        public SearchRequestException(string message)
            : base(message)
        {
        }

        public SearchRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SearchRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public IElasticsearchResponse   ConnectionStatus  { get; set; }
    }
}
