﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Threading.Tasks;

namespace DatabaseInterface
{
    public class DatabaseContext : IDatabaseContext
    {
        private string _connectionString;

        public DatabaseContext(string connectionSting)
        {
            _connectionString = connectionSting;
        }

        public async Task<int> SaveData(string query, List<SqlParameter> parameters = null)
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
            catch (SqlException dbEx)
            {
                throw new Exception("Error de base de datos", dbEx);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Error de base de datos", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error desconocido", ex);
            }
        }
        public async Task<List<object[]>> Select(string query, List<SqlParameter> parameters = null)
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
            catch (SqlException dbEx)
            {
                throw new Exception("Error de base de datos", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Unknown exception", ex);
            }
        }
    }
}