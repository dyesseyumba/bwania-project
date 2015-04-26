// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CoreExceptions.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace bwaniaProject.Exceptions
{
    /// <summary>
    /// </summary>
    public class ExceptionBase : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        protected ExceptionBase()
        {
            // Add implementation (if required)
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected ExceptionBase(string message)
            : base(message)
        {
            // Add implementation (if required)
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        protected ExceptionBase(string message, Exception inner)
            : base(message, inner)
        {
            // Add implementation (if required)
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected ExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }
    }
}