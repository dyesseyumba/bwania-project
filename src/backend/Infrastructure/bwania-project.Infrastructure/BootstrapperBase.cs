// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BootstrapperBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using LightInject;

namespace bwaniaProject
{
    public abstract class BootstrapperBase : IBootstrapper
    {
        public abstract void Compose(IServiceRegistry serviceRegistry);

        public void Compose<TBootstrapper>(IServiceRegistry serviceRegistry) where TBootstrapper : IBootstrapper, new()
        {
            var bootstrapper = new TBootstrapper();
            bootstrapper.Compose(serviceRegistry);
        }
    }
}