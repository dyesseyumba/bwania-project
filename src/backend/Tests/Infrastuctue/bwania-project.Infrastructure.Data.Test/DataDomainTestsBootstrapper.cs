// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DataDomainTestsBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using bwaniaProject.Data.Extensions;
using bwaniaProject.Infrastructure.Data;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;
using Couchbase.Core;
using LightInject;
using Moq;

namespace bwaniaProject.Data.Test
{
    public class DataDomainTestsBootstrapper : DataDomainBootstrapper, ICompositionRoot
    {
        #region Fields

        //private static readonly object Lock = new object();

        #endregion

        #region Methods

        public void Compose(IServiceRegistry container)
        {
            ConfigureExceptionPolicies(container);
            MockBucket(container);
            RegisterRepositories(container);
        }

        //public override void Initialize(IServiceContainer serviceContainer)
        //{
        //    ConfigureExceptionPolicies(serviceContainer);
        //    MockBucket(serviceContainer);
        //}

        protected void ConfigureExceptionPolicies(IServiceRegistry serviceRegistry)
        {
            var mockedExceptionService = new Mock<IExceptionService>();

            mockedExceptionService.Setup(exceptionService => exceptionService.Process(It.IsAny<Action>()))
                .Callback((Action action) => action());

            var exceptionServiceInstance = mockedExceptionService.Object;

            serviceRegistry.RegisterInstance(exceptionServiceInstance);
        }

        protected void RegisterRepositories(IServiceRegistry container)
        {
            container.Register<IDocumentDomainRepository, DocumentDomainRepository>();
            container.Register<ICommentaireDomainRepository, CommentaireDomainRepository>();
        }

        private void MockBucket(IServiceRegistry serviceRegistry)
        {
            var mockedBucket = new Mock<IBucket>();

            mockedBucket.Setup(bucket => bucket.Upsert(It.IsAny<IEntity>().Wrap()).Success)
                .Returns(true);

            mockedBucket.Setup(bucket => bucket.Remove(It.IsAny<IEntity>().Wrap()).Success)
                .Returns(true);

            serviceRegistry.RegisterInstance(mockedBucket);
        }

        #endregion
    }
}