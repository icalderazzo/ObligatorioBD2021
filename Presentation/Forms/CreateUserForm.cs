using System;
using System.Windows.Forms;
using Obligatorio.Services.Interfaces;
using Obligatorio.Domain.Model;

namespace Presentation.Forms
{
    public partial class CreateUserForm : Form
    {
        private readonly IUserService _userService;
        Form _previous;
        public CreateUserForm(IUserService userService, Form previous)
        {
            _userService = userService;
            _previous = previous;
            InitializeComponent();
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            int ci;
            int telefono;

            try
            {
                ci = int.Parse(txtCI.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("La cédula debe ser numérica, sin puntos ni guiones");
                return;
            }

            try
            {
                telefono = int.Parse(txtTelefono.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El telefono solo puede contener números");
                return;
            }

            try
            {
                var newUser = new Usuario
                {
                    Cedula = ci,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Correo = txtCorreo.Text,
                    Telefono = telefono,
                    NombreUsuario = txtNombreUsuario.Text,
                    Contrasenia = txtContrasenia.Text
                };
                _userService.Create(newUser);
                MessageBox.Show("Has sido registrado correctamente!");
                _previous.Show();
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

        private void btnReturnToLogin_Click(object sender, EventArgs e)
        {
            _previous.Show();
            this.Close();
        }
    }
}
