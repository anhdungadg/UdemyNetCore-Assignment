using Microsoft.Data.SqlClient;
using RepoDb;


namespace FunWithRepoDb.Repository
{
    public class ApplicationRepository: BaseRepository<ProductRepository, SqlConnection>
    {
        public ApplicationRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
