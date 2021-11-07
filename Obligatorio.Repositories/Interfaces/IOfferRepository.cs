using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Oferta>
    {
        List<Oferta> getOffersByParams(int ciUser, int userRoleInOffers, int offerStatus);

        Oferta hasCounterOffer(long idOferr);
    }
}
