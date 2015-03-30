using System.Collections.Generic;
using System.Threading.Tasks;
using bwaniaProject.Data;
using bwaniaProject.Entities;
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

        #region Properties

        protected  IBucket Bucket { get; private set; }
        #endregion

        #region Methods

        public async Task SaveAsync(T entity)
        {
            var result = await Task.Run(() => Bucket.Upsert(entity.Wrap())).ConfigureAwait(false);
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