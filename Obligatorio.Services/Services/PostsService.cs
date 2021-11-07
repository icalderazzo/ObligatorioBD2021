using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using Obligatorio.Repositories.Interfaces;
using System.Linq;

namespace Obligatorio.Services.Services
{
    public class PostsService : IPostsService
    {
        private readonly  IPostsRepository _postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
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

        public List<Publicacion> GetPostsAsked(int ciUser, long idOffer)
        {
            return _postsRepository.GetPostsAsked(ciUser, idOffer).ToList();
        }

        public List<Publicacion> GetPostsOffered(int ciUser, long idOffer)
        {
            return _postsRepository.GetPostsOffered(ciUser, idOffer).ToList();
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
            throw new NotImplementedException();
        }

        public void UpdatePostsState(long post, int ciUser, bool isSender) 
        {
            List<long> publicaciones;
            if (isSender)
                publicaciones = (List<long>) GetPostsAsked(ciUser, post).Select(p => p.IdPublicacion);
            else
                publicaciones = (List<long>) GetPostsOffered(ciUser, post).Select(p => p.IdPublicacion);
            publicaciones.ForEach(publicacion => _postsRepository.UpdatePostState(publicacion));

        }
    }
}
