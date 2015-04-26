// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomDatabase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

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