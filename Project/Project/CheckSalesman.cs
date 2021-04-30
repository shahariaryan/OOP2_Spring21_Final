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
    public partial class CheckSalesman : Form
    {
        public CheckSalesman()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(tbId.Text);
            string name = tbName.Text;
            string uname = tbUname.Text;
            string email = tbEmail.Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            string pass = tbPass.Text;
            string salary = tbSalary.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Update users set name='{0}',uname='{1}',email='{2}',gender='{3}',pass='{4}',salary='{5}' where Id={6}", name, uname, email, gender, pass, salary, searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
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

        private void CheckSalesman_Load(object sender, EventArgs e)
        {
            var list = GetSalesman();
            dtSalesman.DataSource = list;
        }

        private void search_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(tbId.Text);

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from users where id='{0}'", searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Salesman s = new Salesman();
            while (reader.Read())
            {

                s.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                s.Name = reader.GetString(reader.GetOrdinal("Name"));
                s.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                s.Email = reader.GetString(reader.GetOrdinal("Email"));
                s.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                s.Pass = reader.GetString(reader.GetOrdinal("Pass"));
                s.Type = reader.GetString(reader.GetOrdinal("Type"));
                s.Salary = reader.GetString(reader.GetOrdinal("Salary"));

            }
            tbName.Text = s.Name;
            tbUname.Text = s.Uname;
            tbEmail.Text = s.Email;
            gbGender.Text = s.Gender;
            tbPass.Text = s.Pass;
            tbSalary.Text = s.Salary;
            conn.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var list = GetSalesman();
            dtSalesman.DataSource = list;
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

        private void dtSalesman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
