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
    public partial class CheckReserve : Form
    {
        public CheckReserve()
        {
            InitializeComponent();
        }

        private void CheckReserve_Load(object sender, EventArgs e)
        {
            var list = GetReserve();
            dtReserve.DataSource = list;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var list = GetReserve();
            dtReserve.DataSource = list;
        }

        private List<Reserve> GetReserve()
        {
            var conn = Database.ConnectDB();
            conn.Open();

            string query = "Select * from reserves";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Reserve> list = new List<Reserve>();
            while (reader.Read())
            {
                Reserve r = new Reserve();
                r.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                r.Name = reader.GetString(reader.GetOrdinal("Name"));
                r.Rid = reader.GetString(reader.GetOrdinal("Rid"));
                r.Email = reader.GetString(reader.GetOrdinal("Email"));
                r.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                r.Guests = reader.GetString(reader.GetOrdinal("Guests"));
                r.Type = reader.GetString(reader.GetOrdinal("Type"));


                list.Add(r);

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

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchReserveId.Text);

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from reserves where id='{0}'", searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Reserve r = new Reserve();
            while (reader.Read())
            {

                r.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                r.Name = reader.GetString(reader.GetOrdinal("Name"));
                r.Rid = reader.GetString(reader.GetOrdinal("Rid"));
                r.Email = reader.GetString(reader.GetOrdinal("Email"));
                r.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                r.Guests = reader.GetString(reader.GetOrdinal("Guests"));
                r.Type = reader.GetString(reader.GetOrdinal("Type"));


            }
            tbName.Text = r.Name;
            tbRid.Text = r.Rid;
            tbEmail.Text = r.Email;
            tbPhone.Text = r.Phone;
            tbGuests.Text = r.Guests;
            cbType.Text = r.Type;
            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int searchId = Int32.Parse(searchReserveId.Text);
            string name = tbName.Text;
            string rid = tbRid.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;
            string guests = tbGuests.Text;
            string type = cbType.SelectedItem.ToString();
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Update reserves set name='{0}',rid='{1}',email='{2}',phone='{3}',guests='{4}',type='{5}' where Id={6}", name, rid, email, phone, guests, type, searchId);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            var list = GetReserve();
            dtReserve.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void dtReserve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void drReserve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}