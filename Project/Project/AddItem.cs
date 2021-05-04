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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name = tbName.Text;
            string type = tbType.Text;
            string quantity = tbQuantity.Text;
            var cost = tbCost.Text;

            string errMsg = null;
            if (tbName.Text.Equals(""))
            {
                errMsg += "\nName Requried";
            }
            else
            {
                name = tbName.Text;
            }

            if (tbType.Text.Equals(""))
            {
                errMsg += "\nType Requried";
            }
            else
            {
                type = tbType.Text;
            }


            if (tbQuantity.Text.Equals(""))
            {
                errMsg += "\nQuantity Requried";
            }
            else
            {
                quantity = tbQuantity.Text;
            }


            if (tbCost.Text.Equals(""))
            {
                errMsg += "\nCost Requried";
            }
            else
            {
                cost = tbCost.Text;
            }


            if (errMsg == null)
            {

                var conn = Database.ConnectDB();
                conn.Open();

                string query = string.Format("Insert into items values ('{0}','{1}','{2}','{3}')", name, type, quantity, cost);
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Item Added");
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

            }
        }
        void RefreshControls()
        {
            tbName.Text = "";
            tbType.Text = "";
            tbQuantity.Text = "";
            tbCost.Text = "";

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void tbCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbType_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManagerDash().Show();
        }
    }
 }

