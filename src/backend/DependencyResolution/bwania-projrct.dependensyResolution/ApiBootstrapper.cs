using bwaniaProject.Data;
using bwaniaProject.Infrastructure.Data;
using BwaniaProject.Domain;
using Catel;
using Catel.ExceptionHandling;
using Catel.IoC;
using LightInject;

namespace bwaniaProject.DependencyResolution
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
            _dataReadBootstrapper.Initialize(serviceContainer);
            _domainWriteBootstrapper.Initialize(serviceContainer);
        }

        #endregion
    }
}