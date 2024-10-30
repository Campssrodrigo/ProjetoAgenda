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

namespace ProjetoAgenda
{
    public partial class Calendario : Form
    {
        public Calendario()
        {
            InitializeComponent();
        }
        #region Variáveis Globais

        int mes, ano;
        //criar método static para passar a informação do formulário de mês e ano
        public static int static_mes, static_ano;
        #endregion

        #region Compenetes de Tela
        private void Calendario_Load(object sender, EventArgs e)
        {
            PainelHoras();
        }

        private void btnAlterior_Click(object sender, EventArgs e)
        {
            //limpar Campos do userControl para ir para o próximo mês, acessando FlowLayoutPanel
            FlowLayDias.Controls.Clear();
            //decrementar o mês para ir para o mês anterior
            mes--;
            static_mes = mes;
            static_ano = ano;
            // Atualizar nome do mês a cada load de furmlário, considera data e ano atual, neste caso após o click decrementando o mês
            string nomeDoMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            lblData.Text = nomeDoMes + " " + ano;

            DateTime diasDoMes = new DateTime(ano, mes, 1);

            // Pega a contagem dos dias de um mês
            int dias = DateTime.DaysInMonth(ano, mes);

            //Converte o diasDoMes para interagir com dias da semana
            int diasDaSemana = Convert.ToInt32(diasDoMes.DayOfWeek.ToString("d"));

            //Primeiro crie o controle do usuário

            for (int i = 1; i < diasDaSemana; i++)
            {
                ControleUsuarioVazio UCVazio = new ControleUsuarioVazio();
                FlowLayDias.Controls.Add(UCVazio);
            }
            //Repetir dias conforme o i, dias dos meses
            for (int i = 1; i <= dias; i++)
            {
                ControleUsuarioDias ucDias = new ControleUsuarioDias();
                ucDias.ContaDias(i);
                FlowLayDias.Controls.Add(ucDias);
            }

        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            //limpar Campos
            FlowLayDias.Controls.Clear();
            //incrementar o mês para ir para o próximo mês
            mes++;

            //declarar métodos estáticos recebendo mes e ano
            static_mes = mes;
            static_ano = ano;
            // Atualizar nome do mês a cada load de furmlário, considera data e ano atual
            string nomeDoMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);
            lblData.Text = nomeDoMes + " " + ano;

            DateTime diasDoMes = new DateTime(ano, mes, 1);

            // Pega a contagem dos dias de um mês
            int dias = DateTime.DaysInMonth(ano, mes);

            //Converte o diasDoMes para interagir com dias da semana
            int diasDaSemana = Convert.ToInt32(diasDoMes.DayOfWeek.ToString("d"));

            //Primeiro crie o controle do usuário

            for (int i = 1; i < diasDaSemana; i++)
            {
                ControleUsuarioVazio UCVazio = new ControleUsuarioVazio();
                FlowLayDias.Controls.Add(UCVazio);
            }
            //Repetir dias conforme o i, dias dos meses
            for (int i = 1; i <= dias; i++)
            {
                ControleUsuarioDias ucDias = new ControleUsuarioDias();
                ucDias.ContaDias(i);
                FlowLayDias.Controls.Add(ucDias);
            }
        }


        #endregion

        #region Métodos Privados
        private void PainelHoras()
        {
            // Instanciando Datetime, para usar métodos desta classe
            DateTime data = DateTime.Now;

            // Dando valores para as variáveis globais, utilizar também no nome do mês e ano, mantém as informações para a troca quando clickado anterior ou próximo
            mes = data.Month;
            ano = data.Year;
            
            // Atualizar nome do mês a cada load de furmlário, considera data e ano atual
            string nomeDoMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes); //olhar como funciona
            lblData.Text = nomeDoMes + " " + ano;
            //métodos estaticos recebendo mes e ano
            static_mes = mes;
            static_ano = ano;
            // Pega primeiros dias do mês
            DateTime diasDoMes = new DateTime(ano, mes, 1);

            // Pega a contagem dos dias de um mês
            int dias = DateTime.DaysInMonth(ano, mes);

            //Converte o diasDoMes para interagir com dias da semana
            int diasDaSemana = Convert.ToInt32(diasDoMes.DayOfWeek.ToString("d"));

            //MessageBox.Show(Convert.ToString(diasDoMes));
            //converter valores para PT-BR
           

            //Primeiro crie o controle do usuário

            for (int i = 1; i < diasDaSemana; i++)
            {
                ControleUsuarioVazio UCVazio = new ControleUsuarioVazio();
                FlowLayDias.Controls.Add(UCVazio);
                
            }
            //Repetir dias conforme o i, dias dos meses, colocar dias em todos os campos
            for (int i = 1; i <= dias; i++)
            {
                ControleUsuarioDias ucDias = new ControleUsuarioDias();
                ucDias.ContaDias(i);
                FlowLayDias.Controls.Add(ucDias);
            }
        }
        #endregion
    }
}
