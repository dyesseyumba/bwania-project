using System.Collections.Generic;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface IDocumentReadRepository : IReadRepository
    {
        IEnumerable<Document> GetTenDocument(int nbPage);
    }
}