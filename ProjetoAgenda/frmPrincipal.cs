using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgenda
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCalendario().ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

   

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
