using Microsoft.Data.SqlClient;
namespace web_api_es.DLAC
{
    public class conexionDLAC
    {
        SqlConnection cn = new SqlConnection("Server=admi2.database.windows.net,1433;Initial Catalog=Plataforma2022;Persist Security Info=False;User ID=admi;Password=boltimax.P;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



        public SqlConnection getcn
            {
                get { return cn; }
            }
    }
}
