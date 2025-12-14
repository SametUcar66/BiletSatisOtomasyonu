using System;
using System.Data.SQLite;
using BiletSatisOtomasyonu.Helpers;

namespace BiletSatisOtomasyonu.Services
{
    /// <summary>
    /// Kullan?c? i?lemleri servisi
    /// </summary>
    public static class UserService
    {
        /// <summary>
        /// Kullan?c?n?n profil foto?raf?n? (logo) getirir
        /// </summary>
        public static string GetUserLogo(int userId)
        {
            try
            {
                string query = @"SELECT a.logo_url 
                                 FROM agencies a 
                                 INNER JOIN users u ON u.agency_id = a.agency_id 
                                 WHERE u.user_id = @userId";

                var result = DatabaseHelper.ExecuteScalar(query,
                    new SQLiteParameter("@userId", userId));

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logo yüklenirken hata: " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// E-posta adresinin sistemde kay?tl? olup olmad???n? kontrol eder
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
        /// Kullan?c? bilgilerini günceller
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
                    new SQLiteParameter("@phone", phone),
                    new SQLiteParameter("@userId", userId));

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kullan?c? ?ifresini do?rular
        /// </summary>
        public static bool VerifyPassword(int userId, string password)
        {
            string query = "SELECT password FROM users WHERE user_id = @userId";
            var result = DatabaseHelper.ExecuteScalar(query,
                new SQLiteParameter("@userId", userId));

            return result?.ToString() == password;
        }

        /// <summary>
        /// Kullan?c? ?ifresini günceller
        /// </summary>
        public static bool UpdatePassword(int userId, string newPassword)
        {
            try
            {
                string query = "UPDATE users SET password = @password WHERE user_id = @userId";
                DatabaseHelper.ExecuteNonQuery(query,
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
        /// Acenta logosunu günceller
        /// </summary>
        public static bool UpdateAgencyLogo(int userId, string logoBase64)
        {
            try
            {
                // Önce agency_id'yi al
                string getAgencyQuery = "SELECT agency_id FROM users WHERE user_id = @userId";
                var result = DatabaseHelper.ExecuteScalar(getAgencyQuery,
                    new SQLiteParameter("@userId", userId));

                if (result != null && result != DBNull.Value)
                {
                    int agencyId = Convert.ToInt32(result);

                    string updateQuery = "UPDATE agencies SET logo_url = @logoUrl WHERE agency_id = @agencyId";
                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new SQLiteParameter("@logoUrl", logoBase64),
                        new SQLiteParameter("@agencyId", agencyId));

                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        /// <summary>
        /// Kullan?c? hesab?n? siler
        /// </summary>
        public static bool DeleteUser(int userId)
        {
            try
            {
                string query = "DELETE FROM users WHERE user_id = @userId";
                DatabaseHelper.ExecuteNonQuery(query,
                    new SQLiteParameter("@userId", userId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kullan?c? kayd? olu?turur
        /// </summary>
        public static long CreateUser(int roleId, long agencyId, string email, string password, string fullName, string phone = "")
        {
            try
            {
                string query = @"INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                                 VALUES (@roleId, @agencyId, @email, @password, @fullName, @phone)";

                using (var connection = DatabaseHelper.CreateConnection())
                {
                    connection.Open();
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@roleId", roleId);
                        cmd.Parameters.AddWithValue("@agencyId", agencyId);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@phone", phone);
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
        /// Acenta olu?turur
        /// </summary>
        public static long CreateAgency(string agencyName, string logoBase64 = null)
        {
            try
            {
                string query = @"INSERT INTO agencies (agency_name, is_active, commission_rate, logo_url) 
                                 VALUES (@agencyName, 1, 10.0, @logoUrl)";

                using (var connection = DatabaseHelper.CreateConnection())
                {
                    connection.Open();
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
        /// Rol ad?n? Türkçe'ye çevirir
        /// </summary>
        public static string GetRoleDisplayName(string roleName)
        {
            switch (roleName)
            {
                case "SuperAdmin": return "Süper Admin";
                case "AgencyAdmin": return "Acenta Yöneticisi";
                case "Staff": return "Personel";
                case "Driver": return "?oför";
                case "Passenger": return "Yolcu";
                default: return roleName ?? "Bilinmiyor";
            }
        }
    }
}   