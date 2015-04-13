// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TaskExt.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace bwaniaProject.Data.Test
{
    public static class TaskExt
    {
        public static async void ShouldThrow<TException>(this Task task) where TException : Exception
        {
            Func<Task> func = () => task;
            func.ShouldThrow<TException>();
        } 
    }
}