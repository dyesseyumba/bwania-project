// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomUser.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot.Relational;

namespace Thinktecture.IdentityManager.Host
{
    public class CustomUser : RelationalUserAccount
    {
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        public virtual int? Age { get; set; }
    }

    public class CustomUserAccountService : UserAccountService<CustomUser>
    {
        public CustomUserAccountService(CustomConfig config, CustomUserRepository repo)
            : base(config, repo)
        {
        }
    }

    public class CustomUserRepository : DbContextUserAccountRepository<CustomDatabase, CustomUser>
    {
        public CustomUserRepository(CustomDatabase ctx)
            : base(ctx)
        {
        }
    }
}