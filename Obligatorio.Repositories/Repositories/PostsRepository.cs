using System;
using System.Collections.Generic;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using DatabaseInterface;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Obligatorio.Repositories.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IDatabaseContext _databaseContext;
        public Usuario _user;

        public PostsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publicacion> FilterByName(string name, int ciActiveUser)
        {
            string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.Imagen " +
               "FROM Publicacion p " +
               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " +
               $"WHERE p.NombreProducto LIKE '%{name}%' AND p.CiUsuario <> @Ci AND p.Estado = 1;";

            var dbResult = _databaseContext.Select(query,
                new SqlParameter("@Ci", ciActiveUser)
                );

            List<Publicacion> result = new();

            foreach (var postRow in dbResult)
            {
                result.Add(new Publicacion()
                {
                    IdPublicacion = long.Parse(postRow[0].ToString()),
                    Articulo = new Articulo()
                    {
                        Nombre = postRow[1].ToString(),
                        Descripcion = postRow[2].ToString(),
                        Valor = int.Parse(postRow[3].ToString())
                    },
                    Estado = true,
                    Propietario = new Usuario()
                    {
                        Cedula = int.Parse(postRow[4].ToString())
                    },
                    Imagen = Encoding.ASCII.GetBytes(postRow[5].ToString())
                });
            }

            return result;
        }

        public Publicacion GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Publicacion Insert(Publicacion model)
        {
            throw new NotImplementedException();
        }

        public Publicacion Insert(Publicacion model, Usuario user)
        {
            try
            {
                string query = "INSERT INTO " +
                               "Publicacion (Estado, NombreProducto, DescripcionProducto, ValorProducto) " +
                               "VALUES (@Estado, @NombreProducto, @DescripcionProducto, @ValorProducto)";

                _databaseContext.SaveData(query,
                    new SqlParameter("@Estado", model.Estado ? 1 : 0),
                    new SqlParameter("@NombreProducto", model.Articulo.Nombre),
                    new SqlParameter("@DescripcionProducto", model.Articulo.Descripcion),
                    new SqlParameter("@ValorProducto", model.Articulo.Valor)
                );
                string idPublicacion = GetIdPost(model);
                AssignPostToUser(model, user);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string GetIdPost(Publicacion post)
        {
            try
            {
                string query = "SELECT p.IdPublicacion, p.Estado, p.NombreProducto," +
                          " p.DescripcionProducto, p.ValorProducto FROM Publicacion p " +
                          "WHERE p.Estado = @Estado AND p.NombreProducto LIKE @NombreProducto" +
                          " AND p.DescripcionProducto LIKE @DescripcionProducto" +
                          " AND p.ValorProducto = @ValorProducto;";

                var dbResult = _databaseContext.Select(query,
                    new SqlParameter("@Estado", post.Estado),
                    new SqlParameter("@NombreProducto", post.Articulo.Nombre),
                    new SqlParameter("@DescripcionProducto", post.Articulo.Descripcion),
                    new SqlParameter("@ValorProducto", post.Articulo.Valor)
                );
                if (dbResult.Any())
                {
                    var filaUsuario = dbResult[0];
                    post.IdPublicacion = long.Parse(filaUsuario[0].ToString());
                    return post.IdPublicacion.ToString();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void AssignPostToUser(Publicacion post, Usuario user)
        {
            try
            {
                string query = "INSERT INTO " +
                               "UsuarioPublicacion(CiUsuario,IdPublicacion,FechaPublicacion) " +
                               "VALUES (@CiUsuario,@IdPublicacion,CAST(@FechaPublicacion AS DATETIME))";

                _databaseContext.SaveData(query,
                    new SqlParameter("@CiUsuario", user.Cedula),
                    new SqlParameter("@IdPublicacion", post.IdPublicacion),
                    new SqlParameter("@FechaPublicacion", post.FechaPublicacion.ToString("yyyy-MM-dd hh:mm:ss"))
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICollection<Publicacion> List()
        {
            throw new NotImplementedException();
        }

        public ICollection<Publicacion> ListForFeed(int ciActiveUser)
        {
            try
            {
                string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.Imagen " +
                               "FROM Publicacion p " +
                               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " + 
                               "WHERE p.CiUsuario <> @Ci AND p.Estado = 1;";

                var dbResult = _databaseContext.Select(query, new SqlParameter("@Ci", ciActiveUser));
                
                List<Publicacion> result = new();

                foreach (var postRow in dbResult)
                {
                    result.Add(new Publicacion()
                    {
                        IdPublicacion = long.Parse(postRow[0].ToString()),
                        Articulo = new Articulo()
                        {
                            Nombre = postRow[1].ToString(),
                            Descripcion = postRow[2].ToString(),
                            Valor = int.Parse(postRow[3].ToString())
                        },
                        Estado = true,
                        Propietario = new Usuario()
                        {
                            Cedula = int.Parse(postRow[4].ToString())
                        },
                        Imagen = Encoding.ASCII.GetBytes(postRow[5].ToString())
                    });
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Publicacion Update(Publicacion model)
        {
            throw new NotImplementedException();
        }
    }
}
