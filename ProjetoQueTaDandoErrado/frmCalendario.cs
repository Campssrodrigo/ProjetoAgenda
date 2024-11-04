using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoQueTaDandoErrado
{
    public partial class frmCalendario : Form
    {
        public frmCalendario()
        {
            InitializeComponent();
        }

    

        private void MostrarCampos()
        {
            int FinalDoMes = 31;

            //Declarado em DateTime para chamar um Date de agora (DateTime.Now), chama dia atual
            DateTime data = DateTime.Now;
            //Configurar o recebimento data no formato 01/01/2000 (duas caracteres no dia)
            MessageBox.Show(data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));



            for(int i = 1; i < FinalDoMes; i++)
            {
                ControleUsuarioVazio UcVazio = new ControleUsuarioVazio();
                FlpCalendario.Controls.Add(UcVazio);
            }
            

        }

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            MostrarCampos();
        }
    }
}
