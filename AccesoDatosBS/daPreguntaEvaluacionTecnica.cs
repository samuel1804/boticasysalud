using EntidadesBS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosBS
{
    public class daPreguntaEvaluacionTecnica
    {
        string strConBS;

        public daPreguntaEvaluacionTecnica()
        {
            strConBS = ConfigurationManager.ConnectionStrings["conexionBS"].ConnectionString;
        }

        public int mantenimiento(bePreguntaEvaluacionTecnica obj)
        {
            int intCod_preg_eva_tec = 0;
            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand(
                obj.intCod_preg_eva_tec == 0 ? "[dbo].[RRH_PreguntaEvaluacionTecnica_Insert]" : "[dbo].[RRH_PreguntaEvaluacionTecnica_Update]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cod_preg_eva_tec", SqlDbType.Int).Value = obj.intCod_preg_eva_tec;
                    cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = obj.strTitulo;
                    cmd.Parameters.Add("@Pregunta", SqlDbType.VarChar).Value = obj.strPregunta.Trim();
                    cmd.Parameters.Add("@Fec_creacion", SqlDbType.Date).Value = obj.datFec_creacion;
                    cmd.Parameters.Add("@Cod_criterio", SqlDbType.Int).Value = obj.obeCriterio.intCod_criterio;
                    cmd.Parameters.Add("@Cod_usu_regi", SqlDbType.VarChar).Value = obj.strCod_usu_regi.Trim();
                    cmd.Parameters.Add("@Fec_usu_regi", SqlDbType.Date).Value = obj.datFec_usu_regi;
                    cmd.Parameters.Add("@Cod_alternativa_evaluaciontec", SqlDbType.Int).Value = obj.obeAlternativa.intCod_alternativa_evaluaciontec;
                    cmd.Parameters.Add("@Cod_perfil", SqlDbType.Int).Value = obj.obePerfil.intCod_perfil;
                    intCod_preg_eva_tec = (int)cmd.ExecuteScalar();
                }
            }
            return intCod_preg_eva_tec;
        }

        public bool delete(int intCod_preg_eva_tec)
        {
            int cantReg = 0;
            var strSQL = new StringBuilder();
            strSQL.AppendLine("DELETE");
            strSQL.AppendLine("FROM [dbo].[RRH_PreguntaEvaluacionTecnica]");
            strSQL.AppendLine("WHERE Cod_preg_eva_tec = " + intCod_preg_eva_tec.ToString());

            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand(strSQL.ToString(), sqlCon))
                    cantReg = cmd.ExecuteNonQuery();
            }
            return (cantReg != 0);
        }

        public IEnumerable<bePreguntaEvaluacionTecnica> select(int startRowIndex,
                                                               int maximumRows,
                                                               string sidx,
                                                               string sord)
        {
            var lstPreguntaEvaluacionTecnica = new List<bePreguntaEvaluacionTecnica>();
            bePreguntaEvaluacionTecnica obePreguntaEvaluacionTecnica;

            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();

                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_PreguntaEvaluacionTecnica_Select]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@startRowIndex", SqlDbType.Int).Value = startRowIndex;
                    cmd.Parameters.Add("@maximumRows", SqlDbType.Int).Value = maximumRows;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            obePreguntaEvaluacionTecnica = new bePreguntaEvaluacionTecnica();
                            obePreguntaEvaluacionTecnica.intCod_preg_eva_tec = (int)dr["Cod_preg_eva_tec"];

                            obePreguntaEvaluacionTecnica.obePerfil = new bePerfil();
                            obePreguntaEvaluacionTecnica.obePerfil.strDesc_perfil = dr["Desc_perfil"].ToString().Trim();
                            obePreguntaEvaluacionTecnica.obePerfil.intCod_perfil = (int)dr["Cod_perfil"];
                            
                            obePreguntaEvaluacionTecnica.obeCriterio = new beCriterio();
                            obePreguntaEvaluacionTecnica.obeCriterio.strDesc_criterio = dr["Desc_criterio"].ToString().Trim();
                            obePreguntaEvaluacionTecnica.obeCriterio.intCod_criterio = (int)dr["Cod_criterio"];

                            obePreguntaEvaluacionTecnica.strPregunta = dr["Pregunta"].ToString().Trim();

                            obePreguntaEvaluacionTecnica.obeAlternativa = new beAlternativa();
                            obePreguntaEvaluacionTecnica.obeAlternativa.strDesc_Alternatica = dr["Desc_Alternatica"].ToString().Trim();
                            obePreguntaEvaluacionTecnica.obeAlternativa.intCod_alternativa_evaluaciontec = (int)dr["Cod_alternativa_evaluaciontec"];

                            lstPreguntaEvaluacionTecnica.Add(obePreguntaEvaluacionTecnica);
                        }
                }
            }

            IEnumerable<bePreguntaEvaluacionTecnica> iePreguntaEvaluacionTecnica = lstPreguntaEvaluacionTecnica;
            //string[] orden = sidx.Split(',');
            //switch (orden[1].Trim())
            //{
            //    case "Codigo":
            //        if (sord == "desc")
            //            lstClienteGarantia = lstClienteGarantia.OrderBy(s => s.strGrupoCliente).ThenByDescending(s => s.strClienteId);
            //        else
            //            lstClienteGarantia = lstClienteGarantia.OrderBy(s => s.strGrupoCliente).ThenBy(s => s.strClienteId);
            //        break;

            //    case "Descripcion":
            //        if (sord == "desc")
            //            lstClienteGarantia = lstClienteGarantia.OrderBy(s => s.strGrupoCliente).ThenByDescending(s => s.strClienteDes);
            //        else
            //            lstClienteGarantia = lstClienteGarantia.OrderBy(s => s.strGrupoCliente).ThenBy(s => s.strClienteDes);
            //        break;

            //    default:
            //        break;
            //}
            return iePreguntaEvaluacionTecnica;
        }

        public int count()
        {
            int cantReg = 0;
            var strSQL = new StringBuilder();
            strSQL.AppendLine("SELECT COUNT(*)");
            strSQL.AppendLine("FROM [dbo].[RRH_PreguntaEvaluacionTecnica]");

            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand(strSQL.ToString(), sqlCon))
                    cantReg = (int)cmd.ExecuteScalar();
            }
            return cantReg;
        }

        public List<bePreguntaEvaluacionTecnica> get(int intCod_perfil)
        {
            var lstPreguntaEvaluacionTecnica = new List<bePreguntaEvaluacionTecnica>();
            bePreguntaEvaluacionTecnica obePreguntaEvaluacionTecnica;

            using (SqlConnection sqlCon = new SqlConnection(strConBS))
            {
                sqlCon.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].[RRH_PreguntaEvaluacionTecnica_get]", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cod_perfil", SqlDbType.Int).Value = intCod_perfil;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            obePreguntaEvaluacionTecnica = new bePreguntaEvaluacionTecnica();
                            obePreguntaEvaluacionTecnica.obeCriterio = new beCriterio();
                            obePreguntaEvaluacionTecnica.obeCriterio.intCod_criterio = (int)dr["Cod_criterio"];
                            obePreguntaEvaluacionTecnica.obeCriterio.strDesc_criterio = dr["Desc_criterio"].ToString().Trim();

                            obePreguntaEvaluacionTecnica.strPregunta = dr["Pregunta"].ToString().Trim();

                            obePreguntaEvaluacionTecnica.obeAlternativa = new beAlternativa();
                            obePreguntaEvaluacionTecnica.obeAlternativa.intCod_alternativa_evaluaciontec = (int)dr["Cod_alternativa_evaluaciontec"];
                            obePreguntaEvaluacionTecnica.obeAlternativa.strDesc_Alternatica = dr["Desc_Alternatica"].ToString().Trim();

                            lstPreguntaEvaluacionTecnica.Add(obePreguntaEvaluacionTecnica);
                        }
                }
            }
            return lstPreguntaEvaluacionTecnica;
        }

    }
}
