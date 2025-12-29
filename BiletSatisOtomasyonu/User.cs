using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class User : UserControl
    {
        private int _currentUserId;

        // Property: Giriş yapan kullanıcının ID'si set edildiğinde işlemleri başlatır
        public int CurrentUserId
        {
            get { return _currentUserId; }
            set
            {
                _currentUserId = value;
                if (_currentUserId > 0)
                {
                    BilgileriDoldur();
                    BiletleriGetir();
                }
            }
        }

        public UserRole CurrentUserRole { get; set; }

        public User()
        {
            InitializeComponent();
            this.Resize += User_Resize;
        }

        private void User_Load(object sender, EventArgs e)
        {
            // Tablo seçim ayarları
            dgvListe.ClearSelection();
            dgvListe.CurrentCell = null;
            this.ActiveControl = null;

            // Eğer varsa tablo stillerini buradan da zorlayabilirsiniz
            dgvListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListe.MultiSelect = false;
        }

        private void User_Resize(object sender, EventArgs e)
        {
            GorunumuAyarla();
        }

        private void GorunumuAyarla()
        {
            // Panel boyutlandırmaları Designer tarafında yapıldığı için 
            // burası boş kalabilir veya özel responsive ayarlar eklenebilir.
        }

        // --- 1. KULLANICI BİLGİLERİNİ GETİR VE YETKİ KONTROLÜ YAP ---
        private void BilgileriDoldur()
        {
            if (CurrentUserId == 0) return;
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Users WHERE Id=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", CurrentUserId);
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtAdSoyad.Text = dr["FullName"].ToString();
                                txtEmail.Text = dr["Email"].ToString();
                                if (!dr.IsDBNull(dr.GetOrdinal("Phone"))) txtTelefon.Text = dr["Phone"].ToString();
                                try { if (!dr.IsDBNull(dr.GetOrdinal("PasswordHash"))) txtSifre.Text = dr["PasswordHash"].ToString(); } catch { }

                                // --- YETKİ KONTROLÜ ---
                                // 4: Kurumsal, 5: Bireysel (Müşteriler) -> Listeyi Görsün
                                // 0,1,2,3: Yönetici ve Personeller -> Listeyi Görmesin
                                int userType = Convert.ToInt32(dr["UserType"]);

                                if (userType == 4 || userType == 5)
                                {
                                    pnlListe.Visible = true; // Müşteri ise biletleri göster
                                }
                                else
                                {
                                    pnlListe.Visible = false; // Personel ise bilet listesini gizle
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata olursa kullanıcıya yansıtmadan loglanabilir
                Console.WriteLine("Bilgi doldurma hatası: " + ex.Message);
            }
        }

        // --- 2. AKTİF BİLETLERİ LİSTELE ---
        public void BiletleriGetir()
        {
            // Eğer panel gizliyse (Personel ise) boşuna sorgu atma
            if (!pnlListe.Visible) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Status=1 olan (Aktif) biletleri getiriyoruz
                    // Trip, Route tablolarıyla birleştirip sefer detayını alıyoruz
                    string sql = @"
                        SELECT 
                            t.Id,
                            r.Name || ' (' || strftime('%d.%m %H:%M', trip.DepartureTime) || ')' AS 'SeferDetay',
                            t.SeatNumber || ' Nolu Koltuk' AS 'Koltuk',
                            t.FinalPrice || ' TL' AS 'Fiyat'
                        FROM Tickets t
                        JOIN Trips trip ON t.TripId = trip.Id
                        JOIN Routes r ON trip.RouteId = r.Id
                        WHERE t.UserId = @uid AND t.Status = 1 
                        ORDER BY trip.DepartureTime DESC";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@uid", CurrentUserId);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvListe.DataSource = null;
                        dgvListe.DataSource = dt;

                        // ID kolonunu gizle (İptal işlemi için arka planda lazım ama kullanıcı görmesin)
                        if (dgvListe.Columns.Contains("Id")) dgvListe.Columns["Id"].Visible = false;

                        // Başlık düzeltmeleri
                        if (dgvListe.Columns.Contains("SeferDetay")) dgvListe.Columns["SeferDetay"].HeaderText = "Sefer Bilgisi";
                        if (dgvListe.Columns.Contains("Koltuk")) dgvListe.Columns["Koltuk"].HeaderText = "Koltuk No";
                        if (dgvListe.Columns.Contains("Fiyat")) dgvListe.Columns["Fiyat"].HeaderText = "Tutar";
                    }
                }
            }
            catch { }
        }

        // --- 3. BİLET İPTAL İŞLEMİ ---
        private void btnBiletIptal_Click(object sender, EventArgs e)
        {
            if (dgvListe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz bileti listeden seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show("Bu bileti iptal etmek istediğinize emin misiniz?\n(İptal edilen biletler listeden kaldırılır.)", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // Gizli ID kolonundan Bilet ID'sini al
                    int biletId = Convert.ToInt32(dgvListe.SelectedRows[0].Cells["Id"].Value);

                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        // Bileti tamamen silmek yerine Status=0 yaparak "İptal" durumuna çekiyoruz
                        string sql = "UPDATE Tickets SET Status = 0 WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", biletId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Bilet başarıyla iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi hemen yenile
                    BiletleriGetir();

                    // Eğer ana ekranda koltuk seçimi açıksa orayı da yenilemek için
                    if (Application.OpenForms["AnaSayfa"] is AnaSayfa ana)
                    {
                        ana.EkraniYenile();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İptal sırasında hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- 4. PROFİL GÜNCELLEME ---
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Users SET FullName=@ad, Phone=@tel, PasswordHash=@pass WHERE Id=@id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@pass", txtSifre.Text);
                        cmd.Parameters.AddWithValue("@id", CurrentUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 5. ÇIKIŞ YAP ---
        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                // Uygulamayı yeniden başlatarak Login ekranına döner
                Application.Restart();
            }
        }

        // --- YARDIMCI OLAYLAR ---
        private void dgvListe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListe.ClearSelection();
            dgvListe.CurrentCell = null;
        }

        private void sifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (sifreGoster.Checked)
            {
                txtSifre.PasswordChar = '\0'; // Şifreyi göster
            }
            else
            {
                txtSifre.PasswordChar = '*'; // Şifreyi gizle
            }
        }
    }
}