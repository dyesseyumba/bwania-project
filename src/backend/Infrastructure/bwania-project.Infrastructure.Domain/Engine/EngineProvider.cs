// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EngineProvider.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using Catel;
using LightInject;

namespace BwaniaProject.Domain.Engines
{
    public class EngineProvider : IEngineProvider
    {
        private readonly IServiceFactory _factory;

        public EngineProvider(IServiceFactory factory)
        {
            Argument.IsNotNull(() => factory);

            _factory = factory;
        }

        public TEngine GetEngine<TEngine>() where TEngine : IEngine
        {
            return _factory.GetInstance<TEngine>();
        }
    }
}