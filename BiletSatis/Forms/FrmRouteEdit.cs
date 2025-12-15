using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmRouteEdit : Form
    {
        private int agencyId;
        private int? routeId;
        private TextBox txtName;
        private ComboBox cmbDeparture;
        private ComboBox cmbArrival;
        private NumericUpDown numDistance;
        private NumericUpDown numDurationHours;
        private NumericUpDown numDurationMinutes;
        private NumericUpDown numBasePrice;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnCancel;

        public FrmRouteEdit(int agencyId, int? routeId = null)
        {
            this.agencyId = agencyId;
            this.routeId = routeId;
            InitializeComponents();
            LoadStations();
            if (routeId.HasValue) LoadRoute();
        }

        private void InitializeComponents()
        {
            this.Text = routeId.HasValue ? "Rota Düzenle" : "Yeni Rota Ekle";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 20;
            int spacing = 55;

            // Rota Adı
            AddLabel("Rota Adı *", 20, y);
            txtName = AddTextBox(20, y + 22, 390);
            y += spacing;

            // Kalkış İstasyonu
            AddLabel("Kalkış İstasyonu *", 20, y);
            cmbDeparture = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(185, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbDeparture);

            // Varış İstasyonu
            AddLabel("Varış İstasyonu *", 220, y);
            cmbArrival = new ComboBox
            {
                Location = new Point(220, y + 22),
                Size = new Size(185, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbArrival);
            y += spacing;

            // Mesafe
            AddLabel("Mesafe (km)", 20, y);
            numDistance = new NumericUpDown
            {
                Location = new Point(20, y + 22),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 5000,
                Value = 0
            };
            this.Controls.Add(numDistance);

            // Süre
            AddLabel("Süre (Saat : Dakika)", 150, y);
            numDurationHours = new NumericUpDown
            {
                Location = new Point(150, y + 22),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 48,
                Value = 0
            };
            this.Controls.Add(numDurationHours);

            var lblColon = new Label
            {
                Text = ":",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(215, y + 22),
                AutoSize = true
            };
            this.Controls.Add(lblColon);

            numDurationMinutes = new NumericUpDown
            {
                Location = new Point(230, y + 22),
                Size = new Size(60, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 59,
                Value = 0
            };
            this.Controls.Add(numDurationMinutes);
            y += spacing;

            // Taban Fiyat
            AddLabel("Taban Fiyat (₺) *", 20, y);
            numBasePrice = new NumericUpDown
            {
                Location = new Point(20, y + 22),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 50000,
                Value = 100,
                DecimalPlaces = 2
            };
            this.Controls.Add(numBasePrice);

            // Aktif
            chkActive = new CheckBox
            {
                Text = "Aktif",
                Location = new Point(180, y + 22),
                Font = new Font("Segoe UI", 10),
                Checked = true,
                AutoSize = true
            };
            this.Controls.Add(chkActive);
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

        private TextBox AddTextBox(int x, int y, int width)
        {
            var txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 25),
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txt);
            return txt;
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
                        while (reader.Read())
                        {
                            var item = new ComboItem(reader["DisplayName"].ToString(), Convert.ToInt32(reader["Id"]));
                            cmbDeparture.Items.Add(item);
                            cmbArrival.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstasyon yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoute()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Routes WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", routeId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                
                                int depId = Convert.ToInt32(reader["DepartureStationId"]);
                                int arrId = Convert.ToInt32(reader["ArrivalStationId"]);
                                
                                for (int i = 0; i < cmbDeparture.Items.Count; i++)
                                {
                                    if (((ComboItem)cmbDeparture.Items[i]).Value == depId)
                                        cmbDeparture.SelectedIndex = i;
                                    if (((ComboItem)cmbArrival.Items[i]).Value == arrId)
                                        cmbArrival.SelectedIndex = i;
                                }

                                if (reader["Distance"] != DBNull.Value)
                                    numDistance.Value = Convert.ToInt32(reader["Distance"]);
                                
                                if (reader["Duration"] != DBNull.Value)
                                {
                                    int duration = Convert.ToInt32(reader["Duration"]);
                                    numDurationHours.Value = duration / 60;
                                    numDurationMinutes.Value = duration % 60;
                                }

                                numBasePrice.Value = Convert.ToDecimal(reader["BasePrice"]);
                                chkActive.Checked = Convert.ToInt32(reader["IsActive"]) == 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Rota adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (cmbDeparture.SelectedItem == null || cmbArrival.SelectedItem == null)
            {
                MessageBox.Show("Kalkış ve varış istasyonlarını seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var depItem = (ComboItem)cmbDeparture.SelectedItem;
            var arrItem = (ComboItem)cmbArrival.SelectedItem;

            if (depItem.Value == arrItem.Value)
            {
                MessageBox.Show("Kalkış ve varış istasyonu aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql;

                    if (routeId.HasValue)
                    {
                        sql = @"UPDATE Routes SET Name = @Name, DepartureStationId = @DepId, ArrivalStationId = @ArrId,
                                Distance = @Distance, Duration = @Duration, BasePrice = @Price, IsActive = @Active
                                WHERE Id = @Id";
                    }
                    else
                    {
                        sql = @"INSERT INTO Routes (AgencyId, Name, DepartureStationId, ArrivalStationId, Distance, Duration, BasePrice, IsActive)
                                VALUES (@AgencyId, @Name, @DepId, @ArrId, @Distance, @Duration, @Price, @Active)";
                    }

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        if (!routeId.HasValue)
                            cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        else
                            cmd.Parameters.AddWithValue("@Id", routeId.Value);

                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@DepId", depItem.Value);
                        cmd.Parameters.AddWithValue("@ArrId", arrItem.Value);
                        cmd.Parameters.AddWithValue("@Distance", (int)numDistance.Value);
                        cmd.Parameters.AddWithValue("@Duration", (int)(numDurationHours.Value * 60 + numDurationMinutes.Value));
                        cmd.Parameters.AddWithValue("@Price", numBasePrice.Value);
                        cmd.Parameters.AddWithValue("@Active", chkActive.Checked ? 1 : 0);

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