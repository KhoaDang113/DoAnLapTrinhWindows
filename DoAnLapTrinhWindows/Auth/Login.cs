using DoAnLapTrinhWindows.Models;
using DoAnLapTrinhWindows.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
                string userName = txt_userName.Text.Trim();
                string password = txt_password.Text.Trim();
                bool verifyPassword = false;

                var user = context.USER_ACCOUNTS.FirstOrDefault(u => u.USERNAME == userName);
                var admin = context.ADMIN_ACCOUNTS.FirstOrDefault(u => u.ADMINNAME == userName);

                if (user != null)
                {
                    verifyPassword = BCrypt.Net.BCrypt.EnhancedVerify(password, user.PASSWORD1);
                    if (!verifyPassword)
                    {
                        verifyPassword = BCrypt.Net.BCrypt.Verify(password, user.PASSWORD1);
                    }
                }
                else if (admin != null)
                {
                    verifyPassword = BCrypt.Net.BCrypt.EnhancedVerify(password, admin.PASSWORD1);
                    if (!verifyPassword)
                    {
                        verifyPassword = BCrypt.Net.BCrypt.Verify(password, admin.PASSWORD1);
                    }
                }

                if ((user != null || admin != null) && verifyPassword)
                {
                    MessageBox.Show("Login successful");
                    if (user != null)
                    {
                        var IDUser = user.ID_USER;
                        BookForm userForm = new BookForm(IDUser);
                        this.Hide();
                        userForm.ShowDialog();
                        this.Close();
                    }
                    if (admin != null)
                    {
                        AdminForm adminForm = new AdminForm(admin, context);
                        adminForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Signup_Click(object sender, EventArgs e)
        {
            Form signUpForm = new Sign_Up();
            signUpForm.ShowDialog();
        }
    }
}
