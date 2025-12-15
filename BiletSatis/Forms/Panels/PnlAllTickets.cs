using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms.Panels
{
    public class PnlAllTickets : Panel
    {
        private DataGridView dgvTickets;
        private DateTimePicker dtpDate;
        private ComboBox cmbStatus;
        private Button btnRefresh;
        private Label lblCount;
        private Label lblTotal;

        public PnlAllTickets()
        {
            InitializeComponents();
            LoadTickets();
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
                Text = "🎫 Tüm Biletler",
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
            dtpDate.ValueChanged += (s, e) => LoadTickets();
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
            cmbStatus.Items.AddRange(new object[] { "Tümü", "Aktif", "Kullanıldı", "İptal" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => LoadTickets();
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
            btnRefresh.Click += (s, e) => LoadTickets();
            pnlToolbar.Controls.Add(btnRefresh);

            lblCount = new Label
            {
                Text = "0 bilet",
                Location = new Point(700, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            lblTotal = new Label
            {
                Text = "Toplam: ₺0",
                Location = new Point(800, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96)
            };
            pnlToolbar.Controls.Add(lblTotal);

            // DataGridView
            dgvTickets = new DataGridView
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
            dgvTickets.RowTemplate.Height = 40;
            this.Controls.Add(dgvTickets);
        }

        private void LoadTickets()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT tk.Id,
                                   tk.PNR AS 'PNR',
                                   u.FullName AS 'Yolcu',
                                   a.Name AS 'Ajans',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   DATE(t.DepartureTime) AS 'Tarih',
                                   TIME(t.DepartureTime) AS 'Saat',
                                   tk.SeatNumber AS 'Koltuk',
                                   tk.FinalPrice AS 'Fiyat',
                                   CASE tk.Status 
                                       WHEN 1 THEN '✅ Aktif'
                                       WHEN 2 THEN '🎫 Kullanıldı'
                                       WHEN 3 THEN '❌ İptal'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum'
                                   FROM Tickets tk
                                   INNER JOIN Trips t ON tk.TripId = t.Id
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   INNER JOIN Agencies a ON v.AgencyId = a.Id
                                   INNER JOIN Users u ON tk.UserId = u.Id
                                   WHERE DATE(tk.PurchaseDate) = @Date";

                    // Durum filtresi
                    if (cmbStatus.SelectedIndex > 0)
                    {
                        sql += $" AND tk.Status = {cmbStatus.SelectedIndex}";
                    }

                    sql += " ORDER BY tk.PurchaseDate DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTickets.DataSource = dt;

                            if (dgvTickets.Columns.Contains("Id"))
                                dgvTickets.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} bilet";

                            // Toplam hesapla
                            decimal total = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["Fiyat"] != DBNull.Value)
                                    total += Convert.ToDecimal(row["Fiyat"]);
                            }
                            lblTotal.Text = $"Toplam: ₺{total:N0}";
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