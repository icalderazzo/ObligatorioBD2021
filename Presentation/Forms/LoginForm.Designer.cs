
namespace Presentation.Forms
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 114);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(345, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 34);
            this.label3.TabIndex = 1;
            this.label3.Text = "Acceder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "UCUTrade";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(237)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(696, 393);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 33);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(257, 197);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(323, 32);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(257, 283);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(323, 32);
            this.txtPassword.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUser.Location = new System.Drawing.Point(255, 167);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(286, 23);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Nombre de usuario o correo";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(255, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña\r\n";
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCreateAccount.AutoSize = true;
            this.lblCreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCreateAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCreateAccount.Location = new System.Drawing.Point(217, 344);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(398, 23);
            this.lblCreateAccount.TabIndex = 6;
            this.lblCreateAccount.Text = "¿Aún no tienes cuenta? Regístrate aquí";
            this.lblCreateAccount.Click += new System.EventHandler(this.lblCreateAccount_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.lblCreateAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UCUTrade";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Label label3;
    }
}