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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(" Vui long nhap day du username va password ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        

            if (Login(username,password) == true)
            {
                DialogResult result = DialogResult.OK;
                this.DialogResult = result;
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Username hoac password khong hop le!", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    txtUsername.Focus();
                }
            }
        }

            private bool Login(string username, string password)
        {
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true;";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            string sql = "SELECT COUNT(UserName) FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;;
            cmd.CommandType = CommandType.Text;
            int count = (int)cmd.ExecuteScalar();

            cn.Close();

            if ( count == 1 )
                return true;
            else 
                return false;

        }
        }
}

