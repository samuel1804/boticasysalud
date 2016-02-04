using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBS
{
    public class beEmpleado
    {
        public int intCod_empleado { get; set; }
        public string strNom_empleado { get; set; }
        public string strAp_paterno { get; set; }
        public string strAp_materno { get; set; }
        public string strNomCompleto { get; set; }
        public string strEvaluado { get; set; }
        public int intCod_perfil { get; set; }
        public string strDesc_perfil { get; set; }
        public int intCod_area { get; set; }
        public string strDesc_Area { get; set; }
        public int intCod_Jefe { get; set; }
        public int intCod_puesto { get; set; }
        public string strNom_puesto { get; set; }
        public int intPuntaje { get; set; }
    }
}
