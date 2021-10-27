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
            throw new NotImplementedException();
        }

        public void Delete(string entityId)
        {
            throw new NotImplementedException();
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

        public void Modify(Publicacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
