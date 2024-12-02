using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnLapTrinhWindows
{
    public partial class Form1 : Form
    {
        SqlConnection sqlcon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(@"Data Source=KHOADEPTRAI;Initial Catalog=DoAnLapTrinhWindows;Integrated Security=True");
                //path Database de vao day
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            string UserName = txt_userName.Text.Trim();
            string Password = txt_password.Text.Trim();
            
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.AddWithValue("@UserName", UserName);
            sqlcmd.Parameters.AddWithValue("@Password", Password);
            sqlcmd.CommandType = CommandType.Text;
            // dung bang luu tru accout user de truy van
            sqlcmd.CommandText = "SELECT * FROM UserAccount WHERE UserName = @UserName AND Password = @Password";
            sqlcmd.Connection = sqlcon;

            

            SqlDataReader data = sqlcmd.ExecuteReader();
            if (data.Read() == true)
            {
                MessageBox.Show("Dang nhap thanh cong");
            }
            else {
                MessageBox.Show("Dang nhap thap bai");
            }
            data.Close();
        }
    }
}
