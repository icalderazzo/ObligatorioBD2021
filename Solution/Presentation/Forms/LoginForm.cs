using Obligatorio.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;
        private readonly MainForm _mainForm;
        public LoginForm(
            IUserService userService,
            MainForm mainForm
            )
        {
            _userService = userService;
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Obligatorio.Domain.Model.Usuario loggedUser = _userService.Login(this.txtUsername.Text, this.txtPassword.Text);
                if (loggedUser != null)
                {
                    Global.LoggedUser = loggedUser;
                    _mainForm.Show();
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
                this.Hide();
                var createUserForm = new CreateUserForm(_userService, this);
                createUserForm.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
