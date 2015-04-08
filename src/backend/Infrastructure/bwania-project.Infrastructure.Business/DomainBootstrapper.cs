// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Catel;
using LightInject;

namespace BwaniaProject.Domain
{
    public class DomainBootstrapper
    {
        /// <summary>
        /// Initializes the specified service container.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        public virtual void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceContainer", serviceContainer);

        }

        /// <summary>
        /// Registers the engines.
        /// </summary>
        /// <param name="container">The container.</param>
        protected void RegisterEngines(IServiceContainer container)
        {
            
        } 
    }
}