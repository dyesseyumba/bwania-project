using System;
using Anotar.Catel;
using BwaniaProject.Data;
using BwaniaProject.Data.Exceptions;
using Catel;
using Catel.ExceptionHandling;
using LightInject;

namespace BwaniaProject.Infrastructure.Data
{
    public class DataDomainBootstrapper
    {
        #region Methods

        /// <summary>
        ///     Initializes the specified service locator.
        /// </summary>
        /// <param name="serviceContainer">The service locator.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceContainer" /> is <c>null</c>.</exception>
        public virtual void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceContainer", serviceContainer);

            ConfigureExceptionPolicies(serviceContainer);

            RegisterRepositories(serviceContainer);
        }

        /// <summary>
        /// Configures the exception policies.
        /// </summary>
        /// <param name="serviceContainer">The service container.</param>
        protected virtual void ConfigureExceptionPolicies(IServiceContainer serviceContainer)
        {
            var exceptionService = serviceContainer.GetInstance<IExceptionService>();

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

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="container">The container.</param>
        protected void RegisterRepositories(IServiceContainer container)
        {
            container.Register<IDocumentDomainRepository, DocumentDomainRepository>();
        }

        #endregion
    }
}