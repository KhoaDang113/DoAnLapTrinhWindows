namespace DoAnLapTrinhWindows.User
{
    partial class BookItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookItem));
            this.lblNameBook = new System.Windows.Forms.Label();
            this.lblPriceBook = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.ptbImgBook = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImgBook)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameBook
            // 
            this.lblNameBook.AllowDrop = true;
            this.lblNameBook.AutoSize = true;
            this.lblNameBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNameBook.Location = new System.Drawing.Point(34, 173);
            this.lblNameBook.Name = "lblNameBook";
            this.lblNameBook.Size = new System.Drawing.Size(99, 20);
            this.lblNameBook.TabIndex = 1;
            this.lblNameBook.Text = "NameBook";
            // 
            // lblPriceBook
            // 
            this.lblPriceBook.AutoSize = true;
            this.lblPriceBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPriceBook.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPriceBook.Location = new System.Drawing.Point(34, 227);
            this.lblPriceBook.Name = "lblPriceBook";
            this.lblPriceBook.Size = new System.Drawing.Size(79, 16);
            this.lblPriceBook.TabIndex = 2;
            this.lblPriceBook.Text = "PriceBook";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Red;
            this.guna2Button1.Font = new System.Drawing.Font("Sans Serif Collection", 4.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Yellow;
            this.guna2Button1.Location = new System.Drawing.Point(111, 256);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(76, 23);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Mua";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ptbImgBook
            // 
            this.ptbImgBook.BackColor = System.Drawing.Color.Transparent;
            this.ptbImgBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbImgBook.Image = ((System.Drawing.Image)(resources.GetObject("ptbImgBook.Image")));
            this.ptbImgBook.ImageRotate = 0F;
            this.ptbImgBook.Location = new System.Drawing.Point(37, 10);
            this.ptbImgBook.Name = "ptbImgBook";
            this.ptbImgBook.Size = new System.Drawing.Size(150, 149);
            this.ptbImgBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbImgBook.TabIndex = 4;
            this.ptbImgBook.TabStop = false;
            this.ptbImgBook.Click += new System.EventHandler(this.ptbImgBook_Click);
            // 
            // BookItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ptbImgBook);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lblPriceBook);
            this.Controls.Add(this.lblNameBook);
            this.Name = "BookItem";
            this.Size = new System.Drawing.Size(219, 295);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImgBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNameBook;
        private System.Windows.Forms.Label lblPriceBook;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2PictureBox ptbImgBook;
    }
}