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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

         List<NhaCC> GetSupplier()
        {
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true;";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            List<NhaCC> list = new List<NhaCC>();
            string sql = "SELECT * FROM Supplier";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            string id, name, address;
            while (dr.Read())
            {
                id = dr[0].ToString();
                name = dr[1].ToString();
                address = dr[2].ToString();

                NhaCC sup = new NhaCC(id, name, address);
                list.Add(sup);
            }
            dr.Close();
            cn.Close();
            return list;
        }

         private void NhaCungCap_Load(object sender, EventArgs e)
         {
             dgvSupplier.DataSource = GetSupplier();
         }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true;";
            SqlConnection cn = new SqlConnection(cnStr);

            string id, name, address;

            id = txtID.Text;
            name = txtName.Text;
            address = txtAddress.Text;

            if (string.IsNullOrEmpty(id))
                MessageBox.Show("ID khong the Rong", "Add supplier");
            else
            {
                string sql = "INSERT INTO Supplier VALUES('" + id + "', N'" + name + "', N'" + address + "')";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                int soDong = cmd.ExecuteNonQuery();
                if (soDong <= 0)
                    MessageBox.Show("Thêm thất bại", "Add supplier");
                else
                    dgvSupplier.DataSource = GetSupplier();
                MessageBox.Show("Thêm thành công", "Add supplier");
                cn.Close();
            }
        }
    }
}
