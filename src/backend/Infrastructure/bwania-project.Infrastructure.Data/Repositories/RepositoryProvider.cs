// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RepositoryProvider.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Data.Repositories;
using Catel;
using LightInject;

namespace bwaniaProject.Data.Repositories
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IServiceFactory _factory;

        public RepositoryProvider(IServiceFactory factory)
        {
            Argument.IsNotNull(() => factory);

            _factory = factory;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return _factory.GetInstance<TRepository>();
        }
    }
}