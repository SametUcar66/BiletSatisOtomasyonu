using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using BiletSatis.Data;
using BiletSatis.Models;

namespace BiletSatis.Services
{
    public class AuthService
    {
        public User Login(string email, string password)
        {
            string hashedPassword = HashPassword(password);

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT Id, Email, PasswordHash, FullName, Phone, TCNo, Address, 
                               UserType, CreatedAt, LastLoginAt, IsActive 
                               FROM Users WHERE Email = @Email AND IsActive = 1";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();

                            if (storedHash == hashedPassword || storedHash == password)
                            {
                                var user = new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Email = reader["Email"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Phone = reader["Phone"]?.ToString(),
                                    TCNo = reader["TCNo"]?.ToString(),
                                    Address = reader["Address"]?.ToString(),
                                    UserType = (UserType)Convert.ToInt32(reader["UserType"]),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    LastLoginAt = reader["LastLoginAt"] != DBNull.Value
                                        ? Convert.ToDateTime(reader["LastLoginAt"])
                                        : (DateTime?)null,
                                    IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                                };

                                UpdateLastLogin(user.Id, conn);
                                return user;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public bool Register(User user, string password)
        {
            if (EmailExists(user.Email))
                return false;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Users (Email, PasswordHash, FullName, Phone, TCNo, UserType, IsActive, CreatedAt)
                               VALUES (@Email, @PasswordHash, @FullName, @Phone, @TCNo, @UserType, 1, @CreatedAt)";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                    cmd.Parameters.AddWithValue("@FullName", user.FullName);
                    cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(user.Phone) ? (object)DBNull.Value : user.Phone);
                    cmd.Parameters.AddWithValue("@TCNo", string.IsNullOrEmpty(user.TCNo) ? (object)DBNull.Value : user.TCNo);
                    cmd.Parameters.AddWithValue("@UserType", (int)user.UserType);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RegisterAgencyManager(User user, string password, string agencyName, int agencyType,
            string taxNo, string agencyPhone, string agencyAddress)
        {
            if (EmailExists(user.Email))
                return false;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kullanıcıyı kaydet
                        string userSql = @"INSERT INTO Users (Email, PasswordHash, FullName, Phone, TCNo, UserType, IsActive, CreatedAt)
                                          VALUES (@Email, @PasswordHash, @FullName, @Phone, @TCNo, @UserType, 1, @CreatedAt);
                                          SELECT last_insert_rowid();";

                        int userId;
                        using (var cmd = new SQLiteCommand(userSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Email", user.Email);
                            cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                            cmd.Parameters.AddWithValue("@FullName", user.FullName);
                            cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(user.Phone) ? (object)DBNull.Value : user.Phone);
                            cmd.Parameters.AddWithValue("@TCNo", string.IsNullOrEmpty(user.TCNo) ? (object)DBNull.Value : user.TCNo);
                            cmd.Parameters.AddWithValue("@UserType", (int)UserType.AgencyManager);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            userId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Ajansı kaydet
                        string agencySql = @"INSERT INTO Agencies (Name, TaxNumber, Phone, Address, AgencyType, IsActive, CreatedAt)
                                            VALUES (@Name, @TaxNumber, @Phone, @Address, @AgencyType, 1, @CreatedAt);
                                            SELECT last_insert_rowid();";

                        int agencyId;
                        using (var cmd = new SQLiteCommand(agencySql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", agencyName);
                            cmd.Parameters.AddWithValue("@TaxNumber", string.IsNullOrEmpty(taxNo) ? (object)DBNull.Value : taxNo);
                            cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(agencyPhone) ? (object)DBNull.Value : agencyPhone);
                            cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(agencyAddress) ? (object)DBNull.Value : agencyAddress);
                            cmd.Parameters.AddWithValue("@AgencyType", agencyType);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            agencyId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 3. Ajans çalışanı olarak yönetici kaydı
                        string employeeSql = @"INSERT INTO AgencyEmployees (UserId, AgencyId, Role, HireDate)
                                              VALUES (@UserId, @AgencyId, 0, @HireDate)";

                        using (var cmd = new SQLiteCommand(employeeSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                            cmd.Parameters.AddWithValue("@HireDate", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool EmailExists(string email)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public int? GetUserAgencyId(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT AgencyId FROM AgencyEmployees WHERE UserId = @UserId";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
        }

        private void UpdateLastLogin(int userId, SQLiteConnection conn)
        {
            string sql = "UPDATE Users SET LastLoginAt = @LastLogin WHERE Id = @Id";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}