using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBS
{
    public class bePreguntaEvaluacionTecnica
    {
        public int intCod_preg_eva_tec { get; set; }
        public string strTitulo { get; set; }
        public string strPregunta { get; set; }
        public DateTime datFec_creacion { get; set; }
        public beCriterio obeCriterio { get; set; }
        public string strCod_usu_regi { get; set; }
        public DateTime datFec_usu_regi { get; set; }
        public beAlternativa obeAlternativa { get; set; }
        public bePerfil obePerfil { get; set; }
    }
}
