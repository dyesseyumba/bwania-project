// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using BwaniaProject.Data;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;
using FluentValidation;

namespace BwaniaProject.Domain.Engines
{
    public class DocumentDomainEngine : DomainEngineBase<IDocument, IDocumentDomainRepository>, IDocumentDomainEngine
    {
        public DocumentDomainEngine(IDocumentDomainRepository repository, IExceptionService exceptionService, 
            IValidatorFactory validatorFactory)
            : base(repository, exceptionService, validatorFactory)
        {
        }
    }
}