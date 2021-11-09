using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IPostsRepository : IRepository<Publicacion>
    {
        ICollection<Publicacion> ListForFeed(int ciActiveUser);
        ICollection<Publicacion> FilterByName(string name, int ciActiveUser);
        ICollection<Publicacion> ListPostsOfUser(int ciUser);
        ICollection<Publicacion> GetPostsInOffer(long offerId, int ciUser);
        void UpdatePostState(long idPost, bool active);
    }
}
