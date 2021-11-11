using Obligatorio.Domain.Model;
using System.Collections.Generic;
using Obligatorio.Domain;

namespace Obligatorio.Services.Interfaces
{
    public interface IPostsService : IService<Publicacion>
    {
        List<Publicacion> ListForFeed(int ciActiveUser);
        List<Publicacion> FilterByName(string name, int ciActiveUser);
        List<Publicacion> ListPostsOfUser(int ciUser);
        List<Publicacion> GetPostsInOffer(long offerId, int ciUser);
        void UpdatePostState(long postId, bool active);
        bool CheckPostInOffers(long idPost, EnumOfertas.EstadoOferta state);
    }
}