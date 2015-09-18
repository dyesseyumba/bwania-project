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
        public const string DesignDocumentNameGet10Doc = "document";
        public const string ViewNameGet10Doc = "document.get10";
#endif

        public static string DocumentBucketName = ConfigurationManager.AppSettings.Get("DocumentBucketName");
        public static string ElasticSearchUri = ConfigurationManager.AppSettings.Get("ElasticSearchUri");
        public static string ElasticDefaultIndex = ConfigurationManager.AppSettings.Get("ElasticDefaultIndex");
        public const string ClusterConfig = "couchbaseClients/couchbase";

#if WEBAPI
        public static class MediaTypeNames
        {
            public const string ApplicationJson = "application/json";
            public const string ApplicationXml = "application/xml";
            public const string TextJson = "text/json";
            public const string TextXml = "text/xml";
            public const string ApplicationOctetStram = "application/octet-stream";
        }

        public static class CommonRoutingDefinitions
        {
            public const string ApiSegmentName = "api";
        }

        public static class RouteNames
        {
            public const string NbPageSuffix = "{nbPage:int}";
            public const string IdSuffix = "{id:int}";

            public static class Document
            {
                public const string GetTen = "documents/get_all/" + NbPageSuffix;
                public const string GetFiltered1St = "documents/get_by_1st_filter/" + NbPageSuffix;
                public const string Insert = "document/create";
                public const string Update = "document/edit/" + IdSuffix;
                public const string InsertComment = "document/edit/comment/" + IdSuffix;
                public const string Delete = "document/delete";
                public const string Upload = "document/upload";
                public const string GetById = "document/" + IdSuffix;
                public const string GetFileById = "document/download/" + IdSuffix + "/file";
                public const string CountTotalDoc = "documents/count_all";
                public const string CountTotalFilteredDoc = "documents/count_all_filtered/" + NbPageSuffix;
                public const string GetSearchedDocumentByTitle = "documents/get_by_title/" + NbPageSuffix +
                    "/{title}";
                public const string GetSearchedFilterdDocumentByTitle = "documents/get_filtered_by_title/" + 
                    NbPageSuffix + "/{title}";
            }
        }
#endif
    }
}