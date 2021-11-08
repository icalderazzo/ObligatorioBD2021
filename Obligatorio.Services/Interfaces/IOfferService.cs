using Obligatorio.Domain.Model;
using System.Collections.Generic;
using Obligatorio.Domain;

namespace Obligatorio.Services.Interfaces
{
    public interface IOfferService : IService<Oferta>
    {
        List<Oferta> FilterOffers(OfferFilter filter);
        public void AcceptOffer(Oferta offer);
        public void CancelOffer(Oferta offer);
    }
}