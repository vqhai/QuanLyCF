using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCF
{
    public partial class SanPham : Form
    {
        SqlConnection cn;
        DataTable productTable;
        public SanPham()
        {
            InitializeComponent();
        }
        ChucNang cng = new ChucNang();
        private void SanPham_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true ;";
            cng.cn = new SqlConnection(cnStr);
            DataSet ds = cng.GetData();
            cng.memberTable = ds.Tables[0];
            dgvProduct.DataSource = cng.memberTable;
        }



        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvProduct.Columns[col] is DataGridViewButtonColumn && dgvProduct.Columns[col].Name == "Delete")
            {
                int row = e.RowIndex;
                if (row >= 0 && row < dgvProduct.Rows.Count)
                {
                    cng.Del(row, cng.memberTable);
                }
            }
        }

        private void SanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cng.Them(cng.memberTable, txtId.Text, txtName.Text, txtPurchase.Text, txtSelling.Text, txtCategory.Text, txtSupplier.Text);
            dgvProduct.DataSource = cng.memberTable;
            txtId.Text = txtName.Text = txtPurchase.Text = txtSelling.Text = txtCategory.Text =  txtSupplier.Text= "";
            txtId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cng.Update(cng.memberTable);
            MessageBox.Show("Cập nhập thành công ", "Cập Nhập");
            txtId.Text = txtName.Text = txtPurchase.Text = txtSelling.Text = txtCategory.Text = txtSupplier.Text = "";
            txtId.Focus();
        }

    }
}
