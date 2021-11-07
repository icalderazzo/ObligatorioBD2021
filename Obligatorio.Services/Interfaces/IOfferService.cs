using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Services.Interfaces
{
    public interface IOfferService : IService<Oferta>
    {
        List<Oferta> GetOffersRecieved(Usuario user);
        public void AcceptOffer(Oferta offer);
        public void CancelOffer(Oferta offer);
    }
}