// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CouchbaseAuthenticationException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Couchbase;

namespace BwaniaProject.Data.Exceptions
{
    public class CouchbaseAuthenticationException : CouchbaseDataException
    {
        public CouchbaseAuthenticationException()
        {
        }

        public CouchbaseAuthenticationException(string message)
            : base(message)
        {
        }

        public CouchbaseAuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CouchbaseAuthenticationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CouchbaseAuthenticationException(IOperationResult result)
            : base(result)
        {
        }

        public CouchbaseAuthenticationException(IDocumentResult result)
            : base(result)
        {
        }
    }
}