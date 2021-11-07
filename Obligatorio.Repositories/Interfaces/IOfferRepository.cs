using Obligatorio.Domain.Model;
using Obligatorio.Domain;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Oferta>
    {
        List<Oferta> getOffersByParams(int ciUser, int userRoleInOffers, int offerStatus);

        Oferta hasCounterOffer(long idOferr);
        void UpdateOfferState(long idOffer, EnumOfertas.EstadoOferta state);
        int GetOfferCi(long idOffer, bool isSender);
    }
}
