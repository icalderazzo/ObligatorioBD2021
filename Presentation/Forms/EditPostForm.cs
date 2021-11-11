using Obligatorio.Domain.Model;
using Presentation.CustomEvents;
using Presentation.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class EditPostForm : Form
    {
        private readonly IImageConverter _imageConverter;
        private readonly System.Drawing.ImageConverter _defaultImageConverter;
        private readonly Publicacion _activePost;

        public EventHandler UpdatePostClick;
        public EventHandler ChangePostStateClick;

        public EditPostForm(
            Publicacion post, 
            IImageConverter imageConverter, 
            System.Drawing.ImageConverter defaultImageConverter)
        {
            _imageConverter = imageConverter;
            _defaultImageConverter = defaultImageConverter;
            _activePost = post;
            InitializeComponent();
            
        }

        private void EditPostForm_Load(object sender, EventArgs e)
        {
            txtNombreProducto.Text = _activePost.Articulo.Nombre;
            txtValorProducto.Text = _activePost.Articulo.Valor.ToString();
            productDescriptionText.Text = _activePost.Articulo.Descripcion;
            btnDisablePost.Text = _activePost.Estado ? "Desactivar" : "Activar";
            btnDisablePost.BackColor = !_activePost.Estado ? Color.FromArgb(47, 132, 212) : Color.FromArgb(212, 47, 47);
            postPicBox.Image = _imageConverter.ConvertFromByteArray(_activePost.Imagen);
        }

        private void btnDisablePost_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (_activePost.Estado)
            {
                msg = "desactivar la publicación, los demás usuarios no podrán visualizarla";
            }
            if (!_activePost.Estado)
            {
                msg = "volver a activar la publicación, los demás usuarios podrán visualizarla";
            }

            DialogResult dialogResult = MessageBox.Show($"¿Está seguro que desea {msg}?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ChangePostStateClick != null)
                {
                    _activePost.Estado = !_activePost.Estado;
                    this.ChangePostStateClick(this, new PostEventArgs(_activePost));
                }
            }
        }

        private void btnUpdatePost_Click(object sender, EventArgs e)
        {
            if (UpdatePostClick != null)
            {
                try
                {
                    _activePost.Articulo.Nombre = txtNombreProducto.Text;
                    _activePost.Articulo.Descripcion = productDescriptionText.Text;
                    _activePost.Articulo.Valor = int.Parse(txtValorProducto.Text);
                    this.UpdatePostClick(this, new PostEventArgs(_activePost));
                }
                catch (FormatException)
                {
                    MessageBox.Show("El campo valor solo puede ser numérico.");
                }
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
                    postPicBox.Image = null;
                    postPicBox.Image = img;

                    byte[] xByte = (byte[])_defaultImageConverter.ConvertTo(img, typeof(byte[]));
                    _activePost.Imagen = xByte;
                    lblImageFileName.Text = fileDialog.SafeFileName;
                }
            }
        }
    }
}
