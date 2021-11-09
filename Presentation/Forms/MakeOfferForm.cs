using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.CustomEvents;
using Presentation.IndividualComponents;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class MakeOfferForm : Form
    {
        private readonly IOfferService _offerService;
        private readonly IPostsService _postsService;
        private readonly IImageConverter _imageConverter;
        private List<Publicacion> _includedOfferPosts;

        public int ReceiversCi { get; set; }
        public Oferta CounteredOffer { get; set; }
        public List<Publicacion> IncludedPostOfferPosts
        {
            get { return _includedOfferPosts; }
            set
            {
                _includedOfferPosts = value;
            }
        }

        public MakeOfferForm(
            IOfferService offerService,
            IPostsService postsService,
            IImageConverter imageConverter
            )
        {
            _offerService = offerService;
            _postsService = postsService;
            _imageConverter = imageConverter;
            _includedOfferPosts = new List<Publicacion>();
            InitializeComponent();
        }

        private async void MakeOfferForm_Shown(object sender, EventArgs e)
        {
            await LoadPage();
        }

        private async Task LoadPage()
        {
            var aciveUserPosts = await Task.Run(() => _postsService.ListPostsOfUser(Global.LoggedUser.Cedula));

            if (aciveUserPosts.Count == 0)
            {
                MessageBox.Show("Aún no tienes articulos publicados, no puedes realizar ofertas", "Advertencia");
                Hide();
                return;
            }

            var receiversPosts = await Task.Run(() => _postsService.ListPostsOfUser(ReceiversCi));

            LoadSelectPostItems(aciveUserPosts, this.flowPanelActiveUserPosts);
            LoadSelectPostItems(receiversPosts, this.flowLayoutPanel2);
        }

        private void LoadSelectPostItems(List<Publicacion> posts, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            foreach (var post in posts)
            {
                var postItem = new SelectPostItem(post, _imageConverter.ConvertFromByteArray(post.Imagen), includeInOffer: IsIncluded(post.IdPublicacion));
                postItem.Check_IncludeInOffer += OnPostChecked;
                postItem.Check_ExcludeInOffer += OnPostUnchecked;
                panel.Controls.Add(postItem);
            }
        }

        private bool IsIncluded(long postId)
        {
            return _includedOfferPosts.FirstOrDefault(p => p.IdPublicacion == postId) != null;
        }

        private void OnPostChecked(object sender, EventArgs e)
        {
            var includedPost = ((PostEventArgs)e).Post;
            _includedOfferPosts.Add(includedPost);
        }

        private void OnPostUnchecked(object sender, EventArgs e)
        {
            var excludedPost = ((PostEventArgs)e).Post;
            _includedOfferPosts.Remove(_includedOfferPosts.FirstOrDefault(p =>
                p.IdPublicacion == excludedPost.IdPublicacion)
            );
        }

        private void MakeOfferForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelOffer_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar la oferta?", "Salir", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                flowLayoutPanel2.Controls.Clear();
                flowPanelActiveUserPosts.Controls.Clear();
                Hide();
            }
        }

        private void btnMakeOffer_Click(object sender, EventArgs e)
        {
            try
            {
                var sendersPosts = _includedOfferPosts.Where(p => p.Propietario.Cedula == Global.LoggedUser.Cedula).ToList();
                var receiversPosts = _includedOfferPosts.Where(p => p.Propietario.Cedula == ReceiversCi).ToList();

                var newOffer = new Oferta()
                {
                    UsuarioEmisor = new Usuario()
                    {
                        Cedula = Global.LoggedUser.Cedula
                    },
                    UsuarioDestinatario = new Usuario()
                    {
                        Cedula = ReceiversCi
                    },
                    PublicacionesEmisor = sendersPosts,
                    PublicacionesDestinatario = receiversPosts,
                    TransaccionContraofertada = CounteredOffer
                };

                _offerService.Create(newOffer);

                CounteredOffer = null;
                _includedOfferPosts = new List<Publicacion>();

                MessageBox.Show("La oferta ha sido realizada exitosamente!", "Éxito");
                Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MakeOfferForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                flowLayoutPanel2.Controls.Clear();
                flowPanelActiveUserPosts.Controls.Clear();
                Hide();
            }
        }
    }
}
