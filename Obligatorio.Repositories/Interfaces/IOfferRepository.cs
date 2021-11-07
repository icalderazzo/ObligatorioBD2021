using Obligatorio.Domain.Model;

namespace Obligatorio.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository<Oferta>
    {
        void UpdateOfferState(Oferta entity);
    }
}
