using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using AccesoDatosBS;

namespace LogicaBS
{
    public class blCriterio
    {
        daCriterio action = new daCriterio();

        public List<beCriterio> select()
        {
            return action.select();
        }

        public int insert(beCriterio obj)
        {
            return action.insert(obj);
        }
    }
}
