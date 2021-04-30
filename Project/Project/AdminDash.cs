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
    public partial class AdminDash : Form
    {
        public AdminDash()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddManager().Show();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckManager().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveManager().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddSalesman().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckSalesmanAdmin().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveSalesman().Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new CheckItemAdmin().Show();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new CheckOrderAdmin().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Homepage().Show();

        }
        

    }
}
