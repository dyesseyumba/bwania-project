﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainRepositoryBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Data.Extensions;
using BwaniaProject.Entities;
using Catel;
using Couchbase.Core;

namespace BwaniaProject.Data.Repositories
{
    public class DomainRepositoryBase<T> : IDomainRepository<T> where T : IEntity
    {
        #region Constructors

        public DomainRepositoryBase(IBucket bucket)
        {
            Bucket = bucket;
        }

        #endregion

        #region Properties

        protected IBucket Bucket { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entity" /> is <c>null</c>.</exception>
        public async Task<bool> SaveAsync(T entity)
        {
            Argument.IsNotNull("entity", entity);

            var result = await Task.Run(() => Bucket.Upsert(entity.Wrap())).ConfigureAwait(false);
            result.ThrowIfNotSuccess();

            return result.Success;
        }

        /// <summary>
        ///     Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entity" /> is <c>null</c>.</exception>
        public async Task<bool> RemoveAsync(T entity)
        {
            Argument.IsNotNull("entity", entity);

            var result = await Task.Run(() => Bucket.Remove(entity.Wrap())).ConfigureAwait(false);
            result.ThrowIfNotSuccess(entity.Id);

            return result.Success;
        }

        #endregion
    }
}