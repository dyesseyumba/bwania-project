// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using LightInject;

namespace bwaniaProject
{
    public interface IBootstrapper : ICompositionRoot
    {
        void Compose<TBootstrapper>(IServiceRegistry serviceRegistry) where TBootstrapper : IBootstrapper, new();
    }
}