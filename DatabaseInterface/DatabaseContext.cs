using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseInterface
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly string _connectionString;

        public DatabaseContext(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        public int SaveData(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = query
                    };
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error de base de datos", ex);
            }
        }
        public int SaveData((SqlConnection, SqlTransaction) transaction, string query, params SqlParameter[] parameters)
        {
            try
            {
                var command = new SqlCommand()
                {
                    CommandText = query,
                    Connection = transaction.Item1,
                    Transaction = transaction.Item2
                };

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Item2.Rollback();
                    transaction.Item1.Close(); //close connection
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<object[]> Select(string query, params SqlParameter[] parameters)
        {
            try
            {
                List<object[]> result = new List<object[]>();
                using (var conn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = query
                    };

                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            result.Add(row);
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error de base de datos", ex);
            }
        }
        public List<object[]> Select((SqlConnection, SqlTransaction) transaction, string query, params SqlParameter[] parameters)
        {
            try
            {
                List<object[]> result = new List<object[]>();
                var cmd = new SqlCommand()
                {
                    Connection = transaction.Item1,
                    CommandText = query,
                    Transaction = transaction.Item2
                };

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            result.Add(row);
                        }
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                try
                {
                    transaction.Item2.Rollback();
                    transaction.Item1.Close(); //close connection
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public (SqlConnection,SqlTransaction) BeginTransaction()
        {
            try
            {
                var conn = new SqlConnection(_connectionString);
                conn.Open();
                var transaction = conn.BeginTransaction();
                return (conn, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Commit((SqlConnection, SqlTransaction) transaction)
        {
            try
            {
                transaction.Item2.Commit();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                transaction.Item1.Close();
            }
        }
    }
}
