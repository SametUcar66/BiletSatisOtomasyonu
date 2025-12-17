using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class RegisterForm : Form
    {
        // Placeholder Metinlerini Sabit Olarak Tanımlıyoruz
        private string PhAdSoyad = "Ad Soyad";
        private const string PhEmail = "E-posta Adresi";
        private const string PhTelefon = "Telefon Numarası";
        private const string PhSifre = "Şifre";

        public RegisterForm()
        {
            InitializeComponent();

            // Başlangıçta odaklanmayı temizleyelim ki ilk kutu hemen silinmesin
            this.ActiveControl = null;

            // Varsayılan seçim
            if (cmbKayitTuru.Items.Count > 0)
                cmbKayitTuru.SelectedIndex = 0;
        }

        // --- COMBOBOX DEĞİŞİNCE PLACEHOLDER GÜNCELLEME ---
        private void cmbKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçime göre Ad Soyad kutusunun placeholder'ını değiştiriyoruz
            if (cmbKayitTuru.SelectedIndex == 2) // Kurumsal
            {
                PhAdSoyad = "Şirket Adı";
            }
            else if (cmbKayitTuru.SelectedIndex == 1) // Acente
            {
                PhAdSoyad = "Acente/Yetkili Adı";
            }
            else // Bireysel
            {
                PhAdSoyad = "Ad Soyad";
            }

            // Eğer kutu şu an boşsa (yani placeholder gösteriyorsa), yeni yazıyı hemen yansıt
            if (txtAdSoyad.ForeColor == Color.Gray)
            {
                txtAdSoyad.Text = PhAdSoyad;
            }
        }

        // --- KAYIT BUTONU ---
        private void btnKayitTamamla_Click(object sender, EventArgs e)
        {
            // Boş Alan Kontrolü (Placeholder metni yazıyorsa orası boş demektir)
            if (txtAdSoyad.Text == PhAdSoyad || string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                txtEmail.Text == PhEmail || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                txtSifre.Text == PhSifre || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string adSoyad = txtAdSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telefon = (txtTelefon.Text == PhTelefon) ? "" : txtTelefon.Text.Trim(); // Telefon opsiyonel olabilir
            string sifre = txtSifre.Text.Trim();

            // Kullanıcı Tipi
            int userType = 5; // Bireysel
            if (cmbKayitTuru.SelectedIndex == 1) userType = 1; // Acente
            else if (cmbKayitTuru.SelectedIndex == 2) userType = 4; // Kurumsal

            if (KayitOl(adSoyad, email, telefon, sifre, userType))
            {
                string rolAdi = cmbKayitTuru.SelectedItem.ToString();
                MessageBox.Show($"{rolAdi} kaydı başarıyla oluşturuldu!\nGiriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool KayitOl(string ad, string email, string tel, string pass, int type)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Mail Kontrolü
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Bu e-posta adresi zaten kullanımda!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // Kayıt Ekleme
                    string insertQuery = @"INSERT INTO Users (Email, PasswordHash, FullName, Phone, UserType, IsActive, CreatedAt) 
                                           VALUES (@Email, @Password, @Name, @Phone, @Type, 1, @Date)";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Parameters.AddWithValue("@Name", ad);
                        cmd.Parameters.AddWithValue("@Phone", tel);
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // --- PLACEHOLDER (YER TUTUCU) EVENTLERİ ---

        // 1. AD SOYAD
        private void txtAdSoyad_Enter(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == PhAdSoyad)
            {
                txtAdSoyad.Text = "";
                txtAdSoyad.ForeColor = Color.Black;
            }
        }
        private void txtAdSoyad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                txtAdSoyad.Text = PhAdSoyad;
                txtAdSoyad.ForeColor = Color.Gray;
            }
        }

        // 2. EMAIL
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == PhEmail)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = PhEmail;
                txtEmail.ForeColor = Color.Gray;
            }
        }

        // 3. TELEFON
        private void txtTelefon_Enter(object sender, EventArgs e)
        {
            if (txtTelefon.Text == PhTelefon)
            {
                txtTelefon.Text = "";
                txtTelefon.ForeColor = Color.Black;
            }
        }
        private void txtTelefon_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                txtTelefon.Text = PhTelefon;
                txtTelefon.ForeColor = Color.Gray;
            }
        }

        // 4. ŞİFRE (Özel: Maskeleme Ayarı Var)
        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == PhSifre)
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.Black;
                txtSifre.UseSystemPasswordChar = true; // Yazarken yıldızlı görünsün
            }
        }
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = PhSifre;
                txtSifre.ForeColor = Color.Gray;
                txtSifre.UseSystemPasswordChar = false; // Placeholder okunabilir olsun
            }
        }
    }
}