using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlSalesManagement : Panel
    {
        private DataGridView dgvSales;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnRefresh;
        private Label lblCount;
        private Label lblTotal;

        public PnlSalesManagement()
        {
            InitializeComponents();
            LoadSales();
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
                Text = "🎫 Bilet Satışları",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Tarih aralığı
            var lblFrom = new Label
            {
                Text = "Başlangıç:",
                Location = new Point(180, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblFrom);

            dtpFrom = new DateTimePicker
            {
                Location = new Point(250, 16),
                Size = new Size(120, 25),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today.AddDays(-7)
            };
            dtpFrom.ValueChanged += (s, e) => LoadSales();
            pnlToolbar.Controls.Add(dtpFrom);

            var lblTo = new Label
            {
                Text = "Bitiş:",
                Location = new Point(385, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblTo);

            dtpTo = new DateTimePicker
            {
                Location = new Point(425, 16),
                Size = new Size(120, 25),
                Format = DateTimePickerFormat.Short
            };
            dtpTo.ValueChanged += (s, e) => LoadSales();
            pnlToolbar.Controls.Add(dtpTo);

            btnRefresh = new Button
            {
                Text = "🔄 Yenile",
                Location = new Point(560, 12),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadSales();
            pnlToolbar.Controls.Add(btnRefresh);

            lblCount = new Label
            {
                Text = "0 satış",
                Location = new Point(680, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            lblTotal = new Label
            {
                Text = "Toplam: ₺0",
                Location = new Point(780, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(39, 174, 96)
            };
            pnlToolbar.Controls.Add(lblTotal);

            // DataGridView
            dgvSales = new DataGridView
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
            dgvSales.RowTemplate.Height = 40;
            this.Controls.Add(dgvSales);
        }

        private void LoadSales()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT tk.Id,
                                   tk.PNR AS 'PNR',
                                   u.FullName AS 'Yolcu',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   DATE(t.DepartureTime) AS 'Sefer Tarihi',
                                   TIME(t.DepartureTime) AS 'Saat',
                                   tk.SeatNumber AS 'Koltuk',
                                   tk.FinalPrice AS 'Fiyat',
                                   DATE(tk.PurchaseDate) AS 'Satış Tarihi',
                                   COALESCE(seller.FullName, 'Online') AS 'Satan',
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
                                   INNER JOIN Users u ON tk.UserId = u.Id
                                   LEFT JOIN Users seller ON tk.SoldBy = seller.Id
                                   WHERE v.AgencyId = @AgencyId
                                   AND DATE(tk.PurchaseDate) BETWEEN @FromDate AND @ToDate
                                   ORDER BY tk.PurchaseDate DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId ?? 0);
                        cmd.Parameters.AddWithValue("@FromDate", dtpFrom.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ToDate", dtpTo.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvSales.DataSource = dt;

                            if (dgvSales.Columns.Contains("Id"))
                                dgvSales.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} satış";

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