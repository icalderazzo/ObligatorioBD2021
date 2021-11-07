using Obligatorio.Domain.Model;

namespace Obligatorio.Services.Interfaces
{
    public interface IOfferService : IService<Oferta>
    {
        void ModifyOfferState(Oferta entity);
    }
}