// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using BwaniaProject.Data;
using BwaniaProject.Data.Exceptions;

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

        protected void ConfigureExceptionPolicies(IServiceContainer serviceContainer)
        {
            var exceptionService = serviceContainer.GetInstance<IExceptionService>();

            ConfigureDataExceptionPolicies(exceptionService);
        }

        private static void ConfigureDataExceptionPolicies(IExceptionService exceptionService)
        {
            exceptionService.Register<SearchRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });

            exceptionService.Register<CouchbaseDataException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });

            exceptionService.Register<QueryRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans lors de la requète. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });

            exceptionService.Register<ViewRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });
        }

        #endregion
    }
}