using System.Web.Http;
using bwaniaProject.DependencyResolution;
using bwaniaProject.WebApi;
using Catel.IoC;
using Catel.Logging;
using LightInject;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Serialization;
using Owin;
using Thinktecture.IdentityManager.Configuration;
using Thinktecture.IdentityManager.Host;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Host;

[assembly: OwinStartup(typeof(Startup))]

namespace bwaniaProject.WebApi
{
    public class Startup : ApiBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            LogManager.AddDebugListener();

            var customDatabase = new CustomDatabase("BwaniaIdServerDb");
            customDatabase.Database.CreateIfNotExists();
#endif

            var serviceLocator = new ServiceContainer();
            Initialize(serviceLocator);

            const string databaseConnectionName = "BwaniaIdServerDb";


            app.Map("/api/{controller}/{id}", builder =>
            {
                var httpConfiguration = new HttpConfiguration();

                UseJsonCamelCaseFormatter(httpConfiguration);

                ConfigureRouting(httpConfiguration);

                builder.UseCors(CorsOptions.AllowAll);

                builder.UseWebApi(httpConfiguration);
            });

            app.Map("/admin", builder =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.Configure(databaseConnectionName);

                builder.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });
            });

            app.Map("/identity", builder =>
            {
                var idSvrFactory = Factory.Configure();
                idSvrFactory.ConfigureCustomUserService(databaseConnectionName);

                var options = new IdentityServerOptions
                {
                    IssuerUri = "http://idsrv3.com/embedded",
                    SiteName = "Bwania IdentityServer",

                    //SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    CorsPolicy = CorsPolicy.AllowAll,
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        IdentityProviders = ConfigureAdditionalIdentityProviders,
                    },
                    RequireSsl = false
                };

                builder.UseIdentityServer(options);
            });

            app.UseWelcomePage();
        }

        public static void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var fb = new FacebookAuthenticationOptions
            {
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = signInAsType,
                AppId = "1414324985471775",
                AppSecret = "9d6ab75f921942e61fb43a9b1fc25c63"
            };
            app.UseFacebookAuthentication(fb);
        }

        private static void ConfigureRouting(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.MapHttpAttributeRoutes();
        }

        private static void UseJsonCamelCaseFormatter(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Formatters.Remove(httpConfiguration.Formatters.XmlFormatter);
            httpConfiguration.Formatters.Remove(httpConfiguration.Formatters.FormUrlEncodedFormatter);
            httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}