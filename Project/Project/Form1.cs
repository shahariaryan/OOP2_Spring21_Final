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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SignUp(object sender, EventArgs e)
        {
            this.Hide();
            string name = tbName.Text;
            string uname = tbUname.Text;
            string email = tbEmail.Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            string pass = tbPass.Text;
            string type = "salesman";
            string salary = "";

            string errMsg = null;
            if (tbName.Text.Equals(""))
            {
                errMsg += "\nName Requried";
            }
            else
            {
                name = tbName.Text;
            }

            if (tbUname.Text.Equals(""))
            {
                errMsg += "\nUsername Requried";
            }
            else
            {
                uname = tbUname.Text;
            }

            if (tbEmail.Text.Equals(""))
            {
                errMsg += "\nEmail Requried";
            }
            else
            {
                email = tbEmail.Text;
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

                string query = string.Format("Insert into users values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, uname, email, gender, pass, type, salary);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("New Account Created");
                    new Login().Show();
                }
                else
                {
                    MessageBox.Show("Error");
                    new Form1().Show();
                }
                conn.Close();
               RefreshControls();
            }
            else 
            { 
             MessageBox.Show(errMsg);
            }
        }
        void RefreshControls() 
        {
            tbName.Text = "";
            tbUname.Text = "";
            tbEmail.Text = "";
            tbPass.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gbGender_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
