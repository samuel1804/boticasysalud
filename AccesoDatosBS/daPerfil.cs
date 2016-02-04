using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesBS;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AccesoDatosBS
{
    public class daPerfil
    {
        string strConBS;

        public daPerfil()
        {
            strConBS = ConfigurationManager.ConnectionStrings["conexionBS"].ConnectionString;
        }

        public List<bePerfil> selectPerfil()
        {
            bePerfil obePerfil = null;
            var lstPerfil = new List<bePerfil>();
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine("select Cod_perfil, Desc_perfil");
                strSQL.AppendLine("from RRH_Perfil");
                strSQL.AppendLine("where Estado = 1");
                strSQL.AppendLine("order by Desc_perfil");

                using (SqlCommand cmd = new SqlCommand(strSQL.ToString(), sqlCon))
                using (SqlDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                    {
                        obePerfil = new bePerfil();
                        obePerfil.intCod_perfil = (int)dr["Cod_perfil"];
                        obePerfil.strDesc_perfil = dr["Desc_perfil"].ToString().Trim();
                        lstPerfil.Add(obePerfil);
                    }
            }
            return lstPerfil;
        }
    }
}
