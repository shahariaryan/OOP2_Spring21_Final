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
    public partial class CheckItemAdmin : Form
    {
        public CheckItemAdmin()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
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

        private void CheckItemAdmin_Load(object sender, EventArgs e)
        {
            var list = GetItem();
            dtItems.DataSource = list;
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
