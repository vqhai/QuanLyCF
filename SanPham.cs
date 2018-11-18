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
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);

            int number = da.Fill(ds);

            return ds;
        }
    }
}
