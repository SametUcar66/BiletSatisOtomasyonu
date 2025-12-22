using System;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    // Rol İsimleri ve ID'leri (Veritabanındaki UserType ile eşleşmeli)
    public enum UserRole
    {
        Admin = 0,             // Yönetici
        AjentaAdmin = 1,       // Acente Yöneticisi
        AjentaCalisan = 2,     // Acente Çalışanı
        Sofor = 3,             // Şoför
        KurumsalMusteri = 4,   // Kurumsal (En az 5 bilet)
        Musteri = 5            // Bireysel
    }

    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection()
        {
            string dbYolu = Path.Combine(Application.StartupPath, "VeriTabani.db");
            // WAL modu ve Timeout ayarı veritabanı kilitlenmelerini önler
            string baglantiCumlesi = $"Data Source={dbYolu};Version=3;Pooling=False;Journal Mode=WAL;Busy Timeout=5000;";
            return new SQLiteConnection(baglantiCumlesi);
        }
    }
}