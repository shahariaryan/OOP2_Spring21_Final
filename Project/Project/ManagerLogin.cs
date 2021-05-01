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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                string uname = tbUname.Text;
                string pass = tbPass.Text;
                string type = "manager";


                var conn = Database.ConnectDB();
                conn.Open();
                string query = string.Format("Select * from users where uname='{0}'and pass='{1}' and type='{2}'", uname, pass, type);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    new ManagerDash().Show();

                }
                else
                {
                    MessageBox.Show("Not Valid");
                    new ManagerLogin().Show();
                }
            }
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
            new Homepage().Show();
        }
    }
}
