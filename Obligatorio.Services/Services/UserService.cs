using Obligatorio.Domain;
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
        private readonly IValidator<Usuario> _userValidator;
        public UserService(IUserRepository userRepository, IValidator<Usuario> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public Usuario Login(string username, string password)
        {
            try
            {
                return _userRepository.GetForLogin(username, HashingModule.ComputeSha256Hash(password));
            }
            catch (Exception e)
            {
                throw new Exception("", e);
            }
        }

        public void Create(Usuario entity)
        {
            (bool, string) validation = _userValidator.Validate(entity);
            bool validationResult = validation.Item1;
            string validationMessage = validation.Item2;

            if (!validationResult)
            {
                throw new InvalidOperationException(validationMessage);
            }

            bool usernameUsed = _userRepository.ExistsUserWithUsername(entity.NombreUsuario);
            bool phoneUsed = _userRepository.ExistsUserWithPhoneNumber(entity.Telefono);
            bool ciUsed = _userRepository.ExistsUserWithCi(entity.Cedula);
            bool emailUsed = _userRepository.ExistsUserWithEmail(entity.Correo);

            // Check username not being used
            if (usernameUsed) { throw new InvalidOperationException("El nombre de usuario seleccionado ya está ocupado"); }
            // Check phone number not being used
            if (phoneUsed) { throw new InvalidOperationException("El número de teléfono seleccionado ya está ocupado"); }
            // Check ci not being used
            if (ciUsed) { throw new InvalidOperationException("La cédula seleccionada ya está ocupada"); }
            // Check email not being used
            if (emailUsed) { throw new InvalidOperationException("El email seleccionado ya está ocupado"); }

            //Hash password
            entity.Contrasenia = HashingModule.ComputeSha256Hash(entity.Contrasenia);

            // Insert user
            _userRepository.Insert(entity);
        }

        public void Delete(string entityId)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(string entityId)
        {
            return _userRepository.GetById(entityId);
        }

        public ICollection<Usuario> List()
        {
            throw new NotImplementedException();
        }

        public void Modify(Usuario entity)
        {
            (bool, string) validation = _userValidator.Validate(entity);
            bool validationResult = validation.Item1;
            string validationMessage = validation.Item2;

            if (!validationResult)
            {
                throw new InvalidOperationException(validationMessage);
            }

            bool usernameUsed = _userRepository.ExistsUserWithUsername(entity.NombreUsuario);
            bool phoneUsed = _userRepository.ExistsUserWithPhoneNumber(entity.Telefono);
            bool ciUsed = _userRepository.ExistsUserWithCi(entity.Cedula);
            bool emailUsed = _userRepository.ExistsUserWithEmail(entity.Correo);

            // Check phone number not being used
            if (phoneUsed) { throw new InvalidOperationException("El número de teléfono seleccionado ya está ocupado"); }
            // Check email not being used
            if (emailUsed) { throw new InvalidOperationException("El email seleccionado ya está ocupado"); }

            //Hash password
            entity.Contrasenia = HashingModule.ComputeSha256Hash(entity.Contrasenia);

            try
            {
                // Update user
                _userRepository.Update(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
