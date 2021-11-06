using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System.Collections.Generic;
using Obligatorio.Repositories.Interfaces;

namespace Obligatorio.Services.Services{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public void Create(Oferta entity)
        {
            // Test without previousOffer (OfferId = 4)
            var offer = new Oferta() 
            {
                IdOferta = 4,
                UsuarioDestinatario = new Usuario() {Cedula= 11111111},
                UsuarioEmisor = new Usuario() { Cedula = 44444444 },
                PublicacionesDeseadas = new List<Publicacion>() 
                { 
                    new Publicacion() {IdPublicacion= 1},
                    new Publicacion() {IdPublicacion= 2}
                },
                PublicacionesOfrecidas = new List<Publicacion>()
                {
                    new Publicacion() {IdPublicacion= 3},
                    new Publicacion() {IdPublicacion= 4}
                }
            };

            // Test with previousOffer (OfferId = 5)
            var offer2 = new Oferta()
            {
                UsuarioDestinatario = new Usuario() { Cedula = 44444444 },
                UsuarioEmisor = new Usuario() { Cedula = 11111111 },
                PublicacionesDeseadas = new List<Publicacion>()
                {
                    new Publicacion() {IdPublicacion= 6}
                },
                PublicacionesOfrecidas = new List<Publicacion>()
                {
                    new Publicacion() {IdPublicacion= 1},
                    new Publicacion() {IdPublicacion= 2}
                },
                TransaccionContraofertada = offer
                
            };

            _offerRepository.Insert(offer2);
        }

        public void Delete(string entityId)
        {
            throw new System.NotImplementedException();
        }

        public Oferta GetById(string entityId)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Oferta> List()
        {
            throw new System.NotImplementedException();
        }

        public void Modify(Oferta entity)
        {
            throw new System.NotImplementedException();
        }
    }

}