using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;

namespace Presentation.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IPostsService _postsService;

        public HomeForm(IPostsService postsService)
        {
            _postsService = postsService;
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

            }
        }

        private async Task<List<Publicacion>> GetActivePosts()
        {
            var posts = await Task.Run(() => _postsService.ListForFeed(Global.LoggedUser.Cedula));
            return posts;
        }
    }
}