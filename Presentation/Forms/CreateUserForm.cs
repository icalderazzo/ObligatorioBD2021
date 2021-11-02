using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class CreateUserForm : Form
    {
        private readonly IUserService _userService;
        private readonly LoginForm _previous;
        public CreateUserForm(IUserService userService, LoginForm loginForm)
        {
            _userService = userService;
            _previous = loginForm;
            InitializeComponent();
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Check null and white spaces in data
            if(
                String.IsNullOrWhiteSpace(txtCI.Text) || String.IsNullOrWhiteSpace(txtTelefono.Text) || 
                String.IsNullOrWhiteSpace(txtApellido.Text) || String.IsNullOrWhiteSpace(txtNombre.Text) || 
                String.IsNullOrWhiteSpace(txtCorreo.Text) || String.IsNullOrWhiteSpace(txtNombreUsuario.Text) || 
                String.IsNullOrWhiteSpace(txtContrasenia.Text))
            {
                MessageBox.Show("Hay datos faltantes, chequee que haya completado todos");
                return;
            }
            
            //Check int CI and Phone
            int ci;
            int telefono;

            try{ci = int.Parse(txtCI.Text);}
            catch (FormatException)
            {
                MessageBox.Show("La cédula debe ser numérica, sin puntos ni guiones");
                return;
            }

            try{telefono = int.Parse(txtTelefono.Text);}
            catch (FormatException)
            {
                MessageBox.Show("El telefono solo puede contener números");
                return;
            }

            //Check string Name and Surname
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras");
                return;
            }
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("El apellido solo puede contener letras");
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
