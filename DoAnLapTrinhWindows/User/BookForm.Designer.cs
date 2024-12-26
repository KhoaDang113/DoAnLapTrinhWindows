namespace DoAnLapTrinhWindows.User
{
    partial class BookForm
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
            this.flpBookList = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.txtPageNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // flpBookList
            // 
            this.flpBookList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpBookList.AutoScroll = true;
            this.flpBookList.Location = new System.Drawing.Point(27, 51);
            this.flpBookList.Name = "flpBookList";
            this.flpBookList.Size = new System.Drawing.Size(1144, 632);
            this.flpBookList.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(1180, 45);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Kệ Sách Thần Kì";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.guna2HtmlLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPrev.ForeColor = System.Drawing.Color.DeepPink;
            this.btnPrev.Location = new System.Drawing.Point(449, 697);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 31);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNext.ForeColor = System.Drawing.Color.DeepPink;
            this.btnNext.Location = new System.Drawing.Point(709, 697);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 31);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnPage_Click);
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLast.ForeColor = System.Drawing.Color.DeepPink;
            this.btnLast.Location = new System.Drawing.Point(657, 697);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(46, 31);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnPage_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnFirst.ForeColor = System.Drawing.Color.DeepPink;
            this.btnFirst.Location = new System.Drawing.Point(495, 697);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(46, 31);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnPage_Click);
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPageNumber.DefaultText = "1";
            this.txtPageNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPageNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPageNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPageNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPageNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPageNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPageNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPageNumber.Location = new System.Drawing.Point(559, 697);
            this.txtPageNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.PasswordChar = '\0';
            this.txtPageNumber.PlaceholderText = "";
            this.txtPageNumber.SelectedText = "";
            this.txtPageNumber.Size = new System.Drawing.Size(79, 31);
            this.txtPageNumber.TabIndex = 6;
            this.txtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageNumber.TextChanged += new System.EventHandler(this.txtPageNumber_TextChanged);
            this.txtPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNumber_KeyPress);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 740);
            this.Controls.Add(this.txtPageNumber);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.flpBookList);
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBookList;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private Guna.UI2.WinForms.Guna2TextBox txtPageNumber;
    }
}