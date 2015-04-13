// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using BwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface ICommentReadRepository
    {
        IEnumerable<Commentaire> GetTenDocument(int nbPage);
    }
}