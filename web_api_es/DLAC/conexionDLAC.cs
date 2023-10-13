using Microsoft.Data.SqlClient;
namespace web_api_es.DLAC
{
    public class conexionDLAC
    {
        SqlConnection cn = new SqlConnection(@"server=servidoralex.database.windows.net; database=Plataforma2022;Trusted_Connection= True;" +
            "MultipleActiveResultSets= True;TrustServerCertificate= False;Encrypt= False");
        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}
