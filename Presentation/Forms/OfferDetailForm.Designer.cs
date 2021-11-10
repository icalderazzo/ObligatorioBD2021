namespace Presentation.Forms
{
    partial class OfferDetailForm
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
            this.activeUsersPostsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.otherUsersPostsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // activeUsersPostsFlowPanel
            // 
            this.activeUsersPostsFlowPanel.AutoScroll = true;
            this.activeUsersPostsFlowPanel.Location = new System.Drawing.Point(26, 70);
            this.activeUsersPostsFlowPanel.Name = "activeUsersPostsFlowPanel";
            this.activeUsersPostsFlowPanel.Size = new System.Drawing.Size(702, 850);
            this.activeUsersPostsFlowPanel.TabIndex = 0;
            // 
            // otherUsersPostsFlowPanel
            // 
            this.otherUsersPostsFlowPanel.AutoScroll = true;
            this.otherUsersPostsFlowPanel.Location = new System.Drawing.Point(775, 70);
            this.otherUsersPostsFlowPanel.Name = "otherUsersPostsFlowPanel";
            this.otherUsersPostsFlowPanel.Size = new System.Drawing.Size(702, 850);
            this.otherUsersPostsFlowPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(273, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tus publicaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(999, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Publicaciones del otro usuario";
            // 
            // OfferDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 960);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.otherUsersPostsFlowPanel);
            this.Controls.Add(this.activeUsersPostsFlowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OfferDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OfferDetailForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel activeUsersPostsFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel otherUsersPostsFlowPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}