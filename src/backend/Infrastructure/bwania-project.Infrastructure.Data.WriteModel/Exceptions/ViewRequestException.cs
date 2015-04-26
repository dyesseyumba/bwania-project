// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ViewRequestException.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Runtime.Serialization;
using bwaniaProject.Data;

namespace BwaniaProject.Data.Exceptions
{
    public class ViewRequestException : DataException
    {
        public ViewRequestException()
        {
        }

        public ViewRequestException(string message)
            : base(message)
        {
        }

        public ViewRequestException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public ViewRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ViewRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}