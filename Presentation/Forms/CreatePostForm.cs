using System;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System.Drawing;

namespace Presentation.Forms
{
    public partial class CreatePostForm : Form
    {
        private readonly IPostsService _postService;
        private byte[] _loadedImage;
        private readonly ImageConverter _imageConverter;

        public CreatePostForm(
            IPostsService postService, 
            ImageConverter imageConverter)
        {
            _postService = postService;
            _imageConverter = imageConverter;
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
                    Propietario = new Usuario()
                    {
                        Cedula = Global.LoggedUser.Cedula
                    },
                    Articulo = new Articulo
                    {
                        Nombre = txtNombreProducto.Text,
                        Descripcion = productDescriptionText.Text,
                        Valor = valorUcuCoins
                    },
                    Imagen = _loadedImage
                };

                if (String.IsNullOrEmpty(newPost.Articulo.Descripcion)) 
                {
                    MessageBox.Show("Descripcion no puede estar vacía");
                    return;
                }
                
                _postService.Create(newPost);
                _loadedImage = null;
                MessageBox.Show("Se ha publicado el post correctamente");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Error desconocido");
            }
         }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(fileDialog.FileName);
                    byte[] xByte = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));
                    _loadedImage = xByte;
                    lblImageFileName.Text = fileDialog.SafeFileName;
                }
            }
        }
    }
}
