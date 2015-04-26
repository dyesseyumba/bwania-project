// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomConfig.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace Thinktecture.IdentityManager.Host
{
    public class CustomConfig : MembershipRebootConfiguration<CustomUser>
    {
        public static readonly CustomConfig Config;

        static CustomConfig()
        {
            Config = new CustomConfig();
            Config.PasswordHashingIterationCount = 10000;
            Config.RequireAccountVerification = false;
            Config.EmailIsUsername = true;
        }
    }
}