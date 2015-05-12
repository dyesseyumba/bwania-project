// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDocumentBucket.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using Couchbase.Core;

namespace bwaniaProject.Data.Buckets.Interfaces
{
    public interface IDocumentBucket
    {
        IBucket Default { get; } 
    }
}