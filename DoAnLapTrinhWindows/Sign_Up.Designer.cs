﻿namespace DoAnLapTrinhWindows
{
    partial class Sign_Up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_Up));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Signup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_Confirm = new System.Windows.Forms.Label();
            this.txt_ConfirmPass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(131, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Signup
            // 
            this.btn_Signup.Location = new System.Drawing.Point(317, 386);
            this.btn_Signup.Name = "btn_Signup";
            this.btn_Signup.Size = new System.Drawing.Size(82, 37);
            this.btn_Signup.TabIndex = 10;
            this.btn_Signup.Text = "Sign Up";
            this.btn_Signup.UseVisualStyleBackColor = true;
            this.btn_Signup.Click += new System.EventHandler(this.btn_Signup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "UserName";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(131, 287);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(268, 22);
            this.txt_password.TabIndex = 8;
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(133, 249);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(268, 22);
            this.txt_userName.TabIndex = 7;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(131, 386);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(82, 37);
            this.btn_login.TabIndex = 9;
            this.btn_login.Text = "Log in";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // lbl_Confirm
            // 
            this.lbl_Confirm.AutoSize = true;
            this.lbl_Confirm.Location = new System.Drawing.Point(12, 334);
            this.lbl_Confirm.Name = "lbl_Confirm";
            this.lbl_Confirm.Size = new System.Drawing.Size(115, 16);
            this.lbl_Confirm.TabIndex = 13;
            this.lbl_Confirm.Text = "Confirm Password";
            // 
            // txt_ConfirmPass
            // 
            this.txt_ConfirmPass.Location = new System.Drawing.Point(131, 328);
            this.txt_ConfirmPass.Name = "txt_ConfirmPass";
            this.txt_ConfirmPass.PasswordChar = '*';
            this.txt_ConfirmPass.Size = new System.Drawing.Size(268, 22);
            this.txt_ConfirmPass.TabIndex = 14;
            // 
            // Sign_Up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 450);
            this.Controls.Add(this.txt_ConfirmPass);
            this.Controls.Add(this.lbl_Confirm);
            this.Controls.Add(this.btn_Signup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sign_Up";
            this.Text = "Sign_Up";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Signup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_Confirm;
        private System.Windows.Forms.TextBox txt_ConfirmPass;
    }
}