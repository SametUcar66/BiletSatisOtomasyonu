using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmEmployeeAdd : Form
    {
        private int agencyId;
        private bool isManager;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private ComboBox cmbRole;
        private Button btnSave;
        private Button btnCancel;

        public FrmEmployeeAdd(int agencyId, bool isManager = false)
        {
            this.agencyId = agencyId;
            this.isManager = isManager;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = isManager ? "Yeni Yönetici Ekle" : "Yeni Çalışan Ekle";
            this.Size = new Size(400, 380);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 20;
            int spacing = 60;

            // Ad Soyad
            AddLabel("Ad Soyad *", 20, y);
            txtFullName = AddTextBox(20, y + 22, 340);
            y += spacing;

            // E-posta
            AddLabel("E-posta *", 20, y);
            txtEmail = AddTextBox(20, y + 22, 340);
            y += spacing;

            // Telefon
            AddLabel("Telefon", 20, y);
            txtPhone = AddTextBox(20, y + 22, 340);
            y += spacing;

            // Şifre
            AddLabel("Şifre * (İlk giriş için)", 20, y);
            txtPassword = AddTextBox(20, y + 22, 340);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Text = "123456"; // Varsayılan şifre
            y += spacing;

            // Rol
            AddLabel("Rol", 20, y);
            cmbRole = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.Add("👑 Yönetici");
            cmbRole.Items.Add("👤 Çalışan");
            cmbRole.SelectedIndex = isManager ? 0 : 1;
            this.Controls.Add(cmbRole);
            y += 70;

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
            var lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            this.Controls.Add(lbl);
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad Soyad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-posta boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // E-posta kontrolü
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (var cmd = new SQLiteCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Bu e-posta adresi zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                            return;
                        }
                    }

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Kullanıcı oluştur
                            int userType = cmbRole.SelectedIndex == 0 ? 1 : 2; // Manager veya Employee
                            string userSql = @"INSERT INTO Users (Email, PasswordHash, FullName, Phone, UserType, IsActive, CreatedAt)
                                              VALUES (@Email, @Password, @FullName, @Phone, @UserType, 1, @CreatedAt);
                                              SELECT last_insert_rowid();";

                            int userId;
                            using (var cmd = new SQLiteCommand(userSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                                cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);
                                cmd.Parameters.AddWithValue("@UserType", userType);
                                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                                userId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 2. Ajans çalışanı kaydı
                            string empSql = @"INSERT INTO AgencyEmployees (UserId, AgencyId, Role, HireDate)
                                             VALUES (@UserId, @AgencyId, @Role, @HireDate)";

                            using (var cmd = new SQLiteCommand(empSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedIndex);
                                cmd.Parameters.AddWithValue("@HireDate", DateTime.Now);

                                cmd.ExecuteNonQuery();
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

                MessageBox.Show($"Kullanıcı başarıyla eklendi.\n\nGiriş bilgileri:\nE-posta: {txtEmail.Text}\nŞifre: {txtPassword.Text}",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

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