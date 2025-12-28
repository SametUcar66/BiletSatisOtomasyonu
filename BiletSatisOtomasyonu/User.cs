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
            //dgvListe.RowHeadersVisible = false;
            //dgvListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvListe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvListe.ReadOnly = true;
            //dgvListe.AllowUserToAddRows = false;
            //dgvListe.BackgroundColor = Color.WhiteSmoke;
            //dgvListe.BorderStyle = BorderStyle.None;
            // Başlıkları açıyoruz ki kullanıcı ne olduğunu görsün
            //dgvListe.ColumnHeadersVisible = true;
            //GorunumuAyarla();
            dgvListe.ClearSelection();
            dgvListe.CurrentCell = null;
        }

        private void User_Resize(object sender, EventArgs e) { GorunumuAyarla(); }

        private void GorunumuAyarla()
        {
            // Sol Bilgi Paneli
            //pnlBilgi.Location = new Point(5, 40);
            //pnlBilgi.Width = this.Width - 10;
            //pnlBilgi.Height = 330;

            // Sağ/Alt Liste Paneli
            //pnlListe.Visible = true;
            //pnlListe.Location = new Point(5, pnlBilgi.Bottom + 10);
            //pnlListe.Width = this.Width - 10;

            //int kalan = this.Height - pnlListe.Top - 10;
            //if (kalan > 50) pnlListe.Height = kalan;

            // İptal Butonunu en alta, Tabloyu üste koy
           // btnBiletIptal.Dock = DockStyle.Bottom;
            //dgvListe.Dock = DockStyle.Fill;
        }

        public void BiletleriGetir()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // ID'yi gizli kullanmak için çekiyoruz
                    // Status=1 olan (Aktif) biletleri getir
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

                        // ID kolonunu gizle (İptal işlemi için arka planda lazım)
                        if (dgvListe.Columns.Contains("Id")) dgvListe.Columns["Id"].Visible = false;

                        // Başlık düzeltmeleri
                        if (dgvListe.Columns.Contains("SeferDetay")) dgvListe.Columns["SeferDetay"].HeaderText = "Sefer Bilgisi";
                    }
                }
            }
            catch { }
        }

        // === BİLET İPTAL METODU ===
        private void btnBiletIptal_Click(object sender, EventArgs e)
        {
            if (dgvListe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz bileti listeden seçin.");
                return;
            }

            DialogResult onay = MessageBox.Show("Bu bileti iptal etmek istediğinize emin misiniz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                    MessageBox.Show("Bilet başarıyla iptal edildi.");

                    // Listeyi hemen yenile
                    BiletleriGetir();

                    // Eğer müşteri ekranı açıksa oradaki koltuğu da boşa düşürmek için ana sayfayı tetikle
                    AnaSayfa ana = (AnaSayfa)Application.OpenForms["AnaSayfa"];
                    if (ana != null) ana.EkraniYenile(); // (Bu metot boş olsa bile hata vermez)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İptal sırasında hata: " + ex.Message);
                }
            }
        }

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
                            }
                        }
                    }
                }
            }
            catch { }
        }

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
                MessageBox.Show("Bilgiler güncellendi.");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) Application.Restart();
        }

        private void dgvListe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvListe.ClearSelection();
            dgvListe.CurrentCell = null;
        }
    }
}