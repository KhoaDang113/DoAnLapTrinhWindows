
using DoAnLapTrinhWindows.Admin;
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
        DBModels context;
        string selectedButton = "Books";


        public AdminForm(ADMIN_ACCOUNT admin, DBModels context)
        {
            this.admin = admin;
            this.context = context;
            InitializeComponent();
        }

        //DATA CHART
        private void SetChartVisible()
        {
            this.dataChart.Visible = !this.dataChart.Visible;
            this.dataPieChart.Visible = !this.dataPieChart.Visible;
            this.lblYear.Visible = !this.lblYear.Visible;
        }

        private Dictionary<int, int> CalculateTotalOfEachMonth()
        {
            Dictionary<int, int> total = new Dictionary<int, int>();
            for (int i = 1; i <= 12; i++)
            {
                int monthTotal = 0;
                foreach (var invoice in context.INVOICE_DETAILS)
                {
                    if (invoice != null && invoice.BUY_DATE.Value.Month == i && invoice.BUY_DATE.Value.Year == DateTime.Today.Year)
                    {

                        monthTotal += invoice.TOTAL.Value;
                    }
                }
                total.Add(i, monthTotal);
            }
            return total;
        }

        private void DrawDataChart()
        {
            Dictionary<int, int> total = CalculateTotalOfEachMonth();
            if (dataChart.Series.FindByName("Total") == null)
            {
                dataChart.Series.Add("Total");
                dataChart.Series["Total"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            else
            {
                this.dataChart.Series["Total"].Points.Clear();
            }

            foreach (var item in total)
            {
                int pointIndex = this.dataChart.Series["Total"].Points.AddXY(item.Key, item.Value);
                this.dataChart.Series["Total"].Points[pointIndex].ToolTip = $"Month: {item.Key}, Total: {item.Value}";
            }
        }

        private void DrawDataPieChart()
        {
            Dictionary<int, int> total = CalculateTotalOfEachMonth();
            Dictionary<int, string> monthNames = new Dictionary<int, string>
            {
                { 1, "January" },
                { 2, "February" },
                { 3, "March" },
                { 4, "April" },
                { 5, "May" },
                { 6, "June" },
                { 7, "July" },
                { 8, "August" },
                { 9, "September" },
                { 10, "October" },
                { 11, "November" },
                { 12, "December" }
            };
            int yearTotal = 0;
            foreach (var t in total)
            {
                yearTotal += t.Value;
            }
            if (dataPieChart.Series.FindByName("Total") == null)
            {
                dataPieChart.Series.Add("Total");
                dataPieChart.Series["Total"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            else
                this.dataPieChart.Series["Total"].Points.Clear();
            foreach (var item in total)
            {
                string monthName = monthNames[item.Key];
                if (item.Value != 0)
                {
                    int pointIndex = this.dataPieChart.Series["Total"].Points.AddXY(monthName, item.Value);
                    this.dataPieChart.Series["Total"].Points[pointIndex].ToolTip = $"Month: {monthName}, Total: {item.Value}";
                }
            }
            this.lblYear.Text += yearTotal.ToString();
        }

        // CREATE VIEW
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

            foreach (var Book in context.BOOKS)
            {
                this.dgv.Rows.Add(Book.ID_BOOK, Book.NAME_BOOK, Book.AUTHOR, Book.PRICE, Book.CATEGORY, Book.QUANTITY);
            }
        }

        private void CreateInvoiceView()
        {

            this.dgv.Columns.Clear();
            this.dgv.Rows.Clear();

            this.dgv.Columns.Add("USERNAME", "Tên người dùng");
            this.dgv.Columns.Add("BOOKNAME", "Tên sách");
            this.dgv.Columns.Add("QUANTITY", "Số lượng");
            this.dgv.Columns.Add("TOTAL", "Tổng tiền");
            this.dgv.Columns.Add("DATE", "Ngày mua");

            foreach (var invoice in context.INVOICE_DETAILS)
                this.dgv.Rows.Add(invoice.USER_ACCOUNT.USERNAME, invoice.BOOK.NAME_BOOK, invoice.BUY_QUANTITY, invoice.TOTAL, invoice.BUY_DATE);
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

        // SEARCH
        private void SetlblTimKiem(string text)
        {
            this.lblTimKiem.Text = "Find";
            this.lblTimKiem.Text += " " + text;
        }


        // FORM EVENTS
        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.CreateBookView();
            this.toolStriplblUserName.Text = "Current user: " + admin.ADMINNAME;
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
                // Change view
                ToolStripButton button = sender as ToolStripButton;
                string buttonText = button.Text.Trim();
                if (this.dataChart.Visible)
                    this.SetChartVisible();
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
                this.txtTimKiem.Clear();

                //Sort
                if (button.Text.Equals("sortDesc"))
                {
                    if (selectedButton.Equals("Books"))
                        this.dgv.Sort(this.dgv.Columns["QUANTITY"], ListSortDirection.Descending);
                    else if (selectedButton.Equals("Invoices"))
                        this.dgv.Sort(this.dgv.Columns["TOTAL"], ListSortDirection.Descending);
                }
                else if (button.Text.Equals("sortAsc"))
                {
                    if (selectedButton.Equals("Books"))
                        this.dgv.Sort(this.dgv.Columns["QUANTITY"], ListSortDirection.Ascending);
                    else if (selectedButton.Equals("Invoices"))
                        this.dgv.Sort(this.dgv.Columns["TOTAL"], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuAddBook_Click(object sender, EventArgs e)
        {
            AddRemoveBookForm addBookForm = new AddRemoveBookForm(admin, context);
            addBookForm.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgv.EndEdit();
            string search = this.txtTimKiem.Text.ToLower();
            foreach (DataGridViewRow row in this.dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;
                if (selectedButton.Equals("Books"))
                {
                    if (row.Cells[1].Value.ToString().ToLower().Contains(search))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
                else
                {
                    if (row.Cells[0].Value.ToString().ToLower().Contains(search))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void toolStripButtonAnalyze_Click(object sender, EventArgs e)
        {
            this.SetChartVisible();
            this.DrawDataChart();
            this.DrawDataPieChart();
        }
    }
}
