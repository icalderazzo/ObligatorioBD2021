using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IPostsRepository : IRepository<Publicacion>
    {
        ICollection<Publicacion> ListForFeed(int ciActiveUser);
    }
}
