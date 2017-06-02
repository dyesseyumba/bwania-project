// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data.Repositories;
using BwaniaProject.Data.Repositories;
using Catel;
using LightInject;

namespace bwaniaProject.Data
{
    public class DataBootstrapper : BootstrapperBase
    {
        protected virtual void RegisterDatabaseServices(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IRepositoryProvider>(factory => new RepositoryProvider(factory));
        }

        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull(() => serviceRegistry);

            RegisterDatabaseServices(serviceRegistry);
        }
    }
}