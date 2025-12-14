using System.Windows.Forms;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Mesaj kutuları
    /// </summary>
    public static class MessageHelper
    {
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowConfirm(string message)
        {
            return MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}