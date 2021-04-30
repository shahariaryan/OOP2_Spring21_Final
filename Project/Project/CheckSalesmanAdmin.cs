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
    public partial class CheckSalesmanAdmin : Form
    {
        public CheckSalesmanAdmin()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var list = GetSalesman();
            dtSalesman.DataSource = list;
        }
        private List<Salesman> GetSalesman()
        {
            var conn = Database.ConnectDB();
            conn.Open();

            string query = "Select * from users where type='salesman'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Salesman> list = new List<Salesman>();
            while (reader.Read())
            {
                Salesman s = new Salesman();
                s.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                s.Name = reader.GetString(reader.GetOrdinal("Name"));
                s.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                s.Email = reader.GetString(reader.GetOrdinal("Email"));
                s.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                s.Pass = reader.GetString(reader.GetOrdinal("Pass"));
                s.Type = reader.GetString(reader.GetOrdinal("Type"));
                s.Salary = reader.GetString(reader.GetOrdinal("Salary"));

                list.Add(s);

            }
            conn.Close();
            return list;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void CheckSalesmanAdmin_Load(object sender, EventArgs e)
        {
            var list = GetSalesman();
            dtSalesman.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminDash().Show();
        }
    }
}
