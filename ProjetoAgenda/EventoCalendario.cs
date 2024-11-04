using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoAgenda
{
    public partial class EventoCalendario : Form
    {
        //criar conexao string
        string conexaoString = "server=localhost;user id=root;database=db_calendar;sslmode=none";
       
        // Criar a base de dados usando xampp
        public EventoCalendario()
        {
            InitializeComponent();
        }

        private void EventoCalendario_Load(object sender, EventArgs e)
        {

          //Resolvi porco, mas resolvi
          // Ao abrir tela evento já recebe a data no campo txtData com o valor do campo
 
                txtData.Text = ControleUsuarioDias.static_dias + "/" + Calendario.static_mes + "/" + Calendario.static_ano;
            
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
         
            //Chamar using, baixar nuGet opção
            MySqlConnection conexao = new MySqlConnection(conexaoString);
            //abrir aplicação de comandos
            conexao.Open();
            //nomear e dar comando para sql
            string sql = "INSERT INTO tb_calendar(data,evento)values(?,?)";
            //criar comando
            MySqlCommand comando = conexao.CreateCommand();
            //comando em texto recebendo o que inserido na variavel sql
            comando.CommandText = sql;
            //comando para receber a data no BD, bindando
            comando.Parameters.AddWithValue("data",txtData.Text);
            //comando para receber evento digitado no BD, bindando
            comando.Parameters.AddWithValue("evento", txtEvento.Text);
            //Comando que executa no banco de dados, se não estiver referenciado corretamente da erro
            comando.ExecuteNonQuery();
            //Mensagem para finalizar
            MessageBox.Show("Salvo com sucesso");
            //Fechar a cadeia de comando do sql
            comando.Dispose();
            //Fechar a aplicação geral
            conexao.Close();
        }
    }
}
