﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgenda.Classes
{
    public class Util
    {

        public string ajudarDataPadraoBR()
        {
            string infoCampoData = string.Empty;

            if (frmCalendario.static_mes == 13)
            {
                frmCalendario.static_mes = 1;
                frmCalendario.static_ano = +1; 

                DateTime dataCompleta = Convert.ToDateTime(ControleUsuarioDias.static_dias + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
                infoCampoData = dataCompleta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (frmCalendario.static_mes == 0)
            {
                frmCalendario.static_mes = 12;
                frmCalendario.static_ano += -1;

                DateTime dataCompleta = Convert.ToDateTime(ControleUsuarioDias.static_dias + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
                infoCampoData = dataCompleta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                DateTime dataCompleta = Convert.ToDateTime(ControleUsuarioDias.static_dias + "/" + frmCalendario.static_mes + "/" + frmCalendario.static_ano);
                infoCampoData = dataCompleta.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            return infoCampoData;
        }




    }
}