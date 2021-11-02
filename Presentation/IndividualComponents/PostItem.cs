using System;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Presentation.CustomEvents;

namespace Presentation.IndividualComponents
{
    public partial class PostItem : UserControl
    {
        private readonly Publicacion _publicacion;
        public event EventHandler ShowDetail_Click;

        public PostItem()
        {
            InitializeComponent();
        }
        public PostItem(Publicacion publicacion)
        {
            _publicacion = publicacion;
            InitializeComponent();
        }

        private void PostItem_Load(object sender, EventArgs e)
        {
            //this.picBox.Image = Image.FromStream(new MemoryStream(_publicacion.Imagen));
            this.lblPostName.Text = _publicacion.Articulo.Nombre;
            this.lblPrice.Text = this.lblPrice.Text.Replace("[1000]", _publicacion.Articulo.Valor.ToString());
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (ShowDetail_Click != null)
            {
                this.ShowDetail_Click(this, new ShowPostDetailEventArgs(_publicacion));
            }
        }
    }
}
