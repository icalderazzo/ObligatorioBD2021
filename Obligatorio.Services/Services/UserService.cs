using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Obligatorio.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Usuario Login(Usuario usuario)
        {
            try
            {
                return _userRepository.Get(usuario).Result;
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public void Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entityId)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> List()
        {
            throw new NotImplementedException();
        }

        public void Modify(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
