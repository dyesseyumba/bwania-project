// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CouchbaseServerException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Couchbase;

namespace BwaniaProject.Data.Exceptions
{
    public class CouchbaseServerException : CouchbaseDataException
    {
        public CouchbaseServerException()
        {
        }

        public CouchbaseServerException(string message)
            : base(message)
        {
        }

        public CouchbaseServerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CouchbaseServerException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public CouchbaseServerException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}