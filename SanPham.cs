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
        SqlDataAdapter da;
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true;";
            cn = new SqlConnection(cnStr);

            DataSet ds = GetProduct();
            productTable = ds.Tables[0];
            dgvProduct.DataSource = productTable;
        }
        DataSet GetProduct()
        {
            DataSet ds = new DataSet();

            string sql = "SELECT * FROM Product";
            da = new SqlDataAdapter(sql, cn);

            int number = da.Fill(ds);

            return ds;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow row = productTable.NewRow();

            row["id"] = txtId.Text;
            row["name"] = txtName.Text;
            row["purchasePrice"] = txtPurchase.Text;
            row["sellingPrice"] = txtSelling.Text;
            row["categoryId"] = txtCategory.Text;
            row["supplierId"] = txtSupplier.Text;

            productTable.Rows.Add(row);
        }


        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;

            if (dgvProduct.Columns[col] is DataGridViewButtonColumn && dgvProduct.Columns[col].Name == "Delete")
            {
                int row = e.RowIndex;
                if (row >= 0 && row < dgvProduct.Rows.Count)
                {
                    productTable.Rows[row].Delete();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(productTable);
        }
    }
}
