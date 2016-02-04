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
    public class daEmpleado
    {
        string strConBS;

        public daEmpleado()
        {
            strConBS = ConfigurationManager.ConnectionStrings["conexionBS"].ConnectionString;
        }

        public beEmpleado getJefe()
        {
            beEmpleado obeEmpleado = null;
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_Empleado_GetJefe]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            obeEmpleado = new beEmpleado();
                            obeEmpleado.intCod_empleado = (int)dr["Cod_empleado"];
                            obeEmpleado.strNom_empleado = dr["Nom_empleado"].ToString().Trim();
                            obeEmpleado.strAp_paterno = dr["Ap_paterno"].ToString().Trim();
                            obeEmpleado.strAp_materno = dr["Ap_materno"].ToString().Trim();
                            obeEmpleado.strNomCompleto = obeEmpleado.strNom_empleado + " " + obeEmpleado.strAp_paterno + " " + obeEmpleado.strAp_materno;
                            obeEmpleado.strDesc_Area = dr["Desc_Area"].ToString().Trim();
                        }
                }
            }
            return obeEmpleado;
        }

        public List<beEmpleado> select(int intCod_Jefe, string strNomCompleto, string strNom_puesto)
        {
            beEmpleado obeEmpleado = null;
            var lstEmpleado = new List<beEmpleado>();
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_Empleado_Select]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cod_Jefe", SqlDbType.Int).Value = intCod_Jefe;
                    cmd.Parameters.Add("@NomCompleto", SqlDbType.VarChar).Value = strNomCompleto;
                    cmd.Parameters.Add("@Nom_puesto", SqlDbType.VarChar).Value = strNom_puesto;
   
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            obeEmpleado = new beEmpleado();
                            obeEmpleado.intCod_empleado = (int)dr["Cod_empleado"];
                            obeEmpleado.strNom_empleado = dr["Nom_empleado"].ToString().Trim();
                            obeEmpleado.strAp_paterno = dr["Ap_paterno"].ToString().Trim();
                            obeEmpleado.strAp_materno = dr["Ap_materno"].ToString().Trim();
                            obeEmpleado.strNomCompleto = obeEmpleado.strNom_empleado + " " + obeEmpleado.strAp_paterno + " " + obeEmpleado.strAp_materno;
                            obeEmpleado.strNom_puesto = dr["Nom_puesto"].ToString().Trim();
                            obeEmpleado.strEvaluado = dr["Evaluado"].ToString().Trim();
                            obeEmpleado.intPuntaje = (int)dr["Puntaje"];
                            lstEmpleado.Add(obeEmpleado);
                        }
                }
            }
            return lstEmpleado;
        }

        public beEmpleado get(int intCod_Empleado)
        {
            beEmpleado obeEmpleado = null;
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_Empleado_Get]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cod_Empleado", SqlDbType.Int).Value = intCod_Empleado;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            obeEmpleado = new beEmpleado();
                            obeEmpleado.intCod_empleado = (int)dr["Cod_empleado"];
                            obeEmpleado.strNom_empleado = dr["Nom_empleado"].ToString().Trim();
                            obeEmpleado.strAp_paterno = dr["Ap_paterno"].ToString().Trim();
                            obeEmpleado.strAp_materno = dr["Ap_materno"].ToString().Trim();
                            obeEmpleado.strNomCompleto = obeEmpleado.strNom_empleado + " " + obeEmpleado.strAp_paterno + " " + obeEmpleado.strAp_materno;
                            obeEmpleado.strNom_puesto = dr["Nom_puesto"].ToString().Trim();
                            obeEmpleado.intCod_perfil = (int)dr["Cod_perfil"];
                            obeEmpleado.strDesc_perfil = dr["Desc_perfil"].ToString().Trim();
                            obeEmpleado.strDesc_Area = dr["Desc_Area"].ToString().Trim();
                        }
                }
            }
            return obeEmpleado;
        }

    }
}
