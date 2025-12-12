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
    public partial class SuperAdminEkleme : Form
    {
        private string logoBase64 = "";

        public SuperAdminEkleme()
        {
            InitializeComponent();
            InitializeRadioButtons();
        }

        SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
        SQLiteCommand cmd;
        DataTable dt;
        DataView dv;

        #region RadioButton İşlemleri

        private void InitializeRadioButtons()
        {
            rbSuperAdmin.Text = "Super Admin";
            rbAgencyAdmin.Text = "Acenta Yöneticisi";
            rbStaff.Text = "Şirket Hesabı";

            rbSuperAdmin.Checked = false;
            rbAgencyAdmin.Checked = false;
            rbStaff.Checked = false;

            rbSuperAdmin.CheckedChanged += RadioButton_CheckedChanged;
            rbAgencyAdmin.CheckedChanged += RadioButton_CheckedChanged;
            rbStaff.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isSuperAdmin = rbSuperAdmin.Checked;

            txtAgencyName.Enabled = !isSuperAdmin;
            picLogo.Enabled = !isSuperAdmin;

            if (isSuperAdmin)
            {
                txtAgencyName.Text = "";
                picLogo.Image = null;
                logoBase64 = "";
            }
        }

        #endregion

        #region Logo İşlemleri

        private void picLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Logo Seçin";
                dialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image image = Image.FromFile(dialog.FileName);
                        picLogo.Image = image;
                        picLogo.SizeMode = PictureBoxSizeMode.Zoom;

                        logoBase64 = ConvertImageToBase64(image, dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenemedi: " + ex.Message, "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Kayıt İşlemleri

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var (selectedRole, roleId, agencyId) = GetSelectedRole();

            if (roleId == 0)
            {
                MessageBox.Show("Lütfen bir rol seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveToDatabase(selectedRole, roleId, agencyId);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowWarning("Lütfen isim soyisim giriniz.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowWarning("Lütfen e-posta giriniz.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowWarning("Lütfen şifre giriniz.");
                return false;
            }

            if ((rbAgencyAdmin.Checked || rbStaff.Checked) && string.IsNullOrWhiteSpace(txtAgencyName.Text))
            {
                ShowWarning("Lütfen acenta/şirket adı giriniz.");
                return false;
            }

            return true;
        }

        private (string role, int roleId, long agencyId) GetSelectedRole()
        {
            if (rbSuperAdmin.Checked)
                return ("Super Admin", 1, 1);

            if (rbAgencyAdmin.Checked)
                return ("Acenta Yöneticisi", 2, 0);

            if (rbStaff.Checked)
                return ("Şirket Hesabı", 3, 0);

            return ("", 0, 0);
        }

        private void SaveToDatabase(string selectedRole, int roleId, long agencyId)
        {
            try
            {
                baglan.Open();

                if (roleId != 1)
                {
                    agencyId = InsertAgency();
                }

                InsertUser(roleId, agencyId);

                ShowSuccessMessage(selectedRole, roleId);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        private long InsertAgency()
        {
            string query = @"INSERT INTO agencies (agency_name, is_active, commission_rate, logo_url) 
                             VALUES (@agencyName, 1, 10.0, @logoUrl)";

            cmd = new SQLiteCommand(query, baglan);
            cmd.Parameters.AddWithValue("@agencyName", txtAgencyName.Text);
            cmd.Parameters.AddWithValue("@logoUrl", string.IsNullOrEmpty(logoBase64) ? (object)DBNull.Value : logoBase64);
            cmd.ExecuteNonQuery();

            return baglan.LastInsertRowId;
        }

        private void InsertUser(int roleId, long agencyId)
        {
            string query = @"INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                             VALUES (@roleId, @agencyId, @email, @password, @fullName, @phone)";

            cmd = new SQLiteCommand(query, baglan);
            cmd.Parameters.AddWithValue("@roleId", roleId);
            cmd.Parameters.AddWithValue("@agencyId", agencyId);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.ExecuteNonQuery();
        }

        private void ShowSuccessMessage(string selectedRole, int roleId)
        {
            string message = roleId == 1
                ? $"{selectedRole} başarıyla eklendi!\n\nYönetici: {txtFullName.Text}"
                : $"{selectedRole} başarıyla eklendi!\n\nAcenta/Şirket: {txtAgencyName.Text}\nYönetici: {txtFullName.Text}";

            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Yardımcı Metodlar

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ClearForm()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtAgencyName.Text = "";
            txtAgencyName.Enabled = true;
            picLogo.Image = null;
            picLogo.Enabled = true;
            logoBase64 = "";

            rbSuperAdmin.Checked = false;
            rbAgencyAdmin.Checked = false;
            rbStaff.Checked = false;
        }

        #endregion
    }
}