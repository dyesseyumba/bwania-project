// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SearchRequestException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using bwaniaProject.Data;
using Elasticsearch.Net;

namespace BwaniaProject.Data.Exceptions
{
    public class SearchRequestException : DataException
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

        public IElasticsearchResponse ConnectionStatus { get; set; }
    }
}