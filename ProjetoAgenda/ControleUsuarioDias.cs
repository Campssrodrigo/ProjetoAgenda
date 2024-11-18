using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgenda
{
    public partial class ControleUsuarioDias : UserControl
    {
        // criar outro método static para dias
        public static string static_dias;

        //criar conexao string
        string conexaoString = "server=localhost;user id=root;database=db_calendar;sslmode=none";

        public ControleUsuarioDias()
        {
            InitializeComponent();
        }

        public void ContaDias(int numeroDias)
        {
            lblDias.Text = numeroDias + ""; // Aqui?? Cultura
        }

        private void ControleUsuarioDias_Click(object sender, EventArgs e)
        {

            static_dias = lblDias.Text;


            // começar o timer do usercontrol no click
            timer1.Start();
            frmEventoCalendario eventoCalendario = new frmEventoCalendario();
            eventoCalendario.Show();
        }
        private void ControleUsuarioDias_Load(object sender, EventArgs e)
        {
            displayEvent();
        }

        

        private void displayEvent()
        {

            MySqlConnection conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            string sql = "SELECT * FROM tb_calendar where data = ?";
            MySqlCommand comando = conexao.CreateCommand();
            comando.CommandText = sql;
            // Declarar viriável que receba as informações de data e tranforme com o CultureInfo.InvariantCulture
            if (Convert.ToInt32(lblDias.Text) >= 10)
            {
                comando.Parameters.AddWithValue("data", lblDias.Text + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
            }
            else
            {
                comando.Parameters.AddWithValue("data", 0+lblDias.Text + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
            }
            
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                
                //for(int i = 1; )
                lblEvento.Text = reader["evento"].ToString();
            }
            reader.Dispose();
            comando.Dispose();
            conexao.Close();
        }

      
        //criar o timer para automatizar evento se novo evento for adicionado
        private void timer1_Tick(object sender, EventArgs e)
        {
            //chamar o método do evento de display
            displayEvent();
        }

  
    }
}
