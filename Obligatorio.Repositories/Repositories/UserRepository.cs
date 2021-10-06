using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obligatorio.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Get(Usuario usuario)
        {
            return null;
        }

        public Task<Usuario> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Insert(Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Usuario>> List()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Update(Usuario model)
        {
            throw new NotImplementedException();
        }
    }
}
