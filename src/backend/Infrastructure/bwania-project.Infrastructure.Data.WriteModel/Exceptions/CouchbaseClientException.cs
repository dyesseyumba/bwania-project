// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CouchbaseClientException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Couchbase;

namespace BwaniaProject.Data.Exceptions
{
    public class CouchbaseClientException : CouchbaseDataException
    {
        public CouchbaseClientException()
        {
        }

        public CouchbaseClientException(string message)
            : base(message)
        {
        }

        public CouchbaseClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CouchbaseClientException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public CouchbaseClientException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}