// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DocumentReadRepository.cs" company="Bwania development team">
//    Copyright (c) 2014 - 2015 Bwania development team. All rights reserved.
//  </copyright>  
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using bwaniaProject.Data.Buckets.Interfaces;
using BwaniaProject.Data.Exceptions;
using BwaniaProject.Domain.Entities.Common;
using BwaniaProject.Entities;
using Catel;
using Catel.ExceptionHandling;
using Couchbase.Core;
using Nest;

namespace BwaniaProject.Data.Repositories
{
    public class DocumentReadRepository : ReadRepositoryBase<IDocument>, IDocumentReadRepository
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DocumentReadRepository" /> class.
        /// </summary>
        /// <param name="bucket">the couchbase Bucket.</param>
        /// <param name="elasticClient">The elastic search client</param>
        /// <param name="exceptionService">The exception service</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="bucket" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="elasticClient" /> is <c>null</c>.</exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="exceptionService" /> is <c>null</c>.</exception>
        public DocumentReadRepository(IDocumentBucket bucket, IElasticClient elasticClient,
            IExceptionService exceptionService)
            : base(bucket, elasticClient, exceptionService)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets ten document from Couchbase.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <returns></returns>
        /// <exception cref="ViewRequestException"></exception>
        /// <exception cref="System.ArgumentNullException">The <paramref name="nbPage" /> is <c>null</c>.</exception>
        public async Task<IEnumerable<IDocument>> GetTenDocumentAsync(int nbPage)
        {
            Argument.IsNotNull("nbPage", nbPage);

            var query = Bucket.CreateQuery(Constants.DesignDocumentNameGet10Doc, Constants.ViewNameGet10Doc, true)
                .Skip(nbPage*10)
                .Limit(10)
                .Desc();

            var results = await ExceptionService.ProcessAsync(() => Bucket.Query<Document>(query))
                .ConfigureAwait(false);

            if (results.Success) return results.Values;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
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
                TotalDoc = (int) results.TotalRows
            };

            if (results.Success) return nbPage;

            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        /// <summary>
        ///     Gets the file asynchronous from couch base.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entityId" /> is <c>null</c>.</exception>
        /// <returns></returns>
        public async Task<IDictionary<string, dynamic>> GetFileAsync(string entityId)
        {
            Argument.IsNotNull("entityID", entityId);

            var document = await GetByIdAsync(entityId).ConfigureAwait(false);
            var dictionary = new Dictionary<string, dynamic>();
            dictionary["file"] = document.Fichier;
            dictionary["fileName"] = "bwania-" + document.NomFichier;

            return dictionary;
        }

        /// <summary>
        ///     Gets the filtered document by domain or by niveau.
        /// </summary>
        /// <param name="nbPage"></param>
        /// <param name="domains">The domains.</param>
        /// <param name="niveaux">The niveau.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<IDocument>> GetFilteredDocumentByDomainOrByNiveau(int nbPage,
            List<string> domains, List<string> niveaux)
        {
            var elasticSearchDocments = new List<ICouchbaseDocument>();
            var resultsDocuments = new List<IDocument>();

            if (domains.Count > 0 && niveaux.Count > 0)
            {
                foreach (var indexResult in from domain in domains
                    from niveau in niveaux
                    select FilterTenByNivauxAndDomains(nbPage, domain, niveau).Documents)
                {
                    elasticSearchDocments.AddRange(indexResult);
                }

                foreach (var index in elasticSearchDocments)
                {
                    resultsDocuments.Add(await GetByIdAsync(index.Meta.Id));
                }
            }
            else if (domains.Count > 0 && niveaux.Count <= 0)
            {
                foreach (var indexResult in from domain in domains
                                            select FilterTenByNivauxOrDomain(nbPage, domain, "domaine").Documents)
                {
                    elasticSearchDocments.AddRange(indexResult);
                }

                foreach (var index in elasticSearchDocments)
                {
                    resultsDocuments.Add(await GetByIdAsync(index.Meta.Id));
                }
            }
            else if (domains.Count <= 0 && niveaux.Count > 0)
            {
                foreach (var indexResult in from niveau in niveaux
                                            select FilterTenByNivauxOrDomain(nbPage, niveau, "niveau").Documents)
                {
                    elasticSearchDocments.AddRange(indexResult);
                }

                foreach (var index in elasticSearchDocments)
                {
                    resultsDocuments.Add(await GetByIdAsync(index.Meta.Id));
                }
            }
            else if (domains.Count <= 0 && niveaux.Count <= 0)
            {
                resultsDocuments.Clear();
                resultsDocuments.AddRange(await GetTenDocumentAsync(nbPage));
            }
            return resultsDocuments;
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

        /// <summary>
        ///     Gets document by identifier asynchronous from Couchbase.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="entityId" /> is <c>null</c>.</exception>
        /// <returns></returns>
        public override async Task<IDocument> GetByIdAsync(string entityId)
        {
            Argument.IsNotNull("entityID", entityId);

            return await GetByIdAsync<Document>(entityId).ConfigureAwait(false);
        }

        #region Customs filter
        /// <summary>
        /// Filters the by nivaux and domains.
        /// </summary>
        /// <param name="nbPage">The nb page.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="niveau">The niveau.</param>
        /// <returns></returns>
        private ISearchResponse<CouchbaseDocument> FilterTenByNivauxAndDomains(int nbPage, string domain, string niveau)
        {
            return ElasticClient.Search<CouchbaseDocument>(s => s
                .Size(10)
                .From(nbPage*10)
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
        private ISearchResponse<CouchbaseDocument> FilterTenByNivauxOrDomain(int nbPage, string queredValue, string fieldName)
        {
            return ElasticClient.Search<CouchbaseDocument>(s => s
                .Size(10)
                .From(nbPage*10)
                .Query(d => d.Match(m => m.OnField(fieldName).Query(queredValue ?? ""))));
        }

        private ISearchResponse<CouchbaseDocument> CountFilterAllByNivauxAndDomains(int nbPage, string domain, string niveau)
        {
            return ElasticClient.Search<CouchbaseDocument>(s => s
                //.From(nbPage)
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
                //.From(nbPage)
                .Query(d => d.Match(m => m.OnField(fieldName).Query(queredValue ?? ""))));
        }
        #endregion

        #endregion
    }
}