
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseInterface
{
    public interface IDatabaseContext
    {
        int SaveData(string query, List<SqlParameter> parameters = null);
        List<object[]> Select(string query, List<SqlParameter> parameters = null);
    }
}
