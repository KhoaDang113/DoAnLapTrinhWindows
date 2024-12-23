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
using DoAnLapTrinhWindows.Models;

namespace DoAnLapTrinhWindows.User
{
    public partial class InvoiceDetail : Form
    {
        DBModels context = new DBModels();

        public InvoiceDetail()
        {
            InitializeComponent();
        }
        public InvoiceDetail(int IDBook, int Quantity, string ToltalPrice, int IDUser)
        {
            InitializeComponent();
            loadInvoiceDetail(IDBook, Quantity, ToltalPrice, IDUser);
        }

        private void loadInvoiceDetail(int idBook, int quantity, string toltalPrice, int idUser)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    var invoiceDetail = context.INVOICE_DETAILS.Max(i => i.ID_INVOICE_DETAILS);
                    var book = context.BOOKS.FirstOrDefault(b => b.ID_BOOK == idBook);
                    var user = context.USER_ACCOUNTS.FirstOrDefault(u => u.ID_USER == idUser);
                    if (invoiceDetail != null)
                    {
                        int idInvoiceDetail = invoiceDetail + 1;
                        lbl_ID_Invoice.Text = idInvoiceDetail.ToString();
                    }
                    else { lbl_ID_Invoice.Text = "1"; }
                    lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    lbl_User.Text = user.USERNAME;
                    lbl_BookName.Text = book.NAME_BOOK;
                    lbl_QuantityBook.Text = quantity.ToString();
                    lbl_ToltalPrice.Text = toltalPrice;

                    var record = new INVOICE_DETAILS
                    {
                        ID_INVOICE_DETAILS = int.Parse(lbl_ID_Invoice.Text),
                        ID_BOOK = idBook,
                        ID_USER = idUser,
                        BUY_DATE = DateTime.Now,
                        BUY_QUANTITY = quantity,
                        TOTAL = int.Parse(toltalPrice.Replace("$", "").Replace(" ", "").Replace("đ", "").Replace(",", "").Trim()),
                    };
                    context.INVOICE_DETAILS.Add(record);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
