using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class AjentaAdmin : UserControl
    {
        public AjentaAdmin()
        {
            InitializeComponent();
        }

        private void AjentaAdmin_Load(object sender, EventArgs e)
        {
            PersonelListele();
            SatisRaporuGetir();
            this.ActiveControl = null;
        }

        // 1. PERSONEL LİSTELEME (Sadece Acente Çalışanları - RoleID: 2)
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
                    }
                }
            }
            catch { }
        }

        // 2. YENİ ÇALIŞAN EKLEME
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
                    // UserType = 2 (Acente Çalışanı) olarak ekliyoruz
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
                txtAd.Clear(); txtEmail.Clear(); txtSifre.Clear();
                PersonelListele();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        // 3. ÇALIŞAN SİLME
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

        // 4. SATIŞ RAPORU (Tüm Biletler)
        private void SatisRaporuGetir()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            t.TicketNo, 
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