using DoAnLapTrinhWindows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhWindows.User
{
    public partial class DetailedBookForm : Form
    {
        DBModels context = new DBModels();
        //Testing Book
        BOOK book;
        //Testing User
        USER_ACCOUNT user;
        public DetailedBookForm()
        {
            context.BOOKS.FirstOrDefault(b => b.NAME_BOOK.Equals(""))
            InitializeComponent();
        }

        private void DetailedBookForm_Load(object sender, EventArgs e)
        {
            string imageUrl = "https://m.media-amazon.com/images/I/81IGFC6oFmL.jpg";
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
                using (System.Net.WebResponse response = request.GetResponse())
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        this.picBook.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        MessageBox.Show("Failed to load image stream.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
