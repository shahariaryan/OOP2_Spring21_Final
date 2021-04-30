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
    public partial class CheckManager : Form
    {
        public CheckManager()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            var list = GetManager();
            dtManager.DataSource = list;
        }

        private List<Manager> GetManager()
        {
            var conn = Database.ConnectDB();
            conn.Open();

            string query = "Select * from users where type='manager'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Manager> list = new List<Manager>();
            while (reader.Read())
            {
                Manager m = new Manager();
                m.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                m.Name = reader.GetString(reader.GetOrdinal("Name"));
                m.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                m.Email = reader.GetString(reader.GetOrdinal("Email"));
                m.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                m.Pass = reader.GetString(reader.GetOrdinal("Pass"));
                m.Type = reader.GetString(reader.GetOrdinal("Type"));
                m.Salary = reader.GetString(reader.GetOrdinal("Salary"));

                list.Add(m);

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

        private void CheckManager_Load(object sender, EventArgs e)
        {
            var list = GetManager();
            dtManager.DataSource = list;
        }

        private void search_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(tbId.Text);

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from users where id='{0}'", searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Manager m = new Manager();
            while (reader.Read()){
               
                m.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                m.Name = reader.GetString(reader.GetOrdinal("Name"));
                m.Uname = reader.GetString(reader.GetOrdinal("Uname"));
                m.Email = reader.GetString(reader.GetOrdinal("Email"));
                m.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                m.Pass = reader.GetString(reader.GetOrdinal("Pass"));
                m.Type = reader.GetString(reader.GetOrdinal("Type"));
                m.Salary = reader.GetString(reader.GetOrdinal("Salary"));

            }
            tbName.Text = m.Name;
            tbUname.Text = m.Uname;
            tbEmail.Text = m.Email;
             gbGender.Text = m.Gender;
             tbPass.Text = m.Pass;
             tbSalary.Text = m.Salary;
            conn.Close();

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
            var list = GetManager();
            dtManager.DataSource = list;







        }

        private void tbIdSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbGender_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminDash().Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
