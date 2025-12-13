using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class TrenBileti : UserControl
    {
        private SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
        private int secilenSeferId = -1;
        private int secilenKoltukNo = -1;
        private decimal biletFiyati = 0;
        private List<int> doluKoltuklar = new List<int>();

            public TrenBileti()
        {
            InitializeComponent();
        }

        private void TrenBileti_Load(object sender, EventArgs e)
        {
            LoadTerminaller();
            SetupDataGridView();
        }

        #region Başlangıç Ayarları

        private void LoadTerminaller()
        {
            try
            {
                baglan.Open();

                string query = "SELECT id, name FROM terminals ORDER BY name";
                SQLiteCommand cmd = new SQLiteCommand(query, baglan);
                SQLiteDataReader reader = cmd.ExecuteReader();

                cmbKalkis.Items.Clear();
                cmbVaris.Items.Clear();

                cmbKalkis.Items.Add("-- Kalkış Seçin --");
                cmbVaris.Items.Add("-- Varış Seçin --");

                while (reader.Read())
                {
                    string terminalAdi = reader["name"].ToString();
                    cmbKalkis.Items.Add(terminalAdi);
                    cmbVaris.Items.Add(terminalAdi);
                }

                cmbKalkis.SelectedIndex = 0;
                cmbVaris.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terminal verileri yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        private void SetupDataGridView()
        {
            dgvSeferler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeferler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeferler.ReadOnly = true;
            dgvSeferler.AllowUserToAddRows = false;
            dgvSeferler.AllowUserToDeleteRows = false;

            // Koyu tema
            dgvSeferler.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvSeferler.ForeColor = Color.White;
            dgvSeferler.GridColor = Color.FromArgb(60, 60, 60);
            dgvSeferler.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvSeferler.DefaultCellStyle.ForeColor = Color.White;
            dgvSeferler.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvSeferler.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            dgvSeferler.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSeferler.EnableHeadersVisualStyles = false;
        }

        #endregion

        #region Sefer Arama

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (cmbKalkis.SelectedIndex <= 0 || cmbVaris.SelectedIndex <= 0)
            {
                MessageBox.Show("Lütfen kalkış ve varış noktalarını seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbKalkis.SelectedItem.ToString() == cmbVaris.SelectedItem.ToString())
            {
                MessageBox.Show("Kalkış ve varış noktaları aynı olamaz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SeferleriAra();
        }

        private void SeferleriAra()
        {
            try
            {
                baglan.Open();

                // Tren seferlerini ara (vehicle_types tablosundan tren tipini filtrele)
                string query = @"
                    SELECT 
                        t.id AS 'Sefer ID',
                        t.name AS 'Sefer Adı',
                        r.firstname AS 'Güzergah',
                        te.expenses AS 'Fiyat (₺)',
                        v.name AS 'Tren Adı'
                    FROM trips t
                    INNER JOIN routes r ON t.driver = r.id
                    INNER JOIN vehicles v ON t.vehicles = v.id
                    INNER JOIN vehicle_types vt ON v.vehicle_types = vt.agency
                    LEFT JOIN trip_expenses te ON t.id = te.trip_expenses
                    WHERE vt.vehicle_type = 'Tren'
                    ORDER BY t.name";

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, baglan);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aradığınız kriterlere uygun sefer bulunamadı.",
                        "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSeferler.DataSource = null;
                }
                else
                {
                    dgvSeferler.DataSource = dt;

                    // Sefer ID kolonunu gizle
                    if (dgvSeferler.Columns["Sefer ID"] != null)
                        dgvSeferler.Columns["Sefer ID"].Visible = false;
                }

                // Koltuk panelini temizle
                flpKoltuklar.Controls.Clear();
                secilenSeferId = -1;
                secilenKoltukNo = -1;
                lblSecilenKoltuk.Text = "Seçilen Koltuk: Yok";
                lblToplamFiyat.Text = "Toplam: 0.00 ₺";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sefer aranırken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        #endregion

        #region Koltuk Seçimi

        private void dgvSeferler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSeferler.Rows[e.RowIndex];
            secilenSeferId = Convert.ToInt32(row.Cells["Sefer ID"].Value);

            // Fiyatı al
            if (row.Cells["Fiyat (₺)"].Value != DBNull.Value)
            {
                biletFiyati = Convert.ToDecimal(row.Cells["Fiyat (₺)"].Value);
            }
            else
            {
                biletFiyati = 150; // Varsayılan fiyat
            }

            KoltuklariYukle();
        }

        private void KoltuklariYukle()
        {
            flpKoltuklar.Controls.Clear();
            doluKoltuklar.Clear();
            secilenKoltukNo = -1;
            lblSecilenKoltuk.Text = "Seçilen Koltuk: Yok";
            lblToplamFiyat.Text = "Toplam: 0.00 ₺";

            // Dolu koltukları veritabanından al
            try
            {
                baglan.Open();

                string query = @"SELECT s.seats FROM seats s 
                                 INNER JOIN tickets tk ON s.ticket = tk.id 
                                 WHERE tk.trip_expenses = @seferId";
                SQLiteCommand cmd = new SQLiteCommand(query, baglan);
                cmd.Parameters.AddWithValue("@seferId", secilenSeferId);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["seats"] != DBNull.Value)
                    {
                        doluKoltuklar.Add(Convert.ToInt32(reader["seats"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koltuk bilgileri yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }

            // Tren vagonu için 40 koltuk oluştur
            int toplamKoltuk = 40;

            for (int i = 1; i <= toplamKoltuk; i++)
            {
                Button btnKoltuk = new Button();
                btnKoltuk.Name = "btnKoltuk" + i;
                btnKoltuk.Text = i.ToString();
                btnKoltuk.Size = new Size(50, 50);
                btnKoltuk.FlatStyle = FlatStyle.Flat;
                btnKoltuk.FlatAppearance.BorderSize = 1;
                btnKoltuk.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnKoltuk.Tag = i;
                btnKoltuk.Margin = new Padding(5);

                if (doluKoltuklar.Contains(i))
                {
                    // Dolu koltuk - Kırmızı
                    btnKoltuk.BackColor = Color.FromArgb(192, 0, 0);
                    btnKoltuk.ForeColor = Color.White;
                    btnKoltuk.Enabled = false;
                }
                else
                {
                    // Boş koltuk - Yeşil
                    btnKoltuk.BackColor = Color.FromArgb(0, 150, 0);
                    btnKoltuk.ForeColor = Color.White;
                    btnKoltuk.Click += BtnKoltuk_Click;
                }

                flpKoltuklar.Controls.Add(btnKoltuk);
            }
        }

        private void BtnKoltuk_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int koltukNo = (int)clickedButton.Tag;

            // Önceki seçimi kaldır
            foreach (Control ctrl in flpKoltuklar.Controls)
            {
                if (ctrl is Button btn && btn.Enabled)
                {
                    btn.BackColor = Color.FromArgb(0, 150, 0);
                }
            }

            // Yeni seçimi işaretle
            clickedButton.BackColor = Color.FromArgb(0, 122, 204);
            secilenKoltukNo = koltukNo;

            lblSecilenKoltuk.Text = $"Seçilen Koltuk: {koltukNo}";
            lblToplamFiyat.Text = $"Toplam: {biletFiyati:N2} ₺";
        }

        #endregion

        #region Satın Alma

        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            if (secilenSeferId == -1)
            {
                MessageBox.Show("Lütfen bir sefer seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (secilenKoltukNo == -1)
            {
                MessageBox.Show("Lütfen bir koltuk seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Sefer: {secilenSeferId}\nKoltuk: {secilenKoltukNo}\nFiyat: {biletFiyati:N2} ₺\n\nSatın almak istiyor musunuz?",
                "Satın Alma Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BiletSatinAl();
            }
        }

        private void BiletSatinAl()
        {
            try
            {
                baglan.Open();

                // Bilet kaydı oluştur
                string insertTicket = @"INSERT INTO tickets (ticket, ticket_id, trip_expenses) 
                                        VALUES (@ticket, @ticketId, @tripId)";
                SQLiteCommand cmdTicket = new SQLiteCommand(insertTicket, baglan);
                cmdTicket.Parameters.AddWithValue("@ticket", "TRN-" + DateTime.Now.Ticks);
                cmdTicket.Parameters.AddWithValue("@ticketId", Guid.NewGuid().ToString().Substring(0, 8).ToUpper());
                cmdTicket.Parameters.AddWithValue("@tripId", secilenSeferId);
                cmdTicket.ExecuteNonQuery();

                // Son eklenen bilet ID'sini al
                long biletId = baglan.LastInsertRowId;

                // Koltuk kaydı oluştur
                string insertSeat = @"INSERT INTO seats (seats, ticket, ticketname, terminame) 
                                      VALUES (@seats, @ticket, @ticketname, @terminame)";
                SQLiteCommand cmdSeat = new SQLiteCommand(insertSeat, baglan);
                cmdSeat.Parameters.AddWithValue("@seats", secilenKoltukNo);
                cmdSeat.Parameters.AddWithValue("@ticket", biletId);
                cmdSeat.Parameters.AddWithValue("@ticketname", "Tren Bileti");
                cmdSeat.Parameters.AddWithValue("@terminame", cmbKalkis.SelectedItem.ToString() + " - " + cmbVaris.SelectedItem.ToString());
                cmdSeat.ExecuteNonQuery();

                MessageBox.Show(
                    $"🎉 Bilet başarıyla satın alındı!\n\nKoltuk No: {secilenKoltukNo}\nFiyat: {biletFiyati:N2} ₺",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Koltukları yeniden yükle
                KoltuklariYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilet satın alınırken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        #endregion
    }
}
