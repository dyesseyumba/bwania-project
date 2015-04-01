using System.Threading.Tasks;
using bwaniaProject.Data.Extensions;
using bwaniaProject.Entities;
using Couchbase.Core;

namespace bwaniaProject.Data
{
    public class DomainRepositoryBase<T> : IDomainRepository<T> where T : IEntity
    {
        #region Constructors
        public DomainRepositoryBase(IBucket bucket)
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

        public async Task RemoveAsync(T entity)
        {
            var result = await Task.Run(() => Bucket.Remove(entity.Wrap())).ConfigureAwait(false);
            result.ThrowIfNotSuccess(entity.id);
        }

        #endregion
    }
}