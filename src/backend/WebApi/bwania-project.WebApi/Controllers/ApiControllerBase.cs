// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApiControllerBase.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;

namespace BwaniaProject.WebApi.Controllers
{
    public class ApiControllerBase<TEngine> : ApiController where TEngine : class
    {
    }
}