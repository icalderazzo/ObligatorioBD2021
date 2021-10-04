﻿using System;
using System.Windows.Forms;
using Presentation.Forms;
using static Presentation.Constant.Styles;

namespace Presentation
{
    public partial class MainForm : Form
    {
        private Button _selectedButton;
        private Form _activeForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _activeForm = new HomeForm();
            ActivateButton(this.btnHome);
        }

        #region ButtonClicks
        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
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

        private void ChangeActiveForm(Form childForm, object sender)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.mainContentPanel.Controls.Add(childForm);
            this.mainContentPanel.Tag = childForm;
            childForm.Show();
            this.lblTitle.Text = ((Button)sender).Text;
        }
        #endregion
    }
}
