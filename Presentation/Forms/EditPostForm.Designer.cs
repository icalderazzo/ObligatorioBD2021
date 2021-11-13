namespace Presentation.Forms
{
    partial class EditPostForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.productDescriptionText = new System.Windows.Forms.RichTextBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnUpdatePost = new System.Windows.Forms.Button();
            this.txtValorProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.postPicBox = new System.Windows.Forms.PictureBox();
            this.btnDisablePost = new System.Windows.Forms.Button();
            this.lblImageFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.postPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1142, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "UCUCoins";
            // 
            // productDescriptionText
            // 
            this.productDescriptionText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productDescriptionText.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productDescriptionText.Location = new System.Drawing.Point(788, 179);
            this.productDescriptionText.Name = "productDescriptionText";
            this.productDescriptionText.Size = new System.Drawing.Size(478, 181);
            this.productDescriptionText.TabIndex = 3;
            this.productDescriptionText.Text = "";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddImage.BackColor = System.Drawing.Color.Transparent;
            this.btnAddImage.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddImage.Location = new System.Drawing.Point(333, 467);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(174, 38);
            this.btnAddImage.TabIndex = 39;
            this.btnAddImage.Text = "Cambiar imagen";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnUpdatePost
            // 
            this.btnUpdatePost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(45)))));
            this.btnUpdatePost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatePost.FlatAppearance.BorderSize = 0;
            this.btnUpdatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePost.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdatePost.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdatePost.Location = new System.Drawing.Point(1123, 507);
            this.btnUpdatePost.Name = "btnUpdatePost";
            this.btnUpdatePost.Size = new System.Drawing.Size(143, 41);
            this.btnUpdatePost.TabIndex = 5;
            this.btnUpdatePost.Text = "Guardar";
            this.btnUpdatePost.UseVisualStyleBackColor = false;
            this.btnUpdatePost.Click += new System.EventHandler(this.btnUpdatePost_Click);
            // 
            // txtValorProducto
            // 
            this.txtValorProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValorProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValorProducto.Location = new System.Drawing.Point(788, 98);
            this.txtValorProducto.MaxLength = 15;
            this.txtValorProducto.Name = "txtValorProducto";
            this.txtValorProducto.Size = new System.Drawing.Size(323, 34);
            this.txtValorProducto.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(549, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 23);
            this.label4.TabIndex = 36;
            this.label4.Text = "Valor Producto";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(549, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(549, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nombre del producto";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreProducto.Location = new System.Drawing.Point(788, 32);
            this.txtNombreProducto.MaxLength = 50;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(478, 34);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // postPicBox
            // 
            this.postPicBox.Location = new System.Drawing.Point(27, 34);
            this.postPicBox.Name = "postPicBox";
            this.postPicBox.Size = new System.Drawing.Size(480, 409);
            this.postPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.postPicBox.TabIndex = 42;
            this.postPicBox.TabStop = false;
            // 
            // btnDisablePost
            // 
            this.btnDisablePost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDisablePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnDisablePost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisablePost.FlatAppearance.BorderSize = 0;
            this.btnDisablePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisablePost.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDisablePost.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDisablePost.Location = new System.Drawing.Point(942, 507);
            this.btnDisablePost.Name = "btnDisablePost";
            this.btnDisablePost.Size = new System.Drawing.Size(160, 41);
            this.btnDisablePost.TabIndex = 4;
            this.btnDisablePost.Text = "Desactivar";
            this.btnDisablePost.UseVisualStyleBackColor = false;
            this.btnDisablePost.Click += new System.EventHandler(this.btnDisablePost_Click);
            // 
            // lblImageFileName
            // 
            this.lblImageFileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblImageFileName.AutoSize = true;
            this.lblImageFileName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageFileName.ForeColor = System.Drawing.Color.Black;
            this.lblImageFileName.Location = new System.Drawing.Point(333, 525);
            this.lblImageFileName.Name = "lblImageFileName";
            this.lblImageFileName.Size = new System.Drawing.Size(0, 23);
            this.lblImageFileName.TabIndex = 44;
            // 
            // EditPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 575);
            this.Controls.Add(this.lblImageFileName);
            this.Controls.Add(this.btnDisablePost);
            this.Controls.Add(this.postPicBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.productDescriptionText);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnUpdatePost);
            this.Controls.Add(this.txtValorProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditPostForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar publicación";
            this.Load += new System.EventHandler(this.EditPostForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox productDescriptionText;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnUpdatePost;
        private System.Windows.Forms.TextBox txtValorProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.PictureBox postPicBox;
        private System.Windows.Forms.Button btnDisablePost;
        private System.Windows.Forms.Label lblImageFileName;
    }
}