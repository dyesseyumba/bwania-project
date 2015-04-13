﻿using System;
using System.Runtime.Serialization;
using Couchbase.N1QL;

namespace BwaniaProject.Data.Exceptions
{
    public class QueryRequestException : Exception
    {
        public QueryRequestException()
        {
        }

        public QueryRequestException(string message,  QueryStatus queryStatus)
            : base(message)
        {
            QueryStatus = queryStatus;
        }

        public QueryRequestException(string message)
            : base(message)
        {
        }

        public QueryRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected QueryRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public QueryStatus QueryStatus { get; set; }
    }
}
