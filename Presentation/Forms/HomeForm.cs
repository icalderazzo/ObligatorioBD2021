using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.IndividualComponents;

namespace Presentation.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IPostsService _postsService;
        private List<PostItem> _activePosts;

        public HomeForm(IPostsService postsService)
        {
            _postsService = postsService;
            _activePosts = new List<PostItem>();
            InitializeComponent();
        }

        private async void HomeForm_Load(object sender, System.EventArgs e)
        {
            await LoadFeed();
        }

        private async Task LoadFeed()
        {
            var posts = await GetActivePosts();

            foreach (var post in posts)
            {
                var postItem = new PostItem(post);
                _activePosts.Add(postItem);
                flowPostPanel.Controls.Add(postItem);
            }
        }

        private async Task<List<Publicacion>> GetActivePosts()
        {
            var posts = await Task.Run(() => _postsService.ListForFeed(Global.LoggedUser.Cedula));
            return posts;
        }

        private void txtFilter_Enter(object sender, System.EventArgs e)
        {
            if (txtFilter.Text == "Busca productos de interés aqui...")
            {
                txtFilter.Text = "";
            }
        }

        private void txtFilter_Leave(object sender, System.EventArgs e)
        {
            if (txtFilter.Text == "")
            {
                txtFilter.Text = "Busca productos de interés aqui...";
            }
        }
    }
}