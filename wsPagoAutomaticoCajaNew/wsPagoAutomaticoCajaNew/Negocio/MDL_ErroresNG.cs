using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wsPagoAutomaticoCajaNew.DataAccess;
using System.Data.SqlClient;
using System.Data;
namespace wsPagoAutomaticoCajaNew.Negocio
{
    public class MDL_ErroresNG
    {
        public void GrabarErroresNG(DateTime fecha, string machineName,
           string userName, int idSistema,
           string mensaje, bool resuelto,
           int numeroError, string modulo)
        {
            try
            {
                ParamsErrores ObjErr = new ParamsErrores();
                ObjErr.GrabarErrores(fecha, machineName, userName, idSistema, mensaje, resuelto, numeroError, modulo);
            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }
           
        }

        //public  DataSet ListaOcurrenciasPagoAutomaticoNG(int idsistema)
        //{
        //    DataSet DtsOcurrenciasNG = new DataSet();
        //    ParamsDates objDatas = new ParamsDates();
        //    DataSet Dst_fechaservi;
        //    DateTime FechaServidor;
        //    Dst_fechaservi = objDatas.getFechasServidor();
        //    FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

        //    try
        //    {
        //        ParamsErrores ObjErr = new ParamsErrores();
        //        DtsOcurrenciasNG = ObjErr.ListaOcurrenciasPagoAutomaticoData(idsistema);

        //    }
        //    catch (Exception ex)
        //    {
        //          ParamsErrores ObjErr = new ParamsErrores();
        //          ObjErr.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
        //          ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
        //          ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/ListaOcurrenciasPagoAutomaticoNG");
               
        //    }
        //    return DtsOcurrenciasNG;
        //}
    }
}