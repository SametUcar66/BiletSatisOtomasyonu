using System;
using System.Data.SQLite;
using System.IO;

namespace BiletSatis.Data
{
    public static class DatabaseHelper
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BiletSatis.db");
        public static string ConnectionString => $"Data Source={DbPath};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}