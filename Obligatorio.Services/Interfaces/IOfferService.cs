using Obligatorio.Domain.Model;
using System.Collections.Generic;
using Obligatorio.Domain;

namespace Obligatorio.Services.Interfaces
{
    public interface IOfferService : IService<Oferta>
    {
        /// <summary>
        /// Filtrar ofertas, con un estado determinado, en las que participa un usuario con un rol específico.
        /// </summary>
        /// <param name="filter">Filtro con: ciUsuario, RolOferta, EstadoOferta</param>
        /// <returns>Listado de ofertas filtradas</returns>
        List<Oferta> FilterOffers(OfferFilter filter);
        public void AcceptOffer(Oferta offer);
        public void CancelOffer(Oferta offer);
    }
}