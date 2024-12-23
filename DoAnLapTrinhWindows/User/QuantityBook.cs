using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLapTrinhWindows.Models;

namespace DoAnLapTrinhWindows.User
{
    public partial class QuantityBook : Form
    {
        DBModels contextDB = new DBModels();
        private int price;
        private int idBook1;
        private int idUser1;

        public QuantityBook()
        {
            InitializeComponent();
            
        }
        public QuantityBook(string NameBook, Image ImageBook, int Price, int IDBook, int IDUser)
        {
            InitializeComponent();
            price = Price;
            idBook1 = IDBook;
            idUser1 = IDUser;
            LoadBuyBook(NameBook,ImageBook);
        }
        public void LoadBuyBook(string NameBook, Image ImageBook)
        {
            this.lblNameBook.Text = NameBook;
            this.txtTotalPrice.Text = $" {price:C0} đ";
            this.ptbImgBook.Image = ImageBook;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button sn = sender as Button;
                int value = int.Parse(txtQuantity.Text.ToString());
                switch (sn.Text.ToString())
                {
                    case "+":
                        value += 1;
                        break;
                    case "-":
                        if(value > 0)
                        {
                            value -= 1;
                        }
                        break;
                    default:
                        value = 1;
                        break;
                }
                txtQuantity.Text = value.ToString();
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    txtTotalPrice.Text = "0,000";
                    return;
                }
                int value = int.Parse(txtQuantity.Text.ToString());
                if (!int.TryParse(txtQuantity.Text, out value) || value <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá trị lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Text = "1";
                }
                this.txtTotalPrice.Text = $" {(price * int.Parse(txtQuantity.Text.ToString())):C0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Text = "1";
                txtTotalPrice.Text = $" {price:C0} đ"; 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var transaction = contextDB.Database.BeginTransaction())
            {
                try
                {
                    var book = contextDB.BOOKS.FirstOrDefault(b => b.ID_BOOK == idBook1);
                    if (book != null)
                    {
                        int quantity = int.Parse(book.QUANTITY.ToString());
                        int quantityBuy = int.Parse(txtQuantity.Text);

                        if (quantity < quantityBuy)
                        {
                            MessageBox.Show($"Số lượng tồn chỉ còn: {quantity}");

                        }
                        else
                        {
                            book.QUANTITY = quantity - quantityBuy;
                            string toltalPrice = txtTotalPrice.Text;
                            InvoiceDetail bookBook = new InvoiceDetail(idBook1, quantityBuy, toltalPrice, idUser1);
                            this.Hide();
                            bookBook.ShowDialog();
                            this.Close();
                            transaction.Commit();
                            //MessageBox.Show($"Đã mua thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sách trong cơ sở dữ liệu.");
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
