// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataDomainBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject;
using BwaniaProject.Data.Repositories;
using Catel;
using LightInject;

namespace BwaniaProject.Data
{
    public class DataDomainBootstrapper : BootstrapperBase
    {
        #region Methods

        /// <summary>
        ///     Registers the repositories.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        protected void RegisterRepositories(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDocumentDomainRepository, DocumentDomainRepository>();
        }

        #endregion

        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull(() => serviceRegistry);

            RegisterRepositories(serviceRegistry);
        }
    }
}