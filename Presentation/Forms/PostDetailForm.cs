using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class PostDetailForm : Form
    {
        private Publicacion _activePost;
        private readonly MakeOfferForm _makeOfferForm;
        private readonly MakeOfferForSinglePostForm _makeOfferForSinglePostForm;
        private readonly IImageConverter _imageConverter;
        private readonly IPostsService _postsService;

        public Publicacion ActivePost
        {
            get { return _activePost; }
            set
            {
                _activePost = value;
                LoadPost();
            }
        }

        public PostDetailForm(
            MakeOfferForm makeOfferForm,
            MakeOfferForSinglePostForm makeOfferForSinglePostForm,
            IImageConverter imageConverter,
            IPostsService postsService)
        {
            _makeOfferForm = makeOfferForm;
            _makeOfferForSinglePostForm = makeOfferForSinglePostForm;
            _imageConverter = imageConverter;
            _postsService = postsService;
            InitializeComponent();
        }

        private void LoadPost()
        {
            pictureBox1.Image = null;
            var img = _imageConverter.ConvertFromByteArray(_activePost.Imagen);

            if (img != null)
                pictureBox1.Image = img;

            lblPostName.Text = _activePost.Articulo.Nombre;
            lblPrice.Text = _activePost.Articulo.Valor.ToString();
            lblDescription.Text = _activePost.Articulo.Descripcion;
        }

        private async void btnMakeOffer_Click(object sender, EventArgs e)
        {
            try
            {
                var activeUsersPosts = await Task.Run(() => _postsService.ListPostsOfUser(Global.LoggedUser.Cedula));
                if (activeUsersPosts.Count == 0)
                {
                    MessageBox.Show("Aún no tienes publicaciones, no puedes realizar la oferta.");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("¿Desea solo ofertar por la publicación seleccionada?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    var otherUsersPosts = await Task.Run(() => _postsService.ListPostsOfUser(_activePost.Propietario.Cedula));
                    _makeOfferForm.IncludedPostOfferPosts = new List<Publicacion>() { _activePost };
                    _makeOfferForm.ActiveUserPosts = activeUsersPosts;
                    _makeOfferForm.OtherUsersPosts = otherUsersPosts;
                    _makeOfferForm.Receiver = _activePost.Propietario;

                    MessageBox.Show("A continuación se mostrarán las demás publicaciones del usuario");

                    _makeOfferForm.Show();
                    Hide();
                }
                else
                {
                    _makeOfferForSinglePostForm.DesiredPost = _activePost;
                    _makeOfferForSinglePostForm.ActiveUsersPosts = activeUsersPosts;
                    _makeOfferForSinglePostForm.Show();
                    Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ingresar a la creación de la oferta");
            }
        }

        private void PostDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                pictureBox1.Image = null;
                Hide();
            }
        }

        private void PostDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
