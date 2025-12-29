using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class AjentaAdmin : UserControl
    {
        public AjentaAdmin()
        {
            InitializeComponent();
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() { return Text; }
        }

        private void AjentaAdmin_Load(object sender, EventArgs e)
        {
            PersonelListele();
            SatisRaporuGetir(); // Varsayılan olarak Satışlar gelsin
            VerileriDoldur(); // Sefer ekleme formunu doldur

            this.ActiveControl = null;

            // Tablo Stil Ayarları
            StilAyarla(dgvSatislar);
            StilAyarla(dgvPersonel);
        }

        private void StilAyarla(DataGridView dgv)
        {
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 8);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
        }

        // --- RADIO BUTTON OLAYLARI (GÖRÜNÜM DEĞİŞTİRME) ---

        private void rbSatislar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSatislar.Checked)
            {
                SatisRaporuGetir();
            }
        }

        private void rbSeferler_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSeferler.Checked)
            {
                SeferleriListele();
            }
        }

        // --- VERİ ÇEKME METOTLARI ---

        private void SatisRaporuGetir()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            t.TicketNo as 'Bilet No', 
                            u.FullName as 'Satan/Alan',
                            r.Name as 'Rota', 
                            t.FinalPrice as 'Tutar' 
                        FROM Tickets t
                        JOIN Users u ON t.UserId = u.Id
                        JOIN Trips tr ON t.TripId = tr.Id
                        JOIN Routes r ON tr.RouteId = r.Id
                        ORDER BY t.Id DESC";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSatislar.DataSource = dt;
                    }
                }
            }
            catch { }
        }

        private void SeferleriListele()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            t.Id, 
                            r.Name as 'Güzergah',
                            v.PlateNumber as 'Araç',
                            u.FullName as 'Sürücü',
                            strftime('%d.%m.%Y %H:%M', t.DepartureTime) as 'Tarih',
                            t.Price as 'Fiyat',
                            t.AvailableSeats as 'Boş Koltuk'
                        FROM Trips t
                        JOIN Routes r ON t.RouteId = r.Id
                        JOIN Vehicles v ON t.VehicleId = v.Id
                        JOIN Drivers d ON t.DriverId = d.Id
                        JOIN Users u ON d.UserId = u.Id
                        ORDER BY t.DepartureTime DESC";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSatislar.DataSource = dt;

                        if (dgvSatislar.Columns["Id"] != null)
                            dgvSatislar.Columns["Id"].Visible = false; // ID'yi gizle
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seferler listelenirken hata: " + ex.Message);
            }
        }

        // --- 1. PERSONEL YÖNETİMİ ---

        private void PersonelListele()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Id, FullName as 'Ad Soyad', Email, Phone FROM Users WHERE UserType = 2";
                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPersonel.DataSource = dt;
                        if (dgvPersonel.Columns["Id"] != null) dgvPersonel.Columns["Id"].Visible = false;
                    }
                }
            }
            catch { }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ad ve E-mail boş olamaz.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (FullName, Email, PasswordHash, UserType) VALUES (@ad, @mail, @pass, 2)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@pass", txtSifre.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Personel eklendi.");
                txtAd.Text = ""; txtEmail.Text = ""; txtSifre.Text = "";
                PersonelListele();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvPersonel.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvPersonel.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("Personeli silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    new SQLiteCommand($"DELETE FROM Users WHERE Id={id}", conn).ExecuteNonQuery();
                }
                PersonelListele();
            }
        }

        // --- 3. YENİ SEFER PLANLAMA ---

        private void VerileriDoldur()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Güzergahları Doldur
                    cmbGuzergah.Items.Clear();
                    string sqlRoute = "SELECT Id, Name FROM Routes WHERE IsActive = 1";
                    using (var cmd = new SQLiteCommand(sqlRoute, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbGuzergah.Items.Add(new ComboBoxItem { Text = dr["Name"].ToString(), Value = dr["Id"] });
                        }
                    }

                    // Araçları Doldur
                    cmbArac.Items.Clear();
                    string sqlVehicle = "SELECT Id, PlateNumber, Capacity FROM Vehicles WHERE IsActive = 1 AND Status = 0";
                    using (var cmd = new SQLiteCommand(sqlVehicle, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbArac.Items.Add(new ComboBoxItem { Text = dr["PlateNumber"].ToString() + " (" + dr["Capacity"] + " Kişilik)", Value = dr["Id"] });
                        }
                    }

                    // Şoförleri Doldur
                    cmbSofor.Items.Clear();
                    string sqlDriver = @"SELECT d.Id, u.FullName 
                                         FROM Drivers d 
                                         JOIN Users u ON d.UserId = u.Id 
                                         WHERE d.IsAvailable = 1";
                    using (var cmd = new SQLiteCommand(sqlDriver, conn))
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbSofor.Items.Add(new ComboBoxItem { Text = dr["FullName"].ToString(), Value = dr["Id"] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message);
            }
        }

        private void btnSeferKaydet_Click(object sender, EventArgs e)
        {
            if (cmbGuzergah.SelectedItem == null || cmbArac.SelectedItem == null || cmbSofor.SelectedItem == null || string.IsNullOrWhiteSpace(txtSeferFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            try
            {
                int routeId = Convert.ToInt32(((ComboBoxItem)cmbGuzergah.SelectedItem).Value);
                int vehicleId = Convert.ToInt32(((ComboBoxItem)cmbArac.SelectedItem).Value);
                int driverId = Convert.ToInt32(((ComboBoxItem)cmbSofor.SelectedItem).Value);
                decimal price = Convert.ToDecimal(txtSeferFiyat.Text);
                DateTime departureTime = dtpTarih.Value;

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    int capacity = 0;
                    int duration = 300;

                    using (var cmd = new SQLiteCommand("SELECT Capacity FROM Vehicles WHERE Id = " + vehicleId, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null) capacity = Convert.ToInt32(result);
                    }

                    using (var cmd = new SQLiteCommand("SELECT Duration FROM Routes WHERE Id = " + routeId, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null) duration = Convert.ToInt32(result);
                    }

                    DateTime arrivalTime = departureTime.AddMinutes(duration);

                    string insertSql = @"INSERT INTO Trips 
                                        (RouteId, VehicleId, DriverId, DepartureTime, ArrivalTime, Price, AvailableSeats, Status) 
                                        VALUES 
                                        (@rid, @vid, @did, @dep, @arr, @price, @seats, 0)";

                    using (var cmd = new SQLiteCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@rid", routeId);
                        cmd.Parameters.AddWithValue("@vid", vehicleId);
                        cmd.Parameters.AddWithValue("@did", driverId);
                        cmd.Parameters.AddWithValue("@dep", departureTime);
                        cmd.Parameters.AddWithValue("@arr", arrivalTime);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@seats", capacity);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sefer başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbGuzergah.SelectedIndex = -1;
                cmbArac.SelectedIndex = -1;
                cmbSofor.SelectedIndex = -1;
                txtSeferFiyat.Text = "";

                // Listeyi Yenile (Eğer Seferler sekmesi açıksa)
                if (rbSeferler.Checked) SeferleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sefer oluşturulurken hata: " + ex.Message);
            }
        }

        private void dgvSatislar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSatislar.ClearSelection();
            dgvSatislar.CurrentCell = null;
        }

        private void dgvPersonel_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPersonel.ClearSelection();
            dgvPersonel.CurrentCell = null;
        }
    }
}