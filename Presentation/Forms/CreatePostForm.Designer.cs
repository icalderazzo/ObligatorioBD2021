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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.txtValorProducto = new System.Windows.Forms.TextBox();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.Imagen = new System.Windows.Forms.PictureBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreProducto.Location = new System.Drawing.Point(171, 168);
            this.txtNombreProducto.MaxLength = 50;
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(478, 34);
            this.txtNombreProducto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 31);
            this.label2.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(400, 320);
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
            this.label5.Location = new System.Drawing.Point(253, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 34);
            this.label5.TabIndex = 24;
            this.label5.Text = "Alta Publicación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(55, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Imagen Adjunta";
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescripcionProducto.Location = new System.Drawing.Point(171, 239);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(478, 34);
            this.txtDescripcionProducto.TabIndex = 14;
            // 
            // txtValorProducto
            // 
            this.txtValorProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValorProducto.Location = new System.Drawing.Point(565, 313);
            this.txtValorProducto.MaxLength = 15;
            this.txtValorProducto.Name = "txtValorProducto";
            this.txtValorProducto.Size = new System.Drawing.Size(85, 34);
            this.txtValorProducto.TabIndex = 16;
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(237)))));
            this.btnCreatePost.FlatAppearance.BorderSize = 0;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreatePost.Location = new System.Drawing.Point(471, 832);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(179, 41);
            this.btnCreatePost.TabIndex = 23;
            this.btnCreatePost.Text = "Crear Publicación";
            this.btnCreatePost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCreatePost.UseVisualStyleBackColor = false;
            this.btnCreatePost.Click += new System.EventHandler(this.btnCreatePost_Click);
            // 
            // Imagen
            // 
            this.Imagen.Image = global::Presentation.Properties.Resources.Post;
            this.Imagen.Location = new System.Drawing.Point(55, 377);
            this.Imagen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(595, 396);
            this.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Imagen.TabIndex = 27;
            this.Imagen.TabStop = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(55, 780);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(123, 29);
            this.btnAddImage.TabIndex = 28;
            this.btnAddImage.Text = "Elegir imagen";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // CreatePostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(704, 919);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.Imagen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreatePost);
            this.Controls.Add(this.txtValorProducto);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreProducto);
            this.Name = "CreatePostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.TextBox txtValorProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreatePost;
        private System.Windows.Forms.Button btnReturnToInit;
        private System.Windows.Forms.PictureBox Imagen;
        private System.Windows.Forms.Button btnAddImage;
    }
}
