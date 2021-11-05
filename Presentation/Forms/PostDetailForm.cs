using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Obligatorio.Domain.Model;

namespace Presentation.Forms
{
    public partial class PostDetailForm : Form
    {
        private Publicacion _activePost;
        
        public Publicacion ActivePost 
        {
            get { return _activePost; } 
            set
            {
                _activePost = value;
                LoadPost();
            }
        }

        public PostDetailForm()
        {
            InitializeComponent();
        }

        private void LoadPost()
        {
            var imgbytes = _activePost.Imagen.Length == 0 ? null : _activePost.Imagen;
            var img = imgbytes != null ? Image.FromStream(new MemoryStream(_activePost.Imagen)) : null;

            if (img != null)
                pictureBox1.Image = img;

            lblPostName.Text = _activePost.Articulo.Nombre;
            lblPrice.Text = _activePost.Articulo.Valor.ToString();
            lblDescription.Text = _activePost.Articulo.Descripcion;
        }

        private void btnMakeOffer_Click(object sender, EventArgs e)
        {
            //CreateOffer
        }

        private void btnShowUserProfile_Click(object sender, EventArgs e)
        {
            //Show form with owner's other post
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
    }
}
