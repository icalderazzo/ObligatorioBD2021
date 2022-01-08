namespace Presentation.Forms
{
    partial class MakeOfferForSinglePostForm
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
            this.flowPanelDesiredPost = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelOffer = new System.Windows.Forms.Button();
            this.btnMakeOffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowPanelActiveUserPosts
            // 
            this.flowPanelActiveUserPosts.AutoScroll = true;
            this.flowPanelActiveUserPosts.Location = new System.Drawing.Point(12, 68);
            this.flowPanelActiveUserPosts.Name = "flowPanelActiveUserPosts";
            this.flowPanelActiveUserPosts.Size = new System.Drawing.Size(828, 860);
            this.flowPanelActiveUserPosts.TabIndex = 0;
            // 
            // flowPanelDesiredPost
            // 
            this.flowPanelDesiredPost.Location = new System.Drawing.Point(950, 68);
            this.flowPanelDesiredPost.Name = "flowPanelDesiredPost";
            this.flowPanelDesiredPost.Size = new System.Drawing.Size(492, 469);
            this.flowPanelDesiredPost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1067, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articulo deseado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(321, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tus publicaciones";
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
            this.btnCancelOffer.Location = new System.Drawing.Point(1098, 895);
            this.btnCancelOffer.Name = "btnCancelOffer";
            this.btnCancelOffer.Size = new System.Drawing.Size(158, 33);
            this.btnCancelOffer.TabIndex = 14;
            this.btnCancelOffer.Text = "Cancelar";
            this.btnCancelOffer.UseVisualStyleBackColor = false;
            this.btnCancelOffer.Click += new System.EventHandler(this.btnCancelOffer_Click);
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
            this.btnMakeOffer.Location = new System.Drawing.Point(1284, 895);
            this.btnMakeOffer.Name = "btnMakeOffer";
            this.btnMakeOffer.Size = new System.Drawing.Size(158, 33);
            this.btnMakeOffer.TabIndex = 13;
            this.btnMakeOffer.Text = "Ofertar";
            this.btnMakeOffer.UseVisualStyleBackColor = false;
            this.btnMakeOffer.Click += new System.EventHandler(this.btnMakeOffer_Click);
            // 
            // MakeOfferForSinglePostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 953);
            this.Controls.Add(this.btnCancelOffer);
            this.Controls.Add(this.btnMakeOffer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowPanelDesiredPost);
            this.Controls.Add(this.flowPanelActiveUserPosts);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MakeOfferForSinglePostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MakeOfferForSinglePostForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelActiveUserPosts;
        private System.Windows.Forms.FlowLayoutPanel flowPanelDesiredPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelOffer;
        private System.Windows.Forms.Button btnMakeOffer;
    }
}