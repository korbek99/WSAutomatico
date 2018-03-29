using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wsPagoAutomaticoCajaNew.Entidades;
using wsPagoAutomaticoCajaNew.DataAccess;
using BANED.NET.Negocio;
using BANED.NET.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace wsPagoAutomaticoCajaNew.Negocio
{
    public class MDL_PagoAutomatico
    {
        public DateTime FechaSis = new DateTime();

        public  ParamsErrores objParam = new ParamsErrores();

        public Boolean ActualizarMovDiaNG(string rutcliente,
                                       string demandante,
                                        string correlat,
                                        string cod_cajero,
                                        DateTime fecha_pago,
                                        string esta_liqui,
                                        string num_caja,
                                        string tip_pag,
                                        string estado,
                                        string tip_mov,
                                        string tip_liq,
                                        string tip_pag_tos,
                                        string cod_cli,
                                        Decimal mto_oper,
                                        string num_doc,
                                        string banco,
                                        DateTime fec_oper,
                                        string hor_oper,
                                        DateTime fec_dia,
                                        string cod_suc,
                                        string login_user,
                                        string folioND)
        {

            bool trans = false;
            PagoAutomaticoMov objPagoAu = new PagoAutomaticoMov();
            PagoAutomatico ObjPA = new PagoAutomatico();

            try
            {
                if (ObjPA.ActualizarPagoAutomaticoMov( rutcliente,
                                        demandante,
                                         correlat,
                                         cod_cajero,
                                         fecha_pago,
                                         esta_liqui,
                                         num_caja,
                                         tip_pag,
                                         estado,
                                         tip_mov,
                                         tip_liq,
                                         tip_pag_tos,
                                         cod_cli,
                                         mto_oper,
                                         num_doc,
                                         banco,
                                         fec_oper,
                                         hor_oper,
                                         fec_dia,
                                         cod_suc,
                                         login_user,
                                         folioND) == true)
                {
                    trans = true;
                }
                else
                {
                    trans = false;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/ActualizarMovDiaNG");

            }

            return trans;
        }

        public Boolean ValidaSaldoCuentaCorriente(string sistema, string rut_deudor, string cod_cliente, decimal monto_tot_deb)
        {
            bool valido = true;
            try
            {
                CalcSaldo calcSaldoDeudor = new CalcSaldo();
                CuentaCorrienteNG objCC = new CuentaCorrienteNG();

                calcSaldoDeudor = objCC.calcSaldosNuevo(sistema, rut_deudor, cod_cliente, "", "");

                if (calcSaldoDeudor.SaldoRut < monto_tot_deb)
                {
                    valido = false;
                }
            }
            catch (Exception ex)
            {
                //Program.frmError(ex);
            }

            return valido;
        }

        public Boolean ActualizacionMOVDIA_DBF_NG(string rutDeudor,  string demandante,string codSucursal, string codCajero, string tipoPago, string numOpe,
                                             string numCuota, string banco, string numDocumento, string plaza, double mtoDoc, double correlativo,
                                             string folio, DateTime fechaPago, string hora, string esta_liqui, string num_caja)
        {
            bool transacction = false;
             PagoAutomatico ObjPA = new PagoAutomatico();
            try
            {
                if (ObjPA.ActualizacionMOVDIA_DBF_DAL(rutDeudor,demandante, codSucursal, codCajero, tipoPago, numOpe, numCuota, banco, numDocumento, plaza,
                                                              mtoDoc, correlativo, folio, fechaPago, hora,  esta_liqui,  num_caja) == true)
                { 
                
                  transacction = true;
                }

                
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/ActualizacionMOVDIA_DBF_NG");
                transacction = false;
            }

            return transacction;
        
        }


        public Boolean ActualizacionTab_Prov_DBF_NG(string rutcliente, string demandante, string correlat, string cod_cajero, DateTime fec_caja, string estado, string hor_caja,DateTime fechaPago)
        {
            bool transacction = true;
            PagoAutomatico ObjPA = new PagoAutomatico();
            try
            {
                if (ObjPA.ActualizacionTab_Prov_DBF_DAL(rutcliente, demandante, correlat, cod_cajero, fec_caja, estado, hor_caja, fechaPago) == true)
                {
                    transacction = true;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/ActualizacionTab_Prov_DBF_NG");
                transacction = false;
            }

            return transacction;
        
        }

        public Boolean InsertarMovTos_DBF_NG(string correlat,string rutDeudor,string codCajero,string tipoMov,string tip_liq   
							,string tip_pag_tos ,string cod_cli  ,double mto_oper ,DateTime fec_oper ,string hor_oper ,DateTime fec_dia , string cod_suc)
        {
            bool transacction = true;
         
            PagoAutomatico ObjPA = new PagoAutomatico();
            try
            {
                if (ObjPA.InsertarMovTos_DBF_DAL( correlat,rutDeudor,codCajero,tipoMov,tip_liq,tip_pag_tos,cod_cli,mto_oper,fec_oper,hor_oper,fec_dia,cod_suc) == true)
                {

                    transacction = true;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/InsertarMovTos_DBF_NG");
                transacction = false;
            }

            return transacction;
        
        }

        public Boolean InsertTabNexo_DBF_NG(string correlat, string folioLi, string folioNc, string folioNd, string folioRe, string cdEstado, string codSuc)
        {
            bool transacction = false;

            PagoAutomatico ObjPA = new PagoAutomatico();
            try
            {
                if (ObjPA.InsertTabNexo_DBF_DAL( correlat,  folioLi,  folioNc,  folioNd,  folioRe,  cdEstado,  codSuc) == true)
                {

                    transacction = true;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/InsertarMovTos_DBF_NG");
                transacction = false;
            }

            return transacction;

        }


        //public  Boolean Actualiza_Detabono(string strRut, string strCorrelat, string strNumDoc, string str_fecha_pago, string strFolio, string strTipoNota, string strEstadoTransaccion)
        //{
        //    string pr_mensage = "";
        //    string strSistema = MgsDescripcionesProcesos.P_str_moduloServicio;
        //    string strCadenaBusqueda = (strRut + strFolio);
        //    string strNombreIndice = "LLAVE";
        //    string strEstadoDocumento = string.Empty;
        //    //string var_resultadoSQL = false;
        //    string condWhere = string.Empty;
        //    System.DateTime fechaPago = default(System.DateTime);
        //    fechaPago = new DateTime(BANED.NET.Parse.ToInt32(str_fecha_pago.Substring(0, 4)), BANED.NET.Parse.ToInt32(str_fecha_pago.Substring(4, 2)), BANED.NET.Parse.ToInt32(str_fecha_pago.Substring(6, 2)));
        //    bool trans = false;
        //    PagoAutomatico ObjPA = new PagoAutomatico();


        //    if ((strEstadoTransaccion == "PAG"))
        //    {
        //        if ((strTipoNota == "ND"))
        //        {
        //            condWhere = " and sEstadoTransaccion='PEN' AND sTipoTransaccion='ND' ";
        //        }
        //        else
        //        {
        //            condWhere = " and sEstadoTransaccion='PEN' AND sTipoTransaccion='NC' ";
        //        }
        //    }
        //    else if ((strEstadoTransaccion == "PEN"))
        //    {
        //        condWhere = " and sEstadoTransaccion = 'PAG' And sCorrelat ='" + strCorrelat + "'";
        //    }

        //    if ((!string.IsNullOrEmpty(strNumDoc.Trim())))
        //    {
        //        strEstadoDocumento = "RET";
        //    }

        //    try 
        //    { 
        //         if (ObjPA.ActualizaDetAbono(strSistema, strCadenaBusqueda, strNombreIndice, strEstadoTransaccion,
        //                strEstadoDocumento, strCorrelat, condWhere, strFolio, pr_mensage) == true)
        //        {
        //            trans = true;
        //        }

        //    }catch (Exception ex)
        //    {
        //        trans = false;
        //    }

        //    return trans;
        //}

        //public void Actualiza_Reabono(string str_rut, string str_folio, string str_num_doc, string str_tipo_nota, int validaDecla, string correlat, string operacion)
        //{
        //    string tipoPago = null;
        //    dynamic pr_sSistema = "CAJA.NET";
        //    string str_cod_cli = null;
        //    string str_cod_suc = null;
        //    string str_area = null;
        //    string str_tipoabono = null;
        //    string nomIndice = null;
        //    string cadBusqueda = null;
        //    string str_monto = null;
        //    string str_monto_ret = null;
        //    int int_total_ret = 0;
        //    int int_montoDecla = 0;
        //    DataTable dt_detabono = new DataTable();
        //    DataSet dts_detabono = new DataSet();
        //    CuentaCorrienteNG objBanedCC = new CuentaCorrienteNG();
        //try
        //   {
        //    //'Efectivo
        //                if ((string.IsNullOrEmpty(str_num_doc.Trim())))
        //                {
        //                    tipoPago = "";
        //                }
        //                else
        //                {
        //                    tipoPago = "CHEQUE";
        //                }
            
        //                dt_detabono = objBanedCC.AbreDetabonoDT(pr_sSistema, "", "", "", "", str_rut, "", str_folio, "", null, null);
         

        //                //If (ds_detabono.Tables(0).Rows.Count > 0) Then
        //                if ((dt_detabono.Rows.Count > 0))
        //                {
        //                    int i;
        //                    for (i = 0; i <= dt_detabono.Rows.Count - 1; i++)
        //                    {
        //                        str_cod_cli = dt_detabono.Rows[i]["cod_cli"].ToString();
        //                        str_cod_suc = dt_detabono.Rows[i]["cod_suc"].ToString();
        //                        str_area = dt_detabono.Rows[i]["area"].ToString();
        //                        str_tipoabono = dt_detabono.Rows[i]["tipoabono"].ToString();

        //                        //'Efectivo
        //                        if ((string.IsNullOrEmpty(str_num_doc.Trim())))
        //                        {
        //                            str_monto = dt_detabono.Rows[i]["monto"].ToString();
        //                            str_monto_ret = "0";
        //                        }
        //                        else
        //                        {
        //                            str_monto = dt_detabono.Rows[i]["monto"].ToString();
        //                            str_monto_ret = dt_detabono.Rows[i]["monto"].ToString();
        //                        }

        //                        //'Revisa cuenta reabono en SQL
        //                        int_total_ret = objBanedCC.getCountRetaAbono(str_cod_cli, str_cod_suc, str_rut, str_area, str_tipoabono);
        //                        cadBusqueda = (str_cod_cli + str_cod_suc + str_area + str_rut + str_tipoabono);
        //                        nomIndice = "CLISUCRU";


        //                        if ((int_total_ret > 0))
        //                        {

        //                            if ((str_tipo_nota == "ND"))
        //                            {
        //                                //'si es nota de Débito, resta el monto
        //                                str_monto = (Convert.ToInt32(str_monto) * -1).ToString();
        //                                str_monto_ret = (Convert.ToInt32(str_monto_ret) * -1).ToString();

        //                                if ((validaDecla == 0))
        //                                {
        //                                    int_montoDecla = 0;
        //                                }
        //                                else
        //                                {
        //                                    int_montoDecla = Convert.ToInt32(str_monto);
        //                                }

        //                                objBanedCC.actualizaReabono(pr_sSistema, cadBusqueda, nomIndice, Convert.ToString(str_monto), "0", int_montoDecla.ToString(), null, null, "", str_tipo_nota,
        //                                correlat, str_folio, operacion);

        //                            }
        //                            else
        //                            {
        //                                //'Valida transacciones pagadas cont. 6483

        //                                if ((dt_detabono.Rows[i]["estado"].ToString() == "PAG"))
        //                                {
        //                                    //'Si es nota de Crédito, suma el monto
        //                                    str_monto = (Convert.ToInt32(str_monto) * 1).ToString();
        //                                    str_monto_ret = (Convert.ToInt32(str_monto_ret) * 1).ToString();

        //                                    if ((validaDecla == 0))
        //                                    {
        //                                        int_montoDecla = 0;
        //                                    }
        //                                    else
        //                                    {
        //                                        int_montoDecla = Convert.ToInt32(str_monto);
        //                                    }


        //                                    if ((tipoPago == "CHEQUE"))
        //                                    {
        //                                        objBanedCC.insertReabono(pr_sSistema, str_cod_cli, str_cod_suc, str_area, str_rut, str_tipoabono, Convert.ToString(str_monto), "0", int_montoDecla.ToString(), "",
        //                                        str_tipo_nota, correlat, str_folio, operacion);
        //                                        objBanedCC.actualizaReabono(pr_sSistema, cadBusqueda, nomIndice, "0", Convert.ToString(str_monto_ret), int_montoDecla.ToString(), null, null, "", "RET",
        //                                        correlat, str_folio, operacion);
        //                                    }
        //                                    else
        //                                    {
        //                                        objBanedCC.actualizaReabono(pr_sSistema, cadBusqueda, nomIndice, Convert.ToString(str_monto), Convert.ToString(str_monto_ret), int_montoDecla.ToString(), null, null, "", str_tipo_nota,
        //                                        correlat, str_folio, operacion);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            //'Valida transacciones pagadas cont. 6483
        //                            if ((dt_detabono.Rows[i]["estado"].ToString() == "PAG"))
        //                            {
        //                                if ((validaDecla == 0))
        //                                {
        //                                    int_montoDecla = 0;
        //                                }
        //                                else
        //                                {
        //                                    int_montoDecla = Convert.ToInt32(str_monto);
        //                                }

        //                                if ((tipoPago == "CHEQUE"))
        //                                {
        //                                    objBanedCC.insertReabono(pr_sSistema, str_cod_cli, str_cod_suc, str_area, str_rut, str_tipoabono, Convert.ToString(str_monto), "0", int_montoDecla.ToString(), "",
        //                                    str_tipo_nota, correlat, str_folio, operacion);

        //                                    objBanedCC.actualizaReabono(pr_sSistema, cadBusqueda, nomIndice, "0", Convert.ToString(str_monto_ret), int_montoDecla.ToString(), null, null, "", "RET",
        //                                    correlat, str_folio, operacion);
        //                                }
        //                                else
        //                                {
        //                                    objBanedCC.insertReabono(pr_sSistema, str_cod_cli, str_cod_suc, str_area, str_rut, str_tipoabono, Convert.ToString(str_monto), "0", int_montoDecla.ToString(), tipoPago,
        //                                    str_tipo_nota, correlat, str_folio, operacion);

        //                                }

        //                            }

        //                        }

        //                    }

        //                }
            

        //}
        //catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
        //catch (Exception e) { Console.WriteLine("Error :" + e.Message); }



        //} //Fin proceso

       
      
    }
}