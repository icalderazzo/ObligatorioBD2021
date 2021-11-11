using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using System.Collections.Generic;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Oferta>
    {
        List<Oferta> FilterOffers(OfferFilter filter);
        Oferta GetCounterOffer(long idOferr);
        void UpdateOfferState(long idOffer, EnumOfertas.EstadoOferta state);
        Usuario GetUserByRole(EnumRoles.RolOferta usersRole, long idOffer);
        bool CheckForExistingOffer(List<Publicacion> posts);
    }
}
