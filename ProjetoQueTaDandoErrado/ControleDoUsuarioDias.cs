using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoQueTaDandoErrado
{
    public partial class ControleDoUsuarioDias : UserControl
    {
        public ControleDoUsuarioDias()
        {
            InitializeComponent();
        }

        public void ContarDias(int numeroDias)
        {
            lblDias.Text = numeroDias + "";
        }
    }
}
