// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Constants.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

namespace BwaniaProject
{
    public static class Constants
    {
        public const string DatabaseConnectionName = "BwaniaIdServerDb";

        public const string DocumentBucketName = "BwaniaDocument";

        public const string DocumentIndexName = "bwania-document";
    }

    public static class RouteNames
    {
        public const string RoutePrefix = "api";
        public const string IdSuffix = "{nbPage:int}";

        public static class Document
        {
            public const string GetTen = "gettendocuments/" + IdSuffix;
        }
    }
}