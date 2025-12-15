using System;
using System.Data.SQLite;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmDriverEdit : Form
    {
        private int agencyId;
        private int? driverId;
        private int? existingUserId;

        // Kullanıcı bilgileri
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtTCNo;
        private TextBox txtPassword;

        // Şoför bilgileri
        private TextBox txtLicenseNumber;
        private ComboBox cmbLicenseType;
        private DateTimePicker dtpLicenseExpiry;
        private TextBox txtSrcNumber;
        private DateTimePicker dtpSrcExpiry;
        private DateTimePicker dtpPsychotechnicExpiry;
        private CheckBox chkAvailable;

        private Button btnSave;
        private Button btnCancel;

        public FrmDriverEdit(int agencyId, int? driverId = null)
        {
            this.agencyId = agencyId;
            this.driverId = driverId;
            InitializeComponents();
            if (driverId.HasValue) LoadDriver();
        }

        private void InitializeComponents()
        {
            this.Text = driverId.HasValue ? "Şoför Düzenle" : "Yeni Şoför Ekle";
            this.Size = new Size(500, 580);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 15;
            int spacing = 50;

            // === Kişisel Bilgiler ===
            var lblPersonal = new Label
            {
                Text = "👤 Kişisel Bilgiler",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, y),
                AutoSize = true
            };
            this.Controls.Add(lblPersonal);
            y += 30;

            // Ad Soyad
            AddLabel("Ad Soyad *", 15, y);
            txtFullName = AddTextBox(15, y + 20, 220);

            // E-posta
            AddLabel("E-posta *", 250, y);
            txtEmail = AddTextBox(250, y + 20, 220);
            y += spacing;

            // Telefon
            AddLabel("Telefon *", 15, y);
            txtPhone = AddTextBox(15, y + 20, 150);

            // TC No
            AddLabel("TC Kimlik No *", 180, y);
            txtTCNo = AddTextBox(180, y + 20, 130);
            txtTCNo.MaxLength = 11;

            // Şifre
            AddLabel(driverId.HasValue ? "Yeni Şifre" : "Şifre *", 325, y);
            txtPassword = AddTextBox(325, y + 20, 145);
            txtPassword.UseSystemPasswordChar = true;
            y += spacing + 15;

            // === Ehliyet Bilgileri ===
            var lblLicense = new Label
            {
                Text = "🚗 Ehliyet Bilgileri",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, y),
                AutoSize = true
            };
            this.Controls.Add(lblLicense);
            y += 30;

            // Ehliyet No
            AddLabel("Ehliyet No *", 15, y);
            txtLicenseNumber = AddTextBox(15, y + 20, 150);

            // Ehliyet Tipi
            AddLabel("Ehliyet Tipi *", 180, y);
            cmbLicenseType = new ComboBox
            {
                Location = new Point(180, y + 20),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLicenseType.Items.AddRange(new object[] { "B", "C", "D", "E" });
            cmbLicenseType.SelectedIndex = 2; // D sınıfı varsayılan
            this.Controls.Add(cmbLicenseType);

            // Ehliyet Bitiş
            AddLabel("Ehliyet Bitiş *", 280, y);
            dtpLicenseExpiry = new DateTimePicker
            {
                Location = new Point(280, y + 20),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today
            };
            this.Controls.Add(dtpLicenseExpiry);
            y += spacing + 15;

            // === SRC Bilgileri ===
            var lblSrc = new Label
            {
                Text = "📋 SRC Belgesi",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, y),
                AutoSize = true
            };
            this.Controls.Add(lblSrc);
            y += 30;

            // SRC No
            AddLabel("SRC No", 15, y);
            txtSrcNumber = AddTextBox(15, y + 20, 150);

            // SRC Bitiş
            AddLabel("SRC Bitiş", 180, y);
            dtpSrcExpiry = new DateTimePicker
            {
                Location = new Point(180, y + 20),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today,
                ShowCheckBox = true,
                Checked = false
            };
            this.Controls.Add(dtpSrcExpiry);

            // Psikoteknik Bitiş
            AddLabel("Psikoteknik Bitiş", 330, y);
            dtpPsychotechnicExpiry = new DateTimePicker
            {
                Location = new Point(330, y + 20),
                Size = new Size(130, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today,
                ShowCheckBox = true,
                Checked = false
            };
            this.Controls.Add(dtpPsychotechnicExpiry);
            y += spacing + 15;

            // Müsaitlik
            chkAvailable = new CheckBox
            {
                Text = "✅ Müsait (Sefere atanabilir)",
                Location = new Point(15, y),
                Font = new Font("Segoe UI", 10),
                Checked = true,
                AutoSize = true
            };
            this.Controls.Add(chkAvailable);
            y += 50;

            // === Butonlar ===
            btnSave = new Button
            {
                Text = "💾 Kaydet",
                Location = new Point(250, y),
                Size = new Size(110, 40),
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
                Location = new Point(370, y),
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

        private void LoadDriver()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT d.*, u.FullName, u.Email, u.Phone, u.TCNo
                                   FROM Drivers d
                                   INNER JOIN Users u ON d.UserId = u.Id
                                   WHERE d.Id = @Id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", driverId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                existingUserId = Convert.ToInt32(reader["UserId"]);

                                // Kullanıcı bilgileri
                                txtFullName.Text = reader["FullName"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtEmail.ReadOnly = true;
                                txtEmail.BackColor = Color.FromArgb(240, 240, 240);
                                txtPhone.Text = reader["Phone"]?.ToString() ?? "";
                                txtTCNo.Text = reader["TCNo"]?.ToString() ?? "";

                                // Şoför bilgileri
                                txtLicenseNumber.Text = reader["LicenseNumber"].ToString();

                                string licenseType = reader["LicenseType"]?.ToString() ?? "D";
                                int typeIndex = cmbLicenseType.Items.IndexOf(licenseType);
                                if (typeIndex >= 0) cmbLicenseType.SelectedIndex = typeIndex;

                                if (reader["LicenseExpiry"] != DBNull.Value)
                                    dtpLicenseExpiry.Value = Convert.ToDateTime(reader["LicenseExpiry"]);

                                txtSrcNumber.Text = reader["SrcNumber"]?.ToString() ?? "";

                                if (reader["SrcExpiry"] != DBNull.Value)
                                {
                                    dtpSrcExpiry.Checked = true;
                                    dtpSrcExpiry.Value = Convert.ToDateTime(reader["SrcExpiry"]);
                                }

                                if (reader["PsychotechnicExpiry"] != DBNull.Value)
                                {
                                    dtpPsychotechnicExpiry.Checked = true;
                                    dtpPsychotechnicExpiry.Value = Convert.ToDateTime(reader["PsychotechnicExpiry"]);
                                }

                                chkAvailable.Checked = Convert.ToInt32(reader["IsAvailable"]) == 1;
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
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad Soyad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Geçerli bir e-posta adresi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Telefon boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTCNo.Text) || txtTCNo.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik No 11 haneli olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTCNo.Focus();
                return;
            }

            if (!driverId.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("Ehliyet numarası boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseNumber.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int userId;

                            if (driverId.HasValue && existingUserId.HasValue)
                            {
                                // Kullanıcı güncelle
                                userId = existingUserId.Value;
                                string userSql = @"UPDATE Users SET FullName = @FullName, Phone = @Phone, TCNo = @TCNo";
                                
                                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                                    userSql += ", PasswordHash = @Password";
                                
                                userSql += " WHERE Id = @Id";

                                using (var cmd = new SQLiteCommand(userSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id", userId);
                                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                                    cmd.Parameters.AddWithValue("@TCNo", txtTCNo.Text.Trim());
                                    
                                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                                        cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text));
                                    
                                    cmd.ExecuteNonQuery();
                                }

                                // Şoför güncelle
                                string driverSql = @"UPDATE Drivers SET 
                                    LicenseNumber = @LicenseNumber, LicenseType = @LicenseType, LicenseExpiry = @LicenseExpiry,
                                    SrcNumber = @SrcNumber, SrcExpiry = @SrcExpiry, PsychotechnicExpiry = @PsychoExpiry,
                                    IsAvailable = @IsAvailable
                                    WHERE Id = @Id";

                                using (var cmd = new SQLiteCommand(driverSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id", driverId.Value);
                                    AddDriverParameters(cmd);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // E-posta kontrolü
                                string checkSql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                                using (var cmd = new SQLiteCommand(checkSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                                    {
                                        MessageBox.Show("Bu e-posta adresi zaten kullanılıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                // Yeni kullanıcı oluştur
                                string userSql = @"INSERT INTO Users (Email, PasswordHash, FullName, Phone, TCNo, UserType, IsActive, CreatedAt)
                                                   VALUES (@Email, @Password, @FullName, @Phone, @TCNo, 3, 1, @CreatedAt);
                                                   SELECT last_insert_rowid();";

                                using (var cmd = new SQLiteCommand(userSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text));
                                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                                    cmd.Parameters.AddWithValue("@TCNo", txtTCNo.Text.Trim());
                                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                                }

                                // Yeni şoför oluştur
                                string driverSql = @"INSERT INTO Drivers (UserId, AgencyId, LicenseNumber, LicenseType, LicenseExpiry, 
                                                     SrcNumber, SrcExpiry, PsychotechnicExpiry, IsAvailable)
                                                     VALUES (@UserId, @AgencyId, @LicenseNumber, @LicenseType, @LicenseExpiry,
                                                     @SrcNumber, @SrcExpiry, @PsychoExpiry, @IsAvailable)";

                                using (var cmd = new SQLiteCommand(driverSql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@UserId", userId);
                                    cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                                    AddDriverParameters(cmd);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
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

        private void AddDriverParameters(SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@LicenseType", cmbLicenseType.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@LicenseExpiry", dtpLicenseExpiry.Value);
            cmd.Parameters.AddWithValue("@SrcNumber", string.IsNullOrEmpty(txtSrcNumber.Text) ? (object)DBNull.Value : txtSrcNumber.Text.Trim());
            cmd.Parameters.AddWithValue("@SrcExpiry", dtpSrcExpiry.Checked ? (object)dtpSrcExpiry.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@PsychoExpiry", dtpPsychotechnicExpiry.Checked ? (object)dtpPsychotechnicExpiry.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IsAvailable", chkAvailable.Checked ? 1 : 0);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}