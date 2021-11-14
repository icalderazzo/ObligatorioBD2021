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
        private readonly HomeForm _homeForm;
        private readonly CreatePostForm _createPostForm;
        private readonly ShowOffersForm _showOffersForm;
        private readonly ShowPostsForm _showPostsForm;
        private readonly UserControlsFrom _userControlsFrom;

        public MainForm(
            HomeForm homeForm,
            CreatePostForm createPostForm,
            ShowOffersForm showOffersForm,
            ShowPostsForm showPostsForm,
            UserControlsFrom userControlsFrom
            )
        {
            _createPostForm = createPostForm;
            _homeForm = homeForm;
            _showOffersForm = showOffersForm;
            _showPostsForm = showPostsForm;
            _userControlsFrom = userControlsFrom;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(_homeForm, this.btnHome);
            this.lblGreeting.Text = this.lblGreeting.Text.Replace("[UserName]", Global.LoggedUser.Nombre);
        }

        #region ButtonClicks
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(_homeForm, sender);
        }
        private void btnPostArticle_Click(object sender, EventArgs e)
        {
            OpenChildForm(_createPostForm, sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(_showOffersForm, sender);
        }

        private void btnUserOptions_Click(object sender, EventArgs e)
        {
            _userControlsFrom.Show();
        }
        private void btnShowPosts_Click(object sender, EventArgs e)
        {
            _showPostsForm.RefreshPosts();
            OpenChildForm(_showPostsForm, sender);
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
                _activeForm.Hide();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Global.LoggedUser = null;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
