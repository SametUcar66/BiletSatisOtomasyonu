using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlFuelManagement : Panel
    {
        private DataGridView dgvFuel;
        private ComboBox cmbVehicle;
        private ComboBox cmbDriver;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnFilter;
        private Button btnExport;
        private Label lblCount;
        private Label lblTotalLiters;
        private Label lblTotalCost;

        public PnlFuelManagement()
        {
            InitializeComponents();
            LoadFilters();
            LoadFuelRecords();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Üst araç çubuğu
            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            var lblTitle = new Label
            {
                Text = "⛽ Yakıt Takibi",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Filtre satırı
            int y = 45;

            // Araç filtresi
            AddLabel(pnlToolbar, "Araç:", 15, y);
            cmbVehicle = new ComboBox
            {
                Location = new Point(55, y - 3),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlToolbar.Controls.Add(cmbVehicle);

            // Şoför filtresi
            AddLabel(pnlToolbar, "Şoför:", 220, y);
            cmbDriver = new ComboBox
            {
                Location = new Point(265, y - 3),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlToolbar.Controls.Add(cmbDriver);

            // Tarih aralığı
            AddLabel(pnlToolbar, "Başlangıç:", 430, y);
            dtpStartDate = new DateTimePicker
            {
                Location = new Point(495, y - 3),
                Size = new Size(110, 25),
                Font = new Font("Segoe UI", 9),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddMonths(-1)
            };
            pnlToolbar.Controls.Add(dtpStartDate);

            AddLabel(pnlToolbar, "Bitiş:", 615, y);
            dtpEndDate = new DateTimePicker
            {
                Location = new Point(655, y - 3),
                Size = new Size(110, 25),
                Font = new Font("Segoe UI", 9),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };
            pnlToolbar.Controls.Add(dtpEndDate);

            // Filtrele butonu
            btnFilter = new Button
            {
                Text = "🔍 Filtrele",
                Location = new Point(780, y - 5),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += (s, e) => LoadFuelRecords();
            pnlToolbar.Controls.Add(btnFilter);

            // Özet bilgiler
            y = 80;
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
                Location = new Point(120, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219)
            };
            pnlToolbar.Controls.Add(lblTotalLiters);

            lblTotalCost = new Label
            {
                Text = "Maliyet: ₺0",
                Location = new Point(250, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60)
            };
            pnlToolbar.Controls.Add(lblTotalCost);

            // DataGridView
            dgvFuel = new DataGridView
            {
                Location = new Point(15, 125),
                Size = new Size(this.Width - 30, this.Height - 140),
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

        private void LoadFilters()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int agencyId = SessionManager.CurrentAgencyId ?? 0;

                    // Araçları yükle
                    cmbVehicle.Items.Clear();
                    cmbVehicle.Items.Add(new ComboItem("Tümü", 0));

                    string vehicleSql = "SELECT Id, PlateNumber FROM Vehicles WHERE AgencyId = @AgencyId AND IsActive = 1 ORDER BY PlateNumber";
                    using (var cmd = new SQLiteCommand(vehicleSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbVehicle.Items.Add(new ComboItem(
                                    reader["PlateNumber"].ToString(),
                                    Convert.ToInt32(reader["Id"])
                                ));
                            }
                        }
                    }
                    cmbVehicle.SelectedIndex = 0;

                    // Şoförleri yükle
                    cmbDriver.Items.Clear();
                    cmbDriver.Items.Add(new ComboItem("Tümü", 0));

                    string driverSql = @"SELECT d.Id, u.FullName FROM Drivers d
                                         INNER JOIN Users u ON d.UserId = u.Id
                                         WHERE d.AgencyId = @AgencyId ORDER BY u.FullName";
                    using (var cmd = new SQLiteCommand(driverSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbDriver.Items.Add(new ComboItem(
                                    reader["FullName"].ToString(),
                                    Convert.ToInt32(reader["Id"])
                                ));
                            }
                        }
                    }
                    cmbDriver.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filtre yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFuelRecords()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    int agencyId = SessionManager.CurrentAgencyId ?? 0;

                    string sql = @"SELECT f.Id,
                                   v.PlateNumber AS 'Araç',
                                   u.FullName AS 'Şoför',
                                   printf('%.1f', f.Liters) || ' L' AS 'Litre',
                                   '₺' || printf('%.2f', f.PricePerLiter) AS 'Birim Fiyat',
                                   '₺' || printf('%.2f', f.TotalCost) AS 'Toplam',
                                   f.Odometer AS 'KM',
                                   f.FuelStation AS 'İstasyon',
                                   f.ReceiptNo AS 'Fiş No',
                                   DATE(f.Date) AS 'Tarih',
                                   f.Notes AS 'Not',
                                   f.Liters AS LitersVal,
                                   f.TotalCost AS CostVal
                                   FROM FuelRecords f
                                   INNER JOIN Vehicles v ON f.VehicleId = v.Id
                                   INNER JOIN Drivers d ON f.DriverId = d.Id
                                   INNER JOIN Users u ON d.UserId = u.Id
                                   WHERE v.AgencyId = @AgencyId
                                   AND DATE(f.Date) BETWEEN @StartDate AND @EndDate";

                    // Araç filtresi
                    var vehicleItem = cmbVehicle.SelectedItem as ComboItem;
                    if (vehicleItem != null && vehicleItem.Value > 0)
                        sql += " AND f.VehicleId = @VehicleId";

                    // Şoför filtresi
                    var driverItem = cmbDriver.SelectedItem as ComboItem;
                    if (driverItem != null && driverItem.Value > 0)
                        sql += " AND f.DriverId = @DriverId";

                    sql += " ORDER BY f.Date DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.ToString("yyyy-MM-dd"));

                        if (vehicleItem != null && vehicleItem.Value > 0)
                            cmd.Parameters.AddWithValue("@VehicleId", vehicleItem.Value);

                        if (driverItem != null && driverItem.Value > 0)
                            cmd.Parameters.AddWithValue("@DriverId", driverItem.Value);

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvFuel.DataSource = dt;

                            // Gizli sütunlar
                            if (dgvFuel.Columns.Contains("Id"))
                                dgvFuel.Columns["Id"].Visible = false;
                            if (dgvFuel.Columns.Contains("LitersVal"))
                                dgvFuel.Columns["LitersVal"].Visible = false;
                            if (dgvFuel.Columns.Contains("CostVal"))
                                dgvFuel.Columns["CostVal"].Visible = false;

                            // Özet hesapla
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

        private class ComboItem
        {
            public string Text { get; }
            public int Value { get; }
            public ComboItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }
    }
}