using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class TabHora2New
    {
        private string cod_suc;
	    private DateTime fmes_inhab;
	    private string nom_dia;
	    private string hora_corte;
	    private string glosa_am;
	    private string glosa_pm;
	    private string fecha_hoy;

        public TabHora2New()
        {

        }

        public string Cod_suc
        {
            get { return cod_suc; }
            set { cod_suc = value; }
        }
        public DateTime Fmes_inhab
        {
            get { return fmes_inhab; }
            set { fmes_inhab = value; }
        }
        public string Nom_dia
        {
            get { return nom_dia; }
            set { nom_dia = value; }
        }
        public string Hora_corte
        {
            get { return hora_corte; }
            set { hora_corte = value; }
        }
        public string Glosa_am
        {
            get { return glosa_am; }
            set { glosa_am = value; }
        }
        public string Glosa_pm
        {
            get { return glosa_pm; }
            set { glosa_pm = value; }
        }
        public string Fecha_hoy
        {
            get { return fecha_hoy; }
            set { fecha_hoy = value; }
        }
    }
}