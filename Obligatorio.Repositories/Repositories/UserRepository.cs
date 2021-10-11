using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Get(string username, string password)
        {
            string query = "SELECT u.Ci, u.Nombre, u.Apellido, u.Correo, u.NombreUsuario FROM Usuario u " +
                           "WHERE u.NombreUsuario = @username AND u.Contrasenia = @password;";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@username",
                    DbType = System.Data.DbType.String,
                    Value = username
                },
                new SqlParameter()
                {
                    ParameterName = "@password",
                    DbType = System.Data.DbType.String,
                    Value = password
                }
            };
            var dbResult = await DataBaseInterface.DatabaseAccess.Select(query, sqlParameters);
            if (dbResult.Any())
            {
                var filaUsuario = dbResult[0];
                Usuario loggedUser = new Usuario()
                {
                    Cedula = int.Parse(filaUsuario[0].ToString()),
                    Nombre = filaUsuario[1].ToString(),
                    Apellido = filaUsuario[2].ToString(),
                    Correo = filaUsuario[3].ToString(),
                    NombreUsuario = filaUsuario[4].ToString()
                };
                return loggedUser;
            }
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
