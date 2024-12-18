﻿using DoAnLapTrinhWindows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DoAnLapTrinhWindows
{
    public partial class Login : Form
    {
        DBModels context = new DBModels();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = txt_userName.Text.Trim();
                string Password = txt_password.Text.Trim();
                bool verifyPassword = false;
                var user = context.USER_ACCOUNTS
                        .FirstOrDefault(u => u.USERNAME == UserName);
                var admin = context.ADMIN_ACCOUNTS
                        .FirstOrDefault(u => u.ADMINNAME == UserName);
                
                if(user != null)
                    verifyPassword = BCrypt.Net.BCrypt.Verify(Password, user.PASSWORD1);       
                else if(admin != null)
                    verifyPassword = BCrypt.Net.BCrypt.Verify(Password, admin.PASSWORD1);

                if ((user != null || admin != null) && verifyPassword)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    if (admin != null)
                    {
                        AdminForm adminForm = new AdminForm(admin);
                        adminForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    MessageBox.Show(Password + "\n" + admin.PASSWORD1 + "\n" + verifyPassword.ToString());
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);    
            }
        }


        private void btn_Signup_Click(object sender, EventArgs e)
        {
            Form f = new Sign_Up();
            f.ShowDialog();
            this.Close();
        }
    }
}