using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBS.DTO
{
    public class AlternativaAutoevaluacionDTO
    {
        public int Cod_resp_autoevaluacion { get; set; }
        public string Respuesta { get; set; }
        public Nullable<int> Puntaje { get; set; }
        public Nullable<System.DateTime> Fec_creacion { get; set; }
        public string Cod_usu_regi { get; set; }
        public Nullable<System.DateTime> Fec_usu_regi { get; set; }
        public string Cod_usu_modi { get; set; }
        public Nullable<System.DateTime> Fec_usu_modi { get; set; }
        public Nullable<int> Cod_criterio { get; set; }
        public string Desc_criterio { get; set; }

        public int cod_operacion { get; set; }
    }
}