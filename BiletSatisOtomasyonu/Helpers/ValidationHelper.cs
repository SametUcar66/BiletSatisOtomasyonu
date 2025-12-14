using System.Text.RegularExpressions;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Doğrulama yardımcı sınıfı
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// E-posta formatını doğrular
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Şifre uzunluğunu doğrular
        /// </summary>
        public static bool IsValidPassword(string password, int minLength = 6)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= minLength;
        }

        /// <summary>
        /// Telefon numarasını doğrular
        /// </summary>
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Telefon opsiyonel

            // Sadece rakam ve bazı karakterlere izin ver
            return Regex.IsMatch(phone, @"^[\d\s\-\+\(\)]+$");
        }

        /// <summary>
        /// Metin alanının boş olmadığını doğrular
        /// </summary>
        public static bool IsNotEmpty(string text, string placeholder = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (placeholder != null && text == placeholder)
                return false;

            return true;
        }
    }
}