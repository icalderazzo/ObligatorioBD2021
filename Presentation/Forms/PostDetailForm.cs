using System;
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
                Hide();
            }
        }
    }
}
