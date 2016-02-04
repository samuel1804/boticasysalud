using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using System.Data.SqlClient;

namespace AccesoDatosBS
{
    public class daAlternativa
    {
        string strConBS;

        public daAlternativa()
        {
            strConBS = ConfigurationManager.ConnectionStrings["conexionBS"].ConnectionString;
        }

        public List<beAlternativa> selectAlternativa()
        {
            beAlternativa obeAlternativa = null;
            var lstAlternativa = new List<beAlternativa>();
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine("select Cod_alternativa_evaluaciontec, Desc_Alternatica, Puntaje");
                strSQL.AppendLine("from RRH_AlternativaEvaluacionTecnica");
                strSQL.AppendLine("order by Desc_Alternatica");

                using (SqlCommand cmd = new SqlCommand(strSQL.ToString(), sqlCon))
                using (SqlDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                    {
                        obeAlternativa = new beAlternativa();
                        obeAlternativa.intCod_alternativa_evaluaciontec = (int)dr["Cod_alternativa_evaluaciontec"];
                        obeAlternativa.strDesc_Alternatica = dr["Desc_Alternatica"].ToString().Trim() + " (" + dr["Puntaje"].ToString() + ")";
                        lstAlternativa.Add(obeAlternativa);
                    }
            }
            return lstAlternativa;
        }
    }
}
