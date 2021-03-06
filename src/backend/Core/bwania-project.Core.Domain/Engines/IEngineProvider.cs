﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEngineProvider.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject.Domain.Engines
{
    public interface IEngineProvider
    {
        TEngine GetEngine<TEngine>() where TEngine : IEngine;
    }
}