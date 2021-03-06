﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wsPagoAutomaticoCajaNew.Entidades;
using System.Data;

using wsPagoAutomaticoCajaNew.DataAccess;
using wsPagoAutomaticoCajaNew.Enumeraciones;
using BANED.NET;
using BANED.NET.Negocio;

namespace wsPagoAutomaticoCajaNew.Negocio
{
    public class MDL_Funciones
    {
        public ParamsErrores objParam = new ParamsErrores();
        public DateTime FechaSis = new DateTime();

        public string str_hora;
        public string str_mes;
        public string str_dia_ultimo_vigente;
        public string str_dia;
        public string str_dia_habil;
        public string str_ano;
        public string str_fecha_ultimo_dia;
        public string str_fecha;
        public string str_fecha_actual;
        public string str_corte;

        public string checkDiaDePago(DateTime fecha,
                                string horaCorteDia,
                                string tramoAM,
                                string tramoPM,
                                DateTime fechaHoy,
                               string sucursal)

            
        {
             string str_fechaPagos="";
             string vHora_Ini = "";
             string vFechaPago;
             string vTramo;
             string Hcorte = "";
             string TramoAM = "AM";
             string TramoPM = "PM";
             DateTime FechaHoy = new DateTime();

             try {

                 Util ObjUtils = new Util();
                 ObjUtils.checkDia(DateTime.Now.Date, ref Hcorte, ref tramoAM, ref tramoPM, ref FechaHoy, "013");
                 vHora_Ini = ObjUtils.getHoraIniCaja(DateTime.Now.Date);

                 if (Hcorte.Contains(":"))
                 {
                     string[] hora = Hcorte.Split(':');
                     TimeSpan corte = new TimeSpan(Convert.ToInt32(hora[0]), Convert.ToInt32(hora[1]), Convert.ToInt32(hora[2]));
                     TimeSpan time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                     if (time > corte)
                     {
                         vFechaPago = Convert.ToString(ObjUtils.diaHabil(FechaHoy.AddDays(1), BANED.NET.Enumeraciones.EnumClienteDiaHabil.Otros, BANED.NET.Enumeraciones.EnumOperacionDiaHabil.DiaHabilSiguiente));
                         vTramo = TramoPM;
                         str_fechaPagos = vFechaPago;
                     }
                     else
                     {
                         vFechaPago = Convert.ToString(fechaHoy);
                         vTramo = TramoAM;
                         str_fechaPagos = vFechaPago;
                     }
                 }
             
             }catch (Exception ex){

                 objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + ex.Message.ToString(), false,
                ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/MDL_funciones/checkDiaDePago");
             }
             return str_fechaPagos;
        }
        
