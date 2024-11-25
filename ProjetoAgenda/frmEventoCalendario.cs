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
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using ProjetoAgenda.Classes;

namespace ProjetoAgenda
{
    public partial class frmEventoCalendario : Form
    {


        // Criar a base de dados usando xampp
        public frmEventoCalendario()
        {
            InitializeComponent();
        }
        #region Variável global
        string conexaoString = "server=localhost;user id=root;database=db_calendar;sslmode=none";
        Util convertDatas = new Util();
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        private void EventoCalendario_Load(object sender, EventArgs e)
        {

            txtData.Text = convertDatas.ajudarDataPadraoBR();

            //MessageBox.Show(data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
        }
        private void btnCores_Click(object sender, EventArgs e)
        {
            // ColorDialog colorDialog = new ColorDialog();
            // colorDialog.ShowDialog();

            new ColorDialog().ShowDialog();
        }
        #endregion

        #region Métodos privados


        private void limparCampos()
        {
            txtEvento.Clear();
            txtEvento.Focus();
        }

        private bool validarCampos()
        {
            bool flag = true;
            if (txtEvento.Text.Trim() == string.Empty)
            {
                flag = false;
            }
            if (txtData.Text.Trim() == string.Empty)
            {
                flag = false;
            }

            if (!flag)
            {
                MessageBox.Show("Preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return flag;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
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
                //comando para receber da classe data ajustada com os valor dd/MM/yyyy
                txtData.Text = convertDatas.ajudarDataPadraoBR();
                //comando para receber a data no BD, bindando
                comando.Parameters.AddWithValue("data", txtData.Text);
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
                limparCampos();
            }

        }
        #endregion

    }
}
