using RepoDb;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FunWithRepoDb.Infrastructure
{
    public static class ApplicationDbContext
    {
        //private readonly string _connString;
        //public ApplicationDbContext(string connectionString)
        //{
        //    _connString = connectionString;
        //}


        //public static IEnumerable<TResult> ExecuteQuery<TResult>(this IDbConnection connection, string commandText, object param = null, CommandType? commandType = null, string cacheKey = null, int? cacheItemExpiration = 180, int? commandTimeout = null, IDbTransaction transaction = null, ICache cache = null)
        //{
        //    return connection.ExecuteQueryInternal<TResult>(commandText, param, commandType, cacheKey, cacheItemExpiration, commandTimeout, transaction, cache, ClassMappedNameCache.Get<TResult>(), skipCommandArrayParametersCheck: false);
        //}

        public static string ConnectionString;

        public static IEnumerable<TResult> ExecuteQuery<TResult>(string commandText, object param = null, CommandType? commandType = null)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //conn.Open();
                return conn.ExecuteQuery<TResult>(commandText, param, commandType);
            }
        }
    }
}
