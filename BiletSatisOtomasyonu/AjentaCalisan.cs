using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class AjentaCalisan : UserControl
    {
        private int seciliSeferId = 0;
        private decimal seferFiyati = 0;

        public AjentaCalisan()
        {
            InitializeComponent();
        }

        private void AjentaCalisan_Load(object sender, EventArgs e)
        {
            SeferleriGetir();
            this.ActiveControl = null;
        }

        private void SeferleriGetir()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            t.Id, 
                            r.Name as 'Guzergah', 
                            t.DepartureTime as 'Tarih', 
                            t.Price as 'Fiyat'
                        FROM Trips t
                        JOIN Routes r ON t.RouteId = r.Id
                        WHERE t.Status = 1";

                    using (var da = new SQLiteDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSeferler.DataSource = dt;
                        if (dgvSeferler.Columns.Contains("Id")) dgvSeferler.Columns["Id"].Visible = false;
                    }
                }
            }
            catch { }
        }

        private void dgvSeferler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeferler.SelectedRows.Count > 0)
            {
                seciliSeferId = Convert.ToInt32(dgvSeferler.SelectedRows[0].Cells["Id"].Value);
                seferFiyati = Convert.ToDecimal(dgvSeferler.SelectedRows[0].Cells["Fiyat"].Value);
            }
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            if (seciliSeferId == 0 || string.IsNullOrWhiteSpace(txtKoltukNo.Text) || string.IsNullOrWhiteSpace(txtYolcuIsim.Text))
            {
                MessageBox.Show("Lütfen Sefer seçin, Koltuk No ve Yolcu Adı girin.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Koltuk dolu mu kontrolü (Basit kontrol)
                    string check = "SELECT COUNT(*) FROM Tickets WHERE TripId=@tid AND SeatNumber=@seat AND Status=1";
                    using (var cmdCheck = new SQLiteCommand(check, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@tid", seciliSeferId);
                        cmdCheck.Parameters.AddWithValue("@seat", txtKoltukNo.Text);
                        int dolu = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (dolu > 0) { MessageBox.Show("Bu koltuk dolu!"); return; }
                    }

                    // Satış Yap
                    string sql = @"INSERT INTO Tickets (TicketNo, TripId, UserId, PassengerName, SeatNumber, Price, FinalPrice, Status) 
                                   VALUES (@pnr, @tid, 1, @name, @seat, @price, @final, 1)";
                    // Not: UserId=1 (Admin/Sistem) veya giriş yapan Acente ID'si kullanılabilir.

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        string pnr = "ACN-" + DateTime.Now.Ticks.ToString().Substring(12);
                        cmd.Parameters.AddWithValue("@pnr", pnr);
                        cmd.Parameters.AddWithValue("@tid", seciliSeferId);
                        cmd.Parameters.AddWithValue("@name", txtYolcuIsim.Text);
                        cmd.Parameters.AddWithValue("@seat", txtKoltukNo.Text);
                        cmd.Parameters.AddWithValue("@price", seferFiyati);
                        cmd.Parameters.AddWithValue("@final", seferFiyati); // İndirimsiz
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Bilet Satıldı!");
                txtKoltukNo.Clear();
                txtYolcuIsim.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void dgvSeferler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSeferler.ClearSelection();
            dgvSeferler.CurrentCell = null;
        }
    }
}