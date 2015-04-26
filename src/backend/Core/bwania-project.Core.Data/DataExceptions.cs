// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataExceptions.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using bwaniaProject.Exceptions;

namespace bwaniaProject.Data
{
    /// <summary>
    /// </summary>
    public class DataException : ExceptionBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DataException" /> class.
        /// </summary>
        public DataException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DataException(string message)
            : base(message)
        {
        }

        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected DataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}