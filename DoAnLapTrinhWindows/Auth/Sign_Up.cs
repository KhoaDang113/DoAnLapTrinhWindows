using DoAnLapTrinhWindows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnLapTrinhWindows
{
    public partial class Sign_Up : Form
    {
        DBModels context = new DBModels();
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void btn_Signup_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txt_userName.Text.Trim();
                string password = txt_password.Text.Trim();
                string confirmPassword = txt_ConfirmPass.Text.Trim();
                var user = context.USER_ACCOUNTS
                        .FirstOrDefault(u => u.USERNAME == userName);
                if (user == null) 
                {
                    if (confirmPassword == password) 
                    {
                        USER_ACCOUNT uSER_ACCOUNT = new USER_ACCOUNT()
                        {
                            ID_USER = context.USER_ACCOUNTS.ToList().Count,
                            USERNAME = userName,
                            PASSWORD1 = BCrypt.Net.BCrypt.EnhancedHashPassword(password,4),
                        };
                        context.USER_ACCOUNTS.Add(uSER_ACCOUNT);
                        context.SaveChanges();
                        MessageBox.Show("Đăng ký thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Confirm Password phải trùng với password");
                    }   
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại tên người dùng không được trùnng nhau");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
