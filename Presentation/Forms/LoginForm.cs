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
                Usuario loggedUser = _userService.Login(this.txtUsername.Text, this.txtPassword.Text);
                if (loggedUser != null)
                {
                    var mainForm = new MainForm(loggedUser);
                    mainForm.Show();
                    Hide();
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
