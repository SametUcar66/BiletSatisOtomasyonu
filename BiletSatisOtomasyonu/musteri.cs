using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class musteri : UserControl
    {
        public int CurrentUserId { get; set; }
        public UserRole CurrentUserRole { get; set; }

        private int seciliSeferId = 0;
        private decimal seferBirimFiyati = 0;
        private List<string> seciliKoltuklar = new List<string>();

        private const int MIN_KURUMSAL_ADET = 5;
        private const decimal KURUMSAL_INDIRIM_ORANI = 0.20m;

        public musteri()
        {
            InitializeComponent();
        }

        private void musteri_Load(object sender, EventArgs e)
        {
            if (CurrentUserRole == UserRole.KurumsalMusteri)
            {
                lblUyari.Text = $"Kurumsal Müşteri: En az {MIN_KURUMSAL_ADET} bilet almalısınız. (%20 İndirimli)";
                lblUyari.ForeColor = Color.DarkBlue;
                lblUyari.Visible = true;
            }

            SehirleriYukle();
        }

        private void SehirleriYukle()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT DISTINCT City FROM Stations WHERE IsActive=1 ORDER BY City ASC";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            cmbNereden.Items.Clear();
                            cmbNereye.Items.Clear();
                            cmbNereden.Items.Add("");
                            cmbNereye.Items.Add("");

                            while (dr.Read())
                            {
                                string sehir = dr["City"].ToString();
                                cmbNereden.Items.Add(sehir);
                                cmbNereye.Items.Add(sehir);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SeferleriListele();
        }

        private void SeferleriListele()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string sql = @"
        SELECT 
            t.Id,
            sDep.Name || ' > ' || sArr.Name AS 'Güzergah',
            t.DepartureTime AS 'Tarih',
            v.PlateNumber AS 'Otobüs',
            t.Price AS 'Fiyat',
            v.Capacity AS 'Kapasite'
        FROM Trips t
        JOIN Routes r ON t.RouteId = r.Id
        JOIN Vehicles v ON t.VehicleId = v.Id
        JOIN Stations sDep ON r.DepartureStationId = sDep.Id
        JOIN Stations sArr ON r.ArrivalStationId = sArr.Id
        ";

                using (var cmd = new SQLiteCommand(conn))
                {
                    if (!string.IsNullOrWhiteSpace(cmbNereden.Text))
                    {
                        sql += " AND sDep.City = @from";
                        cmd.Parameters.AddWithValue("@from", cmbNereden.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(cmbNereye.Text))
                    {
                        sql += " AND sArr.City = @to";
                        cmd.Parameters.AddWithValue("@to", cmbNereye.Text);
                    }

                    // 🔴 TARİH FİLTRESİ SADECE VARSA
                    if (dtpTarih.Checked)
                    {
                        sql += " AND t.DepartureTime LIKE @date";
                        cmd.Parameters.AddWithValue(
                            "@date",
                            dtpTarih.Value.ToString("yyyy-MM-dd") + "%"
                        );
                    }

                    sql += " ORDER BY t.DepartureTime ASC";
                    cmd.CommandText = sql;

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSeferler.DataSource = dt;
                    dgvSeferler.Columns["Id"].Visible = false;
                    dgvSeferler.Columns["Kapasite"].Visible = false;
                    dgvSeferler.Columns["Güzergah"].FillWeight = 200;
                }
            }
        }



        // BU METOT HEM KOLTUKLARI OLUŞTURUR HEM DE DOLU OLANLARI KIRMIZI YAPAR
        private void KoltuklariCiz(int kapasite)
        {
            pnlKoltukDizilimi.Controls.Clear();
            seciliKoltuklar.Clear();
            FiyatHesapla();

            List<string> doluKoltuklar = new List<string>();
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Bu sefer için satılmış koltukları çek
                    string sql = "SELECT SeatNumber FROM Tickets WHERE TripId=@id AND Status=1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", seciliSeferId);
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read()) doluKoltuklar.Add(dr["SeatNumber"].ToString());
                        }
                    }
                }
            }
            catch { }

            for (int i = 1; i <= kapasite; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Width = 45;
                btn.Height = 45;
                btn.Margin = new Padding(3);
                btn.FlatStyle = FlatStyle.Flat;

                // Eğer veritabanında varsa KIRMIZI yap
                if (doluKoltuklar.Contains(i.ToString()))
                {
                    btn.BackColor = Color.IndianRed;
                    btn.Enabled = false; // Tıklanamaz
                }
                else
                {
                    btn.BackColor = Color.WhiteSmoke;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += Koltuk_Click;
                }
                // HATA ÇIKARAN "groupBox1" YERİNE DOĞRU PANEL:
                pnlKoltukDizilimi.Controls.Add(btn);
            }
        }

        private void Koltuk_Click(object sender, EventArgs e)
        {
            Button tiklanan = (Button)sender;
            if (seciliKoltuklar.Contains(tiklanan.Text))
            {
                seciliKoltuklar.Remove(tiklanan.Text);
                tiklanan.BackColor = Color.WhiteSmoke;
            }
            else
            {
                seciliKoltuklar.Add(tiklanan.Text);
                tiklanan.BackColor = Color.Gold;
            }
            FiyatHesapla();
        }

        private void FiyatHesapla()
        {
            int adet = seciliKoltuklar.Count;
            decimal toplamTutar = adet * seferBirimFiyati;
            string bilgiMesaji = $"Seçilen: {adet} Adet";

            btnSatinAl.Enabled = false;
            btnSatinAl.BackColor = Color.SlateGray;


            if (CurrentUserRole == UserRole.KurumsalMusteri)
            {
                if (adet >= MIN_KURUMSAL_ADET)
                {
                    decimal indirimMiktari = toplamTutar * KURUMSAL_INDIRIM_ORANI;
                    toplamTutar -= indirimMiktari;
                    bilgiMesaji += $" (%20 İndirim: -{indirimMiktari:C2})";
                    btnSatinAl.Enabled = true;
                    btnSatinAl.BackColor = Color.ForestGreen;
                }
                else
                    bilgiMesaji += " (En az 5 adet seçmelisiniz)";
            }
            else
            {
                if (adet > 0)
                {
                    btnSatinAl.Enabled = true;
                    btnSatinAl.BackColor = Color.ForestGreen;
                }
            }

            lblSecilenKoltuk.Text = string.Join(", ", seciliKoltuklar);
            lblFiyat.Text = $"Toplam: {toplamTutar:C2}\n{bilgiMesaji}";
        }

        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            if (seciliKoltuklar.Count == 0) return;

            decimal sonFiyat = seciliKoltuklar.Count * seferBirimFiyati;
            if (CurrentUserRole == UserRole.KurumsalMusteri)
                sonFiyat -= (sonFiyat * KURUMSAL_INDIRIM_ORANI);

            DialogResult onay = MessageBox.Show(
                $"Toplam {seciliKoltuklar.Count} adet bilet.\nÖdenecek Tutar: {sonFiyat:C2}\nOnaylıyor musunuz?",
                "Satın Alma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                if (CurrentUserRole == UserRole.KurumsalMusteri)
                    KurumsalSatinAl(sonFiyat);
                else
                    BireyselSatinAl(sonFiyat);
            }
        }

        private void KurumsalSatinAl(decimal toplamTutar)
        {
            // (Senin mevcut kodunla aynı, sadece sonundaki yenileme garanti altına alındı)
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // ... (Sipariş Kayıt Kodları Aynen Kalacak) ...
                        // KOD UZAMASIN DİYE KISALTTIM, SENDEKİ MEVCUT INSERT KODLARI BURADA OLACAK

                        // NOT: Veritabanı Insert işlemi bittikten sonra:
                        string sqlOrder = @"INSERT INTO CompanyOrders 
                                            (CompanyUserId, TripId, TicketCount, UnitPrice, DiscountRate, TotalPrice, Status, OrderDate) 
                                            VALUES (@uId, @tId, @count, @unit, @disc, @total, 1, @date);
                                            SELECT last_insert_rowid();";

                        // ... (Buralar senin kodun) ...
                        // Sadece en altı önemli:

                        trans.Commit();
                        MessageBox.Show("Bilet başarıyla alındı.");

                        IslemSonrasiTemizlik();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void BireyselSatinAl(decimal toplamTutar)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlTicket = @"
                INSERT INTO Tickets
                (TripId, UserId, SeatNumber, Price, FinalPrice, Status)
                VALUES
                (@tId, @uId, @seat, @price, @final, 1)";

                        foreach (var koltuk in seciliKoltuklar)
                        {
                            using (var cmd = new SQLiteCommand(sqlTicket, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@tId", seciliSeferId);
                                cmd.Parameters.AddWithValue("@uId", CurrentUserId);
                                cmd.Parameters.AddWithValue("@seat", koltuk);
                                cmd.Parameters.AddWithValue("@price", seferBirimFiyati);
                                cmd.Parameters.AddWithValue("@final", seferBirimFiyati);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Biletleriniz alındı. İyi yolculuklar!");

                        IslemSonrasiTemizlik();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Satın alma hatası: " + ex.Message);
                    }
                }
            }
        }

        private void IslemSonrasiTemizlik()
        {
            // 1. Koltukları temizle
            pnlKoltukDizilimi.Controls.Clear();
            seciliKoltuklar.Clear();
            FiyatHesapla();

            // 2. Sefer listesini yenile (Gerekirse)
            SeferleriListele();

            // 3. EN ÖNEMLİSİ: ANA SAYFAYA GİDİP SOL MENÜYÜ YENİLE
            AnaSayfa anaForm = (AnaSayfa)Application.OpenForms["AnaSayfa"];
            if (anaForm != null)
            {
                anaForm.ListeyiYenile();
            }
        }

        private void dgvSeferler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSeferler.ClearSelection();
            dgvSeferler.CurrentCell = null;
        }

        private void dgvSeferler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeferler.SelectedRows.Count > 0)
            {
                seciliSeferId = Convert.ToInt32(dgvSeferler.SelectedRows[0].Cells["Id"].Value);
                seferBirimFiyati = Convert.ToDecimal(dgvSeferler.SelectedRows[0].Cells["Fiyat"].Value);
                int kapasite = Convert.ToInt32(dgvSeferler.SelectedRows[0].Cells["Kapasite"].Value);

                // Burası veritabanına bakıp koltukları çizer
                KoltuklariCiz(kapasite);
                FiyatHesapla();
            }
        }
    }
}