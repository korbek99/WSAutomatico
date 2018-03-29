using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BaseDatos;
using System.Configuration;
using BANED.NET.Negocio;


namespace wsPagoAutomaticoCajaNew.DataAccess
{
    public class PagoAutomatico
    {
        // public Util ObjUtil = new Util();
        public ParamsErrores objParam = new ParamsErrores();
        public ParamsDates objDate = new ParamsDates();
        public DateTime FechaServidor;
        public DataSet Dst_fechaservi;

        public DataSet BuscarTodosUltimosDiasHabiles()
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            //  ConexionBD dbm = new ConexionBD();

            Dst_fechaservi = objDate.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {

                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Get_tb_pa_ultimos_dias_habiles");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarTodosUltimosDiasHabiles");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarTodosUltimosDiasHabiles");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;

        }
        public DataSet BuscarUltimoDiasHabil(string fecha)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            ParamsDates objDat = new ParamsDates();
            Dst_fechaservi = objDat.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Busca_tb_pa_ultimos_dias_habiles");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 20).Value = fecha;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarUltimoDiasHabil");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarUltimoDiasHabil");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;

        }
        public DataSet BuscarDiasHabilporMes(string mes)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            //ConexionBD dbm = new ConexionBD();
            ParamsDates objDates = new ParamsDates();
            Dst_fechaservi = objDates.getFechasServidor();

            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Busca_tb_pa_ultimos_dias_habiles_por_mes");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mes", SqlDbType.VarChar, 20).Value = mes;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;

            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarDiasHabilporMes");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/BuscarDiasHabilporMes");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;


        }

        public DataSet ObtieneMovDiaPorParametros(string rutcliente, string demandante, string pendientepago)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            // ConexionBD dbm = new ConexionBD();
            ParamsDates objData = new ParamsDates();
            Dst_fechaservi = objData.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Buscar_movdia_por_parametros");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rut_deu", SqlDbType.VarChar, 10).Value = rutcliente;
                cmd.Parameters.Add("@cod_cli", SqlDbType.VarChar, 20).Value = demandante;
                cmd.Parameters.Add("@esta_liq", SqlDbType.VarChar, 20).Value = pendientepago;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;

            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneMovDiaPorParametros");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneMovDiaPorParametros");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;


        }

        public DataSet ObtieneMovDiaPorParametrosTab_nexo_data(string rutcliente, string demandante, string pendientepago, string correlat)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            // ConexionBD dbm = new ConexionBD();
            ParamsDates objData = new ParamsDates();
            Dst_fechaservi = objData.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Buscar_movdia_para_tab_nexo");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rut_deu", SqlDbType.VarChar, 10).Value = rutcliente;
                cmd.Parameters.Add("@cod_cli", SqlDbType.VarChar, 3).Value = demandante;
                cmd.Parameters.Add("@esta_liq", SqlDbType.VarChar, 1).Value = pendientepago;
                cmd.Parameters.Add("@correlat", SqlDbType.VarChar, 8).Value = correlat;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;

            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneMovDiaPorParametrosTab_nexo_data");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneMovDiaPorParametrosTab_nexo_data");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;


        }
        public DataSet ObtieneTab_prov_Por_Parametros(string rutcliente, string demandante, string estadoprov, string claseprov)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            ParamsDates objDatas = new ParamsDates();
            Dst_fechaservi = objDatas.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Buscar_Tab_prov_por_parametros");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rut_deu", SqlDbType.VarChar, 10).Value = rutcliente;
                cmd.Parameters.Add("@cod_cli", SqlDbType.VarChar, 20).Value = demandante;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoprov;
                cmd.Parameters.Add("@clase", SqlDbType.VarChar, 20).Value = claseprov;

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);

                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneTab_prov_Por_Parametros");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneTab_prov_Por_Parametros");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;
        }

        public DataSet ObtieneTab_prov_Por_Parametros_tab_nexo_data(string rutcliente, string demandante, string estadoprov, string claseprov, string correlat)
        {
            SqlConnection con = new SqlConnection();
            DataSet ds = new DataSet();
            ParamsDates objDatas = new ParamsDates();
            Dst_fechaservi = objDatas.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());

            try
            {
                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Buscar_tab_prov_para_tab_nexo");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@rut_deu", SqlDbType.VarChar, 10).Value = rutcliente;
                cmd.Parameters.Add("@cod_cli", SqlDbType.VarChar, 3).Value = demandante;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 1).Value = estadoprov;
                cmd.Parameters.Add("@clase", SqlDbType.VarChar, 2).Value = claseprov;
                cmd.Parameters.Add("@correlat", SqlDbType.VarChar, 8).Value = correlat;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);

                ad.Fill(ds);
                cmd.Connection.Close();
                return ds;
            }
            catch (SqlException e)
            {

                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                    ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneTab_prov_Por_Parametros_tab_nexo_data");

                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                   ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/ObtieneTab_prov_Por_Parametros_tab_nexo_data");

                Console.WriteLine("Error :" + e.Message);

            }
            return null;
        }
        public Boolean ActualizarPagoAutomaticoMov(string rutcliente,
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
                  string folioNd
                  )
        {


            Boolean res = false;
            Dst_fechaservi = objDate.getFechasServidor();
            FechaServidor = Convert.ToDateTime(Dst_fechaservi.Tables[0].Rows[0]["fechahoramin"].ToString());
            string str_mensaje;
            try
            {

                ExecuteBD DbfUser = new ExecuteBD();
                string StrOperaciones = DbfUser.AbrirConexion(NombreConexion.Operaciones);
                SqlCommand cmd = new SqlCommand("SP_Pa_Procesa_PagoAutomatico");

                cmd.Parameters.Add("@rutcliente", SqlDbType.VarChar, 10).Value = rutcliente;
                cmd.Parameters.Add("@demandante", SqlDbType.VarChar, 3).Value = demandante;
                cmd.Parameters.Add("@correlat", SqlDbType.VarChar, 8).Value = correlat;
                cmd.Parameters.Add("@cod_cajero", SqlDbType.VarChar, 4).Value = cod_cajero;
                cmd.Parameters.Add("@fecha_pago", SqlDbType.Date).Value = fecha_pago;
                cmd.Parameters.Add("@esta_liqui", SqlDbType.VarChar, 1).Value = esta_liqui;
                cmd.Parameters.Add("@num_caja", SqlDbType.VarChar, 2).Value = num_caja;
                cmd.Parameters.Add("@tip_pag", SqlDbType.VarChar, 2).Value = tip_pag;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 1).Value = estado;
                cmd.Parameters.Add("@tip_mov", SqlDbType.VarChar, 1).Value = tip_mov;
                cmd.Parameters.Add("@tip_liq", SqlDbType.VarChar, 2).Value = tip_liq;
                cmd.Parameters.Add("@tip_pag_tos", SqlDbType.VarChar, 2).Value = tip_pag_tos;
                cmd.Parameters.Add("@cod_cli", SqlDbType.VarChar, 3).Value = cod_cli;
                cmd.Parameters.Add("@mto_oper", SqlDbType.Decimal).Value = mto_oper;
                cmd.Parameters.Add("@fec_oper", SqlDbType.Date).Value = fec_oper;
                cmd.Parameters.Add("@hor_oper", SqlDbType.VarChar, 8).Value = hor_oper;
                cmd.Parameters.Add("@fec_dia", SqlDbType.Date).Value = fec_dia;
                cmd.Parameters.Add("@cod_suc", SqlDbType.VarChar, 3).Value = cod_suc;
                cmd.Parameters.Add("@login_user", SqlDbType.VarChar, 10).Value = login_user;
                cmd.Parameters.Add("@folioNd", SqlDbType.VarChar, 7).Value = folioNd;
                cmd.Parameters.Add("@MensajeError", SqlDbType.VarChar, 200);
                cmd.Parameters["@MensajeError"].Direction = ParameterDirection.Output;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Connection = new SqlConnection(StrOperaciones);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                res = true;

                str_mensaje = cmd.Parameters["@MensajeError"].Value.ToString();

                if (str_mensaje != "" && str_mensaje != null)
                {
                    objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SQL" + SubMid(str_mensaje), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions, "/ActualizarPagoAutomaticoMov");
                    res = false;
                }
                cmd.Connection.Close();
            }
            catch (SqlException e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + e.Message.ToString(), false,
                    ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions, "/ActualizarPagoAutomaticoMov");
                res = false;
                Console.WriteLine("Error de SQL :" + e.Message);
            }
            catch (Exception e)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error Exception : " + e.Message.ToString(), false,
                   ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions, "/ActualizarPagoAutomaticoMov");
                res = false;
                Console.WriteLine("Error :" + e.Message);

            }
            return res;
        }

        public Boolean ActualizacionMOVDIA_DBF_DAL(string rutDeudor, string demandante,string codSucursal, string codCajero, string tipoPago, string numOpe,
                                             string numCuota, string banco, string numDocumento, string plaza, double mtoDoc, double correlativo,
                                             string folio, DateTime fechaPago, string hora, string esta_liqui, string num_caja)
        {
            bool transacction = false;
            double filasAfectadas = 0;
            ExecuteBD conn = new ExecuteBD();
            DateTime fechaAux = new DateTime(1899, 12, 30);
            string Tabla = "MOVDIA.DBF";

            try
            {
                string Sql = "UPDATE " + Tabla +
                              " SET fec_pag = " + ((fechaPago.Equals(fechaAux)) ? "{  /  /    }" : "DATE(" + fechaPago.Year.ToString() + "," + fechaPago.Month.ToString() + "," + fechaPago.Day.ToString() + ")") +
                              ", hora_pago = '" + hora +
                              "', cod_cajero = '" + codCajero +
                              "', esta_liq = '" + esta_liqui +
                              "', tip_pag = '" + tipoPago +
                              "', correlat = '" + correlativo +
                              "', num_caj = '" + num_caja +
                         "' WHERE rut_deu = '" + rutDeudor +
                         "' AND cod_cli = '" + demandante + 
                         "' AND esta_liq = 'P'";

                filasAfectadas = Convert.ToInt32(conn.ExecuteNonQueryFox(Sql, conn.RutaTabla(Tabla, "LQMOVDIA")));

                if (filasAfectadas > 0)
                {
                    transacction = true;
                }
            }

            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/DataAccess/ActualizacionMOVDIA_DBF_DAL");
                transacction = false;
            }

            return transacction;

        }

        public Boolean ActualizacionTab_Prov_DBF_DAL(string rutcliente, string demandante, string correlat, string cod_cajero, DateTime fec_caja, string estado, string hor_caja, DateTime fechaPago)
        {
            bool transacction = false;
            ExecuteBD conn = new ExecuteBD();
            DateTime fechaAux = new DateTime(1899, 12, 30);
            int filasAfectadas = 0;
            string Tabla = "TAB_PROV.DBF";
            try
            {
                string query = " update " + Tabla +
                           " set fec_caja  =" + ((fechaPago.Equals(fechaAux)) ? "{  /  /    }" : "DATE(" + fechaPago.Year.ToString() + "," + fechaPago.Month.ToString() + "," + fechaPago.Day.ToString() + ")") +
                           ", correlat='" + correlat + "'" +
                           ", hor_caja='" + hor_caja + "'" +
                           ", cod_cajero='" + cod_cajero + "'" +
                           ", estado= '" + estado + "'" +
                           "  where Rut_Deu= '" + rutcliente + "'" +
                           "  and cod_cli='" + demandante + "'" +
                           "  and clase='ND'" +
                           "  and estado='P'";

                           filasAfectadas = Convert.ToInt32(conn.ExecuteNonQueryFox(query, conn.RutaTabla(Tabla, "LQTAB_PROV")));

                           if (filasAfectadas > 0)
                           {
                               transacction = true;
                           }
                              
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/DataAccess/ActualizacionTab_Prov_DBF_DAL");
                transacction = false;
            }

            return transacction;

        }

        public Boolean InsertarMovTos_DBF_DAL(string correlat,string rutDeudor,string codCajero,string tipoMov,string tip_liq   
							,string tip_pag_tos ,string cod_cli  ,double mto_oper ,DateTime fec_oper ,string hor_oper ,DateTime fec_dia , string cod_suc)
        {
            bool transacction = false;
            ExecuteBD conn = new ExecuteBD();
            DateTime fechaAux = new DateTime(1899, 12, 30);
            string Tabla = "MOVTOS.DBF";
            int filasAfectadas = 0;
            string num_doc = "";
            string banco = "";
            string plaza = "";
            string cod_tran = "";
            string anombrede = "";
            string estado = "";
            string cam_est = "";
            string suc_reneg  = "";
            string fol_reneg  = "";
            string  cod_eje  = "";
            string num_caj = "";
            int cod_folio = 0;
            int num_com = 0;
            int  mtocap = 0;
            int  mtohon = 0;
            string rutgirad = "";
            string nomgirad = "";
            string sub_tipmov = "";
            string ambito = "";
            string folmul = "";

            try
            {
                string Sql = "INSERT INTO " + Tabla +
                              @"(correlat
                               ,rut_deu
                               ,cod_cajero
                               ,tip_mov
                               ,tip_liq
                               ,tip_pag
                               ,cod_cli
                               ,mto_oper
                               ,num_doc
                               ,banco
                               ,fec_oper
                               ,hor_oper
                               ,fec_dia
                               ,cod_suc
                               ,plaza
                               ,cod_tran
                               ,anombrede
                               ,estado
                               ,fec_lib
                               ,cam_est
                               ,fec_recep
                               ,fec_reneg
                               ,suc_reneg
                               ,fol_reneg
                               ,cod_eje
                               ,num_caj
                               ,cod_folio
                               ,num_com
                               ,ven_doc
                               ,mtocap
                               ,mtohon
                               ,rutgirad
                               ,nomgirad
                               ,sub_tipmov
                               ,ambito
                               ,folmul)
                         VALUES
                               ('" + correlat +
                               "','" + rutDeudor +
                               "','" + codCajero +
                               "','" + tipoMov +
                               "','" + tip_liq +
                               "','" + tip_pag_tos +
                               "','" + cod_cli +
                               "'," + mto_oper +
                               ",'" + num_doc +
                               "','" + banco +
                               "'," + ((fec_oper.Equals(fechaAux)) ? "{  /  /    }" : "DATE(" + fec_oper.Year.ToString() + "," + fec_oper.Month.ToString() + "," + fec_oper.Day.ToString() + ")") +
                               ",'" + hor_oper +
                               "'," + ((fec_dia.Equals(fechaAux)) ? "{  /  /    }" : "DATE(" + fec_dia.Year.ToString() + "," + fec_dia.Month.ToString() + "," + fec_dia.Day.ToString() + ")") +
                               ",'" + cod_suc +
                               "','" + plaza +
                               "','" + cod_tran +
                               "','" + anombrede +
                               "','" + estado +
                               "',{  /  /    }" +
                               ",'" + cam_est +
                               "',{  /  /    }" +
                               ",{  /  /    }" +
                               ",'" + suc_reneg +
                               "','" + fol_reneg +
                               "','" + cod_eje +
                               "','" + num_caj +
                               "'," + cod_folio +
                               "," + num_com +
                               ",{  /  /    }" +
                               "," + mtocap +
                               "," + mtohon +
                               ",'" + rutgirad +
                               "','" + nomgirad +
                               "','" + sub_tipmov +
                               "','" + ambito +
                               "','" + folmul + "')";

                filasAfectadas = Convert.ToInt32(conn.ExecuteNonQueryFox(Sql, conn.RutaTabla(Tabla, "CJMOVTOS")));
                if (filasAfectadas > 0)
                {
                    transacction = true;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/DataAccess/InsertarMovTos_DBF_DAL");
                transacction = false;
            }

            return transacction;

        }

        public Boolean InsertTabNexo_DBF_DAL(string correlat, string folioLi, string folioNc, string folioNd, string folioRe, string cdEstado, string codSuc)
        {
            bool transacction = false;
            ExecuteBD conn = new ExecuteBD();
            int filasAfectadas = -1;
            string Tabla = "TAB_NEXO.DBF";
            try
            {
            string Sql = "INSERT INTO " + Tabla +
                        @" (correlat,folio_li,folio_nc,folio_nd,folio_re,cdestado,cod_suc)
                        VALUES ('" + correlat +
                                "','" + folioLi +
                                "','" + folioNc +
                                "','" + folioNd +
                                "','" + folioRe +
                                "','" + cdEstado +
                                "','" + codSuc + "')";

            filasAfectadas = Convert.ToInt32(conn.ExecuteNonQueryFox(Sql, conn.RutaTabla(Tabla, "CJTABNEXO")));

                if (filasAfectadas > 0)
                {
                    transacction = true;
                }
            }
            catch (Exception ex)
            {
                objParam.GrabarErrores(FechaServidor, Environment.MachineName, Environment.MachineName, ParametrosPagoAutoData.P_int_codigo_modulo, "Error SqlException : " + ex.ToString(), false,
                  ParametrosPagoAutoData.P_int_codigo_error_Sql_exceptions,
                  ParametrosPagoAutoData.P_str_codigo_moduloServicio + "/DataAccess/InsertTabNexo");
                transacction = false;
            }
            return transacction;
        }

        //Otras Funciones //

        public string SubMid(string s)
        {
            int a = 0;
            int b = 0;

            if (s.Length > 1000)
            {
                b = 999;
            }
            else
            {
                b = s.Length;

            }
            string temp = s.Substring(a - 1, b);

            return temp;
        }

    }
}