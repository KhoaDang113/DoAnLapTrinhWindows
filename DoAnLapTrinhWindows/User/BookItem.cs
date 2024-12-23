using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhWindows.User
{
    public partial class BookItem : UserControl
    {
        public BookItem()
        {
            InitializeComponent();
        }
        public int idBook;
        public string Title
        {
            get => lblNameBook.Text;
            set => lblNameBook.Text = value;
        }

        public int Price
        {
            get => int.Parse(lblPriceBook.Text.Replace("đ", "").Trim());
            set => lblPriceBook.Text = $"{value:C0} đ"; 
        }

        public void LoadImageFromUrl(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageData = webClient.DownloadData(url);
                        using (MemoryStream stream = new MemoryStream(imageData))
                        {
                            ptbImgBook.Image = Image.FromStream(stream);
                        }
                    }
                }
                else
                {
                    ptbImgBook.Image = Image.FromFile(@"D:\C#\DoAnLapTrinhWindows\Image\no-image.png");
                }
            }
            catch
            {
                ptbImgBook.Image = Image.FromFile(@"D:\C#\DoAnLapTrinhWindows\Image\no-image.png");
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nameBook = lblNameBook.Text;
            Image imageBook = ptbImgBook.Image;
            string labelText = lblPriceBook.Text;
            int price = int.Parse(labelText.Replace("$", "").Replace(" ", "").Replace("đ", "").Replace(",", "").Trim());
            int idBook1 =  idBook;
            QuantityBook quantityBook = new QuantityBook(nameBook, imageBook, price, idBook1);
            quantityBook.ShowDialog();
        }


        private void ptbImgBook_Click(object sender, EventArgs e)
        {
            DetailedBookForm detailedBookForm = new DetailedBookForm();
            detailedBookForm.ShowDialog();
        }
    }
}
