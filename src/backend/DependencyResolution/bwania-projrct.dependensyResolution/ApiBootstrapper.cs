using Catel;
using Catel.IoC;

namespace bwaniaProject.DependencyResolution
{
    public class ApiBootstrapper : IServiceLocatorInitializer
    {
        #region Methods

        /// <summary>
        ///     Initializes the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="serviceLocator" /> is <c>null</c>.</exception>
        public virtual void Initialize(IServiceLocator serviceLocator)
        {
            Argument.IsNotNull("serviceLocator", serviceLocator);
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