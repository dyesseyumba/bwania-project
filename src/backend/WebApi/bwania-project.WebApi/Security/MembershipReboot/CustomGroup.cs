// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomGroup.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace Thinktecture.IdentityManager.Host
{
    public class CustomGroup : RelationalGroup
    {
        public virtual string Description { get; set; }
    }

    public class CustomGroupService : GroupService<CustomGroup>
    {
        public CustomGroupService(CustomGroupRepository repo, CustomConfig config)
            : base(config.DefaultTenant, repo)
        {
        }
    }

    public class CustomGroupRepository : DbContextGroupRepository<CustomDatabase, CustomGroup>
    {
        public CustomGroupRepository(CustomDatabase ctx)
            : base(ctx)
        {
        }
    }
}