using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IPostsService : IService<Publicacion>
    {
        List<Publicacion> ListForFeed(int ciActiveUser);
        List<Publicacion> FilterByName(string name, int ciActiveUser);
        List<Publicacion> ListPostsOfUser(int ciUser);
        /// <summary>
        /// Obtiene publicaciones que se le ofrecen a la usuario activo
        /// </summary>
        /// <param name="ciUser">Cedula del usuario activo</param>
        /// <param name="idOffer"></param>
        /// <returns></returns>
        List<Publicacion> GetPostsOffered(int ciUser, long idOffer);
        /// <summary>
        /// Obtiene publicaciones que desean del usuario activo
        /// </summary>
        /// <param name="ciUser">Cedula del usuario activo</param>
        /// <param name="idOffer"></param>
        /// <returns></returns>
        List<Publicacion> GetPostsAsked(int ciUser, long idOffer);
        void UpdatePostState(long postId, bool active);
    }
}