using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.CustomEvents;
using Presentation.IndividualComponents;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class MakeOfferForSinglePostForm : Form
    {
        private readonly IOfferService _offerService;
        private readonly IImageConverter _imageConverter;
        private List<Publicacion> _includedOfferPosts;
        private Publicacion _desiredPost;
        private List<Publicacion> _activeUsersPosts;
        public Publicacion DesiredPost
        {
            get { return _desiredPost; }
            set
            {
                _desiredPost = value;
                ShowDesiredPost(value);
            }
        }
        public List<Publicacion> ActiveUsersPosts
        {
            get { return _activeUsersPosts; }
            set
            {
                _activeUsersPosts = value;
                ShowActiveUserPosts(value);
            }
        }

        public MakeOfferForSinglePostForm(
            IOfferService offerService,
            IImageConverter imageConverter)
        {
            _offerService = offerService;
            _imageConverter = imageConverter;
            _includedOfferPosts = new List<Publicacion>();
            InitializeComponent();
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
                    PublicacionesEmisor = _includedOfferPosts.ToList(), //clonar lista
                    PublicacionesDestinatario = new List<Publicacion>() { DesiredPost },
                    UsuarioEmisor = new Usuario()
                    {
                        Cedula = Global.LoggedUser.Cedula,
                        Nombre = Global.LoggedUser.Nombre,
                        Apellido = Global.LoggedUser.Apellido,
                        Correo = Global.LoggedUser.Correo
                    },
                    UsuarioDestinatario = new Usuario()
                    {
                        Cedula = DesiredPost.Propietario.Cedula,
                        Nombre = DesiredPost.Propietario.Nombre,
                        Apellido = DesiredPost.Propietario.Apellido,
                        Correo = DesiredPost.Propietario.Correo
                    }
                };

                _offerService.Create(offer);

                MessageBox.Show("Oferta realizada correctamente", "Éxito");
                Hide();
                _includedOfferPosts.Clear();
                _activeUsersPosts.Clear();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
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
