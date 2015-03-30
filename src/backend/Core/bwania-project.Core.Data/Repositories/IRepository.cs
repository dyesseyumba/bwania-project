using System.Collections.Generic;
using System.Threading.Tasks;
using bwaniaProject.Core.Entities;
using Couchbase.N1QL;
using Couchbase.Views;

namespace bwaniaProject.Core.Data
{
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task SaveAsync(T entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Selects documents by the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        IEnumerable<T> Select(IList<string> keys);

        /// <summary>
        /// Selects documents the specified query request.
        /// </summary>
        /// <param name="queryRequest">The query request.</param>
        /// <returns></returns>
        IEnumerable<T> Select(IQueryRequest queryRequest);

        /// <summary>
        /// Selects documents the specified view query.
        /// </summary>
        /// <param name="viewQuery">The view query.</param>
        /// <returns></returns>
        IEnumerable<T> Select(IViewQuery viewQuery);

        /// <summary>
        /// Finds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Find(string key);
    }
}
