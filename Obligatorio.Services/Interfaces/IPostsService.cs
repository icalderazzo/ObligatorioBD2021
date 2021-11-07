using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IPostsService : IService<Publicacion>
    {
        List<Publicacion> ListForFeed(int ciActiveUser);
        List<Publicacion> FilterByName(string name, int ciActiveUser);
        List<Publicacion> ListPostsOfUser(int ciUser);

        List<Publicacion> GetPostsOffered(int ciUser, long idOffer);
        List<Publicacion> GetPostsAsked(int ciUser, long idOffer);
        void UpdatePostsState(long post, int ciUser, bool isOffered);
    }
}