﻿using System.Threading.Tasks;
using BwaniaProject.Entities;

namespace BwaniaProject.Data
{
    public interface IDomainRepository<in T> where T : IEntity
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> SaveAsync(T entity);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(T entity);
    }
}