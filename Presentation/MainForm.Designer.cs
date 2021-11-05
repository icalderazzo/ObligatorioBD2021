
namespace Presentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sideBarPanel = new System.Windows.Forms.Panel();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnPostArticle = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnUserOptions = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.sideBarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideBarPanel
            // 
            this.sideBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.sideBarPanel.Controls.Add(this.btnTransactions);
            this.sideBarPanel.Controls.Add(this.btnPostArticle);
            this.sideBarPanel.Controls.Add(this.btnHome);
            this.sideBarPanel.Controls.Add(this.panel2);
            this.sideBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarPanel.Location = new System.Drawing.Point(0, 0);
            this.sideBarPanel.Name = "sideBarPanel";
            this.sideBarPanel.Size = new System.Drawing.Size(235, 1033);
            this.sideBarPanel.TabIndex = 0;
            // 
            // btnTransactions
            // 
            this.btnTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransactions.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTransactions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransactions.Image")));
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(0, 280);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(235, 90);
            this.btnTransactions.TabIndex = 4;
            this.btnTransactions.Text = " Transacciones";
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnPostArticle
            // 
            this.btnPostArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPostArticle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPostArticle.FlatAppearance.BorderSize = 0;
            this.btnPostArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostArticle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPostArticle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPostArticle.Image = ((System.Drawing.Image)(resources.GetObject("btnPostArticle.Image")));
            this.btnPostArticle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPostArticle.Location = new System.Drawing.Point(0, 190);
            this.btnPostArticle.Name = "btnPostArticle";
            this.btnPostArticle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPostArticle.Size = new System.Drawing.Size(235, 90);
            this.btnPostArticle.TabIndex = 3;
            this.btnPostArticle.Text = "       Publicar";
            this.btnPostArticle.UseVisualStyleBackColor = true;
            this.btnPostArticle.Click += new System.EventHandler(this.btnPostArticle_Click);
            // 
            // btnHome
            // 
            this.btnHome.CausesValidation = false;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(235, 90);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "   Inicio";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.lblAppName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 100);
            this.panel2.TabIndex = 1;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAppName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAppName.Location = new System.Drawing.Point(33, 36);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(148, 34);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "UCUTrade";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.lblGreeting);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(235, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1667, 45);
            this.panel3.TabIndex = 1;
            // 
            // lblGreeting
            // 
            this.lblGreeting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGreeting.Location = new System.Drawing.Point(656, 4);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(343, 34);
            this.lblGreeting.TabIndex = 2;
            this.lblGreeting.Text = "Bienvenido, [UserName]";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnNotifications);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1577, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(45, 45);
            this.panel6.TabIndex = 1;
            // 
            // btnNotifications
            // 
            this.btnNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(224)))));
            this.btnNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNotifications.Image = ((System.Drawing.Image)(resources.GetObject("btnNotifications.Image")));
            this.btnNotifications.Location = new System.Drawing.Point(0, 0);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(45, 45);
            this.btnNotifications.TabIndex = 0;
            this.btnNotifications.UseVisualStyleBackColor = false;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnUserOptions);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1622, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(45, 45);
            this.panel5.TabIndex = 0;
            // 
            // btnUserOptions
            // 
            this.btnUserOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserOptions.FlatAppearance.BorderSize = 0;
            this.btnUserOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserOptions.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUserOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserOptions.Image")));
            this.btnUserOptions.Location = new System.Drawing.Point(0, 0);
            this.btnUserOptions.Name = "btnUserOptions";
            this.btnUserOptions.Size = new System.Drawing.Size(45, 45);
            this.btnUserOptions.TabIndex = 0;
            this.btnUserOptions.UseVisualStyleBackColor = true;
            this.btnUserOptions.Click += new System.EventHandler(this.btnUserOptions_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(237)))));
            this.panel4.Controls.Add(this.lblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(235, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1667, 55);
            this.panel4.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(765, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inicio";
            // 
            // mainContentPanel
            // 
            this.mainContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainContentPanel.Location = new System.Drawing.Point(235, 100);
            this.mainContentPanel.Name = "mainContentPanel";
            this.mainContentPanel.Size = new System.Drawing.Size(1667, 933);
            this.mainContentPanel.TabIndex = 3;
            this.mainContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainContentPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.sideBarPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UCUTrade";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sideBarPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideBarPanel;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnUserOptions;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Button btnPostArticle;
        private System.Windows.Forms.Button btnTransactions;
    }
}