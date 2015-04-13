// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Data;
using BwaniaProject.Entities;

namespace BwaniaProject.Domain.Engines
{
    public interface IDomainEngine<in TEntity, TRepository> 
        where TEntity : IEntity
        where TRepository : IDomainRepository<TEntity>
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> SaveAsync(TEntity entity);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(TEntity entity);
    }
}