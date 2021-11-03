using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IPostsRepository : IRepository<Publicacion>
    {
        ICollection<Publicacion> ListForFeed(int ciActiveUser);
        ICollection<Publicacion> FilterByName(string name, int ciActiveUser);
        Publicacion Insert(Publicacion model);
        Publicacion Insert(Publicacion model, Usuario user);
    }
}
