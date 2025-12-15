using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms.Panels
{
    public class PnlAllTrips : Panel
    {
        private DataGridView dgvTrips;
        private DateTimePicker dtpDate;
        private ComboBox cmbStatus;
        private Button btnRefresh;
        private Label lblCount;

        public PnlAllTrips()
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
                Text = "🚌 Tüm Seferler",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Tarih filtresi
            var lblDate = new Label
            {
                Text = "Tarih:",
                Location = new Point(200, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblDate);

            dtpDate = new DateTimePicker
            {
                Location = new Point(245, 16),
                Size = new Size(130, 25),
                Format = DateTimePickerFormat.Short
            };
            dtpDate.ValueChanged += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(dtpDate);

            // Durum filtresi
            var lblStatus = new Label
            {
                Text = "Durum:",
                Location = new Point(390, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblStatus);

            cmbStatus = new ComboBox
            {
                Location = new Point(440, 16),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9)
            };
            cmbStatus.Items.AddRange(new object[] { "Tümü", "Planlandı", "Yolda", "Tamamlandı", "İptal" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(cmbStatus);

            btnRefresh = new Button
            {
                Text = "🔄 Yenile",
                Location = new Point(580, 12),
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
                Location = new Point(700, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvTrips = new DataGridView
            {
                Location = new Point(15, 70),
                Size = new Size(this.Width - 30, this.Height - 85),
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
            dgvTrips.RowTemplate.Height = 40;
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
                                   a.Name AS 'Ajans',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   v.PlateNumber AS 'Araç',
                                   DATE(t.DepartureTime) AS 'Tarih',
                                   TIME(t.DepartureTime) AS 'Kalkış',
                                   TIME(t.ArrivalTime) AS 'Varış',
                                   t.Price AS 'Fiyat',
                                   v.Capacity - t.AvailableSeats || '/' || v.Capacity AS 'Doluluk',
                                   CASE t.Status 
                                       WHEN 0 THEN '📅 Planlandı'
                                       WHEN 1 THEN '🚌 Yolda'
                                       WHEN 2 THEN '✅ Tamamlandı'
                                       WHEN 3 THEN '❌ İptal'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum'
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   INNER JOIN Agencies a ON v.AgencyId = a.Id
                                   WHERE DATE(t.DepartureTime) = @Date";

                    // Durum filtresi
                    if (cmbStatus.SelectedIndex > 0)
                    {
                        sql += $" AND t.Status = {cmbStatus.SelectedIndex - 1}";
                    }

                    sql += " ORDER BY t.DepartureTime";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTrips.DataSource = dt;

                            if (dgvTrips.Columns.Contains("Id"))
                                dgvTrips.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} sefer";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}