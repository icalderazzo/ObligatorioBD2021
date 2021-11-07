using System;
using System.Collections.Generic;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using DatabaseInterface;
using System.Data.SqlClient;
using System.Text;

namespace Obligatorio.Repositories.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public PostsRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        private ICollection<Publicacion> ExtractPosts(List<object[]> dbResult)
        {
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
                    Imagen = Convert.FromBase64String(postRow[5].ToString())
                });
            }

            return result;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publicacion> FilterByName(string name, int ciActiveUser)
        {
            string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.ImagenBase64 " +
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
                    Imagen = Convert.FromBase64String(postRow[5].ToString())
                });
            }

            return result;
        }

        public Publicacion GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publicacion> GetPostsAsked(int ciUser, long idOffer)
        {
            try
            {
                string query = "select p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.ImagenBase64 from Publicacion p " +
                               "inner join PublicacionOferta on p.IdPublicacion = PublicacionOferta.IdPublicacion " +
                               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " +
                               "where PublicacionOferta.IdOferta = @idOffer and p.CiUsuario = @ciUser";
                var dbResult = _databaseContext.Select(query,
                    new SqlParameter("@idOffer", idOffer),
                    new SqlParameter("@ciUser", ciUser)
                );

                return ExtractPosts(dbResult);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ICollection<Publicacion> GetPostsOffered(int ciUser, long idOffer)
        {
            try
            {
                string query = "select p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.ImagenBase64 from Publicacion p " +
               "inner join PublicacionOferta on p.IdPublicacion = PublicacionOferta.IdPublicacion " +
               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " +
               "where PublicacionOferta.IdOferta = @idOffer and p.CiUsuario <> @ciUser";
                var dbResult = _databaseContext.Select(query,
                    new SqlParameter("@idOffer", idOffer),
                    new SqlParameter("@ciUser", ciUser)
                );

                return ExtractPosts(dbResult);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Publicacion Insert(Publicacion model)
        {
            try
            {
                var tran = _databaseContext.BeginTransaction();

                // Insercion de Publicacion
                string query = "INSERT INTO " +
                               "Publicacion (CiUsuario, NombreProducto, DescripcionProducto, ValorProducto) " +
                               "VALUES (@CiUsuario, @NombreProducto, @DescripcionProducto, @ValorProducto) ";
                
                _databaseContext.SaveData(tran, query,
                    new SqlParameter("@CiUsuario", model.Propietario.Cedula),
                    new SqlParameter("@NombreProducto", model.Articulo.Nombre),
                    new SqlParameter("@DescripcionProducto", model.Articulo.Descripcion),
                    new SqlParameter("@ValorProducto", model.Articulo.Valor)
                );
                
                // Busqueda ID
                string queryId = "SELECT TOP 1 IdPublicacion, CiUsuario FROM Publicacion  " +
                                 "WHERE CiUsuario = @CiUsuario ORDER BY IdPublicacion desc;";

                var dbResult = _databaseContext.Select(tran, queryId,
                    new SqlParameter("@CiUsuario", model.Propietario.Cedula)
                );

                var filaPublicacion = dbResult[0];
                model.IdPublicacion = long.Parse(filaPublicacion[0].ToString());

                if (model.Imagen != null) //si el usuario subio una imagen
                {
                    string addImageQuery = "INSERT INTO Imagen Values (@IdPublicacion, @ImagenBase64);";
                    string imgBase64 = Convert.ToBase64String(model.Imagen);

                    _databaseContext.SaveData(tran, addImageQuery,
                        new SqlParameter("@IdPublicacion", model.IdPublicacion),
                        new SqlParameter("@ImagenBase64", imgBase64)
                        );
                }

                _databaseContext.Commit(tran);

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
                string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.ImagenBase64 " +
                               "FROM Publicacion p " +
                               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " + 
                               "WHERE p.CiUsuario <> @Ci AND p.Estado = 1;";

                var dbResult = _databaseContext.Select(query, new SqlParameter("@Ci", ciActiveUser));

                return ExtractPosts(dbResult);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICollection<Publicacion> ListPostsOfUser(int ciActiveUser)
        {
            try
            {
                string query = "SELECT p.IdPublicacion, p.NombreProducto, p.DescripcionProducto, p.ValorProducto, p.CiUsuario, i.ImagenBase64 " +
                               "FROM Publicacion p " +
                               "LEFT JOIN Imagen i on p.IdPublicacion = i.IdPublicacion " +
                               "WHERE p.CiUsuario = @Ci AND p.Estado = 1;";

                var dbResult = _databaseContext.Select(query, new SqlParameter("@Ci", ciActiveUser));

                return ExtractPosts(dbResult);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePostState(long idPost)
        {
            var tran = _databaseContext.BeginTransaction();
            var queryPubOfrecida = "UPDATE Publicacion SET Estado=0 WHERE IdPublicacion = @IdPublicacion;";
            _databaseContext.SaveData(
                tran, queryPubOfrecida,
                new SqlParameter("@IdPublicacion", idPost)
            );
            _databaseContext.Commit(tran);
        }

        public Publicacion Update(Publicacion model)
        {
            throw new NotImplementedException();
        }
    }
}
