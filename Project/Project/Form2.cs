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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            
            new Form1().Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            string uname = tbUname.Text;
            string pass = tbPass.Text;
            string type = "salesman";

            string errMsg = null;
            if (tbUname.Text.Equals(""))
            {
                errMsg += "\nUsername Requried";
            }
            else
            {
                uname = tbUname.Text;
            }

            if (tbPass.Text.Equals(""))
            {
                errMsg += "\nPassword Requried";
            }
            else
            {
                pass = tbPass.Text;
            }

            if (errMsg == null)
            {
                var conn = Database.ConnectDB();
                conn.Open();
                string query = string.Format("Select * from users where uname='{0}'and pass='{1}' and type='{2}'", uname, pass, type);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    new Dashboard().Show();

                }
                else
                {
                    MessageBox.Show("Not Valid");
                    new Login().Show();
                }
                 conn.Close();
                RefreshControls();
            }
            else
            {
                MessageBox.Show(errMsg);
                new Login().Show();
            }
        }

        void RefreshControls()
        {
            tbUname.Text = "";
            tbPass.Text = "";
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Homepage().Show();

        }
    }
} 
