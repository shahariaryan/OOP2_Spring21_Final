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
    public partial class CheckOrder : Form
    {
        public CheckOrder()
        {
            InitializeComponent();
        }

        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var list = GetOrder();
            dtOrder.DataSource = list;

        }
        private List<Order> GetOrder()
        {
            var conn = Database.ConnectDB();
            conn.Open();

            string query = "Select * from orders";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Order> list = new List<Order>();
            while (reader.Read())
            {
                Order o = new Order();
                o.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                o.Name = reader.GetString(reader.GetOrdinal("Name"));
                o.Type = reader.GetString(reader.GetOrdinal("Type"));
                o.Price = reader.GetString(reader.GetOrdinal("Price")); 
                o.Quantity = reader.GetString(reader.GetOrdinal("Quantity"));
             
                list.Add(o);

            }
            conn.Close();
            return list;
        }
        private void CheckOrder_Load(object sender, EventArgs e)
        {
            var list = GetOrder();
            dtOrder.DataSource = list;
        }
        private void btnSearchId_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchOrderId.Text);

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from orders where id='{0}'", searchId);
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
            gbType.Text = o.Type;
            tbPrice.Text = o.Price;
            tbQuantity.Text = o.Quantity;
            
            conn.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchOrderId.Text);
            string name = tbName.Text;
            string type = gbType.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text; ;
            string price = tbPrice.Text;
            string quantity = tbQuantity.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Update orders set name='{0}',type='{1}',price='{2}',quantity='{3}' where Id={4}", name, type, price, quantity, searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            var list = GetOrder();
            dtOrder.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void dtOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

