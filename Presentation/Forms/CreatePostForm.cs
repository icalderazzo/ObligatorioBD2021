using System;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;

namespace Presentation.Forms
{
    public partial class CreatePostForm : Form
    {
        private readonly IPostsService _postService;
        //private readonly MainForm _previous;

        public CreatePostForm(IPostsService postService)
        {
            _postService = postService;
            //_previous = mainForm;
            InitializeComponent();
        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            int valorUcuCoins;
            try
            {
                valorUcuCoins = int.Parse(txtValorProducto.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El Valor Producto solo puede contener números");
                return;
            }
            try
            {
                var newPost = new Publicacion
                {
                    // Revisar tema de Id Publicacion
                    IdPublicacion = 1,
                    Estado = true,
                    FechaPublicacion = DateTime.Now,
                    Propietario = Global.LoggedUser,
                    Articulo = new Articulo
                    {
                        Nombre = txtNombreProducto.Text,
                        Descripcion = txtDescripcionProducto.Text,
                        Valor = valorUcuCoins
                    },
                    Imagen = null
                };
                if (String.IsNullOrEmpty(newPost.Articulo.Descripcion)) 
                {
                    throw (new InvalidOperationException("Descripcion no puede estar vacía"));
                } 
                _postService.Create(newPost);
                MessageBox.Show("Se ha publicado el post correctamente");
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
         }

    }
}
