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
        private readonly IUserService _userService;

        public PostsService(
            IPostsRepository postsRepository,
            IUserService userService)
        {
            _postsRepository = postsRepository;
            _userService = userService;
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
            List<Publicacion> result;
            if (string.IsNullOrEmpty(name))
            {
                result =  _postsRepository.ListForFeed(ciActiveUser).ToList();
            }
            else
            {
                result = _postsRepository.FilterByName(name, ciActiveUser).ToList();
            }
            foreach (var p in result)
            {
                p.Propietario = _userService.GetById(p.Propietario.Cedula.ToString());
            }

            return result;
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
            var result =  _postsRepository.ListForFeed(ciActiveUser).ToList();
            foreach (var p in result)
            {
                p.Propietario = _userService.GetById(p.Propietario.Cedula.ToString());
            }

            return result;
        }

        public List<Publicacion> ListPostsOfUser(int ciUser)
        {
            return _postsRepository.ListPostsOfUser(ciUser).ToList();
        }

        public void Modify(Publicacion entity)
        {
            bool postInOffers = CheckPostInOffers(entity.IdPublicacion, EnumOfertas.EstadoOferta.Pendiente);

            if (!postInOffers) 
            {
                _postsRepository.Update(entity);
            }
        }

        public void UpdatePostState(long postId, bool active)
        {
            _postsRepository.UpdatePostState(postId, active);
        }
    }
}
