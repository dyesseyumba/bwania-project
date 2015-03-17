using bwania_project.WebApi;
using Catel.Logging;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Host;

[assembly: OwinStartup(typeof (Startup))]

namespace bwania_project.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            LogManager.AddDebugListener();
#endif
            const string databaseConnectionName = "BwaniaIdServerDb";

            app.Map("/identity", builder =>
            {
                var idSvrFactory = Factory.Configure();
                idSvrFactory.ConfigureCustomUserService(databaseConnectionName);

                var options = new IdentityServerOptions
                {
                    IssuerUri = "https://idsrv3/embedded",
                    SiteName = "Bwania IdentityServer",

                    //SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    CorsPolicy = CorsPolicy.AllowAll
                };

                builder.UseIdentityServer(options);
            });
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
    }
}