// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BucketBootstrapper.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject;
using Catel;
using Couchbase;
using LightInject;
using Nest;

namespace bwaniaProject.Data.Buckets
{
    public class BucketBootstrapper : BootstrapperBase
    {
        public override void Compose(IServiceRegistry serviceRegistry)
        {
            Argument.IsNotNull("serviceRegistry", serviceRegistry);

            RegisterBuckets(serviceRegistry);
            RegisterElasticSearchIndex(serviceRegistry);
        }

        protected virtual void RegisterBuckets(IServiceRegistry serviceRegistry)
        {
            var cluster = new Cluster(Constants.ClusterConfig);

            var documentBucket = cluster.OpenBucket(Constants.DocumentBucketName);
            serviceRegistry.RegisterInstance<IDocumentBucket>(new DocumentBucket(documentBucket));
        }

        protected virtual void RegisterElasticSearchIndex(IServiceRegistry serviceRegistry)
        {
            var node = new Uri(Constants.ElasticSearchUri);
            var settings = new ConnectionSettings(node, Constants.ElasticDefaultIndex)
                .SetDefaultTypeNameInferrer(t => "couchbaseDocument");

            serviceRegistry.RegisterInstance<IElasticClient>(new ElasticClient(settings));
        }
    }
}