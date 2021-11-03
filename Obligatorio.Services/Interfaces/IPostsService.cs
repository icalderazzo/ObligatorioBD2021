using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IPostsService : IService<Publicacion>
    {
        List<Publicacion> ListForFeed(int ciActiveUser);
        List<Publicacion> FilterByName(string name, int ciActiveUser);
        void Create(Publicacion entity);
        void Create(Publicacion entity, Usuario user);
    }
}
