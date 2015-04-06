using System.Collections.Generic;
using bwaniaProject.Entities;

namespace bwaniaProject.Data
{
    public interface ICommentReadRepository
    {
        IEnumerable<Commentaire> GetTenDocument(int nbPage); 
    }
}