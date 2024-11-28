﻿using MySql.Data.MySqlClient;
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

        #region Variáveis globais
        //criar conexao string 
        string conexaoString = "server=localhost;user id=root;database=db_calendar;sslmode=none";

        #endregion

        public ControleUsuarioDias()
        {
            InitializeComponent();
        }

        #region Eventos
        private void ControleUsuarioDias_Click(object sender, EventArgs e)
        {

            static_dias = lblDias.Text;
            frmEventoCalendario eventoCalendario = new frmEventoCalendario();
            eventoCalendario.Show();
            timer1.Start();
        }
        private void lblEvento_Click(object sender, EventArgs e)
        {
            static_dias = lblDias.Text;

            frmEventoCalendario eventoCalendario = new frmEventoCalendario();
            eventoCalendario.Show();
            timer1.Start();

        }
        private void ControleUsuarioDias_Load(object sender, EventArgs e)
        {
            displayEvent();
        }
        #endregion

        #region Métodos publicos
        /// <summary>
        /// Conta os dias do calendário, é publico porque compartilha essa informação na tela frmCalendário, está no laço de repetição, mostra nois paineis os dias do mês
        /// </summary>
        /// <param name="numeroDias"></param>
        public void ContaDias(int numeroDias)
        {
            lblDias.Text = numeroDias + ""; // Aqui?? Cultura
        }
        public class ListaDeEventos
        {
            public string evento { get; set; }
        }
        #endregion

        #region Métodos privados
        private void displayEvent()
        {

            MySqlConnection conexao = new MySqlConnection(conexaoString);
            conexao.Open();
            //for tem que pegar também o select do banco de dados, tem que fazer a busca também
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
                //No display do evento ele ainda trás o valor 13, Criar um método para dar o +1 e -1 em mês e ano?
                //Outro método só para converter as datas?
                //Seguir o método ajustarDataPadraoBR(), lá estão todos os lugares que precisam de alteração
                comando.Parameters.AddWithValue("data", 0 + lblDias.Text + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
            }

            // Cria um objeto MySqlDataReader para ler os resultados da consulta SQL
            MySqlDataReader reader = comando.ExecuteReader();

            // Inicializa uma lista para armazenar os eventos marcados
            List<ListaDeEventos> eventosMarcados = new List<ListaDeEventos>();

            // Enquanto houver dados para serem lidos do banco de dados continua o loop
            while (reader.Read())//Melhorar esses While, se não ele vai ficar puxando todos os compromissos sem necessidade, vai travar o programa
            {
                // Cria um novo objeto ListaDeEventos e preenche o campo 'evento'
                // com o valor da coluna correspondente no resultado da consulta
                eventosMarcados.Add(new ListaDeEventos { evento = reader.GetString("evento") });
            }
            // Percorre a lista de eventos e adiciona cada evento ao label lblEvento
            // A cada iteração, uma nova linha é adicionada ao texto da label
            foreach (var repEvento in eventosMarcados)
            {
                lblEvento.Text += $"{repEvento.evento} \n"; 
                
            }
            reader.Dispose();
            comando.Dispose();
            conexao.Close();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblEvento.Text = "";
            displayEvent();
        }
        #endregion


    }


}
