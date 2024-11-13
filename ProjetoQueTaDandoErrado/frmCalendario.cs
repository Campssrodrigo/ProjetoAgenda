using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        int mes, ano;


        public void MostrarCampos()
        {
            //Declarado em DateTime para chamar um Date de agora (DateTime.Now), chama dia atual
            DateTime data = DateTime.Now;
            
            //Configurar o recebimento data no formato 01/01/2000 (duas caracteres no dia)
            mes = data.Month;
            ano = data.Year;

            // Para trazer o nome do mês atual, com as configurações do servidor local, no caso BR, pegando o nome da informação selecionada
            string nomeDoMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            lblMesAno.Text = nomeDoMes + " " + ano;

            //Armazenando a quantidade de dias em um mês, referenciando o .Now, mes e ano e definido em dia 1 na assinatura
            DateTime qtdDiasMes = new DateTime(ano, mes, 1);
            //diasDaSemana está recebendo o dia da semana Convertido em Int, então 0 domingo e 6 sábado
            int diasDaSemana = Convert.ToInt32(qtdDiasMes.DayOfWeek.ToString("d")) + 1;
            //dias está recebendo a informação de quantos dias tem no mês e ano vindo de DateTime.Now
            int dias = DateTime.DaysInMonth(ano, mes);

            // MessageBox.Show(Convert.ToString(qtdDiasMes)+ "  " + Convert.ToString(dias) + "/" + Convert.ToString(mes) +  "/" + Convert.ToString(ano));

            //MessageBox.Show(data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))

            for (int i = 1; i < diasDaSemana; i++)
            {
                ControleUsuarioVazio UcVazio = new ControleUsuarioVazio();
                FlpCalendario.Controls.Add(UcVazio);
            }

            for (int i = 1; i <= dias; i++)
            {
                ControleDoUsuarioDias UcDias = new ControleDoUsuarioDias();
                UcDias.ContarDias(i);
                FlpCalendario.Controls.Add(UcDias);

            }

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            FlpCalendario.Controls.Clear();

            mes++;
           
           
        }

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            MostrarCampos();
        }
    }
}
