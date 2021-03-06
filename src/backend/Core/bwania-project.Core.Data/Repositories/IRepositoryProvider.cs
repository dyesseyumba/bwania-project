﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IRepositoryProvider.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject.Data.Repositories
{
    public interface IRepositoryProvider
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
    }
}