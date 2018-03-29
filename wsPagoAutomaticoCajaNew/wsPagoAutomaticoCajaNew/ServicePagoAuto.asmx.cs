using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using wsPagoAutomaticoCajaNew.Entidades;
using wsPagoAutomaticoCajaNew.Negocio;
using wsPagoAutomaticoCajaNew.Enumeraciones;
using wsPagoAutomaticoCajaNew.DataAccess;
namespace wsPagoAutomaticoCajaNew
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        public string str_descripcionErrores;
        public string str_descripcionErrores_exceptions;
        public string str_descripcion_procesos;
        public int int_estadoProcesosInternos;
        public decimal monto_total_mov;
        public decimal monto_total_prov;
        public int int_correlativo;
        public string str_folio_Deb;
        public string str_cod_sucursal;
        public string str_Tip_pag_movto;
        public int resultado_ActualizaTabNexo;
        public int resultado_Liquida_Nota;
        public int resultado_Actualiza_MovTos;
        public string str_tip_liq;
        public string str_esta_liqui;
        public string str_cod_cli;
        public string str_fecha_pago;
        public string str_cod_age;
        public string str_rut_cliente;
        public string str_cod_deman;
        public string str_descripcion_err_valida;
        public int int_MtoEfec;
        public int int_Vuelto;
        public int int_Total;
        public int int_Mto_Deb;
        public string str_cod_cajero;
        public string str_time_hora;
        public string str_login_user;
        public string str_fecha_hoy;
        public int int_descinte;
        public string str_numOpe;
        public string str_numCuota;
        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        [WebMethod]
        public DataSet PagoAutomaticoCajaPrincipalNew(string str_rut_cli, string str_cod_demandante, string str_login_red)
        {
            DataSet dst = new DataSet();
            DataTable dt = new DataTable();
            int int_codigotransac;
            dst.Tables.Add(dt);
            dt.Columns.Add("Transcodigo", typeof(string));
            dt.Columns.Add("MensajeTrans", typeof(string));
            dt.Columns.Add("Procesoscodigo", typeof(string));
            dt.Columns.Add("MensajeProceso", typeof(string));

            //obtiene codigo estado de proceso de transaccion

            if (ValidaCamposPrincipales(str_rut_cli, str_cod_demandante, str_login_red) == true)
            { 
            
               int_codigotransac = PagoAutomaticoCaja(str_rut_cli, str_cod_demandante, str_login_red);

              switch (int_codigotransac)
              {
                  case -1:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_error_transaccion_proceso;
                      break;
                  case 1:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_transaccion_proceso;
                      break;
                  case -2:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_error_transaccion_no_monto;
                      break;
                  case -3:
                      str_descripcionErrores = str_descripcionErrores_exceptions;
                      break;

                  case -4:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_validacion_diaHabil;
                      break;

                  case -5:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_Error_ActualizaTabNexo;
                      break;
                  case -6:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_Error_Liquida_Nota;
                      break;
                  case -7:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_Error_Actualiza_MovTos;
                      break;
                  case 0:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_transaccion_proceso_no_data;
                      break;
                  default:
                      str_descripcionErrores = MgsDescripcionesProcesos.P_str_estado_error_transaccion_otro;
                      break;
              }

              // obtiene el estado de cada proceso individual de transaccion.
              switch (int_estadoProcesosInternos)
              {
                  case -1:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_error_procesos_internos + "  " + str_descripcion_err_valida;
                      break;
                  case 1:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_transaccion_proceso;
                      break;
                  case -2:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_error_transaccion_no_monto;
                      break;
                  case -4:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_validacion_diaHabil;
                      break;
                  case -15:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_Error_saldos_cuentacorrientes;
                      break;
                  case -16:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_Error_error_validacion_descint;
                      break;
                  case -17:
                      str_descripcion_procesos ="se realizo transaccion pero con  errores en :" + MgsDescripcionesProcesos.P_str_Error_Actualiza_MovDia_DBF;
                      break;
                  case -18:
                      str_descripcion_procesos = "se realizo transaccion pero con  errores en :" + MgsDescripcionesProcesos.P_str_Error_Actualiza_tab_prov_DBF;
                      break;
                  case -19:
                      str_descripcion_procesos = "se realizo transaccion pero con  errores en :" + MgsDescripcionesProcesos.P_str_Error_Actualiza_mov_tos_DBF;
                      break;
                  case -20:
                      str_descripcion_procesos = str_descripcion_err_valida;
                      break;
                  case -21:
                      str_descripcion_procesos = "se realizo transaccion pero con  errores en :" + MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF;
                      break;
                  default:
                      str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_error_procesos_internos_default;
                      break;
              }

              //adjunta los parametros obtenidos para agregarlos a un Dataset para despliege de informacion en WS
              dt.Rows.Add(int_codigotransac, str_descripcionErrores, int_estadoProcesosInternos, str_descripcion_procesos);

              

            }else
            {
                int_codigotransac = -1;
               //int_estadoProcesosInternos = -1;

                switch (int_estadoProcesosInternos)
                {
                    case -1:
                        str_descripcion_procesos = MgsDescripcionesProcesos.P_str_estado_error_procesos_internos + "  " + str_descripcion_err_valida;
                        break;
                }
                str_descripcion_procesos = str_descripcion_err_valida;
                dt.Rows.Add(-1, str_descripcion_procesos, int_estadoProcesosInternos, str_descripcion_err_valida);
            }
            
           return dst;
        }
        //[WebMethod]
        public int PagoAutomaticoCaja(string str_rut_cli, string str_cod_demandante, string str_login_usrs)
        {
            //Proceso de transaccion de caja
            MDL_Funciones objFuncion = new MDL_Funciones();

            //DateTime d_fechaactual = new DateTime(); // solo pruebas ya que se necesita fecha servidor
            DataSet ds_Movdia = new DataSet();
            DataSet ds_Movdia_tempo = new DataSet();
            DataSet ds_tb_prov = new DataSet();
            DataSet ds_fechas_servidor = new DataSet();
            DataSet ds_Movdia_tabnexo = new DataSet();
            DataSet ds_tb_prov_tabnexo = new DataSet();
            ParamsDates ObjDates1 = new ParamsDates();
            DateTime date = new DateTime();
            //Util ObjUtil = new Util();
            ParamsErrores ObjError = new ParamsErrores();
            MDL_Funciones objfunc = new MDL_Funciones();
            MDL_PagoAutomatico ObjPagosMd = new MDL_PagoAutomatico();

            ds_fechas_servidor = ObjDates1.getFechasServidor();
            date = Convert.ToDateTime(ds_fechas_servidor.Tables[0].Rows[0]["fechahoramin"].ToString());
            str_login_user = str_login_usrs;
            str_time_hora = formatoHora(Convert.ToString(date.Hour)) + ":" + formatoMinuto(Convert.ToString(date.Minute)) + ":" + formatoSegundo(Convert.ToString(date.Second));
            str_fecha_hoy = Convert.ToString(date);
            DateTime FechaHoy = new DateTime();
            FechaHoy = Convert.ToDateTime(str_fecha_hoy);

            string str_hora = Convert.ToString(FechaHoy.Hour) + ":" + Convert.ToString(FechaHoy.Minute) + ":" + Convert.ToString(FechaHoy.Second);

            int_estadoProcesosInternos = -2;

            int filasAfectadas = -1;

            // busca disponibilidad de proceso segun dia habil de BD
            if (objFuncion.DisponibilidadWSFinDeMes(str_cod_demandante) == true)
            {
                try
                {
                    // se realiza la operacion de caja
                    PagoAutomatico ObjPagoAuto = new PagoAutomatico();

                    // se obtiene datos desde base datos y se llenan datasets
                    ds_Movdia = ObjPagoAuto.ObtieneMovDiaPorParametros(str_rut_cli, str_cod_demandante, EstadosPagosAutomaticos.P_str_mov_pendiente_de_pago);
                    ds_tb_prov = ObjPagoAuto.ObtieneTab_prov_Por_Parametros(str_rut_cli, str_cod_demandante, EstadosPagosAutomaticos.P_str_prov_pendiente_de_pago, EstadosPagosAutomaticos.P_str_prov_nota_debito);

                    //se obtienen montos de Movdia
                    if (ds_Movdia.Tables[0].Rows.Count > 0)
                    {
                        decimal sumamontos = 0;

                        foreach (DataRow dataRow in ds_Movdia.Tables[0].Rows)
                        {
                            int_descinte = Convert.ToInt32(dataRow["descinte"]);
                            str_cod_sucursal = Convert.ToString(dataRow["cod_suc"]);
                            str_numOpe = Convert.ToString(dataRow["num_ope"]);
                            str_numCuota = Convert.ToString(dataRow["num_cuo"]);
                            sumamontos = sumamontos + Convert.ToDecimal(dataRow["mto_total"]);
                        }
                        monto_total_mov = sumamontos;
                    }
                    else
                    {
                        monto_total_mov = 0;
                        //return filasAfectadas;
                    }

                    //se obtienen montos de tb_pro y se compara con monto movdia
                    if (ds_Movdia.Tables[0].Rows.Count > 0)
                    {
                        // Validar int_descinte > 0 , si no sale del ciclo completo
                        //if (int_descinte > 0)
                        //{
                        // string str_fecha_pago_tempo = objfunc.checkDiaDePago(FechaHoy.AddDays(1), str_hora, "", "", FechaHoy, str_cod_sucursal);

                        if (ds_tb_prov.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dataRow in ds_tb_prov.Tables[0].Rows)
                            {
                                str_folio_Deb = dataRow["folio"].ToString();
                            }
                        }

                        // llama funcion de marca ingreso reajuste
                        // objFuncion.MarcaIngresoReaj(str_cod_demandante, str_rut_cli, int_descinte, str_fecha_pago_tempo, Convert.ToInt32(str_folio_Deb));

                        //inicia proceso Pago Automatico
                        if (ds_tb_prov.Tables[0].Rows.Count > 0)
                        {
                            // busca montos de tab_prov
                            decimal d_sumamontos_prov = 0;
                            foreach (DataRow dataRow in ds_tb_prov.Tables[0].Rows)
                            {
                                str_folio_Deb = dataRow["folio"].ToString();
                                d_sumamontos_prov = d_sumamontos_prov + Convert.ToDecimal(dataRow["monto"].ToString());
                            }

                            monto_total_prov = d_sumamontos_prov;

                            //se compara Montos de movdia y tab_prov , en caso iguales se procesa , si no se sale del ciclo 
                            if (monto_total_mov == monto_total_prov)
                            {
                                str_rut_cliente = str_rut_cli;
                                str_fecha_pago = objfunc.checkDiaDePago(FechaHoy.AddDays(1), str_hora, "", "", FechaHoy, str_cod_sucursal);
                                // str_fecha_pago = Convert.ToString(date);

                                int_correlativo = objfunc.Busca_Correlativo();
                                str_cod_cajero = EstadosPagosAutomaticos.P_str_CM_codigo_cajero + Convert.ToString(Convert.ToInt32(str_cod_sucursal));
                                str_Tip_pag_movto = EstadosPagosAutomaticos.P_str_prov_nota_debito;

                                //valida campos necesarios 
                                if (ValidaCamposTransations() == true)
                                {
                                    // valida cuenta corrientes
                                    if (ObjPagosMd.ValidaSaldoCuentaCorriente(MgsDescripcionesProcesos.P_str_moduloServicio, str_rut_cliente, str_cod_demandante, monto_total_prov) == true)
                                    {
                                        // realiza proceso de pago automatico
                                        if (ObjPagosMd.ActualizarMovDiaNG(
                                                                  str_rut_cliente,
                                                                  str_cod_demandante,
                                                                  Convert.ToString(int_correlativo),
                                                                  str_cod_cajero,
                                                                  Convert.ToDateTime(str_fecha_pago),
                                                                  EstadosPagosAutomaticos.P_str_prov_estado_liq,
                                                                  EstadosPagosAutomaticos.P_str_mov_Num_caja,
                                                                  EstadosPagosAutomaticos.P_str_mov_tipo_pago,
                                                                  EstadosPagosAutomaticos.P_str_prov_estado_liq,
                                                                  EstadosPagosAutomaticos.P_str_mov_tipo_movtos,
                                                                  EstadosPagosAutomaticos.P_str_mov_tipo_liq_movtos,
                                                                  EstadosPagosAutomaticos.P_str_mov_tipo_Pag_movtos,
                                                                  str_cod_demandante,
                                                                  monto_total_prov,
                                                                  "",
                                                                  "",
                                                                  Convert.ToDateTime(str_fecha_pago),
                                                                  str_time_hora,
                                                                  Convert.ToDateTime(str_fecha_pago),
                                                                  str_cod_sucursal,
                                                                  str_login_user,
                                                                  str_folio_Deb) == true)
                                        {

                                            ds_Movdia_tempo = ObjPagoAuto.ObtieneMovDiaPorParametros(str_rut_cli, str_cod_demandante, EstadosPagosAutomaticos.P_str_mov_cancelado_de_pago);
                                            if (ds_Movdia_tempo.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow dataRow in ds_Movdia_tempo.Tables[0].Rows)
                                                {
                                                    int_descinte = Convert.ToInt32(dataRow["descinte"]);
                                                }
                                            }
                                            if (int_descinte > 0)
                                            {
                                                objFuncion.MarcaIngresoReaj(str_cod_demandante, str_rut_cli, int_descinte, str_fecha_pago, Convert.ToInt32(str_folio_Deb));
                                            }

                                            // Actualiza DBF MOVDIA , TAB_PROV y MOVTOS

                                            string str_hora_pago_DBF = "";

                                            str_hora_pago_DBF = formatoHora(Convert.ToString(date.Hour)) + ":" + formatoMinuto(Convert.ToString(date.Minute)) + ":" + formatoSegundo(Convert.ToString(date.Second));

                                                if (ObjPagosMd.ActualizacionMOVDIA_DBF_NG(str_rut_cliente,str_cod_demandante, str_cod_sucursal, str_cod_cajero, EstadosPagosAutomaticos.P_str_mov_tipo_pago, str_numOpe, str_numCuota, "", "", "",
                                                          Convert.ToDouble(monto_total_prov), Convert.ToDouble(int_correlativo), str_folio_Deb, Convert.ToDateTime(str_fecha_pago), str_hora_pago_DBF, EstadosPagosAutomaticos.P_str_prov_estado_liq, EstadosPagosAutomaticos.P_str_mov_Num_caja) == true)
                                                {

                                                }else{
                                                    ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                       MgsDescripcionesProcesos.P_str_Error_Actualiza_MovDia_DBF, false,
                                                       EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                       MgsDescripcionesProcesos.P_str_moduloServicio);

                                                       filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                       str_descripcion_err_valida =  MgsDescripcionesProcesos.P_str_Error_actualizar_movdia_DBF;
                                                       int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_update_movdia_DBF;
                                                    return filasAfectadas;

                                                }

                                                if (ObjPagosMd.ActualizacionTab_Prov_DBF_NG(str_rut_cliente, str_cod_demandante, Convert.ToString(int_correlativo), str_cod_cajero, Convert.ToDateTime(str_fecha_pago), EstadosPagosAutomaticos.P_str_prov_estado_liq, str_hora_pago_DBF, Convert.ToDateTime(str_fecha_pago)) == true)
                                                {

                                                }else{
                                                      ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                      MgsDescripcionesProcesos.P_str_Error_Actualiza_tab_prov_DBF, false,
                                                      EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                      MgsDescripcionesProcesos.P_str_moduloServicio);

                                                        filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                        str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_Actualiza_tab_prov_DBF;
                                                        int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_update_tab_prov_DBF;
                                                     return filasAfectadas;
                                                }

                                                if (ObjPagosMd.InsertarMovTos_DBF_NG(Convert.ToString(int_correlativo),
                                                    str_rut_cliente,
                                                    str_cod_cajero,
                                                    EstadosPagosAutomaticos.P_str_mov_tipo_movtos,
                                                    EstadosPagosAutomaticos.P_str_mov_tipo_liq_movtos,
                                                    EstadosPagosAutomaticos.P_str_mov_tipo_Pag_movtos,
                                                    str_cod_demandante,
                                                    Convert.ToDouble(monto_total_prov),
                                                    Convert.ToDateTime(str_fecha_pago),
                                                    str_hora_pago_DBF,
                                                    Convert.ToDateTime(str_fecha_pago), 
                                                    str_cod_sucursal) == true)
                                                    {

                                                    }else{

                                                       ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                       MgsDescripcionesProcesos.P_str_Error_Actualiza_mov_tos_DBF, false,
                                                       EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                       MgsDescripcionesProcesos.P_str_moduloServicio);

                                                        filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                        str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_insert_MovTos_DBF;
                                                        int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_insert_movtos_DBF;
                                                        return filasAfectadas;

                                                    }

                                                        string str_folioLi = "";
                                                        string str_folioNc = "";
                                                        string str_folioRe = "";

                                                        ds_Movdia_tabnexo = ObjPagoAuto.ObtieneMovDiaPorParametrosTab_nexo_data(str_rut_cli, str_cod_demandante, EstadosPagosAutomaticos.P_str_mov_cancelado_de_pago, Convert.ToString(int_correlativo));
                                                        ds_tb_prov_tabnexo = ObjPagoAuto.ObtieneTab_prov_Por_Parametros_tab_nexo_data(str_rut_cli, str_cod_demandante, EstadosPagosAutomaticos.P_str_prov_estado_liq, EstadosPagosAutomaticos.P_str_prov_nota_debito, Convert.ToString(int_correlativo));

                                                      if (ds_Movdia_tabnexo.Tables[0].Rows.Count > 0 && ds_Movdia_tabnexo != null)
                                                      {
                                                          foreach (DataRow dataRow in ds_Movdia_tabnexo.Tables[0].Rows)
                                                          {
                                                              string str_folio_movdia = dataRow["folio"].ToString();

                                                              if (ObjPagosMd.InsertTabNexo_DBF_NG(Convert.ToString(int_correlativo), str_folio_movdia.ToString(), str_folioNc, "", str_folioRe, EstadosPagosAutomaticos.P_str_cdEstadoTabNexo, str_cod_sucursal.ToString()) == false)
                                                              {
                                                                  ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                                  MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF, false,
                                                                  EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                                  MgsDescripcionesProcesos.P_str_moduloServicio);

                                                                  filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                                  str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF;
                                                                  int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_insert_tabNexo_DBF;
                                                                  return filasAfectadas;
                                                              }
                                                          }
                                                      }else {

                                                          ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                                 MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF, false,
                                                                 EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                                 MgsDescripcionesProcesos.P_str_moduloServicio);

                                                          filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                          str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF + " " + MgsDescripcionesProcesos.P_str_Error_Datos_vacios_MovDia;
                                                          int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_insert_tabNexo_DBF;
                                                          return filasAfectadas;
                                                      }

                                                      if (ds_tb_prov_tabnexo.Tables[0].Rows.Count > 0 && ds_tb_prov_tabnexo != null)
                                                      {
                                                          foreach (DataRow dataRow in ds_tb_prov_tabnexo.Tables[0].Rows)
                                                          {
                                                              string str_folio_tab_prov = dataRow["folio"].ToString();

                                                                  if (ObjPagosMd.InsertTabNexo_DBF_NG(Convert.ToString(int_correlativo), str_folioLi, str_folioNc, str_folio_tab_prov.ToString(), str_folioRe, EstadosPagosAutomaticos.P_str_cdEstadoTabNexo, str_cod_sucursal.ToString()) == false)
                                                                  {
                                                                      ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                                      MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF, false,
                                                                      EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                                      MgsDescripcionesProcesos.P_str_moduloServicio);

                                                                      filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                                      str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF;
                                                                      int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_insert_tabNexo_DBF;
                                                                      return filasAfectadas;
                                                                  }
                                                          }
                                                      }else {

                                                          ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                                                 MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF, false,
                                                                 EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                                                 MgsDescripcionesProcesos.P_str_moduloServicio);

                                                          filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                          str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_insert_tabNexo_DBF + " " + MgsDescripcionesProcesos.P_str_Error_Datos_vacios_Tabprov;
                                                          int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_insert_tabNexo_DBF;
                                                          return filasAfectadas;
                                                      }
                                                      
                                                        filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_monto;
                                                        int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_procesos_internos;
                                                        return filasAfectadas;
                                        }
                                        else
                                        {
                                            ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                            MgsDescripcionesProcesos.P_str_Error_Actualiza_MovDia, false,
                                            EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                            MgsDescripcionesProcesos.P_str_moduloServicio);

                                            filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                                            int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                                            return filasAfectadas;
                                        }
                                    }
                                    else
                                    {
                                        ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                        MgsDescripcionesProcesos.P_str_Error_saldos_cuentacorrientes, false,
                                        EnumEstadosProcesosPagos.codigo_estado_Error_saldo_cuenta_corriente,
                                        MgsDescripcionesProcesos.P_str_moduloServicio);

                                        filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                                        str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_saldos_cuentacorrientes;
                                        int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_saldo_cuenta_corriente;
                                        return filasAfectadas;
                                    }

                                }
                                else
                                {
                                    ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 0,
                                    MgsDescripcionesProcesos.P_str_Error_error_validacion_campos + " " + str_descripcion_err_valida, false,
                                    EnumEstadosProcesosPagos.codigo_estado_procesos_internos,
                                    MgsDescripcionesProcesos.P_str_moduloServicio);

                                    filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                                    int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_validacion_campos;
                                    return filasAfectadas;
                                }

                            }
                            else
                            {
                                ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 9,
                                MgsDescripcionesProcesos.P_str_estado_error_transaccion_no_monto, false,
                                EnumEstadosProcesosPagos.codigo_estado_error_trans_no_monto,
                                MgsDescripcionesProcesos.P_str_moduloServicio);

                                filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_error_trans_no_monto;
                                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_monto_mov_prov;
                                return filasAfectadas;
                            }


                        }
                        else
                        {
                            filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data;
                            int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                        }


                        //}else {
                        //    // Validar int_descinte = 0

                        //    filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                        //    int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_Error_desc_int;
                        //    str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_error_validacion_descint;

                        //}

                    }
                    else
                    {
                        filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data;
                        int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_error_procesos_internos;
                        str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_estado_transaccion_proceso_no_data;
                    }

                }
                catch (Exception ex)
                {
                    filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data_exception;
                    str_descripcionErrores_exceptions = "Error al realizar la operacion de datos ." + ex;
                    //GrabaError(ex, "Error al realizar la operacion de datos .");
                    // objFuncion.GrabaErrores(ex, ErrorDescripPagoAutomaticoCaja.ErrorDescripTransPagoAutomatico);

                    ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, str_login_usrs, 9,
                                    str_descripcionErrores_exceptions, false,
                                    EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data_exception,
                                    MgsDescripcionesProcesos.P_str_moduloServicio);
                }


            }
            else
            {
                filasAfectadas = EnumEstadosProcesosPagos.codigo_estado_validacion_diaHabil;
                int_estadoProcesosInternos = EnumEstadosProcesosPagos.codigo_estado_validacion_diaHabil;

            }

            return filasAfectadas;
        }

        //[WebMethod]
        //public DataSet ListaOcurrenciasPagoAutomatico(int idsistema)
        //{
        //    DataSet DtsOcurrencias = new DataSet();
        //    MDL_ErroresNG ObjErrorNG = new MDL_ErroresNG();
        //    DtsOcurrencias = ObjErrorNG.ListaOcurrenciasPagoAutomaticoNG(idsistema);
        //    return DtsOcurrencias;
        //}
        //otros metodos****************************************************************************************************
        private static string SubMid(string s, int a, int b)
        {

            string temp = s.Substring(a - 1, b);

            return temp;
        }
        private void GrabaError(Exception ex, string mensajeInicial)
        {
            //Util utiles = new Util();
            //utiles.grabaError(ex, Globales.Sistema.SisTema);

            throw new Exception(mensajeInicial + Environment.NewLine + ex.Message, ex);
        }
        private Boolean ValidaCamposPrincipales(string str_rut_cli, string str_cod_demandante, string str_login_red)
        {
            bool validField = true;
            ParamsErrores ObjError = new ParamsErrores();

            if (String.IsNullOrEmpty(str_rut_cli))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_rut_cliente;
                validField = false;

                ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, Environment.MachineName, -1,
                                    str_descripcion_err_valida, false,
                                    EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data_exception,
                                     MgsDescripcionesProcesos.P_str_proyectoDescripcion + "/" + MgsDescripcionesProcesos.P_str_proyectoServicio + "/ValidaCamposPrincipales");
                return validField;
            }
            if (String.IsNullOrEmpty(str_cod_demandante))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_cod_deman;
                ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, Environment.MachineName, -1,
                                   str_descripcion_err_valida, false,
                                   EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data_exception,
                                    MgsDescripcionesProcesos.P_str_proyectoDescripcion + "/" + MgsDescripcionesProcesos.P_str_proyectoServicio + "/ValidaCamposPrincipales");
                validField = false;

                return validField;
            }
            if (String.IsNullOrEmpty(str_login_red))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_login_user;
                ObjError.GrabarErrores(Convert.ToDateTime(str_fecha_hoy), Environment.MachineName, Environment.MachineName, -1,
                                   str_descripcion_err_valida, false,
                                   EnumEstadosProcesosPagos.codigo_estado_transaccion_proceso_no_data_exception,
                                   MgsDescripcionesProcesos.P_str_proyectoDescripcion + "/" + MgsDescripcionesProcesos.P_str_proyectoServicio + "/ValidaCamposPrincipales");
                validField = false;

                return validField;
            }
            return validField;
        }
        private Boolean ValidaCamposTransations()
        {
            bool validField = true;

            if (String.IsNullOrEmpty(str_rut_cliente))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_rut_cliente;
                validField = false;

                return validField;
            }

            if (int_correlativo == 0 || int_correlativo < 0)
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_correlativo;
                validField = false;
                return validField;
            }


            if (String.IsNullOrEmpty(str_cod_cajero))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_cod_cajero;
                validField = false;
                return validField;
            }


            if (String.IsNullOrEmpty(str_fecha_pago))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_fecha_pago;
                validField = false;
                return validField;
            }


            if (monto_total_prov == 0 || monto_total_prov < 0)
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_str_monto_debito_vacio;
                validField = false;
                return validField;
            }


            if (String.IsNullOrEmpty(str_time_hora))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_time_hora;
                validField = false;
                return validField;
            }


            if (String.IsNullOrEmpty(str_cod_sucursal))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_cod_sucursal;
                validField = false;
                return validField;
            }


            if (String.IsNullOrEmpty(str_login_user))
            {
                str_descripcion_err_valida = MgsDescripcionesProcesos.P_str_Error_fecha_pago;
                validField = false;
                return validField;
            }

            return validField;
        }

        public string formatoHora(string minuto)
        {
            string str_Horaformat = "";
            if (minuto.Length > 1)
            {
                str_Horaformat = minuto;
            }
            else
            {
                str_Horaformat = "0" + minuto;

            }
            return str_Horaformat;

        }
        public string formatoMinuto(string minuto)
        {
            string str_Minutoformat = "";
            if (minuto.Length > 1)
            {
                str_Minutoformat = minuto;
            }
            else
            {
                str_Minutoformat = "0" + minuto;

            }
            return str_Minutoformat;

        }

        public string formatoSegundo(string segundo)
        {
            string str_Segundoformat = "";
            if (segundo.Length > 1)
            {
                str_Segundoformat = segundo;
            }
            else
            {
                str_Segundoformat = "0" + segundo;

            }
            return str_Segundoformat;

        }
    }
}