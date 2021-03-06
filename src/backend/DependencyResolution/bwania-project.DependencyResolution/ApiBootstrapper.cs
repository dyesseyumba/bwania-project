﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using Anotar.Catel;
using bwaniaProject;
using bwaniaProject.Data;
using bwaniaProject.Data.Buckets;
using BwaniaProject.Data;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Domain;
using Catel.ExceptionHandling;
using LightInject;

namespace BwaniaProject
{
    public class ApiBootstrapper : ServiceContainer
    {
        public ApiBootstrapper()
        {
            RegisterFrom<SharedBootstrapper>();
            RegisterFrom<BucketBootstrapper>();
            RegisterFrom<DataBootstrapper>();
            RegisterFrom<DataReadBootstrapper>();
            RegisterFrom<DataDomainBootstrapper>();
            RegisterFrom<DomainBootstrapper>();

            ConfigureExceptionPolicies();
        }

        #region Methods

        protected void ConfigureExceptionPolicies()
        {
            var exceptionService = GetInstance<IExceptionService>();

            ConfigureDataExceptionPolicies(exceptionService);
        }

        private static void ConfigureDataExceptionPolicies(IExceptionService exceptionService)
        {
            exceptionService.Register<SearchRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });

            exceptionService.Register<CouchbaseDataException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });

            exceptionService.Register<ViewRequestException>(exception =>
            {
                LogTo.Error(exception.Message);
                throw new Exception(
                    "Une erreur est survenue dans la couche d'accès aux données. Si le problème persiste, contactez l'administrateur.",
                    exception);
            });
        }

        #endregion
    }
}