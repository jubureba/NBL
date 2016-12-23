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
    public partial class telaP : Form
    {
        public telaP()
        {
            InitializeComponent();
        }

        private void telaP_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bottonBar.Panels[0].Text = "Usuario: Nenhum Usuário Logado";
            bottonBar.Panels[1].Text = "Data: " + DateTime.Now.ToString("dd/M/yyyy");
            bottonBar.Panels[2].Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void bottonBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void telaP_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
