using System;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Forms;

namespace BiletSatis
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Veritabanı bağlantı testi
            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show(
                    "Veritabanına bağlanılamadı!\nLütfen BiletSatis.db dosyasının mevcut olduğundan emin olun.",
                    "Bağlantı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
