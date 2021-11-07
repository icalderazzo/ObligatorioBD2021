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
    public partial class MakeOfferForSinglePostForm : Form
    {
        private readonly IPostsService _postsService;
        private readonly IOfferService _offerService;
        private readonly IImageConverter _imageConverter;
        private List<Publicacion> _includedOfferPosts;
        public Publicacion DesiredPost { get; set; }

        public MakeOfferForSinglePostForm(
            IPostsService postsService,
            IOfferService offerService,
            IImageConverter imageConverter
            )
        {
            _postsService = postsService;
            _offerService = offerService;
            _imageConverter = imageConverter;
            _includedOfferPosts = new List<Publicacion>();
            InitializeComponent();
        }
        private async void MakeOfferForSinglePostForm_Load(object sender, EventArgs e)
        {
            await LoadPage();
        }

        private async Task LoadPage()
        {
            try
            {
                var activeUserPosts = await Task.Run(() => _postsService.ListPostsOfUser(Global.LoggedUser.Cedula));

                if (activeUserPosts.Count == 0)
                {
                    MessageBox.Show("Aún no tienes articulos publicados, no puedes realizar ofertas", "Advertencia");
                    Hide();
                    return;
                }

                ShowActiveUserPosts(activeUserPosts);
                ShowDesiredPost(DesiredPost);
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado");
            }
        }

        private void ShowActiveUserPosts(List<Publicacion> posts)
        {
            flowPanelActiveUserPosts.Controls.Clear();
            foreach (var post in posts)
            {
                var selectPostItem = new SelectPostItem(
                    post,
                    includeInOffer: false,
                    image: _imageConverter.ConvertFromByteArray(post.Imagen)
                );

                selectPostItem.Check_IncludeInOffer += OnPostChecked;
                selectPostItem.Check_ExcludeInOffer += OnPostUnchecked;

                flowPanelActiveUserPosts.Controls.Add(selectPostItem);
            }
        }

        private void ShowDesiredPost(Publicacion post)
        {
            flowPanelDesiredPost.Controls.Add(new PostItem(post, _imageConverter.ConvertFromByteArray(post.Imagen)));
        }

        private void btnCancelOffer_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar la oferta?", "Salir", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                flowPanelActiveUserPosts.Controls.Clear();
                flowPanelDesiredPost.Controls.Clear();
                Hide();
            }
        }

        private void btnMakeOffer_Click(object sender, EventArgs e)
        {
            try
            {
                var offer = new Oferta()
                {
                    PublicacionesOfrecidas = _includedOfferPosts,
                    PublicacionesDeseadas = new List<Publicacion>() { DesiredPost },
                    UsuarioEmisor = new Usuario()
                    {
                        Cedula = Global.LoggedUser.Cedula
                    },
                    UsuarioDestinatario = new Usuario()
                    {
                        Cedula = DesiredPost.Propietario.Cedula
                    }
                };

                _offerService.Create(offer);

                MessageBox.Show("Oferta realiza correctamente", "Éxito");
                DesiredPost = null;
                _includedOfferPosts.Clear();
                Hide();
            }
            catch (Exception)
            {
                throw;
            }
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

        private void MakeOfferForSinglePostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                flowPanelDesiredPost.Controls.Clear();
                flowPanelActiveUserPosts.Controls.Clear();
                Hide();
            }
        }
    }
}
