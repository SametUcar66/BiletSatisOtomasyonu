using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlFuelEntry : Panel
    {
        private int? driverId;
        private ComboBox cmbVehicle;
        private ComboBox cmbTrip;
        private NumericUpDown numLiters;
        private NumericUpDown numPricePerLiter;
        private Label lblTotalCost;
        private NumericUpDown numOdometer;
        private TextBox txtFuelStation;
        private TextBox txtReceiptNo;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnClear;

        public PnlFuelEntry()
        {
            GetDriverId();
            InitializeComponents();
            LoadVehicles();
            LoadTrips();
        }

        private void GetDriverId()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Id FROM Drivers WHERE UserId = @UserId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            driverId = Convert.ToInt32(result);
                    }
                }
            }
            catch { }
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Ana kart
            var pnlCard = new Panel
            {
                Location = new Point(30, 30),
                Size = new Size(500, 480),
                BackColor = Color.White
            };
            this.Controls.Add(pnlCard);

            var lblTitle = new Label
            {
                Text = "⛽ Yakıt Girişi",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblTitle);

            int y = 55;
            int spacing = 55;

            // Araç seçimi
            AddLabel(pnlCard, "Araç *", 20, y);
            cmbVehicle = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(220, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlCard.Controls.Add(cmbVehicle);

            // Sefer seçimi (opsiyonel)
            AddLabel(pnlCard, "Sefer (Opsiyonel)", 260, y);
            cmbTrip = new ComboBox
            {
                Location = new Point(260, y + 22),
                Size = new Size(220, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlCard.Controls.Add(cmbTrip);
            y += spacing;

            // Litre
            AddLabel(pnlCard, "Litre *", 20, y);
            numLiters = new NumericUpDown
            {
                Location = new Point(20, y + 22),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 1000,
                DecimalPlaces = 1,
                Value = 50
            };
            numLiters.ValueChanged += CalculateTotal;
            pnlCard.Controls.Add(numLiters);

            // Birim fiyat
            AddLabel(pnlCard, "Birim Fiyat (₺/L) *", 160, y);
            numPricePerLiter = new NumericUpDown
            {
                Location = new Point(160, y + 22),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 100,
                DecimalPlaces = 2,
                Value = 42
            };
            numPricePerLiter.ValueChanged += CalculateTotal;
            pnlCard.Controls.Add(numPricePerLiter);

            // Toplam tutar (hesaplanır)
            AddLabel(pnlCard, "Toplam Tutar", 280, y);
            lblTotalCost = new Label
            {
                Text = "₺2.100,00",
                Location = new Point(280, y + 22),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113)
            };
            pnlCard.Controls.Add(lblTotalCost);
            y += spacing;

            // Kilometre
            AddLabel(pnlCard, "Kilometre Sayacı", 20, y);
            numOdometer = new NumericUpDown
            {
                Location = new Point(20, y + 22),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 9999999,
                Value = 0
            };
            pnlCard.Controls.Add(numOdometer);

            // Akaryakıt istasyonu
            AddLabel(pnlCard, "Akaryakıt İstasyonu", 160, y);
            txtFuelStation = new TextBox
            {
                Location = new Point(160, y + 22),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };
            pnlCard.Controls.Add(txtFuelStation);

            // Fiş numarası
            AddLabel(pnlCard, "Fiş No", 330, y);
            txtReceiptNo = new TextBox
            {
                Location = new Point(330, y + 22),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10)
            };
            pnlCard.Controls.Add(txtReceiptNo);
            y += spacing;

            // Notlar
            AddLabel(pnlCard, "Notlar", 20, y);
            txtNotes = new TextBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(440, 60),
                Font = new Font("Segoe UI", 10),
                Multiline = true
            };
            pnlCard.Controls.Add(txtNotes);
            y += 90;

            // Butonlar
            btnSave = new Button
            {
                Text = "💾 Kaydet",
                Location = new Point(250, y),
                Size = new Size(120, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            pnlCard.Controls.Add(btnSave);

            btnClear = new Button
            {
                Text = "🔄 Temizle",
                Location = new Point(380, y),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;
            pnlCard.Controls.Add(btnClear);

            // İlk hesaplama
            CalculateTotal(null, null);
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

        private void CalculateTotal(object sender, EventArgs e)
        {
            decimal total = numLiters.Value * numPricePerLiter.Value;
            lblTotalCost.Text = $"₺{total:N2}";
        }

        private void LoadVehicles()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Şoförün bağlı olduğu ajansın araçlarını getir
                    string sql = @"SELECT v.Id, v.PlateNumber || ' - ' || v.Brand || ' ' || v.Model AS Display
                                   FROM Vehicles v
                                   INNER JOIN Drivers d ON v.AgencyId = d.AgencyId
                                   WHERE d.UserId = @UserId AND v.IsActive = 1 AND v.Status = 0
                                   ORDER BY v.PlateNumber";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbVehicle.Items.Clear();
                            while (reader.Read())
                            {
                                cmbVehicle.Items.Add(new ComboItem(
                                    reader["Display"].ToString(),
                                    Convert.ToInt32(reader["Id"])
                                ));
                            }
                            if (cmbVehicle.Items.Count > 0)
                                cmbVehicle.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrips()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT t.Id, 
                                   DATE(t.DepartureTime) || ' ' || s1.Name || ' → ' || s2.Name AS Display
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                                   WHERE d.UserId = @UserId 
                                   AND DATE(t.DepartureTime) >= DATE('now', '-7 days')
                                   ORDER BY t.DepartureTime DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbTrip.Items.Clear();
                            cmbTrip.Items.Add(new ComboItem("-- Sefer seçin (opsiyonel) --", 0));
                            while (reader.Read())
                            {
                                cmbTrip.Items.Add(new ComboItem(
                                    reader["Display"].ToString(),
                                    Convert.ToInt32(reader["Id"])
                                ));
                            }
                            cmbTrip.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!driverId.HasValue)
            {
                MessageBox.Show("Şoför bilgisi bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbVehicle.SelectedItem == null)
            {
                MessageBox.Show("Lütfen araç seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vehicleItem = (ComboItem)cmbVehicle.SelectedItem;
            var tripItem = cmbTrip.SelectedItem as ComboItem;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO FuelRecords 
                                   (VehicleId, DriverId, TripId, Liters, PricePerLiter, TotalCost, 
                                    Odometer, FuelStation, ReceiptNo, Date, Notes)
                                   VALUES 
                                   (@VehicleId, @DriverId, @TripId, @Liters, @PricePerLiter, @TotalCost,
                                    @Odometer, @FuelStation, @ReceiptNo, @Date, @Notes)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@VehicleId", vehicleItem.Value);
                        cmd.Parameters.AddWithValue("@DriverId", driverId.Value);
                        cmd.Parameters.AddWithValue("@TripId", tripItem != null && tripItem.Value > 0 ? (object)tripItem.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Liters", numLiters.Value);
                        cmd.Parameters.AddWithValue("@PricePerLiter", numPricePerLiter.Value);
                        cmd.Parameters.AddWithValue("@TotalCost", numLiters.Value * numPricePerLiter.Value);
                        cmd.Parameters.AddWithValue("@Odometer", numOdometer.Value > 0 ? (object)(int)numOdometer.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@FuelStation", string.IsNullOrEmpty(txtFuelStation.Text) ? (object)DBNull.Value : txtFuelStation.Text.Trim());
                        cmd.Parameters.AddWithValue("@ReceiptNo", string.IsNullOrEmpty(txtReceiptNo.Text) ? (object)DBNull.Value : txtReceiptNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(txtNotes.Text) ? (object)DBNull.Value : txtNotes.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    // Araç KM güncelle
                    if (numOdometer.Value > 0)
                    {
                        string updateSql = "UPDATE Vehicles SET TotalKm = @Km WHERE Id = @Id AND TotalKm < @Km";
                        using (var cmd = new SQLiteCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Km", (int)numOdometer.Value);
                            cmd.Parameters.AddWithValue("@Id", vehicleItem.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    $"✅ Yakıt kaydı başarıyla eklendi!\n\n" +
                    $"Litre: {numLiters.Value:N1} L\n" +
                    $"Tutar: ₺{(numLiters.Value * numPricePerLiter.Value):N2}",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                BtnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            numLiters.Value = 50;
            numPricePerLiter.Value = 42;
            numOdometer.Value = 0;
            txtFuelStation.Clear();
            txtReceiptNo.Clear();
            txtNotes.Clear();
            if (cmbTrip.Items.Count > 0)
                cmbTrip.SelectedIndex = 0;
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