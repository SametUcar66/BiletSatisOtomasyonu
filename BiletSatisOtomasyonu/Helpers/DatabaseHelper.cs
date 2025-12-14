using System;
using System.Data;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Veritabanı bağlantı ve işlem yardımcı sınıfı
    /// </summary>
    public static class DatabaseHelper
    {
        private const string CONNECTION_STRING = "Data Source=BiletSatis.db; Version=3";

        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(CONNECTION_STRING);
        }

        public static DataTable ExecuteQuery(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    var adapter = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int ExecuteNonQuery(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query, params SQLiteParameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}