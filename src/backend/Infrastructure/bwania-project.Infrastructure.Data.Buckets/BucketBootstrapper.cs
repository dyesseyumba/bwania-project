// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BucketBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject;
using Catel;
using Couchbase;
using LightInject;

namespace bwaniaProject.Data.Buckets
{
    public class BucketBootstrapper : BootstrapperBase
    {
        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull("serviceRegistry", serviceRegistry);

            RegisterBuckets(serviceRegistry);
        }

        protected virtual void RegisterBuckets(IServiceRegistry serviceRegistry)
        {
            var cluster = new Cluster(Constants.ClusterConfig);

            var documentBucket = cluster.OpenBucket(Constants.DocumentBucketName);
            serviceRegistry.RegisterInstance<IDocumentBucket>(new DocumentBucket(documentBucket));
        }
    }
}