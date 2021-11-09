using Obligatorio.Domain.Model;
using Presentation.IndividualComponents;
using Presentation.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class OfferDetailForm : Form
    {
        private readonly IImageConverter _imageConverter;
        public List<Publicacion> ActiveUsersPosts 
        { 
            set
            {
                LoadSelectPostItems(value, activeUsersPostsFlowPanel);
            }
        }
        public List<Publicacion> OtherUsersPosts 
        { 
            set
            {
                LoadSelectPostItems(value, otherUsersPostsFlowPanel);
            }
        }
        public OfferDetailForm(IImageConverter imageConverter)
        {
            _imageConverter = imageConverter;
            InitializeComponent();
        }

        private void LoadSelectPostItems(List<Publicacion> posts, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            foreach (var post in posts)
            {
                var postItem = new SelectPostItem(
                    post, 
                    image: _imageConverter.ConvertFromByteArray(post.Imagen), 
                    includeInOffer : false,
                    checkVisible : false
                );
                panel.Controls.Add(postItem);
            }
        }

        private void OfferDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                activeUsersPostsFlowPanel.Controls.Clear();
                otherUsersPostsFlowPanel.Controls.Clear();
                Hide();
            }
        }
    }
}
