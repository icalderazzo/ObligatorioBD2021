using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.IndividualComponents;
using System;
using System.Linq;
using Presentation.CustomEvents;

namespace Presentation.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IPostsService _postsService;
        private readonly PostDetailForm _postDetailForm;
        //private List<PostItem> _activePosts;

        public HomeForm(
            IPostsService postsService,
            PostDetailForm postDetailForm)
        {
            _postsService = postsService;
            _postDetailForm = postDetailForm;
            //_activePosts = new List<PostItem>();
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
                var postItem = new PostItem(post);
                postItem.ShowDetail_Click += new EventHandler(PostItem_ShowDetailClick);
                //_activePosts.Add(postItem);
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
            _postDetailForm.ActivePost = ((ShowPostDetailEventArgs)e).Post;
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