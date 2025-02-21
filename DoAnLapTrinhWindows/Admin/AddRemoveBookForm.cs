﻿using DoAnLapTrinhWindows.Models;
using DoAnLapTrinhWindows.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhWindows.Admin
{
    public partial class AddRemoveBookForm : Form
    {
        DBModels context;
        ADMIN_ACCOUNT admin;

        private string imageFilePath;

        public AddRemoveBookForm(ADMIN_ACCOUNT admin, DBModels context)
        {
            InitializeComponent();
            this.admin = admin;
            this.context = context;
        }

        private string SaveImageToFile()
        {
            if (this.picBookImage.Image != null)
            {
                string directory = "Images";
                string folderPath = Path.Combine(Application.StartupPath, directory);
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                string fileName = System.IO.Path.GetFileName(imageFilePath);
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                this.picBookImage.Image.Save(filePath);
                return filePath;
            }
            return string.Empty;
        }

        private void Check()
        {
            if (this.txtBookName.Text == "")
            {
                MessageBox.Show("BookName musn't be empty");
                return;
            }
            if (this.txtAuthor.Text == "")
            {
                MessageBox.Show("Author musn't be empty");
                return;
            }
            if (this.txtPrice.Text == "")
            {
                MessageBox.Show("Price musn't be empty");
                return;
            }
            if (this.txtCategory.Text == "")
            {
                MessageBox.Show("BookName musn't be empty");
                return;
            }
            if (this.txtQuantity.Text == "")
            {
                MessageBox.Show("Quantity musn't be empty");
                return;
            }
        }

        private void Clear()
        {
            this.txtBookName.Text = "";
            this.txtAuthor.Text = "";
            this.txtPrice.Text = "";
            this.txtCategory.Text = "";
            this.txtQuantity.Text = "";
            this.txtImageLink.Text = "";
            this.picBookImage.Image = null;
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            this.toolStripCurrentUser.Text = "current user: " + admin.ADMINNAME;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.picBookImage.Image = Image.FromFile(openFileDialog.FileName);
                imageFilePath = openFileDialog.FileName;
            }
        }

        private void SaveToRedis(string bookId, string imageStream)
        {
            var connection = RedisConnectorHelper.Connection;
            var cache = connection.GetDatabase();
            cache.StringSet(bookId, imageStream);
        }

        private void LoadImageFromUrl(string url, string bookId)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            using (System.Net.WebResponse response = request.GetResponse())
            using (System.IO.Stream stream = response.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                picBookImage.Image = Image.FromStream(new MemoryStream(imageBytes));
                SaveToRedis(bookId, Convert.ToBase64String(imageBytes));
            }
        }

        private void LoadImageFromFile(string filePath, string bookId)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);
            picBookImage.Image = Image.FromFile(filePath);
            SaveToRedis(bookId, Convert.ToBase64String(imageBytes));
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                var find = context.BOOKS.FirstOrDefault(book => book.NAME_BOOK == this.txtBookName.Text);
                if (find != null)
                {
                    MessageBox.Show("Book already exists");
                    return;
                }
                else
                {
                    this.Check();
                    string imageLink = this.txtImageLink.Text;
                    if (string.IsNullOrEmpty(imageLink))
                    {
                        imageLink = SaveImageToFile();
                    }

                    if (string.IsNullOrEmpty(imageLink))
                    {
                        MessageBox.Show("Image mustn't be empty");
                        return;
                    }

                    BOOK book = new BOOK()
                    {
                        AUTHOR = this.txtAuthor.Text,
                        CATEGORY = this.txtCategory.Text,
                        NAME_BOOK = this.txtBookName.Text,
                        QUANTITY = int.Parse(this.txtQuantity.Text),
                        PRICE = int.Parse(this.txtPrice.Text),
                        LINK_IMG = imageLink
                    };
                    context.BOOKS.Add(book);
                    context.SaveChanges();
                    if(imageLink.Contains("http"))
                    {
                        LoadImageFromUrl(imageLink, book.ID_BOOK.ToString());
                    }
                    else
                    {
                        LoadImageFromFile(imageLink, book.ID_BOOK.ToString());
                    }
                    MessageBox.Show("Book successfully added");
                    this.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void btnRemoveBook_Click(object sender, EventArgs e)
        {
            try
            {
                var find = context.BOOKS.FirstOrDefault(book => book.NAME_BOOK == this.txtBookName.Text);
                if (find == null)
                {
                    MessageBox.Show("Book doesn't exist");
                    return;
                }
                else
                {
                    context.BOOKS.Remove(find);
                    context.SaveChanges();
                    MessageBox.Show("Book successfully removed");
                    this.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}