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
        DataProvider daP;
        public string type;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            daP = new DataProvider();
            {
                string userName = txtUsername.Text;
                string password = txtPassword.Text;
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))  
                {
                    MessageBox.Show("Yêu cầu thông tin chưa đầy đủ ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (daP.Login(userName, password))
                    {
                        DangNhap frm = new DangNhap();
                        this.DialogResult = DialogResult.OK;
                        this.Hide();

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("UserName hoặc Password không đúng !", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
            }

        }
        }
}

