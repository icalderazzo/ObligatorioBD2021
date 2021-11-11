namespace Presentation.Forms
{
    partial class CreatePostForm
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

        #endregion
        private void InitializeComponent()
        {
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorProducto = new System.Windows.Forms.TextBox();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.productDescriptionText = new System.Windows.Forms.RichTextBox();
            this.lblImageFileName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreProducto.Location = new System.Drawing.Point(268, 75);
            this.txtNombreProducto.MaxLength = 50;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(478, 34);
            this.txtNombreProducto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del producto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(36, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Valor Producto";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(389, -34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 34);
            this.label5.TabIndex = 24;
            this.label5.Text = "Alta Publicación";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Imagen";
            // 
            // txtValorProducto
            // 
            this.txtValorProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValorProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValorProducto.Location = new System.Drawing.Point(268, 157);
            this.txtValorProducto.MaxLength = 15;
            this.txtValorProducto.Name = "txtValorProducto";
            this.txtValorProducto.Size = new System.Drawing.Size(323, 34);
            this.txtValorProducto.TabIndex = 16;
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(45)))));
            this.btnCreatePost.FlatAppearance.BorderSize = 0;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreatePost.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreatePost.Location = new System.Drawing.Point(768, 636);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(179, 41);
            this.btnCreatePost.TabIndex = 23;
            this.btnCreatePost.Text = "Publicar";
            this.btnCreatePost.UseVisualStyleBackColor = false;
            this.btnCreatePost.Click += new System.EventHandler(this.btnCreatePost_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddImage.BackColor = System.Drawing.Color.Transparent;
            this.btnAddImage.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddImage.Location = new System.Drawing.Point(268, 492);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(121, 38);
            this.btnAddImage.TabIndex = 28;
            this.btnAddImage.Text = "Subir";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // productDescriptionText
            // 
            this.productDescriptionText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productDescriptionText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productDescriptionText.Location = new System.Drawing.Point(268, 255);
            this.productDescriptionText.Name = "productDescriptionText";
            this.productDescriptionText.Size = new System.Drawing.Size(478, 181);
            this.productDescriptionText.TabIndex = 29;
            this.productDescriptionText.Text = "";
            // 
            // lblImageFileName
            // 
            this.lblImageFileName.AutoSize = true;
            this.lblImageFileName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageFileName.ForeColor = System.Drawing.Color.Black;
            this.lblImageFileName.Location = new System.Drawing.Point(274, 552);
            this.lblImageFileName.Name = "lblImageFileName";
            this.lblImageFileName.Size = new System.Drawing.Size(0, 23);
            this.lblImageFileName.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(642, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 31;
            this.label7.Text = "UCUCoins";
            // 
            // CreatePostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 721);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblImageFileName);
            this.Controls.Add(this.productDescriptionText);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreatePost);
            this.Controls.Add(this.txtValorProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreatePostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtValorProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreatePost;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.RichTextBox productDescriptionText;
        private System.Windows.Forms.Label lblImageFileName;
        private System.Windows.Forms.Label label7;
    }
}
