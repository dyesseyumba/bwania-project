using bwaniaProject.Entities;
using Couchbase;

namespace bwaniaProject.Infrastructure.Data.Extensions
{
    public static class EntityExtensions
    {
        public static IDocument<T> Wrap<T>(this T entity) where T : IEntity
        {
            return new Document<T>
            {
                Id = entity.id,
                Cas = entity.Cas,
                Content = entity
            };
        }

        public static T UnWrap<T>(this IDocument<T> document) where T : IEntity
        {
            var entity = document.Content;
            entity.Cas = document.Cas;
            entity.id = document.Id;
            return entity;
        }
    }
}
