using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmVehicleEdit : Form
    {
        private int agencyId;
        private int? vehicleId;
        private TextBox txtPlate;
        private TextBox txtBrand;
        private TextBox txtModel;
        private ComboBox cmbType;
        private NumericUpDown numCapacity;
        private NumericUpDown numYear;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;

        public FrmVehicleEdit(int agencyId, int? vehicleId = null)
        {
            this.agencyId = agencyId;
            this.vehicleId = vehicleId;
            InitializeComponents();
            if (vehicleId.HasValue) LoadVehicle();
        }

        private void InitializeComponents()
        {
            this.Text = vehicleId.HasValue ? "Araç Düzenle" : "Yeni Araç Ekle";
            this.Size = new Size(400, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 20;
            int spacing = 50;

            // Plaka
            AddLabel("Plaka *", 20, y);
            txtPlate = AddTextBox(20, y + 20, 150);
            txtPlate.CharacterCasing = CharacterCasing.Upper;

            // Tip
            AddLabel("Araç Tipi *", 190, y);
            cmbType = new ComboBox
            {
                Location = new Point(190, y + 20),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbType.Items.Add("🚌 Otobüs");
            cmbType.Items.Add("✈️ Uçak");
            cmbType.SelectedIndex = 0;
            this.Controls.Add(cmbType);
            y += spacing + 10;

            // Marka
            AddLabel("Marka *", 20, y);
            txtBrand = AddTextBox(20, y + 20, 150);

            // Model
            AddLabel("Model *", 190, y);
            txtModel = AddTextBox(190, y + 20, 150);
            y += spacing + 10;

            // Kapasite
            AddLabel("Kapasite *", 20, y);
            numCapacity = new NumericUpDown
            {
                Location = new Point(20, y + 20),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 1,
                Maximum = 500,
                Value = 46
            };
            this.Controls.Add(numCapacity);

            // Yıl
            AddLabel("Yıl", 140, y);
            numYear = new NumericUpDown
            {
                Location = new Point(140, y + 20),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 2000,
                Maximum = DateTime.Now.Year + 1,
                Value = DateTime.Now.Year
            };
            this.Controls.Add(numYear);

            // Durum
            AddLabel("Durum", 240, y);
            cmbStatus = new ComboBox
            {
                Location = new Point(240, y + 20),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.Add("✅ Aktif");
            cmbStatus.Items.Add("🔧 Bakımda");
            cmbStatus.Items.Add("❌ Devre Dışı");
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);
            y += spacing + 30;

            // Butonlar
            btnSave = new Button
            {
                Text = "💾 Kaydet",
                Location = new Point(150, y),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(260, y),
                Size = new Size(100, 35),
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

        private void LoadVehicle()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Vehicles WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", vehicleId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtPlate.Text = reader["PlateNumber"].ToString();
                                txtBrand.Text = reader["Brand"] != DBNull.Value ? reader["Brand"].ToString() : "";
                                txtModel.Text = reader["Model"] != DBNull.Value ? reader["Model"].ToString() : "";
                                cmbType.SelectedIndex = Convert.ToInt32(reader["VehicleType"]);
                                numCapacity.Value = Convert.ToInt32(reader["Capacity"]);
                                if (reader["Year"] != DBNull.Value)
                                    numYear.Value = Convert.ToInt32(reader["Year"]);
                                cmbStatus.SelectedIndex = Convert.ToInt32(reader["Status"]);
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
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MessageBox.Show("Plaka boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlate.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBrand.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Marka ve model boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql;

                    if (vehicleId.HasValue)
                    {
                        sql = @"UPDATE Vehicles SET PlateNumber = @Plate, Brand = @Brand, Model = @Model,
                                VehicleType = @Type, Capacity = @Capacity, Year = @Year, Status = @Status
                                WHERE Id = @Id";
                    }
                    else
                    {
                        sql = @"INSERT INTO Vehicles (AgencyId, PlateNumber, Brand, Model, VehicleType, Capacity, Year, Status, IsActive)
                                VALUES (@AgencyId, @Plate, @Brand, @Model, @Type, @Capacity, @Year, @Status, 1)";
                    }

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        if (!vehicleId.HasValue)
                            cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        else
                            cmd.Parameters.AddWithValue("@Id", vehicleId.Value);

                        cmd.Parameters.AddWithValue("@Plate", txtPlate.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim());
                        cmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                        cmd.Parameters.AddWithValue("@Type", cmbType.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Capacity", (int)numCapacity.Value);
                        cmd.Parameters.AddWithValue("@Year", (int)numYear.Value);
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedIndex);

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
    }
}