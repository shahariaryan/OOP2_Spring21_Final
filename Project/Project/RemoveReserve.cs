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
    public partial class RemoveReserve : Form
    {
        public RemoveReserve()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            string searchName = searchReserveName.Text;

            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("Select * from reserves where name='{0}'", searchName);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string searchName = searchReserveName.Text;
            var conn = Database.ConnectDB();
            conn.Open();

            string query = string.Format("DELETE FROM reserves WHERE name='{0}'", searchName);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            this.Hide();
            new CheckReserve().Show();
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

