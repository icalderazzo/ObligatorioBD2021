using DatabaseInterface;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Obligatorio.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _context;
        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsUserWithUsername(string username)
        {
            string query = "SELECT u.Ci FROM Usuario u WHERE u.NombreUsuario = @username;";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@username",
                    DbType = System.Data.DbType.String,
                    Value = username
                }
            };
            var result = _context.Select(query, sqlParameters);
            return result.Count > 0;
        }

        public Usuario GetForLogin(string username, string password)
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
            var dbResult = _context.Select(query, sqlParameters);
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

        public Usuario GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Usuario Insert(Usuario model)
        {
            try
            {
                string query = "INSERT INTO " +
                               "Usuario (Ci, Nombre, Apellido, Correo, Telefono, NombreUsuario, Contrasenia) " +
                               "VALUES (@Ci, @Nombre, @Apellido, @Correo, @Telefono, @NombreUsuario, @Contrasenia)";
                _context.SaveData(query,
                    new List<SqlParameter>()
                    {
                        new SqlParameter()
                        {
                            ParameterName = "@Ci",
                            Value = model.Cedula
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Nombre",
                            Value = model.Nombre
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Apellido",
                            Value = model.Apellido
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Correo",
                            Value = model.Correo
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Telefono",
                            Value = model.Telefono
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@NombreUsuario",
                            Value = model.NombreUsuario
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Contrasenia",
                            Value = model.Contrasenia
                        }
                    });

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Update(Usuario model)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> List()
        {
            throw new NotImplementedException();
        }
    }
}
