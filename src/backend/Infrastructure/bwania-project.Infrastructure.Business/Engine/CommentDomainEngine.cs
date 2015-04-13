// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CommentEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using bwaniaProject.Data;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;
using FluentValidation;

namespace BwaniaProject.Domain.Engines
{
    public class CommentDomainEngine : DomainEngineBase<ICommentaire, ICommentaireDomainRepository>, ICommentDomainEngine
    {
        public CommentDomainEngine(ICommentaireDomainRepository repository, IExceptionService exceptionService, IValidatorFactory validatorFactory) 
            : base(repository, exceptionService, validatorFactory)
        {
        }
    }
}