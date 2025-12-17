using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu
{
    public partial class Form1 : Form
    {
        private const string MailPlaceholder = "E-posta adresinizi girin";
        private const string SifrePlaceholder = "Şifrenizi girin";

        public Form1()
        {
            InitializeComponent();
            AyarlariYukle();
        }

        private void AyarlariYukle()
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                txtMail.Text = MailPlaceholder;
                txtMail.ForeColor = Color.Gray;
            }

            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.Text = SifrePlaceholder;
                txtSifre.ForeColor = Color.Gray;
                txtSifre.UseSystemPasswordChar = false;
            }
        }

        // GİRİŞ YAP BUTONU
        // GİRİŞ YAP BUTONU
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            // 1. Boş Alan Kontrolü
            if (txtMail.Text == MailPlaceholder || string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Lütfen e-posta adresinizi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSifre.Text == SifrePlaceholder || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen şifrenizi girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtMail.Text.Trim();
            string password = txtSifre.Text.Trim();

            // 2. Veritabanı Kontrolü
            int userType = KullaniciDogrula(email, password);

            if (userType != -1) // Giriş Başarılı
            {
                this.Hide(); // Giriş formunu gizle

                // --- YÖNLENDİRME VE KAPATMA MANTIĞI ---

                if (userType == 0) // ADMIN
                {
                   
                    adminPage adminForm = new adminPage();
                    adminForm.Show();

                    // YENİ EKLENEN KISIM: Bu form kapanınca uygulamayı tamamen kapat
                    adminForm.FormClosed += (s, args) => Application.Exit();
                }
                else if (userType == 1) // ACENTE YÖNETİCİSİ
                {
                    ajentaAdmin ajentaForm = new ajentaAdmin();
                    ajentaForm.Show();

                    ajentaForm.FormClosed += (s, args) => Application.Exit();
                }
                else if (userType == 2) // ACENTE ÇALIŞANI
                {
                    ajentaCalisani calisanForm = new ajentaCalisani();
                    calisanForm.Show();

                    calisanForm.FormClosed += (s, args) => Application.Exit();
                }
                else if (userType == 3) // ŞOFÖR
                {
                    soforPage soforForm = new soforPage();
                    soforForm.Show();

                    soforForm.FormClosed += (s, args) => Application.Exit();
                }
                else if (userType == 4) // KURUMSAL (Senin belirttiğin form adı: krurumsal)
                {
                  
                    kurumsal kurumsalForm = new kurumsal(); // Form adını senin düzelttiğin gibi kullandım
                    kurumsalForm.Show();

                    kurumsalForm.FormClosed += (s, args) => Application.Exit();
                }
                else if (userType == 5) // BİREYSEL MÜŞTERİ
                {
                    bireyselPage bireyselForm = new bireyselPage();
                    bireyselForm.Show();

                    bireyselForm.FormClosed += (s, args) => Application.Exit();
                }
                else
                {
                    // Tanımsız roller
                    MessageBox.Show($"Bu rol ({userType}) için panel henüz aktif değil.");
                    this.Show(); // Geri aç
                }
            }
            else
            {
                MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Kullanıcı Doğrulama Metodu
        private int KullaniciDogrula(string email, string password)
        {
            try
            {
                using (SQLiteConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserType FROM Users WHERE Email = @Email AND PasswordHash = @Password AND IsActive = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1; // Kullanıcı bulunamadı
        }

        // --- GÖRSEL AYARLAR ---
        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == MailPlaceholder) { txtMail.Text = string.Empty; txtMail.ForeColor = Color.Black; }
        }
        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text)) { txtMail.Text = MailPlaceholder; txtMail.ForeColor = Color.Gray; }
        }
        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == SifrePlaceholder) { txtSifre.Text = string.Empty; txtSifre.ForeColor = Color.Black; txtSifre.UseSystemPasswordChar = !chkSifreGoster.Checked; }
        }
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSifre.Text)) { txtSifre.Text = SifrePlaceholder; txtSifre.ForeColor = Color.Gray; txtSifre.UseSystemPasswordChar = false; }
        }
        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSifre.Text == SifrePlaceholder) { txtSifre.UseSystemPasswordChar = false; return; }
            txtSifre.UseSystemPasswordChar = !chkSifreGoster.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            RegisterForm kayitol= new RegisterForm();
            kayitol.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitol.Font = new Font(kayitol.Font, FontStyle.Underline);
        }
    }
}