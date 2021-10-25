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

        public Usuario Login(string username, string password)
        {
            try
            {
                return _userRepository.Get(username, password).Result;
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public void Create(Usuario entity)
        {
            if (_userRepository.ExistsUserWithUsername(entity.NombreUsuario).Result)
            {
                throw new InvalidOperationException("El nombre de usuario seleccionado ya está ocupado");
            }
            // chequear cedula
            // chequear telefono
            _userRepository.Insert(entity).Wait();
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
