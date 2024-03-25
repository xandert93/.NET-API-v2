using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace xo.Data
{
  public class DbContext
  {

    private readonly IConfiguration _config;

    public DbContext(IConfiguration config)
    {
      _config = config;
    }

    public IEnumerable<T> Find<T>(string sql)
    {
      IDbConnection dbConn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      return dbConn.Query<T>(sql);
    }

    public T FindOne<T>(string sql)
    {
      IDbConnection dbConn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      return dbConn.QuerySingle<T>(sql);
    }
  }
}
