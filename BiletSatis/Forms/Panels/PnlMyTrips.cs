using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlMyTrips : Panel
    {
        private DataGridView dgvTrips;
        private ComboBox cmbFilter;
        private Button btnRefresh;
        private Label lblCount;
        private Label lblInfo;

        public PnlMyTrips()
        {
            InitializeComponents();
            LoadTrips();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Araç çubuğu
            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            var lblTitle = new Label
            {
                Text = "🚌 Seferlerim",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Filtre
            var lblFilter = new Label
            {
                Text = "Göster:",
                Location = new Point(180, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblFilter);

            cmbFilter = new ComboBox
            {
                Location = new Point(230, 16),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbFilter.Items.AddRange(new object[] { 
                "Yaklaşan Seferler", 
                "Bugünkü Seferler", 
                "Tamamlanan Seferler",
                "Tüm Seferler" 
            });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(cmbFilter);

            btnRefresh = new Button
            {
                Text = "🔄 Yenile",
                Location = new Point(400, 12),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(btnRefresh);

            lblCount = new Label
            {
                Text = "0 sefer",
                Location = new Point(520, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // Bilgi paneli
            lblInfo = new Label
            {
                Text = "",
                Location = new Point(15, 70),
                Size = new Size(this.Width - 30, 25),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(41, 128, 185),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(lblInfo);

            // DataGridView
            dgvTrips = new DataGridView
            {
                Location = new Point(15, 100),
                Size = new Size(this.Width - 30, this.Height - 115),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 9)
            };
            dgvTrips.RowTemplate.Height = 45;
            this.Controls.Add(dgvTrips);
        }

        private void LoadTrips()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT t.Id,
                                   DATE(t.DepartureTime) AS 'Tarih',
                                   TIME(t.DepartureTime) AS 'Kalkış Saati',
                                   TIME(t.ArrivalTime) AS 'Varış Saati',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   v.PlateNumber AS 'Araç',
                                   v.Capacity - t.AvailableSeats || '/' || v.Capacity AS 'Doluluk',
                                   CASE t.Status 
                                       WHEN 0 THEN '⏳ Bekliyor'
                                       WHEN 1 THEN '🚌 Yolda'
                                       WHEN 2 THEN '✅ Tamamlandı'
                                       WHEN 3 THEN '❌ İptal'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum',
                                   t.Notes AS 'Not'
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                                   WHERE d.UserId = @UserId";

                    // Filtre uygula
                    switch (cmbFilter.SelectedIndex)
                    {
                        case 0: // Yaklaşan
                            sql += " AND t.DepartureTime > datetime('now') AND t.Status = 0";
                            break;
                        case 1: // Bugün
                            sql += " AND DATE(t.DepartureTime) = DATE('now')";
                            break;
                        case 2: // Tamamlanan
                            sql += " AND t.Status = 2";
                            break;
                    }

                    sql += " ORDER BY t.DepartureTime";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTrips.DataSource = dt;

                            if (dgvTrips.Columns.Contains("Id"))
                                dgvTrips.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} sefer";

                            // Bugünkü sefer bilgisi
                            UpdateTodayInfo(conn);

                            // Satır renklendirme
                            foreach (DataGridViewRow row in dgvTrips.Rows)
                            {
                                string durum = row.Cells["Durum"].Value?.ToString() ?? "";
                                if (durum.Contains("Yolda"))
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                                else if (durum.Contains("Tamamlandı"))
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 218);
                                else if (durum.Contains("İptal"))
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTodayInfo(SQLiteConnection conn)
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM Trips t
                               INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                               WHERE d.UserId = @UserId AND DATE(t.DepartureTime) = DATE('now')";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                    int todayCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (todayCount > 0)
                        lblInfo.Text = $"📅 Bugün {todayCount} seferiniz bulunuyor.";
                    else
                        lblInfo.Text = "📅 Bugün seferiniz bulunmuyor.";
                }
            }
            catch { lblInfo.Text = ""; }
        }
    }
}