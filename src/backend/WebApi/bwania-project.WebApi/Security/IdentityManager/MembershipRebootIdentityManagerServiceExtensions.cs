// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MembershipRebootIdentityManagerServiceExtensions.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace Thinktecture.IdentityManager.Host
{
    public static class MembershipRebootIdentityManagerServiceExtensions
    {
        public static void Configure(this IdentityManagerServiceFactory factory, string connectionString)
        {
            factory.IdentityManagerService = new Registration<IIdentityManagerService, CustomIdentityManagerService>();
            factory.Register(new Registration<CustomUserAccountService>());
            factory.Register(new Registration<CustomGroupService>());
            factory.Register(new Registration<CustomUserRepository>());
            factory.Register(new Registration<CustomGroupRepository>());
            factory.Register(new Registration<CustomDatabase>(resolver => new CustomDatabase(connectionString)));
            factory.Register(new Registration<CustomConfig>(CustomConfig.Config));
        }
    }
}