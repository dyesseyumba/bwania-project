// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentCountRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Domain.Entities.Common;
using BwaniaProject.Entities;
using Catel.ExceptionHandling;
using Nest;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentCountRepository : ReadRepositoryBase<IDocument>, IDocumentCountRepository
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentCountRepository" /> class.
        /// </summary>
        /// <param name="bucket">the couchbase Bucket.</param>
        /// <param name="elasticClient">The elastic search client</param>
        /// <param name="exceptionService">The exception service</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="bucket" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="elasticClient" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public DocumentCountRepository(IDocumentBucket bucket, IElasticClient elasticClient,
            IExceptionService exceptionService)
            : base(bucket, elasticClient, exceptionService)
        {
        }

        #endregion

        #region Methods

        public override Task<IDocument> GetByIdAsync(string entityId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Counts the the result of view document asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<NbPage> CountGetTenDocumentAsync()
        {
            var query = Bucket.CreateQuery(Constants.DesignDocumentNameGet10Doc, Constants.ViewNameGet10Doc, true);

            var results = await ExceptionService.ProcessAsync(() => Bucket.Query<Document>(query))
                .ConfigureAwait(false);

            var nbPage = new NbPage
            {
                TotalDoc = (int)results.TotalRows
            };

            if (results.Success) return nbPage;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        /// <summary>
        /// Counts the filtered document by domain or by niveau.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="domains">The domains.</param>
        /// <param name="niveaux">The niveaux.</param>
        /// <returns></returns>
        public async Task<NbPage> CountFilteredDocumentByDomainOrByNiveau(int nbPage,
            List<string> domains, List<string> niveaux)
        {
            long totalDocments = 0;

            if (domains.Count > 0 && niveaux.Count > 0)
            {
                foreach (var indexResult in from domain in domains
                                            from niveau in niveaux
                                            select CountFilterAllByNivauxAndDomains(nbPage, domain, niveau).Total)
                {
                    totalDocments += indexResult;
                }
                return new NbPage { TotalDoc = (int)totalDocments };
            }
            else if (domains.Count > 0 && niveaux.Count <= 0)
            {
                foreach (var indexResult in from domain in domains
                                            select CountFilterAllByNivauxOrDomain(nbPage, domain, "domaine").Total)
                {
                    totalDocments += indexResult;
                }
                return new NbPage { TotalDoc = (int)totalDocments };
            }
            else if (domains.Count <= 0 && niveaux.Count > 0)
            {
                foreach (var indexResult in from niveau in niveaux
                                            select CountFilterAllByNivauxOrDomain(nbPage, niveau, "niveau").Total)
                {
                    totalDocments += indexResult;
                }
                return new NbPage { TotalDoc = (int)totalDocments };
            }
            else if (domains.Count <= 0 && niveaux.Count <= 0)
            {
                return await CountGetTenDocumentAsync();
            }
            return new NbPage { TotalDoc = 0 };
        }

        private ISearchResponse<CouchbaseDocument> CountFilterAllByNivauxAndDomains(int nbPage, string domain, string niveau)
        {
            return ElasticClient.Search<CouchbaseDocument>(s => s
                //.From(nbPage * 10)
                .Query(f => f.Bool(b => b
                    .Must(o => o.Match(d => d.OnField("domaine").Query(domain ?? "")),
                        o => o.Match(n => n.OnField("niveau").Query(niveau ?? ""))))));
        }

        /// <summary>
        /// Filters the by nivaux or domain.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="queredValue">The quered value.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        private ISearchResponse<CouchbaseDocument> CountFilterAllByNivauxOrDomain(int nbPage, string queredValue, string fieldName)
        {
            return ElasticClient.Search<CouchbaseDocument>(s => s
                //.From(nbPage * 10)
                .Query(d => d.Match(m => m.OnField(fieldName).Query(queredValue ?? ""))));
        }

        #endregion
    }
}