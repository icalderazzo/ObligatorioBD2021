using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using System.Collections.Generic;
using System;

namespace Obligatorio.Domain
{
    public class OfferValidator : IValidator<Oferta>
    {
        public (bool, string errorMessage) Validate(Oferta offer)
        {
            // Validate equal value in UCUCoins
            var postsOffered = offer.PublicacionesOfrecidas;
            var postsAsked = offer.PublicacionesDeseadas;
            int ucuCoinsOffered = 0;
            int ucuCoinsAsked = 0;

            for (int i = 0; i < postsOffered.Count; i++){ ucuCoinsOffered += postsOffered[i].Articulo.Valor; }

            for (int i = 0; i < postsAsked.Count; i++){ ucuCoinsAsked += postsAsked[i].Articulo.Valor; }

            if (ucuCoinsOffered != ucuCoinsAsked)
            {
                return (false, "El precio en UCUCoins de las publicaciónes ofrecidas debe ser igual al de las publicaciones deseadas");
            }
            else 
            {
                // If offer is a counterOffer --> validate offer != previousOffer
                if (offer.TransaccionContraofertada != null)
                {
                    // newOffer postsOffered are always equal to previousOffer postsAsked
                    // we have to validate that newOffer postsAsked are different from previousOffer postsOffered
                    var postsPreviouslyOffered = offer.TransaccionContraofertada.PublicacionesOfrecidas;

                    var postsDiffer = PostsAreDifferent(postsAsked, postsPreviouslyOffered);

                    if (postsDiffer) { return (true, ""); }
                    else { return (false, "La contraOferta debe ser distinta a la oferta original"); }
                }

                return (true, ""); 
            
            }
            
        }

        private bool PostsAreDifferent(List<Publicacion> posts1, List<Publicacion> posts2)
        {
            if (posts1.Count == posts2.Count)
            {
                // Generate arrays to put ids of posts
                long[] idsPosts1 = new long[posts1.Count];
                long[] idsPosts2 = new long[posts2.Count];

                // Fill arrays with ids
                for (int i = 0; i < posts1.Count; i++){ idsPosts1[i] = posts1[i].IdPublicacion; }
                for (int i = 0; i < posts2.Count; i++) { idsPosts2[i] = posts2[i].IdPublicacion; }

                // Compare arrays
                Array.Sort(idsPosts1);
                Array.Sort(idsPosts2);

                //If idsArrays are different method return true
                return (idsPosts1 != idsPosts2);
            }

            return true;
        }
    }
}
