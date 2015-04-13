// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Data;
using BwaniaProject.Domain;

namespace BwaniaProject.Domain.Engine
{
    public class ReadEngine<TRepository> : IReadEngine<TRepository> 
        where TRepository : IReadRepository
    {
        #region Constructors

        public ReadEngine(TRepository repository)
        {
            Repository = repository;
        }

        #endregion

        #region Properties
        public TRepository Repository{ get; set; }

        #endregion
    }
}