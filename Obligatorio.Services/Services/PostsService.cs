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
        private Usuario _user ;
        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public void Create(Publicacion entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Publicacion entity, Usuario user)
        {
            _postsRepository.Insert(entity,user);
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

        public ICollection<Publicacion> List()
        {
            throw new NotImplementedException();
        }

        public List<Publicacion> ListForFeed(int ciActiveUser)
        {
            return _postsRepository.ListForFeed(ciActiveUser).ToList();
        }

        public void AssignUser(Usuario user)
        {
            this._user = user;
        }

        public void Modify(Publicacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
