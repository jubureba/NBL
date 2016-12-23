using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBL
{
    public partial class splash : Form
    {

    
        public splash()
        {

            InitializeComponent();
            timer.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 99)
            {
                progressBar1.Value = progressBar1.Value + 2;
                porcent.Text = Convert.ToString(progressBar1.Value);
            }
            else 
            {
                timer.Enabled = false;
                this.Visible = false;
                login login = new login();
                login.ShowDialog();

            }
        }
    }
}
