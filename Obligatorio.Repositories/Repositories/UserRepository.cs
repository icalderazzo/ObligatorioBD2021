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

        private Usuario ExtractUser(List<object[]> dbResult)
        {
            var filaUsuario = dbResult[0];
            Usuario user = new Usuario()
            {
                Cedula = int.Parse(filaUsuario[0].ToString()),
                Nombre = filaUsuario[1].ToString(),
                Apellido = filaUsuario[2].ToString(),
                Correo = filaUsuario[3].ToString(),
                NombreUsuario = filaUsuario[4].ToString()
            };
            return user;
        }

        public bool ExistsUserWithUsername(string username)
        {
            string query = "SELECT u.Ci FROM Usuario u WHERE u.NombreUsuario = @username;";
            var result = _context.Select(query, 
                new SqlParameter("@username", username)
            );
            return result.Count > 0;
        }

        public bool ExistsUserWithEmail(string email, int ci)
        {
            string query = "SELECT u.Ci FROM Usuario u WHERE u.Correo = @email AND u.Ci <> @Ci;";
            var result = _context.Select(query, 
                new SqlParameter("@email", email),
                new SqlParameter("@Ci", ci)
            );
            return result.Count > 0;
        }
        public bool ExistsUserWithPhoneNumber(int phoneNumber, int ci)
        {
            string query = "SELECT u.Ci FROM Usuario u WHERE u.Telefono = @phoneNumber AND u.Ci <> @Ci;";
            var result = _context.Select(query, 
                new SqlParameter("@phoneNumber", phoneNumber),
                new SqlParameter("@Ci", ci)
            );
            return result.Count > 0;
        }
        public bool ExistsUserWithCi(int ci)
        {
            string query = "SELECT u.Ci FROM Usuario u WHERE u.Ci = @ci;";
            var result = _context.Select(query, new SqlParameter("@ci", ci));
            return result.Count > 0;
        }

        public Usuario GetForLogin(string username, string password)
        {
            string query = "SELECT u.Ci, u.Nombre, u.Apellido, u.Correo, u.NombreUsuario FROM Usuario u " +
                           "WHERE u.NombreUsuario = @username AND u.Contrasenia = @password;";

            var dbResult = _context.Select(query,
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            );

            if (dbResult.Any())
            {
                return ExtractUser(dbResult);
            }
            return null;
        }

        public Usuario GetById(string id)
        {
            try
            {
                string query = "SELECT Ci, Nombre, Apellido, Correo, NombreUsuario FROM Usuario WHERE Ci = @Ci;";

                var result = _context.Select(query,
                    new SqlParameter("@Ci", id));

                return ExtractUser(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Insert(Usuario model)
        {
            try
            {
                string query = "INSERT INTO " +
                               "Usuario (Ci, Nombre, Apellido, Correo, Telefono, NombreUsuario, Contrasenia) " +
                               "VALUES (@Ci, @Nombre, @Apellido, @Correo, @Telefono, @NombreUsuario, @Contrasenia)";

                _context.SaveData(query,
                    new SqlParameter("@Ci", model.Cedula),
                    new SqlParameter("@Nombre", model.Nombre),
                    new SqlParameter("@Apellido", model.Apellido),
                    new SqlParameter("@Correo", model.Correo),
                    new SqlParameter("@Telefono", model.Telefono),
                    new SqlParameter("@NombreUsuario", model.NombreUsuario),
                    new SqlParameter("@Contrasenia", model.Contrasenia)
                );

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Update(Usuario model)
        {
            try
            {
                var tran = _context.BeginTransaction();

                string query = "UPDATE Usuario SET " +
                              "Nombre=@Nombre, Apellido=@Apellido, Correo=@Correo, Telefono=@Telefono " +
                              "WHERE Usuario.Ci = @Ci";

                _context.SaveData(tran, query,
                    new SqlParameter("@Ci", model.Cedula),
                    new SqlParameter("@Nombre", model.Nombre),
                    new SqlParameter("@Apellido", model.Apellido),
                    new SqlParameter("@Correo", model.Correo),
                    new SqlParameter("@Telefono", model.Telefono)
                );

                if (!string.IsNullOrEmpty(model.Contrasenia))
                {
                    query = "UPDATE Usuario SET Contrasenia=@Contrasenia WHERE Usuario.Ci = @Ci";

                    _context.SaveData(tran,query,
                        new SqlParameter("@Contrasenia", model.Contrasenia),
                        new SqlParameter("@Ci", model.Cedula)
                    );
                }

                _context.Commit(tran);
                return model;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new InvalidOperationException("El número de teléfono seleccionado ya está en uso");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICollection<Usuario> List()
        {
            throw new NotImplementedException();
        }

        public Usuario GetCompleteUserByUsername(string username)
        {
            try
            {
                string query = "SELECT Ci, Nombre, Apellido, Correo, NombreUsuario, Contrasenia, Telefono " +
                    "FROM Usuario WHERE NombreUsuario = @Username;";

                var dbResult = _context.Select(query,
                    new SqlParameter("@Username", username));

                var user = ExtractUser(dbResult);
                user.Contrasenia = dbResult[0][5].ToString();
                user.Telefono = int.Parse(dbResult[0][6].ToString());

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
