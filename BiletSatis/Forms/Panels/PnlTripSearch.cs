using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms.Panels
{
    public class PnlTripSearch : Panel
    {
        private ComboBox cmbFrom;
        private ComboBox cmbTo;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private DataGridView dgvTrips;
        private Button btnBuyTicket;
        private Label lblCount;

        public PnlTripSearch()
        {
            InitializeComponents();
            LoadStations();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Arama paneli
            var pnlSearch = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White
            };
            this.Controls.Add(pnlSearch);

            var lblTitle = new Label
            {
                Text = "🔍 Sefer Ara",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlSearch.Controls.Add(lblTitle);

            // Nereden
            AddLabel(pnlSearch, "Nereden", 20, 50);
            cmbFrom = new ComboBox
            {
                Location = new Point(20, 70),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlSearch.Controls.Add(cmbFrom);

            // Nereye
            AddLabel(pnlSearch, "Nereye", 240, 50);
            cmbTo = new ComboBox
            {
                Location = new Point(240, 70),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlSearch.Controls.Add(cmbTo);

            // Tarih
            AddLabel(pnlSearch, "Tarih", 460, 50);
            dtpDate = new DateTimePicker
            {
                Location = new Point(460, 70),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today
            };
            pnlSearch.Controls.Add(dtpDate);

            // Ara butonu
            btnSearch = new Button
            {
                Text = "🔍 Sefer Ara",
                Location = new Point(630, 65),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += BtnSearch_Click;
            pnlSearch.Controls.Add(btnSearch);

            // Sonuç sayısı
            lblCount = new Label
            {
                Text = "",
                Location = new Point(770, 75),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlSearch.Controls.Add(lblCount);

            // Sonuç tablosu
            dgvTrips = new DataGridView
            {
                Location = new Point(15, 135),
                Size = new Size(this.Width - 30, this.Height - 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10)
            };
            dgvTrips.RowTemplate.Height = 45;
            dgvTrips.CellDoubleClick += (s, e) => BtnBuyTicket_Click(s, e);
            this.Controls.Add(dgvTrips);

            // Alt panel
            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White
            };
            this.Controls.Add(pnlBottom);

            btnBuyTicket = new Button
            {
                Text = "🎫 Bilet Al",
                Location = new Point(20, 12),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnBuyTicket.FlatAppearance.BorderSize = 0;
            btnBuyTicket.Click += BtnBuyTicket_Click;
            pnlBottom.Controls.Add(btnBuyTicket);
        }

        private void AddLabel(Panel parent, string text, int x, int y)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            });
        }

        private void LoadStations()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Id, Name || ' (' || City || ')' AS DisplayName FROM Stations WHERE IsActive = 1 ORDER BY City, Name";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        cmbFrom.Items.Clear();
                        cmbTo.Items.Clear();
                        cmbFrom.Items.Add(new ComboItem("Seçiniz...", 0));
                        cmbTo.Items.Add(new ComboItem("Seçiniz...", 0));

                        while (reader.Read())
                        {
                            var item = new ComboItem(reader["DisplayName"].ToString(), Convert.ToInt32(reader["Id"]));
                            cmbFrom.Items.Add(item);
                            cmbTo.Items.Add(item);
                        }

                        cmbFrom.SelectedIndex = 0;
                        cmbTo.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstasyon yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var fromItem = cmbFrom.SelectedItem as ComboItem;
            var toItem = cmbTo.SelectedItem as ComboItem;

            if (fromItem == null || fromItem.Value == 0)
            {
                MessageBox.Show("Lütfen kalkış noktası seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (toItem == null || toItem.Value == 0)
            {
                MessageBox.Show("Lütfen varış noktası seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fromItem.Value == toItem.Value)
            {
                MessageBox.Show("Kalkış ve varış noktası aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchTrips(fromItem.Value, toItem.Value, dtpDate.Value.Date);
        }

        private void SearchTrips(int fromId, int toId, DateTime date)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT t.Id, 
                                   a.Name AS 'Firma',
                                   CASE v.VehicleType WHEN 0 THEN '🚌' ELSE '✈️' END || ' ' || v.Model AS 'Araç',
                                   TIME(t.DepartureTime) AS 'Kalkış',
                                   TIME(t.ArrivalTime) AS 'Varış',
                                   t.Price AS 'Fiyat',
                                   t.AvailableSeats AS 'Boş Koltuk',
                                   v.Capacity AS 'Kapasite'
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   INNER JOIN Agencies a ON v.AgencyId = a.Id
                                   WHERE r.DepartureStationId = @FromId 
                                   AND r.ArrivalStationId = @ToId
                                   AND DATE(t.DepartureTime) = @Date
                                   AND t.Status = 0
                                   AND t.AvailableSeats > 0
                                   ORDER BY t.DepartureTime";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromId", fromId);
                        cmd.Parameters.AddWithValue("@ToId", toId);
                        cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTrips.DataSource = dt;

                            if (dgvTrips.Columns.Contains("Id"))
                                dgvTrips.Columns["Id"].Visible = false;

                            lblCount.Text = dt.Rows.Count > 0 ? $"{dt.Rows.Count} sefer bulundu" : "Sefer bulunamadı";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuyTicket_Click(object sender, EventArgs e)
        {
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sefer seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["Id"].Value);
            string firma = dgvTrips.SelectedRows[0].Cells["Firma"].Value.ToString();
            string kalkis = dgvTrips.SelectedRows[0].Cells["Kalkış"].Value.ToString();
            decimal fiyat = Convert.ToDecimal(dgvTrips.SelectedRows[0].Cells["Fiyat"].Value);

            using (var form = new FrmBuyTicket(tripId, firma, kalkis, fiyat))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BtnSearch_Click(null, null); // Listeyi yenile
                }
            }
        }

        private class ComboItem
        {
            public string Text { get; }
            public int Value { get; }
            public ComboItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }
    }
}