using Obligatorio.Domain.Model;
using System;
using System.Windows.Forms;
using Obligatorio.Domain;
using System.Collections.Generic;
using System.Text;
using static Presentation.Constant.Styles;
using Presentation.CustomEvents;

namespace Presentation.IndividualComponents
{
    public partial class OfferItem : UserControl
    {
        private readonly Oferta _offer;
        private readonly EnumOfertas.EstadoOferta _offerStatus;
        private readonly EnumRoles.RolOferta _offerRole;

        public EventHandler AcceptOfferEventHandler;
        public EventHandler RejectOfferEventHandler;
        public EventHandler CounterOfferEventHandler;
        public EventHandler ViewOfferDetailEventHandler;

        public OfferItem(
            Oferta offer, 
            EnumOfertas.EstadoOferta offerStatus, 
            EnumRoles.RolOferta offerRole) 
        {
            _offer = offer;
            _offerStatus = offerStatus;
            _offerRole = offerRole;
            InitializeComponent();
        }

        private void OfferItem_Load(object sender, EventArgs e)
        {
            switch (_offerRole)
            {
                case EnumRoles.RolOferta.Emisor:
                    lblSubTitle.Text = lblSubTitle.Text.Replace("[OfferSubtitle]", "Has ofertado por ");
                    LoadPostsList(_offer.PublicacionesDestinatario);
                    break;
                case EnumRoles.RolOferta.Destinatario:
                    lblSubTitle.Text = lblSubTitle.Text.Replace("[OfferSubtitle]", "Has recibido una oferta por ");
                    LoadPostsList(_offer.PublicacionesEmisor);
                    break;
                default:
                    break;
            }

            switch (_offerStatus)
            {
                case EnumOfertas.EstadoOferta.Pendiente:
                    if (_offer.TransaccionContraofertada != null)
                    {
                        lblTitle.Text = "Contraoferta pendiente";
                    }
                    else
                    {
                        lblTitle.Text = "Oferta pendiente";
                    }
                    bannerColorPanel.BackColor = PendingOfferColor;
                    btnAccpetOffer.Visible = true;
                    btnRejectOffer.Visible = true;
                    btnCounterOffer.Visible = true;
                    break;
                case EnumOfertas.EstadoOferta.Completada:
                    lblTitle.Text = "Oferta completada";
                    bannerColorPanel.BackColor = CompletedOfferColor;
                    break;
                case EnumOfertas.EstadoOferta.Rechazada:
                    lblTitle.Text = "Oferta rechazada";
                    bannerColorPanel.BackColor = RejectedOfferColor;
                    break;
                default:
                    break;
            }
        }

        private void LoadPostsList(List<Publicacion> posts)
        {
            lblPostsLists.Text = "";
            var sb = new StringBuilder();
            foreach (var item in posts)
                sb.AppendLine($"- {item.Articulo.Nombre}");

            lblPostsLists.Text = sb.ToString();
        }

        private void btnViewOfferDetail_Click(object sender, EventArgs e)
        {
            if (ViewOfferDetailEventHandler != null)
            {
                this.ViewOfferDetailEventHandler(this, new OfferEventArgs(_offer));
            }
        }

        private void btnCounterOffer_Click(object sender, EventArgs e)
        {
            if (CounterOfferEventHandler != null)
            {
                this.CounterOfferEventHandler(this, new OfferEventArgs(_offer));
            }
        }

        private void btnRejectOffer_Click(object sender, EventArgs e)
        {
            if (RejectOfferEventHandler != null)
            {
                this.RejectOfferEventHandler(this, new OfferEventArgs(_offer));
            }
        }

        private void btnAccpetOffer_Click(object sender, EventArgs e)
        {
            if (AcceptOfferEventHandler != null)
            {
                this.AcceptOfferEventHandler(this, new OfferEventArgs(_offer));
            }
        }
    }
}
