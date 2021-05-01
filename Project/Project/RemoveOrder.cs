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
    public partial class RemoveOrder : Form
    {
        public RemoveOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            string searchName = searchItemName.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from orders where name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Order o = new Order();
            while (reader.Read())
            {

                o.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                o.Name = reader.GetString(reader.GetOrdinal("Name"));
                o.Type = reader.GetString(reader.GetOrdinal("Type"));
                o.Price = reader.GetString(reader.GetOrdinal("Price"));
                o.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));

            }
            tbName.Text = o.Name;
            tbPrice.Text = o.Price;
            tbQuantity.Text = o.Quantity;

            conn.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string searchName = searchItemName.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM orders WHERE name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            new CheckOrder().Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }
    }
}
