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
    public class ParamsDates
    {
        public DataSet getFechasServidor()
        {
            string testFileConfig = ConfigurationManager.AppSettings["FileConfig"];

            ParamsErrores objParam = new ParamsErrores();
            DateTime Fechanow = new DateTime();
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            //ConexionBD dbm = new ConexionBD();
            try
            {
                //con = dbm.getConexion();
                //con.Open();
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_getFechasServidor");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error de SQL :" + e.Message);

                objParam.GrabarErrores(Fechanow, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.Message.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   "DataAccess/ParamsDates" + "/getFechasServidor");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);

                objParam.GrabarErrores(Fechanow, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.Message.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   "DataAccess/ParamsDates" + "/getFechasServidor");
            }
            return null;
        }
    }
}