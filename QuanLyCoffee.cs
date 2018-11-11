using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCF
{
    public partial class QuanLyCoffee : Form
    {
        public QuanLyCoffee()
        {
            InitializeComponent();
        }

        private void QuanLyCoffee_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;

            QuanLyCoffee cf = new QuanLyCoffee();
            DialogResult result = cf.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                label1.Text = "Welcom to Coffee Shop";
            }
        }
    }
}
