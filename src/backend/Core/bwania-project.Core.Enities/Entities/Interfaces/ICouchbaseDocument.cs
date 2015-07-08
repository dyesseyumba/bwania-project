// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IElasticSearchIndex.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------
namespace BwaniaProject.Entities
{
    public interface ICouchbaseDocument
    {
        Meta Meta { get; set; }
    }

    public interface IMeta
    {
        string Id { get; set; }

        string Rev { get; set; }

        int Flags { get; set; }

        int Expiration { get; set; }
    }
}