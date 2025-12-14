using System.Text.RegularExpressions;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Doğrulama işlemleri
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
        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }

        /// <summary>
        /// Metin alanının boş olmadığını doğrular
        /// </summary>
        public static bool IsNotEmpty(string text, string placeholder = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return placeholder == null || text != placeholder;
        }
    }
}