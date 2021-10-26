
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseInterface
{
    public interface IDatabaseContext
    {
        int SaveData(string query, params SqlParameter[] parameters);
        List<object[]> Select(string query, params SqlParameter[] parameters);
    }
}
