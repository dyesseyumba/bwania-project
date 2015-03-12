using Thinktecture.IdentityManager.Host;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Services;
using Thinktecture.IdentityServer.MembershipReboot;

namespace Thinktecture.IdentityServer.Host
{
    public static class CustomUserServiceExtensions
    {
        public static void ConfigureCustomUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, CustomUserService>();
            factory.Register(new Registration<CustomUserAccountService>());
            factory.Register(new Registration<CustomConfig>(CustomConfig.Config));
            factory.Register(new Registration<CustomUserRepository>());
            factory.Register(new Registration<CustomDatabase>(resolver => new CustomDatabase(connString)));
        }
    }

    public class CustomUserService : MembershipRebootUserService<CustomUser>
    {
        public CustomUserService(CustomUserAccountService userSvc)
            : base(userSvc)
        {
        }
    }
}
