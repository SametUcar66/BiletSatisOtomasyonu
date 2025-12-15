using System;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Helpers;
using BiletSatis.Services;

namespace BiletSatis.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _authService;

        // Controls
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlForm;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnShowPassword;
        private CheckBox chkRemember;
        private Button btnLogin;
        private Label lblError;
        private LinkLabel lnkForgotPassword;
        private LinkLabel lnkRegister;

        // Placeholder renkleri
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color TextColor = Color.Black;

        public FrmLogin()
        {
            _authService = new AuthService();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form ayarları
            this.Text = "VoyageHub - Giriş";
            this.Size = new Size(450, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Header Panel
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(41, 128, 185)
            };
            this.Controls.Add(pnlHeader);

            // Başlık
            lblTitle = new Label
            {
                Text = "✈ VoyageHub",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 25)
            };
            pnlHeader.Controls.Add(lblTitle);

            // Alt başlık
            lblSubtitle = new Label
            {
                Text = "Seyahat Bilet Satış Otomasyonu",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(220, 220, 220),
                AutoSize = true,
                Location = new Point(115, 75)
            };
            pnlHeader.Controls.Add(lblSubtitle);

            // Form Panel
            pnlForm = new Panel
            {
                Location = new Point(40, 150),
                Size = new Size(355, 380),
                BackColor = Color.White
            };
            this.Controls.Add(pnlForm);

            // Email Label
            lblEmail = new Label
            {
                Text = "E-posta Adresi",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 30),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblEmail);

            // Email TextBox
            txtEmail = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = new Point(20, 55),
                Size = new Size(315, 30)
            };
            SetPlaceholder(txtEmail, "ornek@email.com");
            pnlForm.Controls.Add(txtEmail);

            // Password Label
            lblPassword = new Label
            {
                Text = "Şifre",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 100),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblPassword);

            // Password TextBox
            txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                Location = new Point(20, 125),
                Size = new Size(275, 30)
            };
            SetPasswordPlaceholder(txtPassword, "Şifrenizi girin");
            pnlForm.Controls.Add(txtPassword);

            // Şifre Göster/Gizle Butonu
            btnShowPassword = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI", 12),
                Location = new Point(295, 125),
                Size = new Size(40, 27),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(236, 240, 241),
                Tag = false // false = gizli, true = görünür
            };
            btnShowPassword.FlatAppearance.BorderSize = 1;
            btnShowPassword.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
            btnShowPassword.Click += BtnShowPassword_Click;
            pnlForm.Controls.Add(btnShowPassword);

            // Beni Hatırla
            chkRemember = new CheckBox
            {
                Text = "Beni Hatırla",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 170),
                AutoSize = true
            };
            pnlForm.Controls.Add(chkRemember);

            // Şifremi Unuttum
            lnkForgotPassword = new LinkLabel
            {
                Text = "Şifremi Unuttum",
                Font = new Font("Segoe UI", 9),
                Location = new Point(235, 170),
                AutoSize = true
            };
            pnlForm.Controls.Add(lnkForgotPassword);

            // Giriş Butonu
            btnLogin = new Button
            {
                Text = "GİRİŞ YAP",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, 210),
                Size = new Size(315, 45),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;
            pnlForm.Controls.Add(btnLogin);

            // Kayıt Linki
            lnkRegister = new LinkLabel
            {
                Text = "Hesabınız yok mu? Kayıt olun",
                Font = new Font("Segoe UI", 9),
                Location = new Point(85, 270),
                AutoSize = true
            };
            lnkRegister.Click += LnkRegister_Click;
            pnlForm.Controls.Add(lnkRegister);

            // Hata Label
            lblError = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(20, 300),
                Size = new Size(315, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlForm.Controls.Add(lblError);

            // Enter tuşu ile giriş
            this.AcceptButton = btnLogin;

            // Test için varsayılan değerler
            txtEmail.Text = "admin@biletsatis.com";
            txtEmail.ForeColor = TextColor;
            txtPassword.Text = "Admin123!";
            txtPassword.ForeColor = TextColor;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void LnkRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = new FrmRegister();
            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.Show();
        }

        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            bool isVisible = (bool)btnShowPassword.Tag;

            if (isVisible)
            {
                // Şifreyi gizle
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "👁";
                btnShowPassword.Tag = false;
            }
            else
            {
                // Şifreyi göster
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "🔒";
                btnShowPassword.Tag = true;
            }

            txtPassword.Focus();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = PlaceholderColor;
            textBox.Tag = placeholder;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = TextColor;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = PlaceholderColor;
                }
            };
        }

        private void SetPasswordPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = PlaceholderColor;
            textBox.UseSystemPasswordChar = false;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder && textBox.ForeColor == PlaceholderColor)
                {
                    textBox.Text = "";
                    textBox.ForeColor = TextColor;
                    textBox.UseSystemPasswordChar = !(bool)btnShowPassword.Tag;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.UseSystemPasswordChar = false;
                    textBox.Text = placeholder;
                    textBox.ForeColor = PlaceholderColor;
                }
            };
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // Placeholder kontrolü
            string email = txtEmail.ForeColor == PlaceholderColor ? "" : txtEmail.Text;
            string password = txtPassword.ForeColor == PlaceholderColor ? "" : txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                lblError.Text = "E-posta adresi boş olamaz!";
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Şifre boş olamaz!";
                txtPassword.Focus();
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Giriş yapılıyor...";

            try
            {
                var user = _authService.Login(email.Trim(), password);

                if (user != null)
                {
                    SessionManager.CurrentUser = user;
                    SessionManager.CurrentAgencyId = _authService.GetUserAgencyId(user.Id);

                    this.Hide();
                    var mainForm = new FrmMain();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
                {
                    lblError.Text = "E-posta veya şifre hatalı!";
                    txtPassword.Text = "";
                    txtPassword.UseSystemPasswordChar = !(bool)btnShowPassword.Tag;
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Bağlantı hatası: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "GİRİŞ YAP";
            }
        }
    }
}