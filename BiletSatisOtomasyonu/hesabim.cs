using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class Hesabim : Form
    {
        #region Alanlar

        private readonly int _userId;
        private string _profilePhotoBase64 = "";
        private string _originalEmail = "";
        private string _originalProfilePhotoBase64 = "";
        private string _originalFullName = "";
        private string _originalPhone = "";

        private readonly Color _inactiveTextColor = Color.FromArgb(180, 180, 180);
        private readonly Color _activeTextColor = Color.White;
        private readonly Color _inactiveBackColor = Color.FromArgb(45, 45, 60);
        private readonly Color _activeBackColor = Color.FromArgb(60, 60, 80);

        public event EventHandler ProfileUpdated;

        #endregion

        #region Constructor

        public Hesabim(int userId)
        {
            InitializeComponent();
            _userId = userId;
            SetupTextBoxEvents();
        }

        #endregion

        #region Form Yükleme

        private void Hesabim_Load(object sender, EventArgs e)
        {
            LoadUserData();
            LoadProfilePhoto();
            ApplyInitialStyles();
        }

        private void ApplyInitialStyles()
        {
            SetTextBoxInactiveStyle(txtFullName);
            SetTextBoxInactiveStyle(txtEmail);
            SetTextBoxInactiveStyle(txtPhone);
            SetTextBoxInactiveStyle(txtPassword);
            SetTextBoxInactiveStyle(txtNewPassword);
            SetTextBoxInactiveStyle(txtConfirmPassword);

            txtPassword.Text = "••••••••";
            txtPassword.PasswordChar = '\0';

            txtAccountType.ForeColor = Color.Gray;
            txtAgency.ForeColor = Color.Gray;
        }

        #endregion

        #region TextBox Event Ayarları

        private void SetupTextBoxEvents()
        {
            txtFullName.Enter += EditableTextBox_Enter;
            txtFullName.Leave += EditableTextBox_Leave;
            txtEmail.Enter += EditableTextBox_Enter;
            txtEmail.Leave += EditableTextBox_Leave;
            txtPhone.Enter += EditableTextBox_Enter;
            txtPhone.Leave += EditableTextBox_Leave;

            txtPassword.Enter += PasswordTextBox_Enter;
            txtPassword.Leave += PasswordTextBox_Leave;
            txtNewPassword.Enter += PasswordTextBox_Enter;
            txtNewPassword.Leave += PasswordTextBox_Leave;
            txtConfirmPassword.Enter += PasswordTextBox_Enter;
            txtConfirmPassword.Leave += PasswordTextBox_Leave;
        }

        private void EditableTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.ForeColor = _activeTextColor;
                textBox.BackColor = _activeBackColor;
            }
        }

        private void EditableTextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                SetTextBoxInactiveStyle(textBox);
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.ForeColor = _activeTextColor;
                textBox.BackColor = _activeBackColor;

                if (textBox == txtPassword && textBox.Text == "••••••••")
                {
                    textBox.Text = "";
                    textBox.PasswordChar = '*';
                }
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                SetTextBoxInactiveStyle(textBox);

                if (textBox == txtPassword && string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = "••••••••";
                    textBox.PasswordChar = '\0';
                }
            }
        }

        private void SetTextBoxInactiveStyle(TextBox textBox)
        {
            textBox.ForeColor = _inactiveTextColor;
            textBox.BackColor = _inactiveBackColor;
        }

        #endregion

        #region Veri Yükleme

        private void LoadUserData()
        {
            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                connection.Open();

                string query = @"SELECT u.*, r.role_name, a.agency_name, a.logo_url
                                 FROM users u
                                 LEFT JOIN roles r ON u.role_id = r.role_id
                                 LEFT JOIN agencies a ON u.agency_id = a.agency_id
                                 WHERE u.user_id = @userId";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", _userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["full_name"]?.ToString() ?? "";
                            txtEmail.Text = reader["email"]?.ToString() ?? "";
                            txtPhone.Text = reader["phone"]?.ToString() ?? "";
                            txtAccountType.Text = GetAccountTypeName(reader["role_name"]?.ToString());
                            txtAgency.Text = reader["agency_name"]?.ToString() ?? "";

                            _originalFullName = txtFullName.Text;
                            _originalEmail = txtEmail.Text;
                            _originalPhone = txtPhone.Text;

                            if (reader["logo_url"] != DBNull.Value)
                            {
                                _profilePhotoBase64 = reader["logo_url"].ToString();
                                _originalProfilePhotoBase64 = _profilePhotoBase64;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı bilgileri yüklenirken hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection?.Close();
                connection?.Dispose();
            }
        }

        private string GetAccountTypeName(string roleName)
        {
            switch (roleName)
            {
                case "SuperAdmin": return "Süper Admin";
                case "AgencyAdmin": return "Acenta Yöneticisi";
                case "Staff": return "Personel";
                case "Driver": return "Şoför";
                case "Passenger": return "Yolcu";
                default: return roleName ?? "Bilinmiyor";
            }
        }

        private void LoadProfilePhoto()
        {
            if (!string.IsNullOrEmpty(_profilePhotoBase64))
            {
                picProfilePhoto.Image = ConvertBase64ToImage(_profilePhotoBase64);
            }
            else
            {
                LoadDefaultImage();
            }
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private void LoadDefaultImage()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "images", "default.png");

            if (File.Exists(defaultImagePath))
            {
                picProfilePhoto.Image = Image.FromFile(defaultImagePath);
            }
            else
            {
                picProfilePhoto.BackColor = Color.Gray;
            }
        }

        #endregion

        #region Fotoğraf İşlemleri

        private void picProfilePhoto_Click(object sender, EventArgs e)
        {
            SelectPhoto();
        }

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            SelectPhoto();
        }

        private void SelectPhoto()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Profil Fotoğrafı Seçin";
                dialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var image = Image.FromFile(dialog.FileName);
                        picProfilePhoto.Image = image;
                        _profilePhotoBase64 = ConvertImageToBase64(image, dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenemedi: " + ex.Message,
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string ConvertImageToBase64(Image image, string filePath)
        {
            using (var ms = new MemoryStream())
            {
                var format = GetImageFormat(filePath);
                image.Save(ms, format);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private ImageFormat GetImageFormat(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".png": return ImageFormat.Png;
                case ".gif": return ImageFormat.Gif;
                case ".bmp": return ImageFormat.Bmp;
                default: return ImageFormat.Jpeg;
            }
        }

        #endregion

        #region Kaydet İşlemi

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            SQLiteConnection connection = null;

            try
            {
                connection = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                connection.Open();

                if (txtEmail.Text != _originalEmail && IsEmailExists(connection, txtEmail.Text))
                {
                    MessageBox.Show("Bu e-posta adresi zaten kullanılıyor!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateUserInfo(connection);

                if (!string.IsNullOrEmpty(txtNewPassword.Text) && !UpdatePassword(connection))
                    return;

                if (_profilePhotoBase64 != _originalProfilePhotoBase64)
                    UpdateLogo(connection);

                _originalFullName = txtFullName.Text;
                _originalEmail = txtEmail.Text;
                _originalPhone = txtPhone.Text;
                _originalProfilePhotoBase64 = _profilePhotoBase64;

                ProfileUpdated?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Bilgileriniz başarıyla güncellendi!",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearPasswordFields();
                ApplyInitialStyles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection?.Close();
                connection?.Dispose();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad Soyad boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-posta boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "••••••••")
                {
                    MessageBox.Show("Şifre değiştirmek için mevcut şifrenizi girin!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Yeni şifreler eşleşmiyor!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                    return false;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Yeni şifre en az 6 karakter olmalı!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsEmailExists(SQLiteConnection connection, string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @email AND user_id != @userId";
            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userId", _userId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void UpdateUserInfo(SQLiteConnection connection)
        {
            string query = @"UPDATE users 
                             SET full_name = @fullName, email = @email, phone = @phone 
                             WHERE user_id = @userId";

            using (var cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.ExecuteNonQuery();
            }
        }

        private bool UpdatePassword(SQLiteConnection connection)
        {
            string checkQuery = "SELECT password FROM users WHERE user_id = @userId";
            using (var cmd = new SQLiteCommand(checkQuery, connection))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);
                string currentPassword = cmd.ExecuteScalar()?.ToString();

                if (currentPassword != txtPassword.Text)
                {
                    MessageBox.Show("Mevcut şifre yanlış!",
                        "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }
            }

            string updateQuery = "UPDATE users SET password = @password WHERE user_id = @userId";
            using (var cmd = new SQLiteCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@password", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        private void UpdateLogo(SQLiteConnection connection)
        {
            if (string.IsNullOrEmpty(_profilePhotoBase64))
                return;

            string getAgencyQuery = "SELECT agency_id FROM users WHERE user_id = @userId";
            using (var cmd = new SQLiteCommand(getAgencyQuery, connection))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int agencyId = Convert.ToInt32(result);

                    string updateQuery = "UPDATE agencies SET logo_url = @logoUrl WHERE agency_id = @agencyId";
                    using (var updateCmd = new SQLiteCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@logoUrl", _profilePhotoBase64);
                        updateCmd.Parameters.AddWithValue("@agencyId", agencyId);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void ClearPasswordFields()
        {
            txtPassword.Text = "••••••••";
            txtPassword.PasswordChar = '\0';
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        #endregion

        #region İptal ve Hesap Silme

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Hesabınızı silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                "Hesap Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SQLiteConnection connection = null;

                try
                {
                    connection = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                    connection.Open();

                    string query = "DELETE FROM users WHERE user_id = @userId";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Hesabınız silindi. Uygulama kapatılacak.",
                        "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hesap silinirken hata: " + ex.Message,
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection?.Close();
                    connection?.Dispose();
                }
            }
        }

        #endregion
    }
}
