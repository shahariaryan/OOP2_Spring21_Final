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
    public partial class AddSalesman : Form
    {
        public AddSalesman()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name = tbName.Text;
            string uname = tbUname.Text;
            string email = tbEmail.Text;
            var gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            string pass = tbPass.Text;
            string type = "salesman";
            string salary = tbSalary.Text;

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

            /*if (!gbGender.Checked)
            {
                errMsg += "\nGender Requried";
            }
            else
            {
                gender = gbGender.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked).Text;
            }*/

            if (tbPass.Text.Equals(""))
            {
                errMsg += "\nPassword Requried";
            }
            else
            {
                pass = tbPass.Text;
            }

            if (tbSalary.Text.Equals(""))
            {
                errMsg += "\nSalary Requried";
            }
            else
            {
                salary = tbSalary.Text;
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
                    MessageBox.Show("New Salesman Added");
                    new ManagerDash().Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                conn.Close();
                RefreshControls();
            }
            else
            {
                MessageBox.Show(errMsg);
                new AddSalesman().Show();
            }
        }

        void RefreshControls() 
        {
            tbName.Text = "";
            tbUname.Text = "";
            tbEmail.Text = "";
            //gbGender.Text = "Select Gender";
            tbPass.Text = "";
            tbSalary.Text = "";
           
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
            new ManagerDash().Show();
        }
    }
 }

