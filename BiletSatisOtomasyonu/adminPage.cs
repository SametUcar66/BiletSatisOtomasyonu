using System;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class adminPage : Form
    {
        public adminPage()
        {
            InitializeComponent();
        }

        private void adminPage_Load(object sender, EventArgs e)
        {
            KartlariYukle();
        }

        private void KartlariYukle()
        {
            // Önce paneli temizle (Refresh yaparsak üst üste binmesin)
            flowLayoutPanelAdmin.Controls.Clear();

            // --- 1. ACENTELER ---
            int acenteSayisi = GetCount("SELECT COUNT(*) FROM Agencies");
            KartEkle("Acenteler", acenteSayisi, Color.DodgerBlue, 1);

            // --- 2. ŞOFÖRLER (UserType=3) ---
            int soforSayisi = GetCount("SELECT COUNT(*) FROM Users WHERE UserType=3");
            KartEkle("Şoförler", soforSayisi, Color.Orange, 3);

            // --- 3. KURUMSAL ŞİRKETLER (UserType=4) ---
            int kurumsalSayisi = GetCount("SELECT COUNT(*) FROM Users WHERE UserType=4");
            KartEkle("Kurumsal Müşteriler", kurumsalSayisi, Color.Purple, 4);

            // --- 4. BİREYSEL MÜŞTERİLER (UserType=5) ---
            int musteriSayisi = GetCount("SELECT COUNT(*) FROM Users WHERE UserType=5");
            KartEkle("Bireysel Müşteriler", musteriSayisi, Color.SeaGreen, 5);
        }

        // Veritabanından sayı çeken yardımcı metot
        private int GetCount(string query)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }

        // Dinamik Kart Oluşturucu
        private void KartEkle(string baslik, int sayi, Color renk, int typeId)
        {
            DashboardCard kart = new DashboardCard();
            kart.SetData(baslik, sayi, renk, typeId);

            // Karttaki butona tıklanınca ne olacağını bağlıyoruz
            kart.ManageClicked += Kart_Tiklandi;

            // Karta biraz boşluk (Margin) verelim ki yapışık durmasın
            kart.Margin = new Padding(10);

            flowLayoutPanelAdmin.Controls.Add(kart);
        }

        // Tıklanma Olayı: Hangi karta tıklandıysa ona göre işlem yap
        private void Kart_Tiklandi(object sender, EventArgs e)
        {
            // Tıklanan kartı yakala
            DashboardCard tiklananKart = (DashboardCard)sender;

            switch (tiklananKart.UserTypeID)
            {
                case 1:
                    MessageBox.Show("Acente Yönetim Listesi Açılacak...");
                    // AcenteListesiForm form = new AcenteListesiForm();
                    // form.ShowDialog();
                    break;
                case 3:
                    MessageBox.Show("Şoför Listesi Açılacak...");
                    // SoforListesiForm form = new SoforListesiForm();
                    // form.ShowDialog();
                    break;
                case 4:
                    MessageBox.Show("Kurumsal Şirketler Listesi Açılacak...");
                    break;
                case 5:
                    MessageBox.Show("Müşteriler Listesi Açılacak...");
                    break;
            }
        }
    }
}