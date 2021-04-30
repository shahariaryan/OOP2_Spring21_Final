using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name = tbName.Text;
            string type = gbType.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text; ;
            var price = tbPrice.Text; 
            string quantity = tbQuantity.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Insert into orders values ('{0}','{1}','{2}','{3}')", name, type, price, quantity);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Order Added");
                new Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
            conn.Close();
        }
          protected override void OnFormClosing(FormClosingEventArgs e)
          {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }
    }
}

