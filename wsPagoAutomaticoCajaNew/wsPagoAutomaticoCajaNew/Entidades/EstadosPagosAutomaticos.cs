using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class EstadosPagosAutomaticos
    {
        public static string P_str_mov_pendiente_de_pago = "P";
        public static string P_str_mov_cancelado_de_pago = "C";
        public static string P_str_prov_pendiente_de_pago = "P";
        public static string P_str_prov_nota_debito = "ND";
        public static string P_str_prov_estado_liq = "C";

        public static string P_str_mov_estado_liq = "C";
        public static string P_str_mov_Num_caja = "SO";
        public static string P_str_mov_tipo_pago = "EF";
        
        public static string P_str_mov_tipo_movtos = "I";
        public static string P_str_mov_tipo_liq_movtos = "CC";
        public static string P_str_mov_tipo_Pag_movtos = "ND";

        public static string P_str_CM_codigo_cajero = "PA";
        public static string P_str_cdEstadoTabNexo = "V";
    }
}