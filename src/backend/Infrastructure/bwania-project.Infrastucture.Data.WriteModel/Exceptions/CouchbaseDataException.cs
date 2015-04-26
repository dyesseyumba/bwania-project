// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CouchbaseDataException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using bwaniaProject.Data;
using Couchbase;
using Couchbase.IO;

namespace BwaniaProject.Data.Exceptions
{
    public class CouchbaseDataException : DataException
    {
        public CouchbaseDataException()
        {
        }

        public CouchbaseDataException(IOperationResult result)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
        }

        public CouchbaseDataException(IDocumentResult result)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
        }

        public CouchbaseDataException(IOperationResult result, string key)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
            Key = key;
        }

        public CouchbaseDataException(IDocumentResult result, string key)
            : this(result.Message, result.Exception)
        {
            Status = result.Status;
            Key = key;
        }

        public CouchbaseDataException(string message)
            : base(message)
        {
        }

        public CouchbaseDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ResponseStatus Status { get; set; }
        public string Key { get; set; }
    }
}