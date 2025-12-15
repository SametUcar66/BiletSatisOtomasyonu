using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlFuelHistory : Panel
    {
        private DataGridView dgvFuel;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnFilter;
        private Label lblCount;
        private Label lblTotalLiters;
        private Label lblTotalCost;

        public PnlFuelHistory()
        {
            InitializeComponents();
            LoadFuelHistory();
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
                Text = "📋 Yakıt Geçmişim",
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
                Location = new Point(80, y - 3),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddMonths(-1)
            };
            pnlToolbar.Controls.Add(dtpStartDate);

            AddLabel(pnlToolbar, "Bitiş:", 215, y);
            dtpEndDate = new DateTimePicker
            {
                Location = new Point(260, y - 3),
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
            btnFilter.Click += (s, e) => LoadFuelHistory();
            pnlToolbar.Controls.Add(btnFilter);

            // Özet
            y = 75;
            lblCount = new Label
            {
                Text = "0 kayıt",
                Location = new Point(15, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            lblTotalLiters = new Label
            {
                Text = "Toplam: 0 L",
                Location = new Point(100, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219)
            };
            pnlToolbar.Controls.Add(lblTotalLiters);

            lblTotalCost = new Label
            {
                Text = "Maliyet: ₺0",
                Location = new Point(220, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 126, 34)
            };
            pnlToolbar.Controls.Add(lblTotalCost);

            // DataGridView
            dgvFuel = new DataGridView
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
            dgvFuel.RowTemplate.Height = 35;
            this.Controls.Add(dgvFuel);
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

        private void LoadFuelHistory()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT f.Id,
                                   v.PlateNumber AS 'Araç',
                                   printf('%.1f', f.Liters) || ' L' AS 'Litre',
                                   '₺' || printf('%.2f', f.PricePerLiter) AS 'Birim Fiyat',
                                   '₺' || printf('%.2f', f.TotalCost) AS 'Toplam',
                                   f.Odometer AS 'KM',
                                   f.FuelStation AS 'İstasyon',
                                   DATE(f.Date) AS 'Tarih',
                                   f.Notes AS 'Not',
                                   f.Liters AS LitersVal,
                                   f.TotalCost AS CostVal
                                   FROM FuelRecords f
                                   INNER JOIN Vehicles v ON f.VehicleId = v.Id
                                   INNER JOIN Drivers d ON f.DriverId = d.Id
                                   WHERE d.UserId = @UserId
                                   AND DATE(f.Date) BETWEEN @StartDate AND @EndDate
                                   ORDER BY f.Date DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvFuel.DataSource = dt;

                            if (dgvFuel.Columns.Contains("Id"))
                                dgvFuel.Columns["Id"].Visible = false;
                            if (dgvFuel.Columns.Contains("LitersVal"))
                                dgvFuel.Columns["LitersVal"].Visible = false;
                            if (dgvFuel.Columns.Contains("CostVal"))
                                dgvFuel.Columns["CostVal"].Visible = false;

                            // Özet
                            decimal totalLiters = 0;
                            decimal totalCost = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                totalLiters += Convert.ToDecimal(row["LitersVal"]);
                                totalCost += Convert.ToDecimal(row["CostVal"]);
                            }

                            lblCount.Text = $"{dt.Rows.Count} kayıt";
                            lblTotalLiters.Text = $"Toplam: {totalLiters:N1} L";
                            lblTotalCost.Text = $"Maliyet: ₺{totalCost:N2}";
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