using DoAnLapTrinhWindows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhWindows
{
    public partial class AdminForm : Form
    {
        ADMIN_ACCOUNT admin;
        DBModels context = new DBModels();
        string selectedButton = "Books";
        

        public AdminForm(ADMIN_ACCOUNT admin)
        {
            this.admin = admin;
            InitializeComponent();
        }

        private void CreateBookView()
        {
            this.dgv.Columns.Clear();
            this.dgv.Rows.Clear();


            this.dgv.Columns.Add("ID_BOOK", "Mã sách");
            this.dgv.Columns.Add("NAME", "Tên sách");
            this.dgv.Columns.Add("AUTHOR", "Tác giả");
            this.dgv.Columns.Add("PRICE", "Giá");
            this.dgv.Columns.Add("CATEGORY", "Thể loại");
            this.dgv.Columns.Add("QUANTITY", "Số lượng");

            foreach(var Book in context.BOOKS)
            {
                this.dgv.Rows.Add(Book.ID_BOOK, Book.NAME_BOOK, Book.AUTHOR, 0, Book.CATEGORY, Book.QUANTITY);
            }
        }

        private void CreateInvoiceView()
        {
            Dictionary<int, string> userDictionary = new Dictionary<int, string>();
            Dictionary<int, string> bookDictionary = new Dictionary<int, string>();

            this.dgv.Columns.Clear();
            this.dgv.Rows.Clear();

            this.dgv.Columns.Add("USERNAME", "Tên người dùng");
            this.dgv.Columns.Add("BOOKNAME", "Tên sách");
            this.dgv.Columns.Add("QUANTITY", "Số lượng");
            this.dgv.Columns.Add("TOTAL", "Tổng tiền");
            this.dgv.Columns.Add("DATE", "Ngày mua");

            foreach (var user in context.USER_ACCOUNTS)
                userDictionary.Add(user.ID_USER, user.USERNAME);
            foreach(var book in context.BOOKS)
                bookDictionary.Add(book.ID_BOOK, book.NAME_BOOK);

            foreach (var invoice in context.INVOICE_DETAILS)
                this.dgv.Rows.Add(userDictionary[invoice.ID_USER], bookDictionary[invoice.ID_BOOK], invoice.BUY_QUANTITY, invoice.TOTAL, invoice.BUY_DATE);
        }

        private bool changeBookData(DataGridViewRow row)
        {
            int bookId = Convert.ToInt32(row.Cells["ID_BOOK"].Value);
            var book = context.BOOKS.FirstOrDefault(b => b.ID_BOOK == bookId);

            if (book != null)
            {
                book.NAME_BOOK = row.Cells["NAME"].Value.ToString();
                book.AUTHOR = row.Cells["AUTHOR"].Value.ToString();
                book.CATEGORY = row.Cells["CATEGORY"].Value.ToString();
                book.QUANTITY = int.Parse(row.Cells["QUANTITY"].Value.ToString());
                
                context.SaveChanges();
                return true;
            }
            return false;
        }


        private void SetlblTimKiem(string text)
        {
            this.lblTimKiem.Text = "Find";
            this.lblTimKiem.Text +=  " " + text;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.CreateBookView();
            SetlblTimKiem("Books");
        }

        private void toolStripThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton button = sender as ToolStripButton;
                string buttonText = button.Text.Trim();

                if (buttonText.Equals("Books"))
                {
                    SetlblTimKiem(buttonText.ToLower());
                    this.CreateBookView();
                    selectedButton = "Books";
                }
                else if (buttonText.Equals("Invoices"))
                {
                    SetlblTimKiem("user");
                    this.CreateInvoiceView();
                    selectedButton = "Invoices";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                if (selectedButton.Equals("Books"))
                {
                    if (changeBookData(row))
                        MessageBox.Show("Update successful");
                    else
                        MessageBox.Show("Failed to update");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
