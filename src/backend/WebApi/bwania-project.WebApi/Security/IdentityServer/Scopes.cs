// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Scopes.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Host
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read data",
                    Type = ScopeType.Resource,
                    Emphasize = false
                },
                new Scope
                {
                    Name = "write",
                    DisplayName = "Write data",
                    Type = ScopeType.Resource,
                    Emphasize = true
                },
                new Scope
                {
                    Name = "forbidden",
                    DisplayName = "Forbidden scope",
                    Type = ScopeType.Resource,
                    Emphasize = true
                }
            };
        }
    }
}