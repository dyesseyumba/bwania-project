﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EntityExtensions.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Entities;
using Couchbase;

namespace BwaniaProject.Data.Extensions
{
    public static class EntityExtensions
    {
        public static IDocument<T> Wrap<T>(this T entity) where T : IEntity
        {
            return new Document<T>
            {
                Id = entity.Id,
                Cas = entity.Cas,
                Content = entity
            };
        }

        public static T UnWrap<T>(this IDocument<T> document) where T : IEntity
        {
            var entity = document.Content;
            entity.Cas = document.Cas;
            entity.Id = document.Id;
            return entity;
        }
    }
}