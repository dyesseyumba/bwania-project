// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Certificate.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Security.Cryptography.X509Certificates;
using BwaniaProject.Web.Api.Properties;

namespace Thinktecture.IdentityServer.Host
{
    internal static class Certificate
    {
        public static X509Certificate2 Get()
        {
            var assembly = typeof (Certificate).Assembly;
            using (var stream = new MemoryStream(Resources.idsrv3test))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16*1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}