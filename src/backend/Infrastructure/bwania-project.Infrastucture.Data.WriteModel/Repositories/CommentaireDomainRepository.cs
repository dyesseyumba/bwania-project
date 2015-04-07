// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommentaireDomainRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Entities;
using Couchbase;

namespace bwaniaProject.Data
{
    public class CommentaireDomainRepository : DomainRepositoryBase<Commentaire>, ICommentaireDomainRepository
    {
        public CommentaireDomainRepository()
            : base(ClusterHelper.GetBucket(BucketNames.CommentBucketName))
        {
        }
    }
}