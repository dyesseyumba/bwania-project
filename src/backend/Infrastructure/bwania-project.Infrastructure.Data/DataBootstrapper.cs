using System;
using System.Data.SqlClient;
using Anotar.Catel;
using bwaniaProject.Infrastructure.Data.Exceptions;
using Catel;
using Catel.ExceptionHandling;
using Catel.IoC;
using LightInject;

namespace bwaniaProject.Infrastructure.Data
{
    public class DataBootstrapper
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

            ConfigureDatabaseInstance(serviceContainer);

            RegisterRepositories(serviceContainer);
        }

        protected void ConfigureExceptionPolicies(IServiceContainer serviceLocator)
        {
            var exceptionService = this.GetDependencyResolver().Resolve<IExceptionService>();

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

        protected void ConfigureDatabaseInstance(IServiceContainer serviceLocator)
        {
            
        }

        protected void RegisterRepositories(IServiceContainer serviceLocator)
        {
            
        }

        #endregion
    }
}