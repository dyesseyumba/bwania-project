// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Constants.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------


using System.Configuration;

namespace BwaniaProject
{
    public static class Constants
    {
#if DATA || WEBAPI
        public const string DatabaseConnectionName = "BwaniaIdServerDb";
#endif
#if DATA
        public const string DocumentIndexName = "bwania-document";
        public const string DesignDocumentNameGet10Doc = "dev_document";
        public const string ViewNameGet10Doc = "document.get10";
#endif

        public static string DocumentBucketName = ConfigurationManager.AppSettings.Get("DocumentBucketName");
        public const string ClusterConfig = "couchbaseClients/couchbase";

#if WEBAPI
        public static class MediaTypeNames
        {
            public const string AplicationJson = "application/json";
            public const string AplicationXml = "application/xml";
            public const string TextJson = "text/json";
            public const string TextXml = "text/xml";
        }

        public static class CommonRoutingDefinitions
        {
            public const string ApiSegmentName = "api";
        }

        public static class RouteNames
        {
            public const string IdSuffix = "{nbPage:int}";

            public static class Document
            {
                public const string GetTen = "documents/" + IdSuffix;
                public const string Insert = "document/create";
                public const string Update = "document/edit";
                public const string Delete = "document/delete";
                public const string Upload = "document/upload";
            }
        }
#endif
    }
}