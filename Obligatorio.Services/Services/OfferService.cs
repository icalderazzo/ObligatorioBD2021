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