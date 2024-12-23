using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLapTrinhWindows.Models;

namespace DoAnLapTrinhWindows.User
{
    public partial class BookForm : Form
    {
        private int currentPage = 1; 
        private int itemsPerPage = 10;
        private int totalPages = 1;
        public BookForm()
        {
            InitializeComponent();
            CalculateTotalPages();
            LoadBooks(currentPage);
        }

        private void CalculateTotalPages()
        {
            using (DBModels context = new DBModels())
            {
                int totalBooks = context.BOOKS.Count();
                totalPages = (int)Math.Ceiling(totalBooks / (double)itemsPerPage);
            }
        }

        
        public void LoadBooks(int page)
        {
            using (DBModels context = new DBModels())
            {
                var books = context.BOOKS
                              .OrderBy(b => b.ID_BOOK)
                              .Skip((page - 1) * itemsPerPage)
                              .Take(itemsPerPage)
                              .ToList();

                flpBookList.Controls.Clear();

                foreach (var book in books)
                {
                    var bookItem = new BookItem
                    {
                        Title = book.NAME_BOOK,
                        Price = int.Parse(book.PRICE.ToString()),
                        idBook = book.ID_BOOK,
                    };
                    bookItem.LoadImageFromUrl(book.LINK_IMG);

                    flpBookList.Controls.Add(bookItem);
                }
            }
        }
        private void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Button sn = sender as Button;
                switch (sn.Text.ToString())
                {
                    case "<":
                        if (currentPage > 1)
                        {
                            currentPage--;
                            txtPageNumber.Text = currentPage.ToString();
                        }
                        break;
                    case ">":
                        if (currentPage < totalPages)
                        {
                            currentPage++;
                            txtPageNumber.Text = currentPage.ToString();
                        }
                        break;
                    case "First":
                        currentPage = 1;
                        txtPageNumber.Text = currentPage.ToString();
                        break;
                    case "Last":
                        currentPage = totalPages;
                        txtPageNumber.Text = currentPage.ToString();
                        break;
                    default:
                        LoadBooks(1);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtPageNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPageNumber.Text))
                {
                    return;
                }
                if (!int.TryParse(txtPageNumber.Text, out int currentPage) || currentPage <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá trị là số nguyên lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPageNumber.Text = "1";
                    return;
                }
                if (currentPage > totalPages)
                {
                    txtPageNumber.Text = totalPages.ToString();
                    LoadBooks(totalPages);
                }
                else
                {
                    LoadBooks(currentPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
