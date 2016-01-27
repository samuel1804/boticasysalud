using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBS.Implement
{
    public sealed class DatosConstantes
    {
        public sealed class EstadoSolicitud
        {
            public const string Pendiente = "P";
            public const string Aprobado = "A";
            public const string Rechazado = "R";
        }

        public sealed class EstadoActividadPlanificada
        {
            public const string Pendiente = "P";
            public const string Proceso = "E";
            public const string Cerrado = "C";
        }

        public enum Prioridad
        {
            Alta = 1,
            Media = 2,
            Baja = 3
        }
    }
}