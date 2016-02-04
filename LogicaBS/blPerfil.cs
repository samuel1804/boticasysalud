using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using AccesoDatosBS;

namespace LogicaBS
{
    public class blPerfil
    {
        public List<bePerfil> selectPerfil()
        {
            var action = new daPerfil();
            return action.selectPerfil();
        }
    }
}
