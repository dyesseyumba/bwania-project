// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using BwaniaProject.Web.Api;
using CacheCow.Server;
using Catel.Logging;
using IdentityManager.Configuration;
using LightInject;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Serialization;
using Owin;
using Thinktecture.IdentityManager.Host;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Logging;
using Thinktecture.IdentityServer.Host;

[assembly: OwinStartup(typeof (Startup))]

namespace BwaniaProject.Web.Api
{
    public class Startup : ApiBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            LogManager.AddDebugListener();
            LogProvider.SetCurrentLogProvider(new TraceSourceLogProvider());

            var customDatabase = new CustomDatabase(Constants.DatabaseConnectionName);
            customDatabase.Database.CreateIfNotExists();
#endif

            this.RegisterApiControllers();

            const string databaseConnectionName = Constants.DatabaseConnectionName;

            app.Map("/" + Constants.CommonRoutingDefinitions.ApiSegmentName, builder =>
            {
                var httpConfiguration = new HttpConfiguration();

                UseJsonCamelCaseFormatter(httpConfiguration);
                ConfigureRouting(httpConfiguration);
                //ConfigureCaching(httpConfiguration);

                this.EnableWebApi(httpConfiguration); //Enabling Ioc on Web API

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

        private static void ConfigureCaching(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.MessageHandlers.Add(new CachingHandler(httpConfiguration, new InMemoryEntityTagStore()));
        }

        private static void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var facebookAuthenticationOptions = new FacebookAuthenticationOptions
            {
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = signInAsType,
                AppId = "1414324985471775",
                AppSecret = "9d6ab75f921942e61fb43a9b1fc25c63"
            };

            app.UseFacebookAuthentication(facebookAuthenticationOptions);
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