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
    public partial class RemoveItem : Form
    {
        public RemoveItem()
        {
            InitializeComponent();
        }

        private void RemoveItem_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            string searchName = searchItemName.Text;

             var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from items where name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Items i = new Items();
            while (reader.Read())
            {

                i.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                i.Name = reader.GetString(reader.GetOrdinal("Name"));
                i.Type = reader.GetString(reader.GetOrdinal("Type"));
                i.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                i.Cost = reader.GetString(reader.GetOrdinal("Cost"));


            }
            tbName.Text = i.Name;
            tbType.Text = i.Type;
            tbQuantity.Text = i.Quantity;
            tbCost.Text = i.Cost;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string searchName = searchItemName.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM items WHERE name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            new CheckItem().Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerDash().Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void searchItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbType_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbCost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
