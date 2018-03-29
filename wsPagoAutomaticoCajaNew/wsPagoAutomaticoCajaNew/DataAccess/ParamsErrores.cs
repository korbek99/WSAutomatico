using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BaseDatos;
using System.Configuration;

namespace wsPagoAutomaticoCajaNew.DataAccess
{
    public class ParamsErrores
    {
        public void GrabarErrores(DateTime fecha, string machineName,
          string userName, int idSistema,
          string mensaje, bool resuelto,
          int numeroError, string modulo)
        {
            try
            {
                ParamsDates objDatas = new ParamsDates();
                DataSet Dst_fechaservi;
                DateTime FechaServidor;
                Dst_fechaservi = objDatas.getFechasServidor();
                FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());


                ExecuteBD DbfUser = new ExecuteBD();
                SqlParameter parametros;
                string StrParametros = DbfUser.AbrirConexion(NombreConexion.Parametros);
                SqlCommand cmd = new SqlCommand("SP_pa_insert_errores_pago_Automatico");

                parametros = cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                parametros.Value = FechaServidor; // Convert.ToDateTime(fecha);
                parametros = cmd.Parameters.Add("@machineName", SqlDbType.VarChar);
                parametros.Value = machineName;
                parametros = cmd.Parameters.Add("@userName", SqlDbType.VarChar);
                parametros.Value = userName;
                parametros = cmd.Parameters.Add("@idSistema", SqlDbType.Int);
                parametros.Value = ParametrosPagoAutoData.P_int_codigo_modulo;
                parametros = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar);
                parametros.Value = SubMid(mensaje);
                parametros = cmd.Parameters.Add("@resuelto", SqlDbType.Bit);
                parametros.Value = resuelto;
                parametros = cmd.Parameters.Add("@numeroError", SqlDbType.Int);
                parametros.Value = numeroError;
                parametros = cmd.Parameters.Add("@modulo", SqlDbType.VarChar);
                parametros.Value = modulo;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrParametros);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
            catch (SqlException e) { Console.WriteLine("Error de SQL :" + e.Message); }
            catch (Exception e) { Console.WriteLine("Error :" + e.Message); }


        }
        //public DataSet ListaOcurrenciasPagoAutomaticoData(int idsistema)
        //{
        //    DataSet DtsOcurrenciasData = new DataSet();
        //    ParamsDates objDatas = new ParamsDates();
        //    DataSet Dst_fechaservi;
        //    DateTime FechaServidor;
        //    Dst_fechaservi = objDatas.getFechasServidor();
        //    FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

        //    try
        //    {
        //         ExecuteBD DbfUser = new ExecuteBD();
        //         string StrParametros = DbfUser.AbrirConexion(NombreConexion.Parametros);
        //        SqlCommand cmd = new SqlCommand("SP_Pa_lista_errores_idsistema");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@IdSistema", SqlDbType.Int).Value = idsistema;
        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        cmd.Connection = new SqlConnection(StrParametros);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection.Open(); ;
        //        adapter.Fill(DtsOcurrenciasData);
        //        cmd.Connection.Close();

        //        return DtsOcurrenciasData;
                

        //    }
        //    catch (Exception ex)
        //    {
        //        ParamsErrores ObjErr = new ParamsErrores();
        //        ObjErr.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
        //        ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
        //        ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/Negocio/ListaOcurrenciasPagoAutomaticoData");

        //    }
        //    return DtsOcurrenciasData;
        //}

        public string SubMid(string s)
        {
            int largo = s.Length;
            int a = 0;
            int b = 0;

            if (largo > 1000)
            {
                b = 999;
            }
            else
            {
                b = largo;
            }

            string temp = s.Substring(a, b);

            return temp;
        }
    }
}