using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlTicketSale : Panel
    {
        private ComboBox cmbFrom;
        private ComboBox cmbTo;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private DataGridView dgvTrips;
        private Button btnSellTicket;
        private Label lblCount;

        public PnlTicketSale()
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
                Height = 100,
                BackColor = Color.White
            };
            this.Controls.Add(pnlSearch);

            var lblTitle = new Label
            {
                Text = "🎫 Bilet Satışı",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true
            };
            pnlSearch.Controls.Add(lblTitle);

            // Nereden
            AddLabel(pnlSearch, "Nereden", 20, 45);
            cmbFrom = new ComboBox
            {
                Location = new Point(20, 65),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlSearch.Controls.Add(cmbFrom);

            // Nereye
            AddLabel(pnlSearch, "Nereye", 220, 45);
            cmbTo = new ComboBox
            {
                Location = new Point(220, 65),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlSearch.Controls.Add(cmbTo);

            // Tarih
            AddLabel(pnlSearch, "Tarih", 420, 45);
            dtpDate = new DateTimePicker
            {
                Location = new Point(420, 65),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today
            };
            pnlSearch.Controls.Add(dtpDate);

            // Ara
            btnSearch = new Button
            {
                Text = "🔍 Ara",
                Location = new Point(570, 60),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += BtnSearch_Click;
            pnlSearch.Controls.Add(btnSearch);

            lblCount = new Label
            {
                Text = "",
                Location = new Point(690, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlSearch.Controls.Add(lblCount);

            // Sonuçlar
            dgvTrips = new DataGridView
            {
                Location = new Point(15, 115),
                Size = new Size(this.Width - 30, this.Height - 180),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10)
            };
            dgvTrips.RowTemplate.Height = 45;
            dgvTrips.CellDoubleClick += (s, e) => BtnSellTicket_Click(s, e);
            this.Controls.Add(dgvTrips);

            // Alt panel
            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White
            };
            this.Controls.Add(pnlBottom);

            btnSellTicket = new Button
            {
                Text = "🎫 Bilet Sat",
                Location = new Point(20, 10),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSellTicket.FlatAppearance.BorderSize = 0;
            btnSellTicket.Click += BtnSellTicket_Click;
            pnlBottom.Controls.Add(btnSellTicket);
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
                        cmbFrom.Items.Add(new ComboItem("Tümü", 0));
                        cmbTo.Items.Add(new ComboItem("Tümü", 0));

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
                MessageBox.Show("İstasyon yükleme hatası: " + ex.Message);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchTrips();
        }

        private void SearchTrips()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    var fromItem = cmbFrom.SelectedItem as ComboItem;
                    var toItem = cmbTo.SelectedItem as ComboItem;

                    string sql = @"SELECT t.Id, 
                                   a.Name AS 'Firma',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   v.PlateNumber AS 'Araç',
                                   TIME(t.DepartureTime) AS 'Kalkış',
                                   TIME(t.ArrivalTime) AS 'Varış',
                                   t.Price AS 'Fiyat',
                                   t.AvailableSeats AS 'Boş Koltuk'
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   INNER JOIN Agencies a ON v.AgencyId = a.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   WHERE DATE(t.DepartureTime) = @Date
                                   AND t.Status = 0
                                   AND t.AvailableSeats > 0";

                    // Ajans filtresi (çalışan sadece kendi ajansının seferlerini görsün)
                    if (SessionManager.CurrentAgencyId.HasValue)
                        sql += " AND v.AgencyId = @AgencyId";

                    if (fromItem != null && fromItem.Value > 0)
                        sql += " AND r.DepartureStationId = @FromId";

                    if (toItem != null && toItem.Value > 0)
                        sql += " AND r.ArrivalStationId = @ToId";

                    sql += " ORDER BY t.DepartureTime";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToString("yyyy-MM-dd"));

                        if (SessionManager.CurrentAgencyId.HasValue)
                            cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId.Value);

                        if (fromItem != null && fromItem.Value > 0)
                            cmd.Parameters.AddWithValue("@FromId", fromItem.Value);

                        if (toItem != null && toItem.Value > 0)
                            cmd.Parameters.AddWithValue("@ToId", toItem.Value);

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTrips.DataSource = dt;

                            if (dgvTrips.Columns.Contains("Id"))
                                dgvTrips.Columns["Id"].Visible = false;

                            lblCount.Text = dt.Rows.Count > 0 ? $"{dt.Rows.Count} sefer" : "Sefer bulunamadı";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama hatası: " + ex.Message);
            }
        }

        private void BtnSellTicket_Click(object sender, EventArgs e)
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

            using (var form = new FrmSellTicket(tripId, firma, kalkis, fiyat))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SearchTrips();
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