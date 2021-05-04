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
    public partial class RemoveManager : Form
    {
        public RemoveManager()
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
            Manager m = new Manager();
            while (reader.Read())
            {

                m.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                m.Name = reader.GetString(reader.GetOrdinal("Name"));
                m.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                m.Email = reader.GetString(reader.GetOrdinal("Email"));

            }
            tbName.Text = m.Name;
            tbUname.Text = m.Uname;
            tbEmail.Text = m.Email;
            conn.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            string name = tbName.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM users WHERE name='{0}'",name);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            new CheckManager().Show();


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

        private void tbSearchName_TextChanged(object sender, EventArgs e)
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

        private void tbUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
