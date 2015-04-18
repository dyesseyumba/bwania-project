// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Domain.Engines;
using BwaniaProject.Domain.Validation;
using BwaniaProject.Domain.Validators;
using BwaniaProject.Entities;
using Catel;
using FluentValidation;
using LightInject;

namespace BwaniaProject.Domain
{
    public class DomainWriteBootstrapper
    {
        /// <summary>
        /// Initializes the specified service container.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        public virtual void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceContainer", serviceContainer);

            //RegisterValidationStuff(serviceContainer);
            RegisterEngines(serviceContainer);
        }

        protected void RegisterValidationStuff(IServiceContainer container)
        {
            container.Register<IValidatorFactory, ValidatorFactory>();

            container.Register<IValidator<IDocument>, DocumentValidator>();
        }

        /// <summary>
        /// Registers the engines.
        /// </summary>
        /// <param name="container">The container.</param>
        protected void RegisterEngines(IServiceContainer container)
        {
            container.Register<IDocumentDomainEngine, DocumentDomainEngine>();
        } 
    }
}