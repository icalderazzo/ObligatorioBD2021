using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.CustomEvents;
using Presentation.IndividualComponents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class ShowOffersForm : Form
    {
        private readonly IOfferService _offerService;
        private readonly IPostsService _postsService;
        private readonly MakeOfferForm _makeOfferForm;
        private readonly OfferDetailForm _offerDetailForm;
        private OfferFilter _currentFilter;
        private Oferta _counteredOffer;

        public ShowOffersForm(
            IOfferService offerService,
            IPostsService postsService,
            MakeOfferForm makeOfferForm,
            OfferDetailForm offerDetailForm
            )
        {
            _offerService = offerService;
            _postsService = postsService;
            _makeOfferForm = makeOfferForm;
            _offerDetailForm = offerDetailForm;
            InitializeComponent();
        }

        private async void ShowOffersForm_Load(object sender, EventArgs e)
        {
            var offers = await FilterOffersAsync();
            LoadOffers(offers);
            LoadCmbWithEnum<EnumOfertas.EstadoOferta>(cmbOfferState);
            LoadCmbWithEnum<EnumRoles.RolOferta>(cmbRole);

            cmbOfferState.SelectedValue = (int)EnumOfertas.EstadoOferta.Pendiente;
            cmbRole.SelectedValue = (int)EnumRoles.RolOferta.Destinatario;
        }

        private void LoadOffers(List<Oferta> offers)
        {
            if (offers == null)
                return;

            flowOffersPanel.Controls.Clear();

            foreach (var offer in offers)
            {
                var offerItem = new OfferItem(offer, _currentFilter.OfferState, _currentFilter.UsersRole);
                offerItem.AcceptOfferEventHandler += new EventHandler(AcceptOffer);
                offerItem.RejectOfferEventHandler += new EventHandler(RejectOffer);
                offerItem.CounterOfferEventHandler += new EventHandler(CounterOffer);
                offerItem.ViewOfferDetailEventHandler += new EventHandler(ShowOfferDetail);
                flowOffersPanel.Controls.Add(offerItem);
            }
        }

        private void LoadCmbWithEnum<T>(ComboBox cmb)
        {
            List<KeyValuePair<string, int>> valuesList = new();
            Array values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                if ((int)value > 0)
                    valuesList.Add(new KeyValuePair<string, int>(value.ToString(), (int)value));
            }
            cmb.DataSource = valuesList;
            cmb.DisplayMember = "Key";
            cmb.ValueMember = "Value";
        }

        private async Task<List<Oferta>> FilterOffersAsync()
        {
            try
            {
                if (_currentFilter == null)
                    _currentFilter = new OfferFilter()
                    {
                        UserCi = Global.LoggedUser.Cedula,
                        UsersRole = EnumRoles.RolOferta.Destinatario,
                        OfferState = EnumOfertas.EstadoOferta.Pendiente
                    };

                var results = await Task.Run(() => _offerService.FilterOffers(_currentFilter));
                return results;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al filtrar ofertas");
                return null;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            _currentFilter.UsersRole = (EnumRoles.RolOferta)cmbRole.SelectedValue;
            _currentFilter.OfferState = (EnumOfertas.EstadoOferta)cmbOfferState.SelectedValue;
            LoadOffers(await FilterOffersAsync());
        }

        #region EventHandlers
        protected async void AcceptOffer(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea aceptar la oferta seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            try
            {
                var offer = ((OfferEventArgs)e).Offer;
                await Task.Run(() => _offerService.AcceptOffer(offer));

                MessageBox.Show("La oferta ha sido aceptada con éxito");

                var offers = await Task.Run(() => _offerService.FilterOffers(_currentFilter)); // vuelvo a obtener pendientes
                LoadOffers(offers);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al aceptar la oferta");
            }
        }
        protected async void RejectOffer(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea rechazar la oferta seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            try
            {
                var offer = ((OfferEventArgs)e).Offer;
                await Task.Run(() => _offerService.CancelOffer(offer));

                var offers = await Task.Run(() => _offerService.FilterOffers(_currentFilter)); // vuelvo a obtener pendientes
                LoadOffers(offers);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al rechazar la oferta");
            }


        }
        protected async void CounterOffer(object sender, EventArgs e)
        {
            try
            {
                _counteredOffer = ((OfferEventArgs)e).Offer;
                var includedPosts = new List<Publicacion>();

                // set included post in original offer to see them checked
                foreach (var post in _counteredOffer.PublicacionesDestinatario)
                {
                    includedPosts.Add(new Publicacion()
                    {
                        IdPublicacion = post.IdPublicacion,
                        Propietario = new Usuario() { Cedula = post.Propietario.Cedula },
                        Articulo = new Articulo()
                        {
                            Nombre = post.Articulo.Nombre,
                            Valor = post.Articulo.Valor
                        }
                    });
                }
                foreach (var post in _counteredOffer.PublicacionesEmisor)
                {
                    includedPosts.Add(new Publicacion()
                    {
                        IdPublicacion = post.IdPublicacion,
                        Propietario = new Usuario() { Cedula = post.Propietario.Cedula },
                        Articulo = new Articulo()
                        {
                            Nombre = post.Articulo.Nombre,
                            Valor = post.Articulo.Valor
                        }
                    });
                }
                _makeOfferForm.IncludedOfferPosts = includedPosts;

                // set counter offer
                _makeOfferForm.CounteredOffer = _counteredOffer;
                //set receiver user
                _makeOfferForm.Receiver = _counteredOffer.UsuarioEmisor;

                // Load all posts of users
                _makeOfferForm.CounterofferPosts = _counteredOffer.PublicacionesDestinatario;
                _makeOfferForm.OtherUsersPosts = await Task.Run(() => _postsService.ListPostsOfUser(_counteredOffer.UsuarioEmisor.Cedula));

                _makeOfferForm.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void ShowOfferDetail(object sender, EventArgs e)
        {
            var offer = ((OfferEventArgs)e).Offer;

            if (offer.UsuarioEmisor.Cedula == Global.LoggedUser.Cedula) //Usuario activo es emisor
            {
                _offerDetailForm.ActiveUsersPosts = offer.PublicacionesEmisor;
                _offerDetailForm.OtherUsersPosts = offer.PublicacionesDestinatario;
            }
            else
            {
                _offerDetailForm.ActiveUsersPosts = offer.PublicacionesDestinatario;
                _offerDetailForm.OtherUsersPosts = offer.PublicacionesEmisor;
            }

            _offerDetailForm.Show();
        }
        #endregion
    }
}
