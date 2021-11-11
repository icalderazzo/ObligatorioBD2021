using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using Presentation.CustomEvents;
using Presentation.IndividualComponents;
using Presentation.Utils;

namespace Presentation.Forms
{
    public partial class ShowPostsForm : Form
    {
        private EditPostForm _editPostForm;
        private readonly IPostsService _postsService;
        private readonly IImageConverter _imageConverter; 
        private readonly System.Drawing.ImageConverter _defaultImageConverter;
        public ShowPostsForm(
            IPostsService postsService,
            IImageConverter imageConverter,
            System.Drawing.ImageConverter defaultImageConverter)
        {
            _postsService = postsService;
            _imageConverter = imageConverter;
            _defaultImageConverter = defaultImageConverter;
            InitializeComponent();
        }

        private async void ShowPostsForm_Load(object sender, EventArgs e)
        {
            await GetActiveUsersPosts();
        }

        private void LoadPostInPanel(Publicacion post)
        {
            var postItem = new PostItem(post, _imageConverter.ConvertFromByteArray(post.Imagen));
            postItem.ShowDetail_Click += new EventHandler(ShowEditForm);
            postsFlowPanel.Controls.Add(postItem);
        }
        private async Task GetActiveUsersPosts()
        {
            var posts = await Task.Run(() => _postsService.ListPostsOfUser(Global.LoggedUser.Cedula));
            foreach (var post in posts)
            {
                LoadPostInPanel(post);
            }
        }

        private void ShowEditForm(object sender, EventArgs e)
        {
            if (_editPostForm == null)
            {
                var post = ((PostEventArgs)e).Post;
                _editPostForm = new EditPostForm(post, _imageConverter, _defaultImageConverter);
                _editPostForm.UpdatePostClick += new EventHandler(UpdatePost);
                _editPostForm.ChangePostStateClick += new EventHandler(ChangePostState);
            }

            _editPostForm.Show();
        }

        #region EventHandlers
        protected void UpdatePost(object sender, EventArgs e)
        {
            try
            {
                var post = ((PostEventArgs)e).Post;
                _postsService.Modify(post);
                _editPostForm.Close();
                _editPostForm = null;
                MessageBox.Show("Datos guardados correctamente");
            }
            catch (InvalidOperationException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Error desconocido");
            }

        }
        protected void ChangePostState(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
