namespace Presentation.IndividualComponents
{
    partial class SelectPostItem
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
            this.picBoxPostImage = new System.Windows.Forms.PictureBox();
            this.chkIncludeInOffer = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPostImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxPostImage
            // 
            this.picBoxPostImage.Location = new System.Drawing.Point(25, 49);
            this.picBoxPostImage.Name = "picBoxPostImage";
            this.picBoxPostImage.Size = new System.Drawing.Size(370, 261);
            this.picBoxPostImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxPostImage.TabIndex = 0;
            this.picBoxPostImage.TabStop = false;
            // 
            // chkIncludeInOffer
            // 
            this.chkIncludeInOffer.AutoSize = true;
            this.chkIncludeInOffer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIncludeInOffer.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIncludeInOffer.Location = new System.Drawing.Point(25, 12);
            this.chkIncludeInOffer.Name = "chkIncludeInOffer";
            this.chkIncludeInOffer.Size = new System.Drawing.Size(147, 24);
            this.chkIncludeInOffer.TabIndex = 1;
            this.chkIncludeInOffer.Text = "Incluir en oferta";
            this.chkIncludeInOffer.UseVisualStyleBackColor = true;
            this.chkIncludeInOffer.CheckedChanged += new System.EventHandler(this.chkIncludeInOffer_CheckedChanged);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(444, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(108, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "[PostName]";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblValue.Location = new System.Drawing.Point(444, 95);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(106, 21);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "[PostValue]";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(446, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "UCUCoins";
            // 
            // SelectPostItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.chkIncludeInOffer);
            this.Controls.Add(this.picBoxPostImage);
            this.Name = "SelectPostItem";
            this.Size = new System.Drawing.Size(588, 336);
            this.Load += new System.EventHandler(this.SelectPostItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPostImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxPostImage;
        private System.Windows.Forms.CheckBox chkIncludeInOffer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label label1;
    }
}
