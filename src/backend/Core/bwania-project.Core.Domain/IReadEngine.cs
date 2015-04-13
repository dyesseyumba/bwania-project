// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IReadEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Data;

namespace BwaniaProject.Domain
{
    public interface IReadEngine<TRepository>   where TRepository : IReadRepository
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        TRepository Repository { get; set; }
    }
}