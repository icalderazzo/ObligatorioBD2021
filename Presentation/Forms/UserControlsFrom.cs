using System;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class UserControlsFrom : Form
    {
        private readonly EditUserFrom _editUserForm;
        //private readonly LoginForm _loginForm;
        public UserControlsFrom(
            EditUserFrom editUserFrom)
        {
            _editUserForm = editUserFrom;
            //_loginForm = loginForm;
            InitializeComponent();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            Hide();
            _editUserForm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Salir", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Global.LoggedUser = null;
                Application.Restart();
            }
        }
    }
}
