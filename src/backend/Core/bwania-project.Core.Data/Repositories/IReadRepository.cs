using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface IReadRepository<in T> where T : IEntity
    {
        
    }
}