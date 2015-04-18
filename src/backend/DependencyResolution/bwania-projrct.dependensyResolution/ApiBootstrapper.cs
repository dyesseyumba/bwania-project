﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Data;
using BwaniaProject.Domain;
using BwaniaProject.Infrastructure.Data;
using Catel;
using Catel.ExceptionHandling;
using LightInject;

namespace BwaniaProject.DependencyResolution
{
    public class ApiBootstrapper
    {
        #region Fields

        private readonly DataDomainBootstrapper _dataDomainBootstrapper = new DataDomainBootstrapper();
        private readonly DataReadBootstrapper _dataReadBootstrapper = new DataReadBootstrapper();
        private readonly DomainWriteBootstrapper _domainWriteBootstrapper = new DomainWriteBootstrapper();

        #endregion

        #region Methods

        /// <summary>
        ///     Initializes the specified service container.
        /// </summary>
        /// <param name="serviceContainer"></param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceContainer" /> is <c>null</c>.</exception>
        public virtual void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceLocator", serviceContainer);

            serviceContainer.Register<IExceptionService, ExceptionService>();

            _dataDomainBootstrapper.Initialize(serviceContainer);
            _domainWriteBootstrapper.Initialize(serviceContainer);
            _dataReadBootstrapper.Initialize(serviceContainer);
        }

        #endregion
    }
}