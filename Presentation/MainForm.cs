using Obligatorio.Domain.Model;
using Obligatorio.Services.Services;
using Presentation.Forms;
using System;
using System.Windows.Forms;
using static Presentation.Constant.Styles;

namespace Presentation
{
    public partial class MainForm : Form
    {
        private Button _selectedButton;
        private Form _activeForm;
        private Usuario _loggedUser;

        public MainForm(Usuario usuario)
        {
            _loggedUser = usuario;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new HomeForm(), this.btnHome);
            this.lblGreeting.Text = this.lblGreeting.Text.Replace("[UserName]", _loggedUser.Nombre);
        }

        #region ButtonClicks
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HomeForm(), sender);
        }
        private void btnPostArticle_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {

        }

        private void btnUserOptions_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Beheaviour
        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (_selectedButton != (Button)sender)
                {
                    UnselectButtons();
                    _selectedButton = (Button)sender;
                    _selectedButton.BackColor = SideBarSelectedButtonColor;
                }
            }
        }

        public void UnselectButtons()
        {
            foreach (Control btn in this.sideBarPanel.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = SideBarButtonColor;
                }
            }
        }

        private void OpenChildForm(Form childForm, object sender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            ActivateButton(sender);
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.mainContentPanel.Controls.Add(childForm);
            this.mainContentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.lblTitle.Text = ((Button)sender).Text;
        }
        #endregion

        private void lblGreeting_Click(object sender, EventArgs e)
        {

        }
    }
}
