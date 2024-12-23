
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
            InitializeComponent();
        }

        public DetailedBookForm(BOOK book, USER_ACCOUNT user)
        {
            this.book = book;
            this.user = user;
            InitializeComponent();
        }

        private void LoadImage(BOOK book)
        {
            if (book.LINK_IMG.Contains("http"))
            {
                string imageUrl = book.LINK_IMG;
                try
                {
                    System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
                    using (System.Net.WebResponse response = request.GetResponse())
                    using (System.IO.Stream stream = response.GetResponseStream())
                    {
                        if (stream != null)
                            this.picBook.Image = Image.FromStream(stream);
                        else
                            MessageBox.Show("Failed to load image stream.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                this.picBook.Image = Image.FromFile(book.LINK_IMG);
            }
        }

        private void LoadBook()
        {
            var book = context.BOOKS.FirstOrDefault(b => b.NAME_BOOK == "Design Patterns: Elements of Reusable Object-Oriented Software");
            if (book != null)
            {
                this.LoadImage(book);
                var bookName = book.NAME_BOOK.Split();
                var j = 0;
                for (int i = 0; i < bookName.Length; i++)
                {
                    if (i == 4)
                        this.lblBookName.Text += "\n";
                    else
                        this.lblBookName.Text += bookName[i] + " ";
                }

                this.lblMoney.Text = "";
                string priceString = book.PRICE.ToString();
                int length = priceString.Length;
                for (int i = 0; i < length; i++)
                {
                    if (i > 0 && (length - i) % 3 == 0)
                    {
                        this.lblMoney.Text += ",";
                    }
                    this.lblMoney.Text += priceString[i];
                }
                this.lblMoney.Text += " VND";

                this.lblAuthor.Text = book.AUTHOR;
                this.lblCategory.Text = book.CATEGORY;
                if (book.QUANTITY > 0)
                {
                    this.lblStatus.Text = "In stock: " + book.QUANTITY;
                    this.lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    this.lblStatus.Text = "Out of stock";
                    this.lblStatus.ForeColor = Color.Red;
                }
            }
        }

        private void LoadUser()
        {
            try
            {
                var user = context.USER_ACCOUNTS.FirstOrDefault(u => u.USERNAME == "UserLuan");
                this.toolStripStatusUser.Text = "Current user: " + user.USERNAME;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DetailedBookForm_Load(object sender, EventArgs e)
        {
            this.LoadBook();
            this.LoadUser();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
