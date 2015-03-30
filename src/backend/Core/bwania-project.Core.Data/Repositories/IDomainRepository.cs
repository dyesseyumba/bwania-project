using System.Threading.Tasks;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface IDomainRepository<in T> where T : IEntity
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
        Task Remove(T entity);
    }
}