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
    public partial class CheckOrderAdmin : Form
    {
        public CheckOrderAdmin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void CheckOrderAdmin_Load(object sender, EventArgs e)
        {
            var list = GetOrder();
            dtOrder.DataSource = list;
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
            new AdminDash().Show();
        }
    }
}
