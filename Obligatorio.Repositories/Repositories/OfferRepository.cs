﻿using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using System.Collections.Generic;
using DatabaseInterface;
using System.Data.SqlClient;
using Obligatorio.Domain;
using System;

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
    }
}
