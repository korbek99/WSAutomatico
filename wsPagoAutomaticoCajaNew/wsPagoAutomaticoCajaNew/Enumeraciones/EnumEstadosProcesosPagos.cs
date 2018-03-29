using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsPagoAutomaticoCajaNew.Enumeraciones
{
    public class EnumEstadosProcesosPagos
    {
        public static int codigo_estado_error_trans_no_monto =-2; //"transacción no fue realizada , debitos no cuadra";
        public static int codigo_estado_transaccion_monto = 1;  //"ingreso transacción con exito";
        public static int codigo_estado_procesos_internos = 1; //"no hubo errores en procesos internos transacción";
        public static int codigo_estado_error_procesos_internos = -1; // "hubo errores en procesos internos transacción";
        public static int codigo_estado_transaccion_proceso_no_data = 0;//"no se encontraron datos";
        public static int codigo_estado_transaccion_proceso_no_data_exception = -3; //"ocurrio un error Exception ";
        public static int codigo_estado_validacion_diaHabil = -4; //"Servicio no esta disponible por estar fuera de hora disponible de transaccion";
        public static int codigo_estado_Error_ActualizaTabNexo = -5; // codigo error proceso de actualizacion  de tabnexo
        public static int codigo_estado_Error_Liquida_Nota = -6; // codigo error proceso de Liquida_Nota
        public static int codigo_estado_Error_Actualiza_MovTos = -7; // codigo error proceso de Actualiza MovTos
        public static int codigo_estado_Error_correlativo = -8; //numero correlativo vacio
        public static int codigo_estado_Error_fecha_pago = -9; //fecha pago vacia
        public static int codigo_estado_Error_cod_cajero =-10; 
        public static int codigo_estado_Error_monto_debito_vacio = -11;
        public static int codigo_estado_Error_time_hora = -12;
        public static int codigo_estado_Error_cod_sucursal = -13;
        public static int codigo_estado_Error_login_user = -14;
        public static int codigo_estado_Error_saldo_cuenta_corriente = -15;
        public static int codigo_estado_Error_desc_int = -16;
        public static int codigo_estado_Error_update_movdia_DBF = -17;
        public static int codigo_estado_Error_update_tab_prov_DBF = -18;
        public static int codigo_estado_Error_insert_movtos_DBF = -19;
        public static int codigo_estado_Error_validacion_campos = -20;
        public static int codigo_estado_Error_insert_tabNexo_DBF = -21;
       // public static int codigo_estado_Error_validacion_campos = -14;
    }
}