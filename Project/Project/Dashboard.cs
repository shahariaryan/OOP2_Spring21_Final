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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddOrder().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckOrder().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveOrder().Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddReserve().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CheckReserve().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RemoveReserve().Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
