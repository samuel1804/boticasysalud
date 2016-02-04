using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatosBS;
using EntidadesBS;

namespace LogicaBS
{
    public class blEmpleado
    {
        daEmpleado action = new daEmpleado();

        public beEmpleado getJefe()
        {
            return action.getJefe();
        }

        public List<beEmpleado> select(int intCod_Jefe, string strNomCompleto, string strNom_puesto)
        {
            return action.select(intCod_Jefe, strNomCompleto, strNom_puesto);
        }

        public beEmpleado get(int intCod_Empleado)
        {
            return action.get(intCod_Empleado);
        }
    }
}
