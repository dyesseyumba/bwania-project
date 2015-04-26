// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.DependencyResolution;
using BwaniaProject.WebApi;
using Thinktecture.IdentityManager.Host;
using Thinktecture.IdentityServer.Host;

[assembly: OwinStartup(typeof (Startup))]

namespace BwaniaProject.WebApi
{
    public class Startup : ApiBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            LogManager.AddDebugListener();

            var customDatabase = new CustomDatabase(Constants.DatabaseConnectionName);
            customDatabase.Database.CreateIfNotExists();
#endif

            var serviceContainer = new ServiceContainer();
            serviceContainer.RegisterApiControllers();
            Initialize(serviceContainer);

            const string databaseConnectionName = Constants.DatabaseConnectionName;


            app.Map("/" + RouteNames.RoutePrefix, builder =>
            {
                var httpConfiguration = new HttpConfiguration();

                UseJsonCamelCaseFormatter(httpConfiguration);

                serviceContainer.EnableWebApi(httpConfiguration); //Enabling Ioc on Web API

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
                        IdentityProviders = ConfigureAdditionalIdentityProviders
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