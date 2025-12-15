using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlMySales : Panel
    {
        private DataGridView dgvSales;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnFilter;
        private Label lblCount;
        private Label lblTotalSales;
        private Label lblTotalRevenue;

        public PnlMySales()
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
                Height = 100,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            var lblTitle = new Label
            {
                Text = "📋 Satışlarım",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Tarih filtreleri
            int y = 45;
            AddLabel(pnlToolbar, "Başlangıç:", 15, y);
            dtpStartDate = new DateTimePicker
            {
                Location = new Point(85, y - 3),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.Date
            };
            pnlToolbar.Controls.Add(dtpStartDate);

            AddLabel(pnlToolbar, "Bitiş:", 220, y);
            dtpEndDate = new DateTimePicker
            {
                Location = new Point(265, y - 3),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };
            pnlToolbar.Controls.Add(dtpEndDate);

            btnFilter = new Button
            {
                Text = "🔍 Filtrele",
                Location = new Point(400, y - 5),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += (s, e) => LoadSales();
            pnlToolbar.Controls.Add(btnFilter);

            // Hızlı filtreler
            var btnToday = CreateQuickFilterButton("Bugün", 520, y);
            btnToday.Click += (s, e) => { dtpStartDate.Value = DateTime.Today; dtpEndDate.Value = DateTime.Now; LoadSales(); };
            pnlToolbar.Controls.Add(btnToday);

            var btnWeek = CreateQuickFilterButton("Bu Hafta", 590, y);
            btnWeek.Click += (s, e) => { dtpStartDate.Value = DateTime.Today.AddDays(-7); dtpEndDate.Value = DateTime.Now; LoadSales(); };
            pnlToolbar.Controls.Add(btnWeek);

            var btnMonth = CreateQuickFilterButton("Bu Ay", 670, y);
            btnMonth.Click += (s, e) => { dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); dtpEndDate.Value = DateTime.Now; LoadSales(); };
            pnlToolbar.Controls.Add(btnMonth);

            // Özet bilgiler
            y = 75;
            lblCount = new Label
            {
                Text = "0 satış",
                Location = new Point(15, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            lblTotalSales = new Label
            {
                Text = "Toplam: 0 bilet",
                Location = new Point(100, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219)
            };
            pnlToolbar.Controls.Add(lblTotalSales);

            lblTotalRevenue = new Label
            {
                Text = "Gelir: ₺0",
                Location = new Point(230, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113)
            };
            pnlToolbar.Controls.Add(lblTotalRevenue);

            // DataGridView
            dgvSales = new DataGridView
            {
                Location = new Point(15, 115),
                Size = new Size(this.Width - 30, this.Height - 130),
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
            dgvSales.RowTemplate.Height = 35;
            this.Controls.Add(dgvSales);
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

        private Button CreateQuickFilterButton(string text, int x, int y)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y - 5),
                Size = new Size(65, 28),
                BackColor = Color.FromArgb(236, 240, 241),
                ForeColor = Color.FromArgb(44, 62, 80),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadSales()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT t.Id,
                                   t.TicketNo AS 'Bilet No',
                                   t.PassengerName AS 'Yolcu',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   DATE(tr.DepartureTime) AS 'Sefer Tarihi',
                                   t.SeatNumber AS 'Koltuk',
                                   '₺' || printf('%.2f', t.FinalPrice) AS 'Tutar',
                                   CASE t.Status 
                                       WHEN 0 THEN '⏳ Rezerve'
                                       WHEN 1 THEN '✅ Aktif'
                                       WHEN 2 THEN '❌ İptal'
                                       WHEN 3 THEN '✔️ Kullanıldı'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum',
                                   DATETIME(t.PurchaseDate) AS 'Satış Zamanı',
                                   t.FinalPrice AS PriceVal
                                   FROM Tickets t
                                   INNER JOIN Trips tr ON t.TripId = tr.Id
                                   INNER JOIN Routes r ON tr.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   WHERE t.SoldBy = @UserId
                                   AND DATE(t.PurchaseDate) BETWEEN @StartDate AND @EndDate
                                   ORDER BY t.PurchaseDate DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvSales.DataSource = dt;

                            if (dgvSales.Columns.Contains("Id"))
                                dgvSales.Columns["Id"].Visible = false;
                            if (dgvSales.Columns.Contains("PriceVal"))
                                dgvSales.Columns["PriceVal"].Visible = false;

                            // Özet hesapla
                            decimal totalRevenue = 0;
                            int activeCount = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                string durum = row["Durum"].ToString();
                                if (durum.Contains("Aktif") || durum.Contains("Kullanıldı"))
                                {
                                    totalRevenue += Convert.ToDecimal(row["PriceVal"]);
                                    activeCount++;
                                }
                            }

                            lblCount.Text = $"{dt.Rows.Count} satış";
                            lblTotalSales.Text = $"Aktif: {activeCount} bilet";
                            lblTotalRevenue.Text = $"Gelir: ₺{totalRevenue:N2}";

                            // Satır renklendirme
                            foreach (DataGridViewRow row in dgvSales.Rows)
                            {
                                string durum = row.Cells["Durum"].Value?.ToString() ?? "";
                                if (durum.Contains("İptal"))
                                    row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                                else if (durum.Contains("Kullanıldı"))
                                    row.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
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
    }
}