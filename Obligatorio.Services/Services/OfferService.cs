using Obligatorio.Domain.Model;
using Obligatorio.Domain;
using Obligatorio.Services.Interfaces;
using System.Collections.Generic;
using Obligatorio.Repositories.Interfaces;
using Obligatorio.Domain;

namespace Obligatorio.Services.Services{
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
            throw new System.NotImplementedException();
        }

        public List<Oferta> GetOffersRecieved(Usuario user)
        {
            // Obtain offers that the user recieved and are pending
            var offersRecieved = _offerRepository.getOffersByParams(user.Cedula, (int)EnumRoles.RolOferta.Destinatatio, (int)EnumOfertas.EstadoOferta.Pendiente);
            
            foreach (var offer in offersRecieved)
            {
                offer.UsuarioEmisor = _userService.GetUserByRole(offer.IdOferta, (int)EnumRoles.RolOferta.Emisor);
                offer.PublicacionesDeseadas = _postService.GetPostsAsked(user.Cedula, offer.IdOferta);
                offer.PublicacionesOfrecidas = _postService.GetPostsOffered(user.Cedula, offer.IdOferta);
                offer.TransaccionContraofertada = _offerRepository.hasCounterOffer(offer.IdOferta);
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

        public void ModifyOfferState(Oferta entity)
        {
            _offerRepository.UpdateOfferState(entity);
        }
    }

}