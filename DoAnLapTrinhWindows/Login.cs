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
using DoAnLapTrinhWindows.Modifile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DoAnLapTrinhWindows
{
    public partial class Login : Form
    {
        DBModes context = new DBModes();
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
                var user = context.USER_ACCOUNT
                        .FirstOrDefault(u => u.USERNAME == UserName && u.PASSWORD1 == Password);
                var admin = context.ADMIN_ACCOUNT
                        .FirstOrDefault(u => u.ADMINNAME == UserName && u.PASSWORD1 == Password);
                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
                else if(admin != null)
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);    
            }
        }

        private void btn_Signup_Click(object sender, EventArgs e)
        {

        }
    }
}
