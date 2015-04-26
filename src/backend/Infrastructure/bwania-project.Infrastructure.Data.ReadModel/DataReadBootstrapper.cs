// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataReadBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject;
using BwaniaProject.Data.Repositories;
using Catel;
using LightInject;

namespace BwaniaProject.Data
{
    public class DataReadBootstrapper : BootstrapperBase
    {
        #region Methods

        protected void RegisterRepositories(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDocumentReadRepository, DocumentReadRepository>();
        }

        #endregion

        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull(() => serviceRegistry);

            RegisterRepositories(serviceRegistry);
        }
    }
}