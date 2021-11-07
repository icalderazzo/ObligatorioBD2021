using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System.Collections.Generic;
using DatabaseInterface;
using System.Data.SqlClient;
using Obligatorio.Domain;
using System;
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
            throw new System.NotImplementedException();
        }

        public List<Oferta> getOffersByParams(int ciUser, int userRoleInOffers, int offerStatus)
        {
            try
            {
                var query = "select UsuarioOferta.IdOferta, Oferta.FechaRealizacion from UsuarioOferta " +
                            "inner join RolOferta on UsuarioOferta.IdRolOferta = RolOferta.IdRolOferta " +
                            "inner join Oferta on UsuarioOferta.IdOferta = Oferta.IdOferta " +
                            "where CiUsuario = @ciUser and UsuarioOferta.IdRolOferta = @userRoleInOffers and Oferta.EstadoOferta = @offerStatus";

                var offersLines = _context.Select(query,
                    new SqlParameter("@ciUser", ciUser),
                    new SqlParameter("@userRoleInOffers", userRoleInOffers),
                    new SqlParameter("@offerStatus", offerStatus)
                );

                List<Oferta> offers = new List<Oferta>(); 

                for (int i = 0; i < offersLines.Count; i++)
                {
                    var offersLine = offersLines[i];
                    
                    Oferta offer = new Oferta()
                    {
                        IdOferta = long.Parse(offersLine[0].ToString()),
                        Fecha = DateTime.Parse(offersLine[1].ToString()),
                    };

                    offers.Add(offer);
                }

                return offers;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Oferta hasCounterOffer(long idOferr)
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
                    var queryUpdateState = "UPDATE Oferta SET EstadoOferta = @estadoInactivo WHERE IdOferta = @IdOfertaAnterior";
                    _context.SaveData(
                        tran, queryUpdateState,
                        new SqlParameter("@estadoInactivo", EnumOfertas.EstadoOferta.Rechazada),
                        new SqlParameter("@IdOfertaAnterior", model.TransaccionContraofertada.IdOferta)
                    );
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
                    new SqlParameter("@IdRolOferta", EnumRoles.RolOferta.Destinatatio),
                    new SqlParameter("@CiUsuario", model.UsuarioDestinatario.Cedula)
                );
                // Insert sender posts in PublicacionOferta
                foreach (var publicacion in model.PublicacionesOfrecidas)
                {
                    var query = "insert into PublicacionOferta (IdPublicacion, IdOferta) values (@IdPublicacion, @IdOfertaNueva)";
                    _context.SaveData(
                        tran, query,
                        new SqlParameter("@IdPublicacion", publicacion.IdPublicacion),
                        new SqlParameter("@IdOfertaNueva", model.IdOferta)
                    );
                }
                // Insert reciever posts in PublicacionOferta
                foreach (var publicacion in model.PublicacionesDeseadas)
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

        public void UpdateOfferState(Oferta model)
        {
            try
            {
                var tran = _context.BeginTransaction();
                if (model.Estado == EnumOfertas.EstadoOferta.Completada)
                {
                    var queryCompletada = "UPDATE Oferta SET EstadoOferta=@EstadoOferta WHERE IdOferta=@IdOferta;";
                    _context.SaveData(
                        tran, queryCompletada,
                        new SqlParameter("@EstadoOferta", EnumOfertas.EstadoOferta.Completada),
                        new SqlParameter("@IdOferta", model.IdOferta)
                    );

                    // Updatea estado publicaciones ofrecidas
                    foreach (var publicacion in model.PublicacionesOfrecidas)
                    {
                        var queryPubOfrecida = "UPDATE Publicacion SET Estado=0 WHERE IdPublicacion = @IdPublicacion;";
                        _context.SaveData(
                            tran, queryPubOfrecida,
                            new SqlParameter("@IdPublicacion", publicacion.IdPublicacion)
                        );
                        publicacion.Estado = false;
                    }
                    // Updatea estado publicaciones deseadas
                    foreach (var publicacion in model.PublicacionesDeseadas)
                    {
                        var queryPubDeseada = "UPDATE Publicacion SET Estado=0 WHERE IdPublicacion = @IdPublicacion;";
                        _context.SaveData(
                            tran, queryPubDeseada,
                            new SqlParameter("@IdPublicacion", publicacion.IdPublicacion)
                        );
                        publicacion.Estado = false;
                    }
                    _context.Commit(tran);
                }
                else if (model.Estado == EnumOfertas.EstadoOferta.Rechazada)
                {
                    var queryCompletada = "UPDATE Oferta SET EstadoOferta=@EstadoOferta WHERE IdOferta=@IdOferta;";
                    _context.SaveData(
                        tran, queryCompletada,
                        new SqlParameter("@EstadoOferta", EnumOfertas.EstadoOferta.Rechazada),
                        new SqlParameter("@IdOferta", model.IdOferta)
                    );
                    _context.Commit(tran);
                }                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
