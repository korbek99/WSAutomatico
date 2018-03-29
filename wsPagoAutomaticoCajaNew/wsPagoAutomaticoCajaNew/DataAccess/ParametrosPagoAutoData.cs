using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace wsPagoAutomaticoCajaNew.DataAccess
{
    public class ParametrosPagoAutoData
    {
        public static string P_str_codigo_moduloServicio = "WS PagoAutomaticoCaja Net";
        public static int P_int_codigo_modulo = 109;
        public static int P_int_codigo_error_trans = -2; //"transacción no fue realizada";
        public static int P_int_codigo_error_Sql_exceptions = -1;  //"error Sql exceptions";
        public static int P_int_codigo_error_procedimiento_almace = -3; //" errores en procedimiento almacenado ";
    }
}