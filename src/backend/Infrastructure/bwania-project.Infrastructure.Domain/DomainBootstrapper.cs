// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject;
using BwaniaProject.Domain.Engines;
using BwaniaProject.Domain.Validation;
using BwaniaProject.Domain.Validators;
using BwaniaProject.Entities;
using Catel;
using FluentValidation;
using LightInject;

namespace BwaniaProject.Domain
{
    public class DomainBootstrapper : BootstrapperBase
    {
        protected void RegisterValidationStuff(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IValidatorFactory, ValidatorFactory>();

            serviceRegistry.Register<IValidator<IDocument>, DocumentValidator>();
        }

        /// <summary>
        ///     Registers the engines.
        /// </summary>
        /// <param name="serviceRegistry"></param>
        protected void RegisterEngines(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDocumentEngine, DocumentEngine>();
            serviceRegistry.Register<IEngineProvider>(factory => new EngineProvider(factory));
        }

        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull("serviceRegistry", serviceRegistry);

            //RegisterValidationStuff(serviceRegistry);
            RegisterEngines(serviceRegistry);
        }
    }
}