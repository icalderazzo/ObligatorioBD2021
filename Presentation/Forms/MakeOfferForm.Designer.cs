namespace Presentation.Forms
{
    partial class MakeOfferForm
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
            this.flowPanelActiveUserPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMakeOffer = new System.Windows.Forms.Button();
            this.btnCancelOffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowPanelActiveUserPosts
            // 
            this.flowPanelActiveUserPosts.AutoScroll = true;
            this.flowPanelActiveUserPosts.Location = new System.Drawing.Point(13, 59);
            this.flowPanelActiveUserPosts.Name = "flowPanelActiveUserPosts";
            this.flowPanelActiveUserPosts.Size = new System.Drawing.Size(720, 804);
            this.flowPanelActiveUserPosts.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(783, 59);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(720, 804);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(273, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(181, 23);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Tus publicaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1002, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Publicaciones del destinatario";
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
            this.btnMakeOffer.Location = new System.Drawing.Point(1345, 895);
            this.btnMakeOffer.Name = "btnMakeOffer";
            this.btnMakeOffer.Size = new System.Drawing.Size(158, 33);
            this.btnMakeOffer.TabIndex = 11;
            this.btnMakeOffer.Text = "Ofertar";
            this.btnMakeOffer.UseVisualStyleBackColor = false;
            this.btnMakeOffer.Click += new System.EventHandler(this.btnMakeOffer_Click);
            // 
            // btnCancelOffer
            // 
            this.btnCancelOffer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(53)))), ((int)(((byte)(43)))));
            this.btnCancelOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelOffer.FlatAppearance.BorderSize = 0;
            this.btnCancelOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOffer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelOffer.ForeColor = System.Drawing.Color.White;
            this.btnCancelOffer.Location = new System.Drawing.Point(1161, 895);
            this.btnCancelOffer.Name = "btnCancelOffer";
            this.btnCancelOffer.Size = new System.Drawing.Size(158, 33);
            this.btnCancelOffer.TabIndex = 12;
            this.btnCancelOffer.Text = "Cancelar";
            this.btnCancelOffer.UseVisualStyleBackColor = false;
            this.btnCancelOffer.Click += new System.EventHandler(this.btnCancelOffer_Click);
            // 
            // MakeOfferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1522, 953);
            this.Controls.Add(this.btnCancelOffer);
            this.Controls.Add(this.btnMakeOffer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowPanelActiveUserPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MakeOfferForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MakeOfferForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelActiveUserPosts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnMakeOffer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelOffer;
    }
}