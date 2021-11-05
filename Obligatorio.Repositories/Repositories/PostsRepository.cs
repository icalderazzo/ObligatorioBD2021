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
            try
            {
                // Insercion de Publicacion
                string query = "INSERT INTO " +
                               "Publicacion (CiUsuario, Estado, NombreProducto, DescripcionProducto, ValorProducto, FechaPublicacion) " +
                               "VALUES (@CiUsuario, @Estado, @NombreProducto, @DescripcionProducto, @ValorProducto, @FechaPublicacion)";
                _databaseContext.SaveData(query,
                    new SqlParameter("@CiUsuario", model.Propietario.Cedula),
                    new SqlParameter("@Estado", model.Estado ? 1 : 0),
                    new SqlParameter("@NombreProducto", model.Articulo.Nombre),
                    new SqlParameter("@DescripcionProducto", model.Articulo.Descripcion),
                    new SqlParameter("@ValorProducto", model.Articulo.Valor),
                    new SqlParameter("@FechaPublicacion", model.FechaPublicacion)
                );
                
                // Busqueda ID
                string queryId = "SELECT TOP 1 IdPublicacion, CiUsuario FROM Publicacion  " +
                               "WHERE CiUsuario = @CiUsuario ORDER BY IdPublicacion desc;";

                var dbResult = _databaseContext.Select(queryId,
                    new SqlParameter("@CiUsuario", model.Propietario.Cedula)
                );

                if (dbResult.Any())
                {
                    var filaUsuario = dbResult[0];
                    model.IdPublicacion = long.Parse(filaUsuario[0].ToString());
                } 
                else 
                {
                    throw (new Exception("No existe ID"));                
                }

                // Asociación de imágenes A IMPLEMENTAR

                return model;
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

        public ICollection<Publicacion> ListActivePosts(int ciActiveUser)
        {
            try
            {
                string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.Imagen " +
                               "FROM Publicacion p " +
                               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " +
                               "WHERE p.CiUsuario = @Ci AND p.Estado = 1;";

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