        public bool DisponibilidadWSFinDeMes(string str_cod_cli)
        {
            bool disponibilidadWS = true;
            DateTime date =  DateTime.Now; // solo pruebas ya que se necesita fecha servidor
            DataTable dt = new DataTable();
            DataSet ds_diahabil = new DataSet();
            DataSet ds_diahabilmes = new DataSet();
            DataSet ds_fechas_servidor = new DataSet();
            PagoAutomatico ObjPagoAuto = new PagoAutomatico();
            ParamsDates ObjDate = new ParamsDates();

            try
            {
                // se realiza la operacion de disponibilidad de dias 
                ds_fechas_servidor = ObjDate.getFechasServidor();

                date = Convert.ToDateTime(ds_fechas_servidor.Tables[0].Rows[0]["fechahoramin"].ToString());

                str_mes = Convert.ToString(date.Date.Month);
                str_dia = Convert.ToString(date.Date.Day);
                str_ano = Convert.ToString(date.Date.Year);
                str_hora = Convert.ToString(date.Hour) + ":" + Convert.ToString(date.Minute);


                str_fecha_actual = formatoDia(str_dia) + "-" + str_mes + "-" + str_ano;

                 ds_diahabilmes = ObjPagoAuto.BuscarDiasHabilporMes(str_mes);

                if (ds_diahabilmes.Tables[0].Rows.Count == 0)
                {

                }else{

                    foreach (DataRow dataRow in ds_diahabilmes.Tables[0].Rows)
                    {
                        string str_diatemporal = Convert.ToString(Convert.ToString(dataRow["dia"]));

                        if (str_diatemporal.Equals(formatoDia(str_dia)))
                        {
                            str_dia_ultimo_vigente = Convert.ToString(Convert.ToString(dataRow["dia"]));
                        }
                    }

                     
                 }

                if (!string.IsNullOrEmpty(str_dia_ultimo_vigente))
                {
                    // date = Convert.ToDateTime("19-11-2011");
                    // str_fecha_ultimo_dia = Convert.ToString(FechaHabil(date, str_cod_cli));
                    str_fecha_ultimo_dia = formatoDia(str_dia_ultimo_vigente) + "-" + str_mes + "-" + str_ano;

                    //llamar rutina para obtencion de datos de bd

                    ds_diahabil = ObjPagoAuto.BuscarUltimoDiasHabil(str_fecha_ultimo_dia);
                }
                else {
                    ds_diahabil = null;
                }

                if (ds_diahabil == null || ds_diahabil.Tables[0].Rows.Count == 0)
                {
                     str_fecha = "";
                     str_corte = "";
                }else{
                     str_fecha = ds_diahabil.Tables[0].Rows[0]["fecha"].ToString();
                     str_corte = ds_diahabil.Tables[0].Rows[0]["corte"].ToString();
                }

                //verifica si fecha ultimo dia viene vacia desde BD
                //if (str_fecha == "" || string.IsNullOrEmpty(str_fecha))
                //{
                //    disponibilidadWS = false;

                //}else {

                if (str_fecha_actual == str_fecha)
                    {
                        if (Convert.ToDateTime(str_hora).Hour >= Convert.ToDateTime(str_corte).Hour)
                        {
                            disponibilidadWS = false;
                        }else{
                            disponibilidadWS = true;
                        }
                    }else{

                        disponibilidadWS = true;
                    }
                //}
 
            }
            catch (Exception ex)
            {
                 disponibilidadWS = false;
                 objParam.GrabarErrores(FechaSis.Date, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                 ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                 ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/MDL_funciones/DisponibilidadWSFinDeMes");
            }
            return disponibilidadWS;
        }

        public string formatoDia(string dia)
        {
            string str_diaformat="";
                        if (dia.Length > 1)
                        {
                            str_diaformat = dia;
                        }else
                        {
                            str_diaformat = "0" + dia;
            
                        }
                return str_diaformat;
        
        }
        public void GrabaErrores(Exception ex, string str_mensajeInicial)
        {

            throw new Exception(str_mensajeInicial + Environment.NewLine + ex.Message, ex);
        }

        public static DateTime FechaHabil(DateTime dat_fecha, string str_cod_cli)
        {
            DateTime fecha_aux = new DateTime();

            try
            {
                //Util objutil = new Util();
                BANED.NET.Util objutils = new BANED.NET.Util();

                switch (str_cod_cli)
                {
                    case "701":
                        fecha_aux = objutils.diaHabil(dat_fecha, BANED.NET.Enumeraciones.EnumClienteDiaHabil.BancoChile, BANED.NET.Enumeraciones.EnumOperacionDiaHabil.DiaHabilSiguiente);
                        break;
                    case "002":
                        fecha_aux = objutils.diaHabil(dat_fecha, BANED.NET.Enumeraciones.EnumClienteDiaHabil.CrediChile, BANED.NET.Enumeraciones.EnumOperacionDiaHabil.DiaHabilSiguiente);
                        break;
                    default:
                        fecha_aux = objutils.diaHabil(dat_fecha, BANED.NET.Enumeraciones.EnumClienteDiaHabil.Otros, BANED.NET.Enumeraciones.EnumOperacionDiaHabil.DiaHabilSiguiente);
                        break;
                }
            }
            catch (Exception e) 
            { 
                Console.WriteLine("Error :" + e.Message); 
            }
            return fecha_aux;
        }

        public  int Busca_Correlativo()
        {
            DataSet ds_corr = new DataSet();
            string str_correlat = null;
            Int32 int_correlat = default(Int32);
            bool bol_corrvalido = false;

            CajaNG objCajaNG = new CajaNG();

            int_correlat = 0;
            str_correlat = "";
            bol_corrvalido = false;

            //Busca correlativo en tab_corr

            try
            {
                str_correlat = objCajaNG.genCorrelSuc();

                if (!str_correlat.Equals(""))
                {
                    int_correlat = Parse.ToInt32(str_correlat);
                }

                //str_correlat = Convert.ToString(int_correlat).PadLeft(8, "0");
                bol_corrvalido = true;

                //Fin
                //Cambio_A_BANED_32

            }
            catch (Exception ex)
            {
                //Program.frmError(ex);
            }



            //Inserta en corrfin
            if (bol_corrvalido == true)
            {
                try
                {

                    objCajaNG.insertaCajaCorrelativo(str_correlat);

                }
                catch (Exception ex)
                {
                    //Program.frmError(ex);
                }
            }
            int_correlat = Convert.ToInt32(str_correlat);

            //Fin
            //Cambio_A_BANED_33

            return int_correlat;

        }

        public  void MarcaIngresoReaj(string strcodcli, string strrut, int descinte, string strfechapago, int stfolio)
        {
                DateTime fechaerror = new DateTime();
               
                DataSet ds_fechas_ser = new DataSet();
                ParamsDates Objfechas = new ParamsDates();

                ds_fechas_ser = Objfechas.getFechasServidor();
                fechaerror = Convert.ToDateTime(ds_fechas_ser.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                CuentaCorrienteNG objBanedCC = new CuentaCorrienteNG();
              
                int nSaldoDisp = 0;
                int inserta = 0;
                int actualiza = 0;
                int saldoFin = 0;
                string fechapag = strfechapago.Substring(6, 2) + "-" + strfechapago.Substring(4, 2) + "-" + strfechapago.Substring(0, 4);

                //ctg
                nSaldoDisp = objBanedCC.SaldoDisponibleReajuste(strrut, strcodcli, "LIQUIDA");

                saldoFin = nSaldoDisp - descinte;

                //ctg
                string str_tipoTransaccion = "GIRO POR REAJUSTE";
               
                inserta = objBanedCC.InsertaTBSDMDistribucionReajusteTransacciones(strcodcli, strrut, str_tipoTransaccion, 0, 0, descinte, 0, saldoFin, fechapag.ToString(), stfolio.ToString(), ParametrosPagoAutoData.P_str_codigo_moduloServicio);
                actualiza = objBanedCC.ActualizaTBSDMDistribucionReajInteresAcumulado(strcodcli, strrut, saldoFin);
                actualiza = objBanedCC.ActualizaTBSDMDistribucionLiquida(strcodcli.ToString(), strrut.ToString(), "CANCELADO POR WS PAGO AUTOMATICO", stfolio.ToString(), fechapag.ToString(), ParametrosPagoAutoData.P_str_codigo_moduloServicio);

            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(fechaerror, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/MDL_funciones/MarcaIngresoReaj");
            }
        }
    }
}