using System;
using System.Data.SQLite;
using BiletSatisOtomasyonu.Helpers;

namespace BiletSatisOtomasyonu.Services
{
    /// <summary>
    /// Kullanıcı işlemleri
    /// </summary>
    public static class UserService
    {
        /// <summary>
        /// Kullanıcı girişi
        /// </summary>
        public static (bool success, int userId, int agencyId, string roleName) Login(string email, string password)
        {
            try
            {
                string query = @"
                    SELECT u.user_id, u.agency_id, r.role_name 
                    FROM users u 
                    LEFT JOIN roles r ON u.role_id = r.role_id 
                    WHERE u.email = @email AND u.password = @password";

                var dt = DatabaseHelper.ExecuteQuery(query,
                    new SQLiteParameter("@email", email),
                    new SQLiteParameter("@password", password));

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    int userId = Convert.ToInt32(row["user_id"]);
                    int agencyId = row["agency_id"] != DBNull.Value ? Convert.ToInt32(row["agency_id"]) : 0;
                    string roleName = row["role_name"]?.ToString() ?? "";
                    return (true, userId, agencyId, roleName);
                }
            }
            catch { }

            return (false, 0, 0, "");
        }

        /// <summary>
        /// E-posta kontrolü
        /// </summary>
        public static bool IsEmailExists(string email, int excludeUserId = 0)
        {
            string query = excludeUserId > 0
                ? "SELECT COUNT(*) FROM users WHERE email = @email AND user_id != @userId"
                : "SELECT COUNT(*) FROM users WHERE email = @email";

            var parameters = excludeUserId > 0
                ? new[] { new SQLiteParameter("@email", email), new SQLiteParameter("@userId", excludeUserId) }
                : new[] { new SQLiteParameter("@email", email) };

            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        /// <summary>
        /// Kullanıcı kaydı
        /// </summary>
        public static bool Register(string email, string password, string fullName, int roleId = 5, int agencyId = 1)
        {
            try
            {
                string query = @"
                    INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                    VALUES (@roleId, @agencyId, @email, @password, @fullName, '')";

                DatabaseHelper.ExecuteNonQuery(query,
                    new SQLiteParameter("@roleId", roleId),
                    new SQLiteParameter("@agencyId", agencyId),
                    new SQLiteParameter("@email", email),
                    new SQLiteParameter("@password", password),
                    new SQLiteParameter("@fullName", fullName));

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kullanıcı logosu
        /// </summary>
        public static string GetUserLogo(int userId)
        {
            try
            {
                var result = DatabaseHelper.ExecuteScalar(@"
                    SELECT a.logo_url FROM agencies a 
                    INNER JOIN users u ON u.agency_id = a.agency_id 
                    WHERE u.user_id = @userId",
                    new SQLiteParameter("@userId", userId));

                if (result != null && result != DBNull.Value)
                    return result.ToString();
            }
            catch { }

            return null;
        }

        /// <summary>
        /// Kullanıcı bilgilerini günceller
        /// </summary>
        public static bool UpdateUserInfo(int userId, string fullName, string email, string phone)
        {
            try
            {
                string query = @"UPDATE users 
                                 SET full_name = @fullName, email = @email, phone = @phone 
                                 WHERE user_id = @userId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new SQLiteParameter("@fullName", fullName),
                    new SQLiteParameter("@email", email),
                    new SQLiteParameter("@phone", phone ?? ""),
                    new SQLiteParameter("@userId", userId));

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Şifre doğrulama
        /// </summary>
        public static bool VerifyPassword(int userId, string password)
        {
            var result = DatabaseHelper.ExecuteScalar(
                "SELECT password FROM users WHERE user_id = @userId",
                new SQLiteParameter("@userId", userId));

            return result?.ToString() == password;
        }

        /// <summary>
        /// Şifre güncelleme
        /// </summary>
        public static bool UpdatePassword(int userId, string newPassword)
        {
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE users SET password = @password WHERE user_id = @userId",
                    new SQLiteParameter("@password", newPassword),
                    new SQLiteParameter("@userId", userId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Acenta logosu güncelleme
        /// </summary>
        public static bool UpdateAgencyLogo(int userId, string logoBase64)
        {
            try
            {
                var result = DatabaseHelper.ExecuteScalar(
                    "SELECT agency_id FROM users WHERE user_id = @userId",
                    new SQLiteParameter("@userId", userId));

                if (result != null && result != DBNull.Value)
                {
                    int agencyId = Convert.ToInt32(result);
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE agencies SET logo_url = @logoUrl WHERE agency_id = @agencyId",
                        new SQLiteParameter("@logoUrl", logoBase64 ?? (object)DBNull.Value),
                        new SQLiteParameter("@agencyId", agencyId));
                    return true;
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Kullanıcı silme
        /// </summary>
        public static bool DeleteUser(int userId)
        {
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM users WHERE user_id = @userId",
                    new SQLiteParameter("@userId", userId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Yeni kullanıcı oluşturma
        /// </summary>
        public static long CreateUser(int roleId, long agencyId, string email, string password, string fullName, string phone = "")
        {
            try
            {
                using (var connection = DatabaseHelper.CreateConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                                     VALUES (@roleId, @agencyId, @email, @password, @fullName, @phone)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        cmd.Parameters.AddWithValue("@agencyId", agencyId);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.ExecuteNonQuery();
                        return connection.LastInsertRowId;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Acenta oluşturma
        /// </summary>
        public static long CreateAgency(string agencyName, string logoBase64 = null)
        {
            try
            {
                using (var connection = DatabaseHelper.CreateConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO agencies (agency_name, is_active, commission_rate, logo_url) 
                                     VALUES (@agencyName, 1, 10.0, @logoUrl)";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@agencyName", agencyName);
                        cmd.Parameters.AddWithValue("@logoUrl",
                            string.IsNullOrEmpty(logoBase64) ? (object)DBNull.Value : logoBase64);
                        cmd.ExecuteNonQuery();
                        return connection.LastInsertRowId;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Rol adını Türkçeleştirir
        /// </summary>
        public static string GetRoleDisplayName(string roleName)
        {
            switch (roleName)
            {
                case "SuperAdmin": return "Süper Admin";
                case "AgencyAdmin": return "Acenta Yöneticisi";
                case "Staff": return "Personel";
                case "Driver": return "Şoför";
                case "Passenger": return "Yolcu";
                default: return roleName ?? "Bilinmiyor";
            }
        }
    }
}