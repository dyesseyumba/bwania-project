using Thinktecture.IdentityManager.MembershipReboot;

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