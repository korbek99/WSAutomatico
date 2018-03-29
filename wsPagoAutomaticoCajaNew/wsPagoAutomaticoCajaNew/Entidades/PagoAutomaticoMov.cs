using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class PagoAutomaticoMov
    {
          //Variables de MovDia
	     public string rutcliente  {get; set;}
	     public string demandante  {get; set;}
	     public string correlat  {get; set;}
	     public string cod_cajero  {get; set;}
         public DateTime fecha_pago { get; set; } 
	     public string esta_liqui  {get; set;}
	     public string num_caja  {get; set;} 
	     public string tip_pag  {get; set;}

         //Variables de tab_prov
        public string estado {get; set;}
 
         //Variables de MovTos
	    public string tip_mov  {get; set;}
	    public string tip_liq  {get; set;}
	    public string tip_pag_tos  {get; set;}
	    public string cod_cli  {get; set;}
	    public Decimal  mto_oper  {get; set;}
	    public string num_doc  {get; set;}
	    public string banco  {get; set;}
        public DateTime fec_oper { get; set; }
	    public string hor_oper  {get; set;}
	    public DateTime   fec_dia  {get; set;}
	    public string cod_suc  {get; set;}
	
      //Variable tb_pa_mov_trx_usuario
       public string login_user {get; set;}

       //Variable tb_nexo
       public string folioNd { get; set; }
    }
}