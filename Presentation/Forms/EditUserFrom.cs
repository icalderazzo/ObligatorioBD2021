using System;
using System.Windows.Forms;
using Obligatorio.Domain.Model;
using Obligatorio.Services.Interfaces;

namespace Presentation.Forms
{
    public partial class EditUserFrom : Form
    {
        private readonly IUserService _userService;
        public EditUserFrom(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!lblCurrentPasswd.Visible)
            {
                btnChangePassword.Text = "Cancelar";
            }
            else
            {
                btnChangePassword.Text = "Cambiar contraseña";
            }

            // change lables state
            lblCurrentPasswd.Visible = !lblCurrentPasswd.Visible;
            lblNewPasswd.Visible = !lblNewPasswd.Visible;
            lblRepeatNewPasswd.Visible = !lblRepeatNewPasswd.Visible;

            // change textboxes state
            txtCurrentPasswd.Visible = !txtCurrentPasswd.Visible;
            txtNewPasswd.Visible = !txtNewPasswd.Visible;
            txtRepeatNewPasswd.Visible = !txtRepeatNewPasswd.Visible;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario updatedUser = new()
                {
                    Cedula = Global.LoggedUser.Cedula,
                    NombreUsuario = Global.LoggedUser.NombreUsuario,
                    Nombre = txtName.Text,
                    Apellido = txtSurname.Text,
                    Correo = txtEmail.Text,
                    Telefono = int.Parse(txtPhoneNumber.Text),
                    Contrasenia = ""
                };
                
                // si el usuario habilito el cambio de contraseña
                if (txtCurrentPasswd.Visible)
                {
                    if(_userService.IsUserAllowedToChangePassword(Global.LoggedUser.NombreUsuario, txtCurrentPasswd.Text))
                    {
                        if (txtNewPasswd.Text.Equals(txtRepeatNewPasswd.Text))
                        {
                            updatedUser.Contrasenia = txtNewPasswd.Text;
                        }
                        else
                        {
                            MessageBox.Show("La nueva contraseña debe coincidir en los dos campos solicitados");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseña anterior incorrecta");
                        return;
                    }
                }

                _userService.Modify(updatedUser);

                MessageBox.Show("Datos actualizados correctamente");

                txtCurrentPasswd.Text = "";
                txtNewPasswd.Text = "";
                txtRepeatNewPasswd.Text = "";

                Hide();
            }
            catch(InvalidOperationException io)
            {
                MessageBox.Show(io.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EditUserFrom_Load(object sender, EventArgs e)
        {
            lblCi.Text = lblCi.Text.Replace("[Ci]", Global.LoggedUser.Cedula.ToString());
            lblUsername.Text = lblUsername.Text.Replace("[Username]", Global.LoggedUser.NombreUsuario.ToString());

            txtName.Text = Global.LoggedUser.Nombre.ToString();
            txtSurname.Text = Global.LoggedUser.Apellido.ToString();
            txtEmail.Text = Global.LoggedUser.Correo.ToString();
            txtPhoneNumber.Text = Global.LoggedUser.Telefono.ToString();
        }

        private void EditUserFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
