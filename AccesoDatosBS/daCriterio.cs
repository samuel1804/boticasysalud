using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatosBS
{
    public class daCriterio
    {
        string strConBS;

        public daCriterio()
        {
            strConBS = ConfigurationManager.ConnectionStrings["conexionBS"].ConnectionString;
        }

        public List<beCriterio> select()
        {
            beCriterio obeCriterio = null;
            var lstCriterio = new List<beCriterio>();
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine("select Cod_criterio, Desc_criterio");
                strSQL.AppendLine("from RRH_Criterio");
                strSQL.AppendLine("order by Desc_criterio");

                using (SqlCommand cmd = new SqlCommand(strSQL.ToString(), sqlCon))
                using (SqlDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                    {
                        obeCriterio = new beCriterio();
                        obeCriterio.intCod_criterio = (int)dr["Cod_criterio"];
                        obeCriterio.strDesc_criterio = dr["Desc_criterio"].ToString().Trim();
                        lstCriterio.Add(obeCriterio);
                    }
            }
            return lstCriterio;
        }

        public int insert(beCriterio obj)
        {
            int intCod_criterio = 0;
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_Criterio_Insert]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Desc_criterio", SqlDbType.VarChar).Value = obj.strDesc_criterio;
                    intCod_criterio = (int)cmd.ExecuteScalar();
                }
            }
            return intCod_criterio;
        }

    }
}
