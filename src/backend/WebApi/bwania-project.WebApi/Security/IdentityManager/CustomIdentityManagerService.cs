// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomIdentityManagerService.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using IdentityManager.MembershipReboot;

namespace Thinktecture.IdentityManager.Host
{
    public class CustomIdentityManagerService : MembershipRebootIdentityManagerService<CustomUser, CustomGroup>
    {
        public CustomIdentityManagerService(CustomUserAccountService userSvc, CustomGroupService groupSvc)
            : base(userSvc, groupSvc)
        {
        }
    }
}