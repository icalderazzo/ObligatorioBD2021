
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DatabaseInterface
{
    public interface IDatabaseContext
    {
        Task<int> SaveData(string query, List<SqlParameter> parameters = null);
        Task<List<object[]>> Select(string query, List<SqlParameter> parameters = null);

    }
}
