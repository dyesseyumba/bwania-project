using System;
using System.Data.SqlClient;
using Anotar.Catel;
using bwaniaProject.Infrastructure.Data.Exceptions;
using Catel;
using Catel.ExceptionHandling;
using Catel.IoC;

namespace bwaniaProject.Infrastructure.Data
{
    public class DataBootstrapper : IServiceLocatorInitializer
    {
        #region Methods

        /// <summary>
        ///     Initializes the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceLocator" /> is <c>null</c>.</exception>
        public void Initialize(IServiceLocator serviceLocator)
        {
            Argument.IsNotNull("serviceLocator", serviceLocator);

            ConfigureExceptionPolicies(serviceLocator);

            ConfigureDatabaseInstance(serviceLocator);

            RegisterRepositories(serviceLocator);
        }

        protected void ConfigureExceptionPolicies(IServiceLocator serviceLocator)
        {
            var exceptionService = serviceLocator.ResolveType<IExceptionService>();

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

        protected void ConfigureDatabaseInstance(IServiceLocator serviceLocator)
        {
            
        }

        protected void RegisterRepositories(IServiceLocator serviceLocator)
        {
            
        }

        #endregion
    }
}