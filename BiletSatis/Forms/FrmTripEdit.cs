using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmTripEdit : Form
    {
        private int agencyId;
        private int? tripId;
        private ComboBox cmbRoute;
        private ComboBox cmbVehicle;
        private DateTimePicker dtpDepartureDate;
        private DateTimePicker dtpDepartureTime;
        private DateTimePicker dtpArrivalTime;
        private NumericUpDown numPrice;
        private Button btnSave;
        private Button btnCancel;

        public FrmTripEdit(int agencyId, int? tripId = null)
        {
            this.agencyId = agencyId;
            this.tripId = tripId;
            InitializeComponents();
            LoadRoutes();
            LoadVehicles();
            if (tripId.HasValue) LoadTrip();
        }

        private void InitializeComponents()
        {
            this.Text = tripId.HasValue ? "Sefer Düzenle" : "Yeni Sefer Ekle";
            this.Size = new Size(450, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 20;
            int spacing = 55;

            // Rota
            AddLabel("Güzergah *", 20, y);
            cmbRoute = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(390, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbRoute);
            y += spacing;

            // Araç
            AddLabel("Araç *", 20, y);
            cmbVehicle = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(390, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbVehicle);
            y += spacing;

            // Tarih ve Kalkış Saati
            AddLabel("Kalkış Tarihi *", 20, y);
            AddLabel("Kalkış Saati *", 170, y);
            AddLabel("Varış Saati *", 290, y);

            dtpDepartureDate = new DateTimePicker
            {
                Location = new Point(20, y + 22),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today
            };
            this.Controls.Add(dtpDepartureDate);

            dtpDepartureTime = new DateTimePicker
            {
                Location = new Point(170, y + 22),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };
            this.Controls.Add(dtpDepartureTime);

            dtpArrivalTime = new DateTimePicker
            {
                Location = new Point(290, y + 22),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };
            this.Controls.Add(dtpArrivalTime);
            y += spacing;

            // Fiyat
            AddLabel("Bilet Fiyatı (₺) *", 20, y);
            numPrice = new NumericUpDown
            {
                Location = new Point(20, y + 22),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 50000,
                Value = 100,
                DecimalPlaces = 2
            };
            this.Controls.Add(numPrice);
            y += spacing + 20;

            // Butonlar
            btnSave = new Button
            {
                Text = "💾 Kaydet",
                Location = new Point(200, y),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(310, y),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }

        private void AddLabel(string text, int x, int y)
        {
            this.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            });
        }

        private void LoadRoutes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT r.Id, s1.Name || ' → ' || s2.Name AS RouteName
                                   FROM Routes r
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   WHERE r.AgencyId = @AgencyId AND r.IsActive = 1
                                   ORDER BY s1.Name";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbRoute.Items.Clear();
                            while (reader.Read())
                            {
                                cmbRoute.Items.Add(new ComboItem(
                                    reader["RouteName"].ToString(),
                                    Convert.ToInt32(reader["Id"])
                                ));
                            }
                            if (cmbRoute.Items.Count > 0)
                                cmbRoute.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rota yükleme hatası: " + ex.Message);
            }
        }

        private void LoadVehicles()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT Id, PlateNumber || ' - ' || Brand || ' ' || Model || ' (' || Capacity || ' koltuk)' AS VehicleName
                                   FROM Vehicles
                                   WHERE AgencyId = @AgencyId AND Status = 0 AND IsActive = 1
                                   ORDER BY PlateNumber";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            cmbVehicle.Items.Clear();
                            while (reader.Read())
                            {
                                cmbVehicle.Items.Add(new ComboItem(
                                    reader["VehicleName"].ToString(),
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
                MessageBox.Show("Araç yükleme hatası: " + ex.Message);
            }
        }

        private void LoadTrip()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Trips WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", tripId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Route seç
                                int routeId = Convert.ToInt32(reader["RouteId"]);
                                for (int i = 0; i < cmbRoute.Items.Count; i++)
                                {
                                    if (((ComboItem)cmbRoute.Items[i]).Value == routeId)
                                    {
                                        cmbRoute.SelectedIndex = i;
                                        break;
                                    }
                                }

                                // Vehicle seç
                                int vehicleId = Convert.ToInt32(reader["VehicleId"]);
                                for (int i = 0; i < cmbVehicle.Items.Count; i++)
                                {
                                    if (((ComboItem)cmbVehicle.Items[i]).Value == vehicleId)
                                    {
                                        cmbVehicle.SelectedIndex = i;
                                        break;
                                    }
                                }

                                var departure = Convert.ToDateTime(reader["DepartureTime"]);
                                var arrival = Convert.ToDateTime(reader["ArrivalTime"]);

                                dtpDepartureDate.Value = departure.Date;
                                dtpDepartureTime.Value = departure;
                                dtpArrivalTime.Value = arrival;
                                numPrice.Value = Convert.ToDecimal(reader["Price"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme hatası: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRoute.SelectedItem == null)
            {
                MessageBox.Show("Lütfen güzergah seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbVehicle.SelectedItem == null)
            {
                MessageBox.Show("Lütfen araç seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var routeItem = (ComboItem)cmbRoute.SelectedItem;
            var vehicleItem = (ComboItem)cmbVehicle.SelectedItem;

            DateTime departureDateTime = dtpDepartureDate.Value.Date.Add(dtpDepartureTime.Value.TimeOfDay);
            DateTime arrivalDateTime = dtpDepartureDate.Value.Date.Add(dtpArrivalTime.Value.TimeOfDay);

            // Varış ertesi gün ise
            if (arrivalDateTime <= departureDateTime)
                arrivalDateTime = arrivalDateTime.AddDays(1);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Araç kapasitesini al
                    int capacity = 46;
                    string capSql = "SELECT Capacity FROM Vehicles WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(capSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", vehicleItem.Value);
                        var result = cmd.ExecuteScalar();
                        if (result != null) capacity = Convert.ToInt32(result);
                    }

                    string sql;
                    if (tripId.HasValue)
                    {
                        sql = @"UPDATE Trips SET RouteId = @RouteId, VehicleId = @VehicleId,
                                DepartureTime = @Departure, ArrivalTime = @Arrival, Price = @Price
                                WHERE Id = @Id";
                    }
                    else
                    {
                        sql = @"INSERT INTO Trips (RouteId, VehicleId, DepartureTime, ArrivalTime, Price, AvailableSeats, Status, CreatedAt)
                                VALUES (@RouteId, @VehicleId, @Departure, @Arrival, @Price, @Capacity, 0, @CreatedAt)";
                    }

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RouteId", routeItem.Value);
                        cmd.Parameters.AddWithValue("@VehicleId", vehicleItem.Value);
                        cmd.Parameters.AddWithValue("@Departure", departureDateTime);
                        cmd.Parameters.AddWithValue("@Arrival", arrivalDateTime);
                        cmd.Parameters.AddWithValue("@Price", numPrice.Value);

                        if (tripId.HasValue)
                            cmd.Parameters.AddWithValue("@Id", tripId.Value);
                        else
                        {
                            cmd.Parameters.AddWithValue("@Capacity", capacity);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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