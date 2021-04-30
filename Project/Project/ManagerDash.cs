using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ManagerDash : Form
    {
        public ManagerDash()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddSalesman().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckSalesman().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveSalesman().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddItem().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckItem().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveItem().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Homepage().Show();
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
