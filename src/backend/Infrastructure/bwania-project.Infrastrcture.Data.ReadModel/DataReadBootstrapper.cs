using System;
using Anotar.Catel;
using bwaniaProject.Data.Exceptions;
using Catel;
using Catel.ExceptionHandling;
using LightInject;

namespace bwaniaProject.Data
{
    public class DataReadBootstrapper
    {
        #region Methods

        /// <summary>
        ///     Initializes the specified service locator.
        /// </summary>
        /// <param name="serviceContainer">The service locator.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceContainer" /> is <c>null</c>.</exception>
        public void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceContainer", serviceContainer);

            ConfigureExceptionPolicies(serviceContainer);

            RegisterRepositories(serviceContainer);
        }

        protected void ConfigureExceptionPolicies(IServiceContainer serviceContainer)
        {
            var exceptionService = serviceContainer.GetInstance<IExceptionService>();

            exceptionService.Register<SearchRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });
        }

        protected void RegisterRepositories(IServiceContainer container)
        {
            container.Register<IDocumentReadRepository, DocumentReadRepository>();
        }

        #endregion 
    }
}