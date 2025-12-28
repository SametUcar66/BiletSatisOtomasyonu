using System;
using System.Data;
using System.Data.SQLite; // NuGet: System.Data.SQLite
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    // DÜZELTME: Burası artık Form değil, UserControl sınıfından türüyor.
    public partial class Sofor : UserControl
    {
        // Veritabanı bağlantı cümlesi
        string connectionString = "Data Source=VeriTabani.db;Version=3;";

        // Giriş yapan kullanıcının ID'si ve Sürücü ID'si
        private int _currentUserId;
        private int _driverId;

        // Constructor
        public Sofor(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
        }

        // UserControl Yüklendiğinde
        private void sofor_Load(object sender, EventArgs e)
        {
            // 1. Kullanıcı ID'sinden Sürücü ID'sini ve Adını bul
            if (SurucuBilgisiniGetir())
            {
                // 2. Seferleri DataGridView'e doldur
                SeferleriGetir();
            }
            else
            {
                MessageBox.Show("Bu kullanıcıya bağlı bir sürücü kaydı bulunamadı!", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // UserControl olduğu için 'Close()' diyemeyiz. 
                // Bunun yerine ekranı kilitliyoruz.
                this.Enabled = false;
            }

            // Butonların başlangıç durumu
            ButonlariAyarla(false, false);
            this.ActiveControl = null;
        }

        // Sürücü kimliğini ve adını veritabanından çeker
        private bool SurucuBilgisiniGetir()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Users ve Drivers tablolarını birleştirerek bilgi alıyoruz
                    string sql = @"
                        SELECT d.Id, u.FullName 
                        FROM Drivers d 
                        JOIN Users u ON d.UserId = u.Id 
                        WHERE u.Id = @userId";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", _currentUserId);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _driverId = reader.GetInt32(0);
                                string surucuAdi = reader.GetString(1);
                                lblSoforAdi.Text = "Hoşgeldiniz, " + surucuAdi;
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sürücü bilgisi alınırken hata: " + ex.Message);
                }
            }
            return false;
        }

        // Seferleri dgvSeferler aracına doldurur
        private void SeferleriGetir()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Expeditions yerine TRIPS tablosu kullanılıyor
                    string sql = @"
                        SELECT 
                            T.Id, 
                            R.Name AS 'Güzergah', 
                            T.DepartureTime AS 'Kalkış Tarihi', 
                            T.Status AS 'DurumKodu', 
                            CASE 
                                WHEN T.Status = 0 THEN 'Bekliyor'
                                WHEN T.Status = 1 THEN 'Yolda'
                                ELSE 'Tamamlandı'
                            END AS 'Durum'
                        FROM Trips T
                        JOIN Routes R ON T.RouteId = R.Id
                        WHERE T.DriverId = @driverId AND T.Status IN (0, 1) -- Sadece Bekleyen ve Aktifler
                        ORDER BY T.DepartureTime ASC";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@driverId", _driverId);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSeferler.DataSource = dt;

                        // ID ve DurumKodu sütunlarını gizle (Kullanıcı görmesin ama kodda lazım)
                        if (dgvSeferler.Columns["Id"] != null) dgvSeferler.Columns["Id"].Visible = false;
                        if (dgvSeferler.Columns["DurumKodu"] != null) dgvSeferler.Columns["DurumKodu"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seferler listelenirken hata: " + ex.Message);
                }
            }
        }

        // Sefer Listesinden seçim yapıldığında
        private void dgvSeferler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeferler.SelectedRows.Count > 0)
            {
                // Hücre değerlerini alırken null kontrolü yapmak güvenlidir
                var idVal = dgvSeferler.SelectedRows[0].Cells["Id"].Value;
                var durumVal = dgvSeferler.SelectedRows[0].Cells["DurumKodu"].Value;
                var guzergahVal = dgvSeferler.SelectedRows[0].Cells["Güzergah"].Value;

                if (idVal == null || durumVal == null) return;

                int seferId = Convert.ToInt32(idVal);
                int durumKodu = Convert.ToInt32(durumVal);
                string guzergah = guzergahVal.ToString();

                lblSeciliSefer.Text = $"Seçili Sefer: {guzergah}";

                // Yolcuları getir
                YolculariGetir(seferId);

                // Butonları duruma göre aktif/pasif yap
                if (durumKodu == 0) // Bekliyor
                {
                    ButonlariAyarla(true, false); // Başlat: Aktif, Bitir: Pasif
                }
                else if (durumKodu == 1) // Yolda
                {
                    ButonlariAyarla(false, true); // Başlat: Pasif, Bitir: Aktif
                }
            }
            else
            {
                // Seçim yoksa temizle
                dgvYolcular.DataSource = null;
                lblSeciliSefer.Text = "Sefer Detayı ve Listesi";
                ButonlariAyarla(false, false);
            }
        }

        // Yolcu Listesini dgvYolcular aracına doldurur
        private void YolculariGetir(int tripId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            SeatNumber AS 'Koltuk',
                            PassengerName AS 'Ad Soyad',
                            PassengerTCNo AS 'TC No',
                            CASE WHEN PassengerGender = 1 THEN 'Erkek' ELSE 'Kadın' END AS 'Cinsiyet'
                        FROM Tickets
                        WHERE TripId = @tripId AND Status = 1 -- Sadece aktif biletler
                        ORDER BY CAST(SeatNumber AS INTEGER) ASC";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@tripId", tripId);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvYolcular.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yolcu listesi alınırken hata: " + ex.Message);
                }
            }
        }

        // Seferi Başlat Butonu
        private void btnSeferBaslat_Click(object sender, EventArgs e)
        {
            DurumGuncelle(1, "Sefer başarıyla başlatıldı. İyi yolculuklar!");
        }

        // Seferi Bitir Butonu
        private void btnSeferBitir_Click(object sender, EventArgs e)
        {
            DurumGuncelle(2, "Sefer başarıyla tamamlandı. Geçmiş olsun.");
        }

        // Veritabanında sefer durumunu güncelleyen yardımcı metot
        private void DurumGuncelle(int yeniDurum, string mesaj)
        {
            if (dgvSeferler.SelectedRows.Count == 0) return;

            int seferId = Convert.ToInt32(dgvSeferler.SelectedRows[0].Cells["Id"].Value);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Trips SET Status = @status WHERE Id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", yeniDurum);
                        cmd.Parameters.AddWithValue("@id", seferId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi yenile ki butonlar ve durum güncellensin
                    SeferleriGetir();

                    // Tablo yenilendiği için seçim kaybolabilir, yolcu listesini temizleyelim
                    dgvYolcular.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message);
                }
            }
        }

        // Butonların Enabled/BackColor özelliklerini ayarlayan yardımcı metot
        private void ButonlariAyarla(bool baslatAktif, bool bitirAktif)
        {
            btnSeferBaslat.Enabled = baslatAktif;
            btnSeferBaslat.BackColor = baslatAktif ? Color.SlateGray : Color.Gray;

            btnSeferBitir.Enabled = bitirAktif;
            btnSeferBitir.BackColor = bitirAktif ? Color.IndianRed : Color.Gray;
        }

        private void dgvSeferler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSeferler.ClearSelection();
            dgvSeferler.CurrentCell = null;
        }

        private void dgvYolcular_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvYolcular.ClearSelection();
            dgvYolcular.CurrentCell = null;
        }
    }
}