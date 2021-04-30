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
using System.Collections;


namespace Project
{
    public partial class CheckItem : Form
    {
        public CheckItem()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = GetItem();
            dtItems.DataSource = list;
        }
        private List<Items> GetItem()
        {
            var conn = Database.ConnectDB();
            conn.Open();

            string query = "Select * from items";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Items> list = new List<Items>();
            while (reader.Read())
            {
                Items i = new Items();
                i.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                i.Name = reader.GetString(reader.GetOrdinal("Name"));
                i.Type = reader.GetString(reader.GetOrdinal("Type"));
                i.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
                i.Cost = reader.GetString(reader.GetOrdinal("Cost"));
              
                list.Add(i);

            }
            conn.Close();
            return list;
        }

        private void CheckItem_Load(object sender, EventArgs e)
        {
            var list = GetItem();
            dtItems.DataSource = list;
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchItemId.Text);

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from items where id='{0}'", searchId);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchItemId.Text);
            string name = tbName.Text;
            string type = tbType.Text;
            string quantity = tbQuantity.Text;
            var cost = tbCost.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Update items set name='{0}',type='{1}',quantity='{2}',cost='{3}' where Id={4}", name, type, quantity, cost, searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            var list = GetItem();
            dtItems.DataSource = list;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerDash().Show();
            
        }

        private void searchItemId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
