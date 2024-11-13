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
    public partial class frmEventoCalendario : Form
    {
        //criar conexao string
        string conexaoString = "server=localhost;user id=root;database=db_calendar;sslmode=none";
       
        // Criar a base de dados usando xampp
        public frmEventoCalendario()
        {
            InitializeComponent();
        }

        private void EventoCalendario_Load(object sender, EventArgs e)
        {
            DateTime dataCompleta = Convert.ToDateTime(ControleUsuarioDias.static_dias + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
            txtData.Text = dataCompleta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            //MessageBox.Show(data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
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

        private void btnCores_Click(object sender, EventArgs e)
        {
           // ColorDialog colorDialog = new ColorDialog();
           // colorDialog.ShowDialog();

            new ColorDialog().ShowDialog();

           
        }
    }
}
