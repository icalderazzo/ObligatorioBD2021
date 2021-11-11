using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Obligatorio.Services.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public bool CheckPostInOffers(long idPost, EnumOfertas.EstadoOferta state)
        {
            return _postsRepository.CheckPostInOffers(idPost, state);
        }

        public void Create(Publicacion entity)
        {
            _postsRepository.Insert(entity);
        }

        public void Delete(string entityId)
        {
            throw new NotImplementedException();
        }

        public List<Publicacion> FilterByName(string name, int ciActiveUser)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _postsRepository.ListForFeed(ciActiveUser).ToList();
            }
            return _postsRepository.FilterByName(name, ciActiveUser).ToList();
        }

        public Publicacion GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public List<Publicacion> GetPostsInOffer(long offerId, int ciUser)
        {
            return _postsRepository.GetPostsInOffer(offerId, ciUser).ToList();
        }

        public ICollection<Publicacion> List()
        {
            throw new NotImplementedException();
        }

        public List<Publicacion> ListForFeed(int ciActiveUser)
        {
            return _postsRepository.ListForFeed(ciActiveUser).ToList();
        }

        public List<Publicacion> ListPostsOfUser(int ciUser)
        {
            return _postsRepository.ListPostsOfUser(ciUser).ToList();
        }

        public void Modify(Publicacion entity)
        {
            bool postInOffers = CheckPostInOffers(entity.IdPublicacion, EnumOfertas.EstadoOferta.Pendiente);

            if (postInOffers) 
            {
                throw new InvalidOperationException("No puedes actualizar los datos de la publicación ya que se encuentra en una oferta en curso");
            }

            _postsRepository.Update(entity);
        }

        public void UpdatePostState(long postId, bool active)
        {
            if (_postsRepository.CheckPostInOffers(postId, EnumOfertas.EstadoOferta.Pendiente))
            {
                throw new InvalidOperationException("No puedes cambiar el estado a una publicación que está incluida en una oferta en curso.");
            }
            _postsRepository.UpdatePostState(postId, active);
        }
    }
}
