using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu
{
    public partial class Hesabim : Form
    {
        private int userId;
        private string profilePhotoBase64 = "";
        private string originalEmail = "";
        private string originalProfilePhotoBase64 = "";

        // Orijinal değerler (veritabanından gelen)
        private string originalFullName = "";
        private string originalPhone = "";

        // Renk sabitleri
        private readonly Color inactiveTextColor = Color.FromArgb(180, 180, 180);
        private readonly Color activeTextColor = Color.White;
        private readonly Color inactiveBackColor = Color.FromArgb(45, 45, 60);
        private readonly Color activeBackColor = Color.FromArgb(60, 60, 80);

        // Profil güncellendiğinde tetiklenecek event
        public event EventHandler ProfileUpdated;

        public Hesabim(int userId)
        {
            InitializeComponent();  
            this.userId = userId;
            SetupTextBoxEvents();
        }

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
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.ForeColor = activeTextColor;
                textBox.BackColor = activeBackColor;
            }
        }

        private void EditableTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.ForeColor = inactiveTextColor;
                textBox.BackColor = inactiveBackColor;
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.ForeColor = activeTextColor;
                textBox.BackColor = activeBackColor;

                if (textBox == txtPassword && textBox.Text == "••••••••")
                {
                    textBox.Text = "";
                    textBox.PasswordChar = '*';
                }
            }
        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.ForeColor = inactiveTextColor;
                textBox.BackColor = inactiveBackColor;

                if (textBox == txtPassword && string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = "••••••••";
                    textBox.PasswordChar = '\0';
                }
            }
        }

        private void SetTextBoxInactiveStyle(TextBox textBox)
        {
            textBox.ForeColor = inactiveTextColor;
            textBox.BackColor = inactiveBackColor;
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

        private void LoadUserData()
        {
            SQLiteConnection baglan = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;

            try
            {
                baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                baglan.Open();

                string query = @"SELECT u.*, r.role_name, a.agency_name, a.logo_url
                                 FROM users u
                                 LEFT JOIN roles r ON u.role_id = r.role_id
                                 LEFT JOIN agencies a ON u.agency_id = a.agency_id
                                 WHERE u.user_id = @userId";

                cmd = new SQLiteCommand(query, baglan);
                cmd.Parameters.AddWithValue("@userId", userId);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["full_name"]?.ToString() ?? "";
                    txtEmail.Text = reader["email"]?.ToString() ?? "";
                    txtPhone.Text = reader["phone"]?.ToString() ?? "";
                    txtAccountType.Text = GetAccountTypeName(reader["role_name"]?.ToString());
                    txtAgency.Text = reader["agency_name"]?.ToString() ?? "";

                    originalFullName = txtFullName.Text;
                    originalEmail = txtEmail.Text;
                    originalPhone = txtPhone.Text;

                    if (reader["logo_url"] != DBNull.Value)
                    {
                        profilePhotoBase64 = reader["logo_url"].ToString();
                        originalProfilePhotoBase64 = profilePhotoBase64;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Kullanıcı bilgileri yüklenirken hata: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                cmd?.Dispose();
                baglan?.Close();
                baglan?.Dispose();
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
            if (!string.IsNullOrEmpty(profilePhotoBase64))
            {
                picProfilePhoto.Image = ConvertBase64ToImage(profilePhotoBase64);
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
                MemoryStream ms = new MemoryStream(imageBytes);
                Image img = Image.FromStream(ms);
                return img;
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
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Profil Fotoğrafı Seçin";
                dialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image image = Image.FromFile(dialog.FileName);
                        picProfilePhoto.Image = image;
                        profilePhotoBase64 = ConvertImageToBase64(image, dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        ShowError("Resim yüklenemedi: " + ex.Message);
                    }
                }
            }
        }

        private string ConvertImageToBase64(Image image, string filePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ImageFormat format = GetImageFormat(filePath);
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

            SQLiteConnection baglan = null;

            try
            {
                baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                baglan.Open();

                if (txtEmail.Text != originalEmail)
                {
                    if (IsEmailExists(baglan, txtEmail.Text))
                    {
                        ShowWarning("Bu e-posta adresi zaten kullanılıyor!");
                        return;
                    }
                }

                UpdateUserInfo(baglan);

                if (!string.IsNullOrEmpty(txtNewPassword.Text))
                {
                    if (!UpdatePassword(baglan))
                        return;
                }

                if (profilePhotoBase64 != originalProfilePhotoBase64)
                {
                    UpdateLogo(baglan);
                }

                originalFullName = txtFullName.Text;
                originalEmail = txtEmail.Text;
                originalPhone = txtPhone.Text;
                originalProfilePhotoBase64 = profilePhotoBase64;

                // Event'i tetikle - AnaSayfa'yı güncelle
                ProfileUpdated?.Invoke(this, EventArgs.Empty);

                ShowSuccess("Bilgileriniz başarıyla güncellendi!");
                ClearPasswordFields();
                ApplyInitialStyles();
            }
            catch (Exception ex)
            {
                ShowError("Güncelleme sırasında hata: " + ex.Message);
            }
            finally
            {
                baglan?.Close();
                baglan?.Dispose();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowWarning("Ad Soyad boş olamaz!");
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowWarning("E-posta boş olamaz!");
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "••••••••")
                {
                    ShowWarning("Şifre değiştirmek için mevcut şifrenizi girin!");
                    txtPassword.Focus();
                    return false;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    ShowWarning("Yeni şifreler eşleşmiyor!");
                    txtConfirmPassword.Focus();
                    return false;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    ShowWarning("Yeni şifre en az 6 karakter olmalı!");
                    txtNewPassword.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsEmailExists(SQLiteConnection baglan, string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @email AND user_id != @userId";
            using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userId", userId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void UpdateUserInfo(SQLiteConnection baglan)
        {
            string query = @"UPDATE users 
                             SET full_name = @fullName, email = @email, phone = @phone 
                             WHERE user_id = @userId";

            using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
            {
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        private bool UpdatePassword(SQLiteConnection baglan)
        {
            string checkQuery = "SELECT password FROM users WHERE user_id = @userId";
            using (SQLiteCommand cmd = new SQLiteCommand(checkQuery, baglan))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                string currentPassword = cmd.ExecuteScalar()?.ToString();

                if (currentPassword != txtPassword.Text)
                {
                    ShowWarning("Mevcut şifre yanlış!");
                    txtPassword.Focus();
                    return false;
                }
            }

            string updateQuery = "UPDATE users SET password = @password WHERE user_id = @userId";
            using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, baglan))
            {
                cmd.Parameters.AddWithValue("@password", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        private void UpdateLogo(SQLiteConnection baglan)
        {
            if (string.IsNullOrEmpty(profilePhotoBase64))
                return;

            string getAgencyQuery = "SELECT agency_id FROM users WHERE user_id = @userId";
            using (SQLiteCommand cmd = new SQLiteCommand(getAgencyQuery, baglan))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int agencyId = Convert.ToInt32(result);

                    string updateQuery = "UPDATE agencies SET logo_url = @logoUrl WHERE agency_id = @agencyId";
                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, baglan))
                    {
                        updateCmd.Parameters.AddWithValue("@logoUrl", profilePhotoBase64);
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
            this.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Hesabınızı silmek istediğinizden emin misiniz?\n\nBu işlem geri alınamaz!",
                "Hesap Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SQLiteConnection baglan = null;

                try
                {
                    baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                    baglan.Open();

                    string query = "DELETE FROM users WHERE user_id = @userId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    baglan.Close();
                    baglan.Dispose();

                    ShowSuccess("Hesabınız silindi. Uygulama kapatılacak.");
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    ShowError("Hesap silinirken hata: " + ex.Message);
                }
                finally
                {
                    baglan?.Close();
                    baglan?.Dispose();
                }
            }
        }

        #endregion

        #region Yardımcı Metodlar

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
