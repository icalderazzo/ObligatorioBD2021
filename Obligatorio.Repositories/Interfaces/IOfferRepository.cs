using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Oferta>
    {
        List<Oferta> GetOffersByParams(int ciUser, int userRoleInOffers, int offerStatus);
        Oferta GetCounterOffer(long idOferr);
        void UpdateOfferState(long idOffer, EnumOfertas.EstadoOferta state);
    }
}
