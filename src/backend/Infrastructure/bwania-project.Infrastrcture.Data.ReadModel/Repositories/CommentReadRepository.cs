// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using bwaniaProject.Data.Exceptions;
using BwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public class CommentReadRepository : ReadRepositoryBase, ICommentReadRepository
    {
        #region Constructores

        public CommentReadRepository()
            : base(ElasticSearchIndexNames.CommentIndexName)
        {
        }

        #endregion

        public IEnumerable<Commentaire> GetTenDocument(int nbPage)
        {
            var results = Client.Search<Commentaire>(s => s
                .From(nbPage)
                .Size(10));

            if (results.IsValid) return results.Documents;

            throw new SearchRequestException(results.RequestInformation);
        }
    }
}