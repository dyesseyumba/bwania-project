// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ElasticSearchIndex.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject.Entities
{
    public class ElasticSearchIndex : IElasticSearchIndex
    {
        public Meta Meta { get; set; }
    }

    public class Meta : IMeta
    {
        public string Id { get; set; }

        public string Rev { get; set; }

        public int Flags { get; set; }

        public int Expiration { get; set; }
    }
}