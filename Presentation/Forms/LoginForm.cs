using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        public LoginForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    NombreUsuario = this.txtUsername.Text,
                    Contrasenia = this.txtPassword.Text
                };

                Usuario loggedUser = _userService.Login(usuario);

                if (loggedUser != null)
                {
                    var mainForm = new MainForm(loggedUser);
                    this.Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
