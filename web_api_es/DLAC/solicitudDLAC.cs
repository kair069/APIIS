using Microsoft.Data.SqlClient;
using System.Data;
using web_api_es.Models;

namespace web_api_es.DLAC
{
    public class solicitudDLAC
    {
        public IEnumerable<Solicitud> listado()
        {
            List<Solicitud> seller = new List<Solicitud>();
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("listar_solicitud", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    seller.Add(new Solicitud()
                    {
                        
                        nsolicitud = dr.GetInt32(0),
                        fsolicitud = dr.GetDateTime(1),
                        desact = dr.GetString(2),
                        dni = dr.GetString(3),
                        nombre = dr.GetString(4),
                        email = dr.GetString(5),
                        idact = dr.GetInt32(6),
                    });
                }
            }
            return seller;
        }
        public string insertar(Solicitud reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("registrar_solicitud", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@dni", reg.dni));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@email", reg.email));
                    cmd.Parameters.Add(new SqlParameter("@idact", reg.idact));
                    cmd.Parameters.Add(new SqlParameter("@fsolicitud", reg.fsolicitud));
                    cmd.ExecuteNonQuery();
                    mensaje = "Solicitud Registrado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }
        public string actualizar(Solicitud reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new conexionDLAC().getcn)
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_solicitud", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@dni", reg.dni));
                    cmd.Parameters.Add(new SqlParameter("@nombre", reg.nombre));
                    cmd.Parameters.Add(new SqlParameter("@email", reg.email));
                    cmd.Parameters.Add(new SqlParameter("@idact", reg.idact));
                    cmd.Parameters.Add(new SqlParameter("@nsolicitud", reg.nsolicitud));
                    cmd.ExecuteNonQuery();
                    mensaje = "Solicitud Actualizado";
                }
                catch (Exception ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

    }
}
