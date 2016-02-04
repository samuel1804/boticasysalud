using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using AccesoDatosBS;

namespace LogicaBS
{
    public class blPreguntaEvaluacionTecnica
    {
        daPreguntaEvaluacionTecnica action = new daPreguntaEvaluacionTecnica();

        public int mantenimiento(bePreguntaEvaluacionTecnica obj)
        {
            return action.mantenimiento(obj);
        }

        public bool delete(int intCod_preg_eva_tec)
        {
            return action.delete(intCod_preg_eva_tec);
        }

        public IEnumerable<bePreguntaEvaluacionTecnica> select(int startRowIndex,
                                                            int maximumRows,
                                                            string sidx,
                                                            string sord)
        {
            return action.select(startRowIndex, maximumRows, sidx, sord);
        }

        public List<bePreguntaEvaluacionTecnica> get(int intCod_perfil)
        {
            return action.get(intCod_perfil);
        }

        public int count()
        {
            return action.count();
        }

    }
}
