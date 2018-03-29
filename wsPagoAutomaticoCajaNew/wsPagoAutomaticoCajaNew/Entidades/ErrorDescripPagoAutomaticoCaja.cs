using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wsPagoAutomaticoCajaNew.Entidades
{
    public class ErrorDescripPagoAutomaticoCaja
    {
        public static string ErrorDescripDisponibilidadWSmensaje = "Servicio  no disponible por fuera de horario para transacciones";
        public static string ErrorDescripDisponibilidad = "Error de operacion de validacion de disponibilidad servicio web";
        public static string ErrorDescripTransPagoAutomatico = "Error al realizar la operacion de pago automatico de caja";
    }
}