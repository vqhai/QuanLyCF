using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using QuanLyCF;
namespace QuanLyCFTest
{
    [TestClass]
    public class UnitTest1
    {
        private DataProvider daP;
        private ChucNang cn;
        private DataSet ds;
        [TestInitialize]
        public void SetUp()
        {
            daP = new DataProvider();
            cn = new ChucNang();
            ds = cn.GetData();
        }
        [TestMethod]
        public void TestLogin1()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "admin";
            string pass = "123";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLogin2()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "user1";
            string pass = "111";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLogin3()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "user2";
            string pass = "222";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLogin4()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "user3";
            string pass = "333";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLogin5()
        {
            SetUp();
            bool expected = true;
            bool actual = true;
            string user = "user4";
            string pass = "444";
            if (daP.Login(user, pass) == true)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLoginNullPass()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = "sssa";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLoginNullPass1()
        {
            SetUp();
            bool expected = false;

            string user = "admin";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLoginEmpty()
        {
            SetUp();
            bool expected = false;

            string user = " ";
            string pass = " ";
            bool actual = true;
            if (daP.Login(user, pass) == false)
            {
                actual = false;

            }
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestThem1()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphe", "Latte", "8000", "10000", "1" ,"Pepsico");
            Assert.AreEqual(1, daTt.Rows.Count);

        }
        [TestMethod]
        public void TestThem2()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Bialon", "Heniken", "10000", "18000", "2", "Sapporo");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThem3()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "Capuchino", "9000", "11000", "3", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullID()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", "Capuchino", "9000", "11000", "3", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullTen()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "", "9000", "11000", "3", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemNullGiaMua()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "Capuchino", "", "11000", "3", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        public void TestThemNullGiaBan()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "Capuchino", "8000", "", "3", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        public void TestThemNullLoai()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "Capuchino", "8000", "11000", "", "NamViet");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        public void TestThemNullNCC()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, "Caphenong", "Capuchino", "8000", "11000", "3", "");
            Assert.AreEqual(1, daTt.Rows.Count);
        }
        [TestMethod]
        public void TestThemEmpty()
        {
            SetUp();
            DataTable daTt = ds.Tables[0];
            Assert.AreEqual(0, daTt.Rows.Count);
            cn.Them(daTt, " ", " ", " ", " ", " "," ");
            Assert.AreEqual(1, daTt.Rows.Count);
        }

        [TestMethod]
        public void TestXoa()
        {
            SetUp();
            DataTable daTx = ds.Tables[0];
            cn.Them(daTx, "Bialon", "Heniken", "10000", "18000", "2", "Sapporo");
            cn.Them(daTx, "Caphe", "Latte", "10000", "12000", "2", "Sapporo");//dong muon xoa
            cn.Them(daTx, "Sting", "Nước tăng lực", "9000", "11000", "2", "Sapporo");

            cn.Del(1, daTx);
            Assert.AreEqual(2, daTx.Rows.Count);
            cn.Del(0, daTx);
            cn.Del(0, daTx);
        }
        [TestMethod]
        public void TestUpdate()
        {
            SetUp();
            DataTable daTa = ds.Tables[0];
            cn.Them(daTa, "Bialon", "Heniken", "10000", "18000", "2", "Sapporo");
            cn.Them(daTa, "Caphe", "Latte", "10000", "12000", "2", "Sapporo");
            cn.Them(daTa, "Sting", "Nước tăng lực", "9000", "11000", "2", "Sapporo");
            cn.Update(daTa);

            DataTable tbNew = ds.Tables[0];
            Assert.AreEqual(3, tbNew.Rows.Count);
            cn.Del(0, daTa);
            cn.Del(0, daTa);
            cn.Del(0, daTa);
        }
        }
}

