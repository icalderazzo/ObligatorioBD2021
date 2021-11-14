using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

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
                if (valorUcuCoins == 0)
                {
                    MessageBox.Show("El precio en UcuCoins debe ser mayor a 0");
                    return;
                }
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

                if (String.IsNullOrWhiteSpace(newPost.Articulo.Descripcion))
                {
                    MessageBox.Show("Descripcion no puede estar vacía");
                    return;
                }
                if (String.IsNullOrWhiteSpace(newPost.Articulo.Nombre))
                {
                    MessageBox.Show("Nombre no puede estar vacío");
                    return;
                }

                _postService.Create(newPost);

                MessageBox.Show("Se ha publicado el post correctamente");

                txtNombreProducto.Text = "";
                txtValorProducto.Text = "";
                productDescriptionText.Text = "";
                lblImageFileName.Text = "";
                _loadedImage = null;
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
                fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.bmp; *.png";
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
