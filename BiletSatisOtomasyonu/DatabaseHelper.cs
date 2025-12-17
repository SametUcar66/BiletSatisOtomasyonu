using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public class DatabaseHelper
    {
        // BURAYI DEĞİŞTİRDİK: Senin dosya isminle aynı yaptık
        private static string dbFileName = "VeriTabani.db";

        // Programın çalıştığı klasörü (Debug klasörü) alıp dosya adını ekliyoruz
        private static string dbPath = Path.Combine(Application.StartupPath, dbFileName);

        private static string connectionString = $"Data Source={dbPath};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            // Kontrol: Eğer dosya gerçekten orada yoksa hata vermeden önce uyaralım
            if (!File.Exists(dbPath))
            {
                // Dosya yolunu gösteren bir hata mesajı, böylece nereye baktığını anlarsın
                MessageBox.Show($"Veritabanı dosyası bulunamadı!\nProgramın aradığı yer:\n{dbPath}",
                                "Dosya Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new SQLiteConnection(connectionString);
        }
    }
}