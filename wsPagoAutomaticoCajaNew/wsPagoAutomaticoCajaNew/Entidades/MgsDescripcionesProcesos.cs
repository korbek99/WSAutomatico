using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class MgsDescripcionesProcesos
    {
        public static string P_str_moduloServicio = "WS PagoAutomaticoCaja Net";
        public static string P_str_proyectoDescripcion = "wsPagoAutomaticoCajaNew";
        public static string P_str_proyectoServicio = "ServicePagoAuto.asmx";
        public static string P_str_moduloServicio_accion = "ingreso con exito a wsPagoAutomaticoCaja";
        public static string P_str_estado_transaccion_proceso = "ingreso transacción con exito";
        public static string P_str_estado_transaccion_proceso_no_data = "no se encontraron datos";
        public static string P_str_estado_error_transaccion_proceso = " transacción no realizada";
        public static string P_str_estado_error_transaccion_otro = "ocurrio un error , transacción no fue realizada";
        public static string P_str_estado_error_transaccion_no_monto = "transacción no fue realizada , debitos no cuadra";
        public static string P_str_estado_procesos_internos = "no hubo errores en procesos internos transacción";
        public static string P_str_estado_error_procesos_internos = "hubo errores en procesos internos transacción";
        public static string P_str_estado_error_procesos_internos_default = "error desconocido en procesos internos transacción";
        public static string P_str_estado_transaccion_proceso_no_data_exception = "ocurrio un error Exception ";
        public static string P_str_estado_validacion_diaHabil = "Servicio no esta disponible por estar fuera de hora disponible de transaccion";
        public static string P_str_Error_ActualizaTabNexo = "hubo errores en procesos Actualizar TabNexo";
        public static string P_str_Error_Liquida_Nota = "hubo errores en procesos en liquidacion Nota de debito";
        public static string P_str_Error_Actualiza_MovTos = "hubo errores en procesos  de Actualiza Movimientos";
        public static string P_str_Error_Actualiza_MovDia = "hubo errores en procesos  de Actualiza Movimientos Dia";
        public static string P_str_Error_Actualiza_MovDia_DBF = "error de Actualización MovDia DBF";
        public static string P_str_Error_Actualiza_tab_prov_DBF = "error de Actualización Tab_prov DBF";
        public static string P_str_Error_Actualiza_mov_tos_DBF = "error de Actualización MovTos DBF";
        //public static string P_str_Error_Insert_tab_nexo_DBF = "error de insercion Tab_Nexo DBF";

        public static string P_str_Error_correlativo = "hubo un error por numero correlativo vacio";
        public static string P_str_Error_fecha_pago = "hubo un error por fecha de pago vacia";
        public static string P_str_Error_str_folio_Deb = "hubo un error por folio debito vacia";
        public static string P_str_Error_str_cod_sucursal = "hubo un error por codigo sucursal vacia";
        public static string P_str_Error_str_str_Tip_pag_movto = "hubo un error por tipo pago monto vacio";
        public static string P_str_Error_str_rut_cliente = "hubo un error por rut cliente vacio";
        public static string P_str_Error_str_cod_deman = "hubo un error por codigo demandante vacio";
        public static string P_str_Error_str_fecha_pago = "hubo un error por fecha de pago vacio";
        public static string P_str_Error_int_Total = "hubo un error por monto total vacio";
        public static string P_str_Error_int_Mto_Deb = "hubo un error por monto debito vacio";
        public static string P_str_Error_str_monto_mov_prov= "hubo un error por monto movimiento y debito no cuadran";

        public static string P_str_Error_str_cod_cajero = "hubo un error por codigo cajero vacio";
        public static string P_str_Error_str_monto_debito_vacio = "hubo un error por monto vacio de debito para trasacción";
        public static string P_str_Error_time_hora = "hubo un error por variable hora vacia  para trasacción";
        public static string P_str_Error_cod_sucursal = "hubo un error por variable codigo sucursal vacia  para trasacción";
        public static string P_str_Error_login_user = "hubo un error por variable usuario vacia  para trasacción";
        public static string P_str_Error_saldos_cuentacorrientes = "sin saldos de cuenta corriente";

        public static string P_str_Error_actualizar_movdia_DBF = "ocurrio un error en actualización MovDia DBF";
        public static string P_str_Error_actualizar_tab_prov_DBF = "ocurrio un error en actualización tab_prov DBF";
        public static string P_str_Error_insert_MovTos_DBF = "ocurrio un error en inserción de Movtos  DBF";
        public static string P_str_Error_insert_tabNexo_DBF = "ocurrio un error en inserción de tabNexo DBF";

        public static string P_str_Error_Datos_vacios_MovDia = "No existen datos para procesar en MovDia";
        public static string P_str_Error_Datos_vacios_Tabprov = "No existen datos para procesar en Tab_prov";

        public static string P_str_Error_Actualiza_Detabono = "hubo un error trasacción de Actualiza DetaAbono";
        public static string P_str_Error_error_validacion_campos = "hubo un error en validacion de campos";
        public static string P_str_Error_error_validacion_descint = "dato descint es igual a 0";
    }
}