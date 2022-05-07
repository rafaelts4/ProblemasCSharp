using System.Data.SqlClient;

namespace INSS.Repositories
{
    using System.Configuration;
    
    public class BaseRepository
    {
        protected static readonly string ConnectionString;

        static BaseRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DbINSS"].ConnectionString;
        }

        protected SqlConnection ObterConexao()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
