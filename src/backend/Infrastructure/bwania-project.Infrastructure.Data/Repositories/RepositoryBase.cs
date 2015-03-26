using System.Collections.Generic;
using bwaniaProject.Core.Data;
using bwaniaProject.Core.Entities;
using bwaniaProject.Infrastructure.Data.Exceptions;
using bwaniaProject.Infrastructure.Data.Extensions;
using Couchbase.Core;
using Couchbase.N1QL;
using Couchbase.Views;
using Newtonsoft.Json;

namespace bwaniaProject.Infrastructure.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        #region Constructors
        public RepositoryBase(IBucket bucket)
        {
            Bucket = bucket;
        }
        #endregion

        #region Methods

        protected  IBucket Bucket { get; set; }
        #endregion

        #region Methods

        public void Save(T entity)
        {
            var result = Bucket.Upsert(entity.Wrap());
            result.ThrowIfNotSuccess();
        }

        public void Remove(T entity)
        {
            var result = Bucket.Remove(entity.Wrap());
            result.ThrowIfNotSuccess(entity.Id);
        }

        public IEnumerable<T> Select(IQueryRequest queryRequest)
        {
            var results = Bucket.Query<T>(queryRequest);
            if (results.Success) return results.Rows;
            var message = JsonConvert.SerializeObject(results.Errors);
            throw new QueryRequestException(message, results.Status);
        }

        public IEnumerable<T> Select(IViewQuery viewQuery)
        {
            var results = Bucket.Query<T>(viewQuery);
            if (results.Success) return results.Values;
            var message = results.Error;
            throw new ViewRequestException(message, results.StatusCode);
        }

        public T Find(string key)
        {
            var result = Bucket.GetDocument<T>(key);
            result.ThrowIfNotSuccess();
            return result.Document.UnWrap();
        }

        public IEnumerable<T> Select(IList<string> keys)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}