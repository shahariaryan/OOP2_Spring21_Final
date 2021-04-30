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
    public partial class RemoveSalesman : Form
    {
        public RemoveSalesman()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            string searchName = tbSearchName.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from users where name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Salesman s = new Salesman();
            while (reader.Read())
            {

                s.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                s.Name = reader.GetString(reader.GetOrdinal("Name"));
                s.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                s.Email = reader.GetString(reader.GetOrdinal("Email"));

            }
            tbName.Text = s.Name;
            tbUname.Text = s.Uname;
            tbEmail.Text = s.Email;
            conn.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM users WHERE name='{0}'", name);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            new CheckSalesman().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerDash().Show();
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
