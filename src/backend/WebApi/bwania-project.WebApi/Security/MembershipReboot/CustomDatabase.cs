using BrockAllen.MembershipReboot.Ef;

namespace Thinktecture.IdentityManager.Host
{
    public class CustomDatabase : MembershipRebootDbContext<CustomUser, CustomGroup>
    {
        public CustomDatabase(string name)
            : base(name)
        {
        }
    }
}