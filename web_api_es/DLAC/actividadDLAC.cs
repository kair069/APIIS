using Microsoft.Data.SqlClient;
using System.Data;
using web_api_es.Models;

namespace web_api_es.DLAC
{
    public class actividadDLAC
    {
        public IEnumerable<Actividad> listado()
        {
            List<Actividad> seller = new List<Actividad>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("listar_actividad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Actividad()
                    {
                        idact = dr.GetInt32(0),
                        desact = dr.GetString(1),
                        idcateg = dr.GetInt32(2),
                        descateg = dr.GetString(3),
                        fecha = dr.GetDateTime(4),
                        vacantes = dr.GetInt32(5),
                    });
                }
            }
            return seller;
        }
    }
}
