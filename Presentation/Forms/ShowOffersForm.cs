using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio.Domain;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.IndividualComponents;

namespace Presentation.Forms
{
    public partial class ShowOffersForm : Form
    {
        private readonly IOfferService _offerService;
        private OfferFilter _currentFilter;

        public ShowOffersForm(
            IOfferService offerService
            )
        {
            _offerService = offerService;
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
    }
}
