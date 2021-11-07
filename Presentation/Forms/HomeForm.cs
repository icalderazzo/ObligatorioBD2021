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
    public partial class HomeForm : Form
    {
        private readonly IPostsService _postsService;
        private readonly PostDetailForm _postDetailForm;
        private readonly IImageConverter _imageConverter;

        public HomeForm(
            IPostsService postsService,
            PostDetailForm postDetailForm,
            IImageConverter imageConverter)
        {
            _postsService = postsService;
            _postDetailForm = postDetailForm;
            _imageConverter = imageConverter;
            InitializeComponent();
        }

        private async void HomeForm_Load(object sender, EventArgs e)
        {
            await GetActivePosts();
        }

        private void LoadFeed(List<Publicacion> posts)
        {
            foreach (var post in posts)
            {
                var postItem = new PostItem(post, _imageConverter.ConvertFromByteArray(post.Imagen));
                postItem.ShowDetail_Click += new EventHandler(PostItem_ShowDetailClick);
                flowPostPanel.Controls.Add(postItem);
            }
        }

        private async Task GetActivePosts()
        {
            var posts = await Task.Run(() => _postsService.ListForFeed(Global.LoggedUser.Cedula));
            LoadFeed(posts);
        }

        private async Task<List<Publicacion>> FilterPosts(string nameFilter)
        {
            var filteredPosts = await Task.Run(() => _postsService.FilterByName(nameFilter, Global.LoggedUser.Cedula));
            return filteredPosts;
        }

        protected void PostItem_ShowDetailClick(object sender, EventArgs e)
        {
            _postDetailForm.ActivePost = ((PostEventArgs)e).Post;
            _postDetailForm.Show();
        }


        #region FormElementsBeahaviour
        private void txtFilter_Enter(object sender, EventArgs e)
        {
            if (txtFilter.Text == "Busca productos de interés aqui...")
            {
                txtFilter.Text = "";
            }
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                txtFilter.Text = "Busca productos de interés aqui...";
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                flowPostPanel.Controls.Clear(); //limpiar panel

                string filter = txtFilter.Text == "Busca productos de interés aqui..." ? "" : txtFilter.Text;

                var filteredPosts = await FilterPosts(filter);
                if (filteredPosts.Any())
                {
                    LoadFeed(filteredPosts);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("No se encontraron coincidencias. ¿Desea volver a mostrar todas las publicaciones?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await GetActivePosts();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al filtrar las publicaciones");
            }
        }

        #endregion
    }
}