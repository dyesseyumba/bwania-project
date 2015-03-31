using System.Threading.Tasks;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface IDomainRepository<in T> where T : IEntity
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task SaveAsync(T entity);

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task RemoveAsync(T entity);
    }
}