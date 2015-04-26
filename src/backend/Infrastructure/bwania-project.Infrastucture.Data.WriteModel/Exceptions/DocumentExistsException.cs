// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentExistsException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Couchbase;

namespace BwaniaProject.Data.Exceptions
{
    public class DocumentExistsException : CouchbaseDataException
    {
        public DocumentExistsException()
        {
        }

        public DocumentExistsException(string message)
            : base(message)
        {
        }

        public DocumentExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DocumentExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public DocumentExistsException(IOperationResult result, string key)
            : base(result, key)
        {
        }

        public DocumentExistsException(IDocumentResult result, string key)
            : base(result, key)
        {
        }
    }
}