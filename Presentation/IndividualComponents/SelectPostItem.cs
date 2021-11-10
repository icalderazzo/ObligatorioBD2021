using Obligatorio.Domain.Model;
using Presentation.CustomEvents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.IndividualComponents
{
    public partial class SelectPostItem : UserControl
    {
        private readonly Publicacion _publicacion;
        private readonly Image _postImage;
        public EventHandler Check_IncludeInOffer;
        public EventHandler Check_ExcludeInOffer;

        public SelectPostItem(Publicacion publicacion, Image image, bool includeInOffer, bool checkVisible = true)
        {
            _publicacion = publicacion;
            _postImage = image;
            InitializeComponent();
            this.chkIncludeInOffer.Visible = checkVisible;
            this.chkIncludeInOffer.Checked = includeInOffer;
        }

        private void chkIncludeInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeInOffer.Checked)
            {
                if (Check_IncludeInOffer != null)
                {
                    this.Check_IncludeInOffer(this, new PostEventArgs(_publicacion));
                }
            }
            else
            {
                if (Check_ExcludeInOffer != null)
                {
                    this.Check_ExcludeInOffer(this, new PostEventArgs(_publicacion));
                }
            }
        }

        private void SelectPostItem_Load(object sender, EventArgs e)
        {
            lblName.Text = _publicacion.Articulo.Nombre;
            lblValue.Text = _publicacion.Articulo.Valor.ToString();

            if (_postImage != null)
                picBoxPostImage.Image = _postImage;
        }
    }
}
