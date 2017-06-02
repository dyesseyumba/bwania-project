// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SharedBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using Catel;
using Catel.ExceptionHandling;
using LightInject;

namespace bwaniaProject
{
    public class SharedBootstrapper : BootstrapperBase
    {
        protected virtual void RegisterServices(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull(() => serviceRegistry);

            serviceRegistry.RegisterInstance(ExceptionService.Default);
        }

        public override void Compose(IServiceRegistry serviceRegistry)
        {
            RegisterServices(serviceRegistry);
        }
    }
}