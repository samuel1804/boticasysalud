using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBS.Implement
{
    public sealed class TablaDefinicion
    {

        public static List<CodigoValor> EstadoSolicitud
        {
            get
            {
                return new List<CodigoValor>
                {
                    new CodigoValor () { Codigo =DatosConstantes.EstadoSolicitud.Pendiente , Valor="Pendiente" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoSolicitud.Aprobado, Valor="Aprobado" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoSolicitud.Rechazado , Valor="Rechazado" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoSolicitud.Proceso , Valor="En Proceso" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoSolicitud.Proceso , Valor="Cerrado" }
                };
            }
        }

        public static List<CodigoValor> EstadoActividadPlanificada
        {
            get
            {
                return new List<CodigoValor>
                {
                    new CodigoValor () { Codigo =DatosConstantes.EstadoActividadPlanificada.Pendiente , Valor="Pendiente" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoActividadPlanificada.Proceso , Valor="En Proceso" },
                    new CodigoValor () { Codigo =DatosConstantes.EstadoActividadPlanificada.Cerrado , Valor="Cerrado" },
                };
            }
        }

        public static List<CodigoValor> Prioridad
        {
            get
            {
                return new List<CodigoValor>
                {
                    new CodigoValor () { Codigo =((int)DatosConstantes.Prioridad.Alta).ToString() , Valor="Alta" },
                    new CodigoValor () { Codigo =((int)DatosConstantes.Prioridad.Media).ToString(), Valor="Media" },
                    new CodigoValor () { Codigo =((int)DatosConstantes.Prioridad.Baja).ToString(), Valor="Baja" },
                };
            }
        }

        public static string ObtenerValor(object codigo, List<CodigoValor> fuente)
        {
            var resultado = fuente.Where(e => e.Codigo == codigo.ToString()).Select(a => a.Valor).FirstOrDefault();
            return resultado;
        }
    }
}
