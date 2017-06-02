// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentBucket.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data.Buckets.Interfaces;
using Catel;
using Couchbase.Core;

namespace bwaniaProject.Data.Buckets
{
    public class DocumentBucket : IDocumentBucket
    {
        public DocumentBucket(IBucket bucket)
        {
            Argument.IsNotNull(() => bucket);

            Default = bucket;
        }

        public IBucket Default { get; private set; } 
    }
}