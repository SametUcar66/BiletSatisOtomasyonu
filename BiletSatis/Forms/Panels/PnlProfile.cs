using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlProfile : Panel
    {
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtTCNo;
        private TextBox txtAddress;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnChangePassword;

        public PnlProfile()
        {
            InitializeComponents();
            LoadProfile();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.AutoScroll = true;

            // Profil Kartı
            var pnlCard = new Panel
            {
                Location = new Point(30, 30),
                Size = new Size(500, 400),
                BackColor = Color.White
            };
            this.Controls.Add(pnlCard);

            var lblTitle = new Label
            {
                Text = "👤 Profil Bilgileri",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblTitle);

            int y = 55;
            int spacing = 55;

            // Ad Soyad
            AddLabel(pnlCard, "Ad Soyad", 20, y);
            txtFullName = AddTextBox(pnlCard, 20, y + 20, 300);
            y += spacing;

            // E-posta (readonly)
            AddLabel(pnlCard, "E-posta", 20, y);
            txtEmail = AddTextBox(pnlCard, 20, y + 20, 300);
            txtEmail.ReadOnly = true;
            txtEmail.BackColor = Color.FromArgb(240, 240, 240);
            y += spacing;

            // Telefon
            AddLabel(pnlCard, "Telefon", 20, y);
            txtPhone = AddTextBox(pnlCard, 20, y + 20, 300);
            y += spacing;

            // TC No
            AddLabel(pnlCard, "TC Kimlik No", 20, y);
            txtTCNo = AddTextBox(pnlCard, 20, y + 20, 300);
            txtTCNo.MaxLength = 11;
            y += spacing;

            // Adres
            AddLabel(pnlCard, "Adres", 20, y);
            txtAddress = AddTextBox(pnlCard, 20, y + 20, 440);
            y += spacing + 10;

            // Kaydet butonu
            btnSave = new Button
            {
                Text = "💾 Bilgileri Kaydet",
                Location = new Point(20, y),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            pnlCard.Controls.Add(btnSave);

            // Şifre Değiştirme Kartı
            var pnlPassword = new Panel
            {
                Location = new Point(30, 450),
                Size = new Size(500, 250),
                BackColor = Color.White
            };
            this.Controls.Add(pnlPassword);

            var lblPasswordTitle = new Label
            {
                Text = "🔐 Şifre Değiştir",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlPassword.Controls.Add(lblPasswordTitle);

            y = 55;

            // Mevcut Şifre
            AddLabel(pnlPassword, "Mevcut Şifre", 20, y);
            txtCurrentPassword = AddTextBox(pnlPassword, 20, y + 20, 300);
            txtCurrentPassword.UseSystemPasswordChar = true;
            y += spacing;

            // Yeni Şifre
            AddLabel(pnlPassword, "Yeni Şifre", 20, y);
            txtNewPassword = AddTextBox(pnlPassword, 20, y + 20, 300);
            txtNewPassword.UseSystemPasswordChar = true;
            y += spacing;

            // Yeni Şifre Tekrar
            AddLabel(pnlPassword, "Yeni Şifre Tekrar", 20, y);
            txtConfirmPassword = AddTextBox(pnlPassword, 20, y + 20, 300);
            txtConfirmPassword.UseSystemPasswordChar = true;
            y += spacing;

            // Şifre Değiştir butonu
            btnChangePassword = new Button
            {
                Text = "🔑 Şifreyi Değiştir",
                Location = new Point(20, y - 10),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Click += BtnChangePassword_Click;
            pnlPassword.Controls.Add(btnChangePassword);
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

        private TextBox AddTextBox(Panel parent, int x, int y, int width)
        {
            var txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 25),
                Font = new Font("Segoe UI", 10)
            };
            parent.Controls.Add(txt);
            return txt;
        }

        private void LoadProfile()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return;

            txtFullName.Text = user.FullName;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.Phone;
            txtTCNo.Text = user.TCNo;
            txtAddress.Text = user.Address;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad Soyad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Users SET FullName = @FullName, Phone = @Phone, 
                                   TCNo = @TCNo, Address = @Address WHERE Id = @Id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);
                        cmd.Parameters.AddWithValue("@TCNo", string.IsNullOrEmpty(txtTCNo.Text) ? (object)DBNull.Value : txtTCNo.Text);
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Id", SessionManager.CurrentUser.Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Session güncelle
                SessionManager.CurrentUser.FullName = txtFullName.Text.Trim();
                SessionManager.CurrentUser.Phone = txtPhone.Text;
                SessionManager.CurrentUser.TCNo = txtTCNo.Text;
                SessionManager.CurrentUser.Address = txtAddress.Text;

                MessageBox.Show("Profil bilgileri güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("Mevcut şifrenizi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Yeni şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Yeni şifre en az 6 karakter olmalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Mevcut şifre kontrolü
                    string checkSql = "SELECT PasswordHash FROM Users WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", SessionManager.CurrentUser.Id);
                        string storedPassword = cmd.ExecuteScalar()?.ToString();

                        if (storedPassword != txtCurrentPassword.Text)
                        {
                            MessageBox.Show("Mevcut şifre hatalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Şifre güncelle
                    string updateSql = "UPDATE Users SET PasswordHash = @Password WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
                        cmd.Parameters.AddWithValue("@Id", SessionManager.CurrentUser.Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Şifreniz başarıyla değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}