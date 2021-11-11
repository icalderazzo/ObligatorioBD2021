using DatabaseInterface;
using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Obligatorio.Repositories.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IDatabaseContext _context;

        public OfferRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Oferta GetById(string id)
        {
            try
            {
                string query = "SELECT IdOferta, FechaRealizacion FROM Oferta WHERE IdOferta = @IdOffer;";
                var result = _context.Select(
                    query, 
                        new SqlParameter("@IdOffer", long.Parse(id))
                    );
                return ExtractOffer(result[0]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Oferta> FilterOffers(OfferFilter filter)
        {
            try
            {
                var query = "select UsuarioOferta.IdOferta, Oferta.FechaRealizacion from UsuarioOferta " +
                            "inner join RolOferta on UsuarioOferta.IdRolOferta = RolOferta.IdRolOferta " +
                            "inner join Oferta on UsuarioOferta.IdOferta = Oferta.IdOferta " +
                            "where CiUsuario = @ciUser and UsuarioOferta.IdRolOferta = @userRoleInOffers and Oferta.EstadoOferta = @offerStatus";

                var offersLines = _context.Select(query,
                    new SqlParameter("@ciUser", filter.UserCi),
                    new SqlParameter("@userRoleInOffers", filter.UsersRole),
                    new SqlParameter("@offerStatus", filter.OfferState)
                );

                List<Oferta> offers = new List<Oferta>();

                for (int i = 0; i < offersLines.Count; i++)
                {
                    offers.Add(ExtractOffer(offersLines[i]));
                }

                return offers;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Oferta GetCounterOffer(long idOferr)
        {
            try
            {
                string query = "select IdOfertaAnterior from ContraOferta where IdOfertaNueva = @idOferr";

                var dbResult = _context.Select(query, new SqlParameter("@idOferr", idOferr));

                if (dbResult.Any())
                {
                    Oferta offer = new Oferta() { IdOferta = long.Parse(dbResult[0][0].ToString()) };
                    return offer;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Oferta Insert(Oferta model)
        {
            try
            {
                var tran = _context.BeginTransaction();

                var insertOfferQuery = "insert into Oferta (FechaRealizacion) values (@fecha)";
                _context.SaveData(
                    tran, insertOfferQuery,
                    new SqlParameter("@fecha", DateTime.Now)
                );

                var getInsertedOffer = "select top 1 IdOferta from Oferta order by IdOferta desc";
                var insertedOfferId = long.Parse(_context.Select(tran, getInsertedOffer, null)[0][0].ToString());

                model.IdOferta = insertedOfferId;
                if (model.TransaccionContraofertada != null)
                {
                    // Reject previous offer
                    UpdateOfferState(model.TransaccionContraofertada.IdOferta, EnumOfertas.EstadoOferta.Rechazada);

                    // Register counter offer
                    var queryInsertCounterOffer = "Insert into ContraOferta (IdOfertaAnterior, IdOfertaNueva) values (@IdOfertaAnterior, @IdOfertaNueva)";
                    _context.SaveData(
                        tran, queryInsertCounterOffer,
                        new SqlParameter("@IdOfertaNueva", model.IdOferta),
                        new SqlParameter("@IdOfertaAnterior", model.TransaccionContraofertada.IdOferta)
                    );
                }
                var queryInsertUserOfferSender = "insert into UsuarioOferta (IdOferta, IdRolOferta, CiUsuario) values (@IdOferta, @IdRolOferta, @CiUsuario)";
                _context.SaveData(
                    tran, queryInsertUserOfferSender,
                    new SqlParameter("@IdOferta", model.IdOferta),
                    new SqlParameter("@IdRolOferta", EnumRoles.RolOferta.Emisor),
                    new SqlParameter("@CiUsuario", model.UsuarioEmisor.Cedula)
                );
                var queryInsertUserOfferReciever = "insert into UsuarioOferta (IdOferta, IdRolOferta, CiUsuario) values (@IdOferta, @IdRolOferta, @CiUsuario)";
                _context.SaveData(
                    tran, queryInsertUserOfferReciever,
                    new SqlParameter("@IdOferta", model.IdOferta),
                    new SqlParameter("@IdRolOferta", EnumRoles.RolOferta.Destinatario),
                    new SqlParameter("@CiUsuario", model.UsuarioDestinatario.Cedula)
                );
                // Insert sender posts in PublicacionOferta
                foreach (var publicacion in model.PublicacionesEmisor)
                {
                    var query = "insert into PublicacionOferta (IdPublicacion, IdOferta) values (@IdPublicacion, @IdOfertaNueva)";
                    _context.SaveData(
                        tran, query,
                        new SqlParameter("@IdPublicacion", publicacion.IdPublicacion),
                        new SqlParameter("@IdOfertaNueva", model.IdOferta)
                    );
                }
                // Insert reciever posts in PublicacionOferta
                foreach (var publicacion in model.PublicacionesDestinatario)
                {
                    var query = "insert into PublicacionOferta (IdPublicacion, IdOferta) values (@IdPublicacion, @IdOfertaNueva)";
                    _context.SaveData(
                        tran, query,
                        new SqlParameter("@IdPublicacion", publicacion.IdPublicacion),
                        new SqlParameter("@IdOfertaNueva", model.IdOferta)
                    );
                }
                _context.Commit(tran);
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ICollection<Oferta> List()
        {
            throw new System.NotImplementedException();
        }

        public Oferta Update(Oferta model)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOfferState(long idOffer, EnumOfertas.EstadoOferta state)
        {
            try
            {
                var queryCompletada = "UPDATE Oferta SET EstadoOferta=@EstadoOferta WHERE IdOferta=@IdOferta;";
                _context.SaveData(
                    queryCompletada,
                    new SqlParameter("@EstadoOferta", state),
                    new SqlParameter("@IdOferta", idOffer)
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Oferta ExtractOffer (object[] oferta)
        {
            Oferta offer = new Oferta()
            {
                IdOferta = long.Parse(oferta[0].ToString()),
                Fecha = DateTime.Parse(oferta[1].ToString()),
            };
            return offer;
        }

        public Usuario GetUserByRole(EnumRoles.RolOferta usersRole, long idOffer)
        {
            try
            {
                string query = "select u.Ci, u.Nombre, u.Apellido, u.Correo, u.NombreUsuario from UsuarioOferta " +
                   "inner join RolOferta on UsuarioOferta.IdRolOferta = RolOferta.IdRolOferta " +
                   "inner join Usuario u on UsuarioOferta.CiUsuario = u.Ci " +
                   "where UsuarioOferta.IdOferta = @idOffer and UsuarioOferta.IdRolOferta = @idRole";

                var dbResult = _context.Select(query,
                    new SqlParameter("@idOffer", idOffer),
                    new SqlParameter("@idRole", usersRole)
                );

                var filaUsuario = dbResult[0];
                Usuario user = new()
                {
                    Cedula = int.Parse(filaUsuario[0].ToString()),
                    Nombre = filaUsuario[1].ToString(),
                    Apellido = filaUsuario[2].ToString(),
                    Correo = filaUsuario[3].ToString(),
                    NombreUsuario = filaUsuario[4].ToString()
                };

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckForExistingOffer(List<Publicacion> posts)
        {
            try
            {
                string query = "SELECT po.IdOferta, COUNT(*) FROM PublicacionOferta po " +
                               "INNER JOIN Oferta o ON po.IdOferta = o.IdOferta " +
                               "WHERE o.EstadoOferta = @EstadoOferta " +
                               "AND po.IdPublicacion IN ([Posts]) GROUP BY po.IdOferta " +
                               "HAVING COUNT(*) = @PostsCount;";

                string postsIds = "";
                foreach (var p in posts)
                {
                    postsIds += $"{p.IdPublicacion}, ";
                }
                postsIds = postsIds.Substring(0, postsIds.Length - 2);

                query = query.Replace("[Posts]", postsIds);

                var result = _context.Select(query,
                    new SqlParameter("@PostsCount", posts.Count),
                    new SqlParameter("@EstadoOferta", EnumOfertas.EstadoOferta.Pendiente));

                return result.Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
