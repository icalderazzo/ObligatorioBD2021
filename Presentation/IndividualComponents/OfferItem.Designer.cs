namespace Presentation.IndividualComponents
{
    partial class OfferItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPostsLists = new System.Windows.Forms.Label();
            this.bannerColorPanel = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnAccpetOffer = new System.Windows.Forms.Button();
            this.btnRejectOffer = new System.Windows.Forms.Button();
            this.btnCounterOffer = new System.Windows.Forms.Button();
            this.btnViewOfferDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(15, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "[OfferTitle]";
            // 
            // lblPostsLists
            // 
            this.lblPostsLists.AutoSize = true;
            this.lblPostsLists.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPostsLists.Location = new System.Drawing.Point(27, 121);
            this.lblPostsLists.Name = "lblPostsLists";
            this.lblPostsLists.Size = new System.Drawing.Size(0, 21);
            this.lblPostsLists.TabIndex = 1;
            // 
            // bannerColorPanel
            // 
            this.bannerColorPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerColorPanel.Name = "bannerColorPanel";
            this.bannerColorPanel.Size = new System.Drawing.Size(415, 23);
            this.bannerColorPanel.TabIndex = 9;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTitle.Location = new System.Drawing.Point(15, 73);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(124, 21);
            this.lblSubTitle.TabIndex = 10;
            this.lblSubTitle.Text = "[OfferSubtitle]";
            // 
            // btnAccpetOffer
            // 
            this.btnAccpetOffer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccpetOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(45)))));
            this.btnAccpetOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccpetOffer.FlatAppearance.BorderSize = 0;
            this.btnAccpetOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccpetOffer.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccpetOffer.ForeColor = System.Drawing.Color.White;
            this.btnAccpetOffer.Location = new System.Drawing.Point(259, 36);
            this.btnAccpetOffer.Name = "btnAccpetOffer";
            this.btnAccpetOffer.Size = new System.Drawing.Size(139, 33);
            this.btnAccpetOffer.TabIndex = 11;
            this.btnAccpetOffer.Text = "Aceptar";
            this.btnAccpetOffer.UseVisualStyleBackColor = false;
            this.btnAccpetOffer.Visible = false;
            // 
            // btnRejectOffer
            // 
            this.btnRejectOffer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRejectOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnRejectOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRejectOffer.FlatAppearance.BorderSize = 0;
            this.btnRejectOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejectOffer.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRejectOffer.ForeColor = System.Drawing.Color.White;
            this.btnRejectOffer.Location = new System.Drawing.Point(259, 84);
            this.btnRejectOffer.Name = "btnRejectOffer";
            this.btnRejectOffer.Size = new System.Drawing.Size(139, 33);
            this.btnRejectOffer.TabIndex = 12;
            this.btnRejectOffer.Text = "Rechazar";
            this.btnRejectOffer.UseVisualStyleBackColor = false;
            this.btnRejectOffer.Visible = false;
            // 
            // btnCounterOffer
            // 
            this.btnCounterOffer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCounterOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(132)))), ((int)(((byte)(212)))));
            this.btnCounterOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCounterOffer.FlatAppearance.BorderSize = 0;
            this.btnCounterOffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCounterOffer.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCounterOffer.ForeColor = System.Drawing.Color.White;
            this.btnCounterOffer.Location = new System.Drawing.Point(259, 133);
            this.btnCounterOffer.Name = "btnCounterOffer";
            this.btnCounterOffer.Size = new System.Drawing.Size(139, 33);
            this.btnCounterOffer.TabIndex = 13;
            this.btnCounterOffer.Text = "Contraofertar";
            this.btnCounterOffer.UseVisualStyleBackColor = false;
            this.btnCounterOffer.Visible = false;
            // 
            // btnViewOfferDetail
            // 
            this.btnViewOfferDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewOfferDetail.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnViewOfferDetail.Location = new System.Drawing.Point(259, 240);
            this.btnViewOfferDetail.Name = "btnViewOfferDetail";
            this.btnViewOfferDetail.Size = new System.Drawing.Size(139, 29);
            this.btnViewOfferDetail.TabIndex = 14;
            this.btnViewOfferDetail.Text = "Ver detalle";
            this.btnViewOfferDetail.UseVisualStyleBackColor = true;
            this.btnViewOfferDetail.Click += new System.EventHandler(this.btnViewOfferDetail_Click);
            // 
            // OfferItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnViewOfferDetail);
            this.Controls.Add(this.btnCounterOffer);
            this.Controls.Add(this.btnRejectOffer);
            this.Controls.Add(this.btnAccpetOffer);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.bannerColorPanel);
            this.Controls.Add(this.lblPostsLists);
            this.Controls.Add(this.lblTitle);
            this.Name = "OfferItem";
            this.Size = new System.Drawing.Size(414, 286);
            this.Load += new System.EventHandler(this.OfferItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPostsLists;
        private System.Windows.Forms.Panel bannerColorPanel;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnAccpetOffer;
        private System.Windows.Forms.Button btnRejectOffer;
        private System.Windows.Forms.Button btnCounterOffer;
        private System.Windows.Forms.Button btnViewOfferDetail;
    }
}
