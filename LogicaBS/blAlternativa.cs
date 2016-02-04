using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using AccesoDatosBS;

namespace LogicaBS
{
    public class blAlternativa
    {
        public List<beAlternativa> selectAlternativa()
        {
            var action = new daAlternativa();
            return action.selectAlternativa();
        }
    }
}
