using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyCF;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyCF
{
    public class DataProvider
    {
        public SqlConnection cnn;

        public void Connection()
        {
            try
            {
                string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true";
                cnn = new SqlConnection(cnStr);
                if (cnn != null && cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void DisConnecTion()
        {
            cnn.Close();
        }
        public bool Login(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            string userName = UserName;
            string password = Password;

            Connection();
            string cnStr = "Server = .; Database = CSDLQuanLyCF; Integrated security = true;";
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            string sql = "SELECT COUNT(UserName) FROM Users WHERE Username = '" + userName + "' AND Password = '" + password + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql; ;
            cmd.CommandType = CommandType.Text;
            int count = (int)cmd.ExecuteScalar();

            cn.Close();

            if (count == 1)
                return true;
            else
                return false;
        }

    }
}
