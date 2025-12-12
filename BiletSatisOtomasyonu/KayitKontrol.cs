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
    public partial class KayitKontrol : UserControl
    {
        private string profilePhotoBase64 = "";

        // Hesap tiplerine göre rol ve acenta ID'leri
        private const int ROLE_PASSENGER = 5;      // Kişisel kullanıcı
        private const int ROLE_STAFF = 3;          // Şirket hesabı
        private const int ROLE_AGENCY_ADMIN = 2;   // Acenta yöneticisi

        private const int AGENCY_PERSONAL = 4;     // Bireysel kullanıcılar acentası

        public KayitKontrol()
        {
            InitializeComponent();
        }

        #region Form Yükleme

        private void KayitKontrol_Load(object sender, EventArgs e)
        {
            SetupPlaceholders();
            SetupRadioButtons();
        }

        private void SetupPlaceholders()
        {
            txtRegisterEmail.Text = "E-posta adresi";
            txtRegisterEmail.ForeColor = Color.DarkGray;

            txtRegisterUsername.Text = "Ad Soyad";
            txtRegisterUsername.ForeColor = Color.DarkGray;

            txtRegisterPassword.Text = "Parola";
            txtRegisterPassword.ForeColor = Color.DarkGray;
        }

        private void SetupRadioButtons()
        {
            rbPersonal.Checked = true;
            rbCompany.Checked = false;
            rbAgency.Checked = false;
        }

        #endregion

        #region Placeholder Eventleri

        private void txtRegisterEmail_Enter(object sender, EventArgs e)
        {
            if (txtRegisterEmail.Text == "E-posta adresi")
            {
                txtRegisterEmail.Text = "";
                txtRegisterEmail.ForeColor = Color.White;
            }
        }

        private void txtRegisterEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegisterEmail.Text))
            {
                txtRegisterEmail.Text = "E-posta adresi";
                txtRegisterEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtRegisterUsername_Enter(object sender, EventArgs e)
        {
            if (txtRegisterUsername.Text == "Ad Soyad")
            {
                txtRegisterUsername.Text = "";
                txtRegisterUsername.ForeColor = Color.White;
            }
        }

        private void txtRegisterUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegisterUsername.Text))
            {
                txtRegisterUsername.Text = "Ad Soyad";
                txtRegisterUsername.ForeColor = Color.DarkGray;
            }
        }

        private void txtRegisterPassword_Enter(object sender, EventArgs e)
        {
            if (txtRegisterPassword.Text == "Parola")
            {
                txtRegisterPassword.Text = "";
                txtRegisterPassword.ForeColor = Color.White;
                txtRegisterPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtRegisterPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegisterPassword.Text))
            {
                txtRegisterPassword.Text = "Parola";
                txtRegisterPassword.ForeColor = Color.DarkGray;
                txtRegisterPassword.UseSystemPasswordChar = false;
            }
        }

        #endregion

        #region RadioButton Eventleri

        private void rbAccountType_CheckedChanged(object sender, EventArgs e)
        {
            // Şirket veya Acenta seçildiğinde profil fotoğrafı logo olarak kullanılacak
            if (rbCompany.Checked || rbAgency.Checked)
            {
                // Logo için görsel ipucu
                picProfilePhoto.BackColor = Color.FromArgb(60, 60, 80);
            }
            else
            {
                picProfilePhoto.BackColor = Color.Gray;
            }
        }

        #endregion

        #region Profil Fotoğrafı

        private void picProfilePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = rbPersonal.Checked ? "Profil Fotoğrafı Seçin" : "Logo Seçin";
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

        #region Kayıt İşlemi

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var (roleId, agencyId, accountType) = GetAccountTypeInfo();

            RegisterUser(roleId, agencyId, accountType);
        }

        private bool ValidateForm()
        {
            string email = txtRegisterEmail.Text;
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || email == "E-posta adresi")
            {
                ShowWarning("Lütfen e-posta adresinizi giriniz.");
                return false;
            }

            if (!IsValidEmail(email))
            {
                ShowWarning("Lütfen geçerli bir e-posta adresi giriniz.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(username) || username == "Ad Soyad")
            {
                ShowWarning("Lütfen adınızı ve soyadınızı giriniz.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password) || password == "Parola")
            {
                ShowWarning("Lütfen parolanızı giriniz.");
                return false;
            }

            if (password.Length < 6)
            {
                ShowWarning("Parola en az 6 karakter olmalıdır.");
                return false;
            }

            if (!rbPersonal.Checked && !rbCompany.Checked && !rbAgency.Checked)
            {
                ShowWarning("Lütfen hesap türü seçiniz.");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private (int roleId, long agencyId, string accountType) GetAccountTypeInfo()
        {
            if (rbPersonal.Checked)
                return (ROLE_PASSENGER, AGENCY_PERSONAL, "Kişisel");

            if (rbCompany.Checked)
                return (ROLE_STAFF, 0, "Şirket");

            if (rbAgency.Checked)
                return (ROLE_AGENCY_ADMIN, 0, "Acenta");

            return (ROLE_PASSENGER, AGENCY_PERSONAL, "Kişisel");
        }

        private void RegisterUser(int roleId, long agencyId, string accountType)
        {
            try
            {
                using (SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3"))
                {
                    baglan.Open();

                    // E-posta kontrolü
                    if (IsEmailExists(baglan, txtRegisterEmail.Text))
                    {
                        ShowWarning("Bu e-posta adresi zaten kayıtlı!");
                        return;
                    }

                    // Şirket veya Acenta ise yeni acenta oluştur
                    if (roleId != ROLE_PASSENGER)
                    {
                        agencyId = CreateAgency(baglan, accountType);
                    }

                    // Kullanıcıyı kaydet
                    InsertUser(baglan, roleId, agencyId);

                    ShowSuccess($"Kayıt başarılı!\n\nHesap Türü: {accountType}\nE-posta: {txtRegisterEmail.Text}");
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                ShowError("Kayıt sırasında hata oluştu: " + ex.Message);
            }
        }

        private bool IsEmailExists(SQLiteConnection baglan, string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";
            using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private long CreateAgency(SQLiteConnection baglan, string accountType)
        {
            string agencyName = $"{txtRegisterUsername.Text} - {accountType}";

            string query = @"INSERT INTO agencies (agency_name, is_active, commission_rate, logo_url) 
                             VALUES (@agencyName, 1, 10.0, @logoUrl)";

            using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
            {
                cmd.Parameters.AddWithValue("@agencyName", agencyName);
                cmd.Parameters.AddWithValue("@logoUrl", 
                    string.IsNullOrEmpty(profilePhotoBase64) ? (object)DBNull.Value : profilePhotoBase64);
                cmd.ExecuteNonQuery();
            }

            return baglan.LastInsertRowId;
        }

        private void InsertUser(SQLiteConnection baglan, int roleId, long agencyId)
        {
            string query = @"INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                             VALUES (@roleId, @agencyId, @email, @password, @fullName, @phone)";

            using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
            {
                cmd.Parameters.AddWithValue("@roleId", roleId);
                cmd.Parameters.AddWithValue("@agencyId", agencyId);
                cmd.Parameters.AddWithValue("@email", txtRegisterEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtRegisterPassword.Text);
                cmd.Parameters.AddWithValue("@fullName", txtRegisterUsername.Text);
                cmd.Parameters.AddWithValue("@phone", "");
                cmd.ExecuteNonQuery();
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

        private void ClearForm()
        {
            txtRegisterEmail.Text = "E-posta adresi";
            txtRegisterEmail.ForeColor = Color.DarkGray;

            txtRegisterUsername.Text = "Ad Soyad";
            txtRegisterUsername.ForeColor = Color.DarkGray;

            txtRegisterPassword.Text = "Parola";
            txtRegisterPassword.ForeColor = Color.DarkGray;
            txtRegisterPassword.UseSystemPasswordChar = false;

            rbPersonal.Checked = true;
            picProfilePhoto.Image = null;
            profilePhotoBase64 = "";
        }

        #endregion
    }
}
