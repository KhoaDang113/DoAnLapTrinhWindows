namespace DoAnLapTrinhWindows.User
{
    partial class DetailedBookForm
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
            this.picBook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).BeginInit();
            this.SuspendLayout();
            // 
            // picBook
            // 
            this.picBook.Location = new System.Drawing.Point(202, 95);
            this.picBook.Name = "picBook";
            this.picBook.Size = new System.Drawing.Size(221, 259);
            this.picBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBook.TabIndex = 0;
            this.picBook.TabStop = false;
            // 
            // DetailedBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBook);
            this.Name = "DetailedBookForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.DetailedBookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBook;
    }
}