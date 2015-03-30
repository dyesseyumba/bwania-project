using Catel;
using Catel.ExceptionHandling;
using Catel.IoC;
using LightInject;

namespace bwaniaProject.DependencyResolution
{
    public class ApiBootstrapper
    {
        #region Methods

        /// <summary>
        ///     Initializes the specified service locator.
        /// </summary>
        /// <param name="serviceContainer"></param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceContainer" /> is <c>null</c>.</exception>
        public virtual void Initialize(IServiceContainer serviceContainer)
        {
            Argument.IsNotNull("serviceLocator", serviceContainer);

            serviceContainer.Register<IExceptionService, ExceptionService>();

            //TODO: call your others bootstrappers here
        }

        /// <summary>
        /// Initializes the specified service locator.
        /// </summary>
        /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
        /// <param name="serviceLocator">The service locator.</param>
        protected virtual void Initialize<TBootstrapper>(IServiceLocator serviceLocator)
            where TBootstrapper : IServiceLocatorInitializer, new()
        {
            var bootstrapper = new TBootstrapper();

            bootstrapper.Initialize(serviceLocator);
        }

        #endregion
    }
}