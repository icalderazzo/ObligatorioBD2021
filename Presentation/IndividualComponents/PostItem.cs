using Obligatorio.Domain.Model;
using Presentation.CustomEvents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.IndividualComponents
{
    public partial class PostItem : UserControl
    {
        private readonly Publicacion _publicacion;
        public event EventHandler ShowDetail_Click;
        private readonly Image _image;

        public PostItem()
        {
            InitializeComponent();
        }
        public PostItem(Publicacion publicacion, Image image)
        {
            _publicacion = publicacion;
            _image = image;
            InitializeComponent();
        }

        private void PostItem_Load(object sender, EventArgs e)
        {
            if (_image != null)
                this.picBox.Image = _image;

            this.lblPostName.Text = _publicacion.Articulo.Nombre;
            this.lblPrice.Text = this.lblPrice.Text.Replace("[1000]", _publicacion.Articulo.Valor.ToString());
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (ShowDetail_Click != null)
            {
                this.ShowDetail_Click(this, new PostEventArgs(_publicacion));
            }
        }
    }
}
