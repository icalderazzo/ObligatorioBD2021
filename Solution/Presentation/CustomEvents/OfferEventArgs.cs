
using Obligatorio.Domain.Model;
using System;

namespace Presentation.CustomEvents
{
    public class OfferEventArgs : EventArgs
    {
        public Oferta Offer { get; set; }

        public OfferEventArgs()
        {

        }

        public OfferEventArgs(Oferta offer)
        {
            Offer = offer;
        }
    }
}
