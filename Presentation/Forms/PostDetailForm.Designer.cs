namespace Presentation.Forms
{
    partial class PostDetailForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPostName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnMakeOffer = new System.Windows.Forms.Button();
            this.btnShowUserProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 291);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblPostName
            // 
            this.lblPostName.AutoSize = true;
            this.lblPostName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPostName.Location = new System.Drawing.Point(40, 323);
            this.lblPostName.Name = "lblPostName";
            this.lblPostName.Size = new System.Drawing.Size(125, 23);
            this.lblPostName.TabIndex = 2;
            this.lblPostName.Text = "[PostName]";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrice.Location = new System.Drawing.Point(451, 323);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(83, 23);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "[Value]";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Location = new System.Drawing.Point(40, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 153);
            this.panel1.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(83, 48);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(64, 21);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "[Desc]";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesc.Location = new System.Drawing.Point(3, 11);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(134, 23);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Descripción: ";
            // 
            // btnMakeOffer
            // 
            this.btnMakeOffer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMakeOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(45)))));
            this.btnMakeOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMakeOffer.FlatAppearance.BorderSize = 0;
            this.btnMakeOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeOffer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMakeOffer.ForeColor = System.Drawing.Color.White;
            this.btnMakeOffer.Location = new System.Drawing.Point(594, 12);
            this.btnMakeOffer.Name = "btnMakeOffer";
            this.btnMakeOffer.Size = new System.Drawing.Size(158, 33);
            this.btnMakeOffer.TabIndex = 7;
            this.btnMakeOffer.Text = "Ofertar";
            this.btnMakeOffer.UseVisualStyleBackColor = false;
            this.btnMakeOffer.Click += new System.EventHandler(this.btnMakeOffer_Click);
            // 
            // btnShowUserProfile
            // 
            this.btnShowUserProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowUserProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(130)))));
            this.btnShowUserProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowUserProfile.FlatAppearance.BorderSize = 0;
            this.btnShowUserProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowUserProfile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowUserProfile.ForeColor = System.Drawing.Color.White;
            this.btnShowUserProfile.Location = new System.Drawing.Point(594, 70);
            this.btnShowUserProfile.Name = "btnShowUserProfile";
            this.btnShowUserProfile.Size = new System.Drawing.Size(158, 36);
            this.btnShowUserProfile.TabIndex = 8;
            this.btnShowUserProfile.Text = "Visitar perfil";
            this.btnShowUserProfile.UseVisualStyleBackColor = false;
            this.btnShowUserProfile.Click += new System.EventHandler(this.btnShowUserProfile_Click);
            // 
            // PostDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.btnShowUserProfile);
            this.Controls.Add(this.btnMakeOffer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblPostName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PostDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostDetailForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPostName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnMakeOffer;
        private System.Windows.Forms.Button btnShowUserProfile;
    }
}