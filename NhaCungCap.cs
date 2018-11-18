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

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = . ; Database = CSDLQuanLyCF; Integrated security = true";
            SqlConnection cn = new SqlConnection(cnStr);

            string sql = " Select * FROM Supplier";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<NhaCC> list = new List<NhaCC>();
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

            dgvSupplier.DataSource = list;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string cnStr = "Server = . ; Database = CSDLQuanLyCF; Integrated security = true";
            SqlConnection cn = new SqlConnection(cnStr);

            string id, name, address;
            id = txtID.Text;
            name = txtName.Text;
            address = txtAddress.Text; 
            if (string.IsNullOrEmpty(id))
                return;
            string sql = "INSERT INTO Supplier VALUES('" + id + "', N'" + name + "' , N'" + address + "')";
            SqlCommand cmd = new SqlCommand(sql, cn);
        }
    }
}
