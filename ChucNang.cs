using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QuanLyCF;
namespace QuanLyCF
{
    public class ChucNang
    {
        public SqlConnection cn;
        public DataTable memberTable;
        public SqlDataAdapter da;
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            string sql = " Select * FROM Product";
            DataProvider daP = new DataProvider();
            daP.Connection();
            da = new SqlDataAdapter(sql, daP.cnn);
            da.Fill(ds);
            return ds;
        }
        public void Them(DataTable daT, string id, string name, string purchasePrice, string sellingPrice, string categoryId, string supplierId)
        {
            foreach (DataRow r in daT.Rows)
            {
                if (string.Compare(r["id"].ToString(), id) == 0)
                {
                    MessageBox.Show("Trùng id", "Cảnh Báo");
                    return;
                }

            }
            DataRow row = daT.NewRow();
            row["id"] = id;
            row["name"] = name;
            row["purchasePrice"] = purchasePrice;
            row["sellingPrice"] =sellingPrice;
            row["categoryId"] = categoryId;
            row["supplierId"] = supplierId;
            daT.Rows.Add(row);
        }
        public void Update(DataTable daT)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(daT);
        }
        public void Del(int row, DataTable daT)
        {
            daT.Rows[row].Delete();
        }
        
    }
}
