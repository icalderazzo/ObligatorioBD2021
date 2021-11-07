using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Presentation.Utils;

namespace Presentation.Forms
{
    public partial class PostDetailForm : Form
    {
        private Publicacion _activePost;
        private readonly MakeOfferForm _makeOfferForm;
        private readonly IImageConverter _imageConverter;
        
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
            IImageConverter imageConverter)
        {
            _makeOfferForm = makeOfferForm;
            _imageConverter = imageConverter;
            InitializeComponent();
        }

        private void LoadPost()
        {
            var img = _imageConverter.ConvertFromByteArray(_activePost.Imagen);

            if (img != null)
                pictureBox1.Image = img;

            lblPostName.Text = _activePost.Articulo.Nombre;
            lblPrice.Text = _activePost.Articulo.Valor.ToString();
            lblDescription.Text = _activePost.Articulo.Descripcion;
        }

        private void btnMakeOffer_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea solo ofertar por la publicación seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("A continuación se mostrarán las demás publicaciones del usuario");
                //CreateOffer
                _makeOfferForm.ReceiversCi = _activePost.Propietario.Cedula;
                _makeOfferForm.IncludedPostOfferPosts = new List<Publicacion>() { this._activePost };
                _makeOfferForm.Show();
            }
            else
            {
                // List my posts
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
