using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Services.Interfaces;
using System.Collections.Generic;
using System;

namespace Obligatorio.Services.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IPostsService _postService;
        private readonly IUserService _userService;

        public OfferService(IOfferRepository offerRepository, IPostsService postsService, IUserService userService)
        {
            _postService = postsService;
            _offerRepository = offerRepository;
            _userService = userService;
        }
        public void Create(Oferta entity)
        {
            _offerRepository.Insert(entity);
        }

        public void Delete(string entityId)
        {
            throw new System.NotImplementedException();
        }

        public Oferta GetById(string entityId)
        {
            try
            {
                var offer = _offerRepository.GetById(entityId);
                offer.UsuarioEmisor = _userService.GetUserByRole(offer.IdOferta, (int)EnumRoles.RolOferta.Emisor);
                offer.UsuarioDestinatario = _userService.GetUserByRole(offer.IdOferta, (int)EnumRoles.RolOferta.Destinatatio);
                offer.PublicacionesDeseadas = _postService.GetPostsAsked(offer.UsuarioDestinatario.Cedula, offer.IdOferta);
                offer.PublicacionesOfrecidas = _postService.GetPostsOffered(offer.UsuarioDestinatario.Cedula, offer.IdOferta);
                offer.TransaccionContraofertada = _offerRepository.GetCounterOffer(offer.IdOferta);

                return offer;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">Usuario destinatario</param>
        /// <returns></returns>
        public List<Oferta> GetOffersRecieved(Usuario user)
        {
            // Obtain offers that the user recieved and are pending
            var offersRecieved = _offerRepository.GetOffersByParams(user.Cedula, (int)EnumRoles.RolOferta.Destinatatio, (int)EnumOfertas.EstadoOferta.Pendiente);

            foreach (var offer in offersRecieved)
            {
                offer.UsuarioEmisor = _userService.GetUserByRole(offer.IdOferta, (int)EnumRoles.RolOferta.Emisor);
                offer.PublicacionesDeseadas = _postService.GetPostsAsked(user.Cedula, offer.IdOferta);
                offer.PublicacionesOfrecidas = _postService.GetPostsOffered(user.Cedula, offer.IdOferta);
                offer.TransaccionContraofertada = _offerRepository.GetCounterOffer(offer.IdOferta);
            }

            return offersRecieved;

        }

        public ICollection<Oferta> List()
        {
            throw new System.NotImplementedException();
        }

        public void Modify(Oferta entity)
        {
            throw new System.NotImplementedException();
        }

        public void AcceptOffer(Oferta offer)
        {
            _offerRepository.UpdateOfferState(offer.IdOferta, EnumOfertas.EstadoOferta.Completada);

            foreach (Publicacion pub in offer.PublicacionesDeseadas)
                _postService.UpdatePostState(pub.IdPublicacion, false);

            foreach (Publicacion pub in offer.PublicacionesOfrecidas)
                _postService.UpdatePostState(pub.IdPublicacion, false);

            //Enviar mail a destinatario
        }

        public void CancelOffer(Oferta offer)
        {
            _offerRepository.UpdateOfferState(offer.IdOferta, EnumOfertas.EstadoOferta.Rechazada);
        }

    }

}