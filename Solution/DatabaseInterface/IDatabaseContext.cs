
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseInterface
{
    public interface IDatabaseContext
    {
        int SaveData(string query, params SqlParameter[] parameters);
        int SaveData((SqlConnection, SqlTransaction) transaction, string query, params SqlParameter[] parameters);
        List<object[]> Select(string query, params SqlParameter[] parameters);
        List<object[]> Select((SqlConnection, SqlTransaction) transaction, string query, params SqlParameter[] parameters);
        (SqlConnection, SqlTransaction) BeginTransaction();
        void Commit((SqlConnection, SqlTransaction) transaction);
    }
}