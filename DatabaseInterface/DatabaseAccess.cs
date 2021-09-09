using System;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseInterface
{
    public static class DatabaseAccess
    {
        private static string _connString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<int> SaveData(string query, List<SqlParameter> parameters = null)
        {
            try
            {
                using(var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = query
                    };
                    if (parameters!=null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    await conn.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
            }
            catch(SqlException dbEx)
            {
                throw new Exception("Error de base de datos", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ubknown exception", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<object[]>> Select(string query, List<SqlParameter> parameters = null)
        {
            try
            {
                List<object[]> result = new List<object[]>();
                using (var conn = new SqlConnection(_connString))
                {
                    var cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = query
                    };

                    if (parameters!=null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    await conn.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();

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
            catch (SqlException dbEx)
            {
                throw new Exception("Error de base de datos", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown exception", ex);
            }
        }


        public static void SetConnectionString(string connString)
        {
            _connString = connString;
        }
    }
}
