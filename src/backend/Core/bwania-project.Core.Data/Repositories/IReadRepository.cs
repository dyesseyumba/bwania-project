// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Entities;

namespace BwaniaProject.Data.Repositories
{
    public interface IReadRepository<T> : IRepository where T : IEntity
    {
        /// <summary>
        /// Gets the one by identifier asynchronous.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string entityId);
    }
}