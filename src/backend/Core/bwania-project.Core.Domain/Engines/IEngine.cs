// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Entities;

namespace BwaniaProject.Domain.Engines
{
    public interface IEngine
    {
    }

    public interface IEngine<in TEntity> : IEngine
        where TEntity : IEntity
    {
        /// <summary>
        ///     Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> SaveAsync(TEntity entity);

        /// <summary>
        ///     Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(TEntity entity);
    }
}