// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentEngine.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using BwaniaProject.Data.Repositories;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;

namespace BwaniaProject.Domain.Engines
{
    public class DocumentEngine : EngineBase<IDocument>, IDocumentEngine
    {
        private readonly IDocumentDomainRepository _documentDomainRepository;

        public DocumentEngine(IRepositoryProvider repositoryProvider, IExceptionService exceptionService)
            : base(exceptionService)
        {
            Argument.IsNotNull(() => repositoryProvider);

            _documentDomainRepository = repositoryProvider.GetRepository<IDocumentDomainRepository>();
        }

        public override Task<bool> SaveAsync(IDocument document)
        {
            Argument.IsNotNull("document", document);

            return _documentDomainRepository.SaveAsync(document);
        }

        public override Task<bool> RemoveAsync(IDocument document)
        {
            Argument.IsNotNull("document", document);

            return _documentDomainRepository.RemoveAsync(document);
        }
    }
}