using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BiletSatis.Models;
using BiletSatis.Services;

namespace BiletSatis.Forms
{
    public partial class FrmRegister : Form
    {
        private readonly AuthService _authService;

        // Controls
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlForm;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblTCNo;
        private TextBox txtTCNo;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnShowPassword;
        private Label lblPasswordConfirm;
        private TextBox txtPasswordConfirm;
        private Button btnShowPasswordConfirm;
        private Label lblUserType;
        private ComboBox cmbUserType;
        
        // Ajans bilgileri paneli
        private Panel pnlAgency;
        private Label lblAgencyName;
        private TextBox txtAgencyName;
        private Label lblAgencyTaxNo;
        private TextBox txtAgencyTaxNo;
        private Label lblAgencyPhone;
        private TextBox txtAgencyPhone;
        private Label lblAgencyAddress;
        private TextBox txtAgencyAddress;
        private Label lblAgencyType;
        private ComboBox cmbAgencyType;

        private Button btnRegister;
        private LinkLabel lnkLogin;
        private Label lblError;
        private Label lblSuccess;

        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color TextColor = Color.Black;

        public FrmRegister()
        {
            _authService = new AuthService();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form ayarları
            this.Text = "VoyageHub - Kayıt Ol";
            this.Size = new Size(480, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Header Panel
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(46, 204, 113)
            };
            this.Controls.Add(pnlHeader);

            // Başlık
            lblTitle = new Label
            {
                Text = "✈ VoyageHub - Kayıt",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 15)
            };
            pnlHeader.Controls.Add(lblTitle);

            // Alt başlık
            lblSubtitle = new Label
            {
                Text = "Yeni Hesap Oluşturun",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(220, 220, 220),
                AutoSize = true,
                Location = new Point(165, 50)
            };
            pnlHeader.Controls.Add(lblSubtitle);

            // Form Panel (Scrollable)
            pnlForm = new Panel
            {
                Location = new Point(30, 95),
                Size = new Size(405, 600),
                BackColor = Color.White,
                AutoScroll = true
            };
            this.Controls.Add(pnlForm);

            int yPos = 15;
            int spacing = 55;
            int labelOffset = 18;

            // Hesap Türü (En üstte)
            lblUserType = new Label
            {
                Text = "Hesap Türü *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblUserType);

            cmbUserType = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(350, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbUserType.Items.Add(new ComboItem("👤 Bireysel Kullanıcı", UserType.Individual));
            cmbUserType.Items.Add(new ComboItem("🏢 Kurumsal (Şirket) - Toplu Bilet Alımı", UserType.Company));
            cmbUserType.Items.Add(new ComboItem("🚌 Ajans Yöneticisi - Otobüs/Havayolu Şirketi", UserType.AgencyManager));
            cmbUserType.SelectedIndex = 0;
            cmbUserType.SelectedIndexChanged += CmbUserType_SelectedIndexChanged;
            pnlForm.Controls.Add(cmbUserType);
            yPos += spacing + 5;

            // Ad Soyad
            lblFullName = new Label
            {
                Text = "Ad Soyad *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblFullName);

            txtFullName = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(350, 25)
            };
            pnlForm.Controls.Add(txtFullName);
            yPos += spacing;

            // E-posta
            lblEmail = new Label
            {
                Text = "E-posta Adresi *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblEmail);

            txtEmail = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(350, 25)
            };
            pnlForm.Controls.Add(txtEmail);
            yPos += spacing;

            // Telefon
            lblPhone = new Label
            {
                Text = "Telefon",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblPhone);

            txtPhone = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(350, 25)
            };
            pnlForm.Controls.Add(txtPhone);
            yPos += spacing;

            // TC No
            lblTCNo = new Label
            {
                Text = "TC Kimlik No",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblTCNo);

            txtTCNo = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(350, 25),
                MaxLength = 11
            };
            txtTCNo.KeyPress += TxtNumericOnly_KeyPress;
            pnlForm.Controls.Add(txtTCNo);
            yPos += spacing;

            // Şifre
            lblPassword = new Label
            {
                Text = "Şifre * (En az 6 karakter)",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblPassword);

            txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(310, 25),
                UseSystemPasswordChar = true
            };
            pnlForm.Controls.Add(txtPassword);

            btnShowPassword = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI", 9),
                Location = new Point(330, yPos + labelOffset),
                Size = new Size(40, 25),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(236, 240, 241),
                Tag = false
            };
            btnShowPassword.FlatAppearance.BorderSize = 1;
            btnShowPassword.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
            btnShowPassword.Click += (s, e) => TogglePasswordVisibility(txtPassword, btnShowPassword);
            pnlForm.Controls.Add(btnShowPassword);
            yPos += spacing;

            // Şifre Tekrar
            lblPasswordConfirm = new Label
            {
                Text = "Şifre Tekrar *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, yPos),
                AutoSize = true
            };
            pnlForm.Controls.Add(lblPasswordConfirm);

            txtPasswordConfirm = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, yPos + labelOffset),
                Size = new Size(310, 25),
                UseSystemPasswordChar = true
            };
            pnlForm.Controls.Add(txtPasswordConfirm);

            btnShowPasswordConfirm = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI", 9),
                Location = new Point(330, yPos + labelOffset),
                Size = new Size(40, 25),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(236, 240, 241),
                Tag = false
            };
            btnShowPasswordConfirm.FlatAppearance.BorderSize = 1;
            btnShowPasswordConfirm.FlatAppearance.BorderColor = Color.FromArgb(189, 195, 199);
            btnShowPasswordConfirm.Click += (s, e) => TogglePasswordVisibility(txtPasswordConfirm, btnShowPasswordConfirm);
            pnlForm.Controls.Add(btnShowPasswordConfirm);
            yPos += spacing + 10;

            // =============================================
            // AJANS BİLGİLERİ PANELİ (Başlangıçta gizli)
            // =============================================
            pnlAgency = new Panel
            {
                Location = new Point(10, yPos),
                Size = new Size(370, 220),
                BackColor = Color.FromArgb(245, 247, 250),
                Visible = false
            };
            pnlForm.Controls.Add(pnlAgency);

            var lblAgencyHeader = new Label
            {
                Text = "🏢 Ajans Bilgileri",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(10, 5),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyHeader);

            int agencyY = 30;

            // Ajans Adı
            lblAgencyName = new Label
            {
                Text = "Ajans/Şirket Adı *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, agencyY),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyName);

            txtAgencyName = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, agencyY + labelOffset),
                Size = new Size(340, 25)
            };
            pnlAgency.Controls.Add(txtAgencyName);
            agencyY += 50;

            // Ajans Tipi ve Vergi No (Yan yana)
            lblAgencyType = new Label
            {
                Text = "Ajans Tipi *",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, agencyY),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyType);

            lblAgencyTaxNo = new Label
            {
                Text = "Vergi No",
                Font = new Font("Segoe UI", 9),
                Location = new Point(180, agencyY),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyTaxNo);

            cmbAgencyType = new ComboBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, agencyY + labelOffset),
                Size = new Size(160, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbAgencyType.Items.Add(new AgencyTypeItem("🚌 Otobüs", 0));
            cmbAgencyType.Items.Add(new AgencyTypeItem("✈️ Havayolu", 1));
            cmbAgencyType.SelectedIndex = 0;
            pnlAgency.Controls.Add(cmbAgencyType);

            txtAgencyTaxNo = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(180, agencyY + labelOffset),
                Size = new Size(170, 25),
                MaxLength = 11
            };
            txtAgencyTaxNo.KeyPress += TxtNumericOnly_KeyPress;
            pnlAgency.Controls.Add(txtAgencyTaxNo);
            agencyY += 50;

            // Ajans Telefon
            lblAgencyPhone = new Label
            {
                Text = "Ajans Telefon",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, agencyY),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyPhone);

            txtAgencyPhone = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, agencyY + labelOffset),
                Size = new Size(340, 25)
            };
            pnlAgency.Controls.Add(txtAgencyPhone);
            agencyY += 50;

            // Ajans Adres
            lblAgencyAddress = new Label
            {
                Text = "Ajans Adresi",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, agencyY),
                AutoSize = true
            };
            pnlAgency.Controls.Add(lblAgencyAddress);

            txtAgencyAddress = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, agencyY + labelOffset),
                Size = new Size(340, 25)
            };
            pnlAgency.Controls.Add(txtAgencyAddress);

            // Kayıt Butonu
            btnRegister = new Button
            {
                Text = "KAYIT OL",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, yPos),
                Size = new Size(350, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;
            pnlForm.Controls.Add(btnRegister);

            // Giriş Linki
            lnkLogin = new LinkLabel
            {
                Text = "Zaten hesabınız var mı? Giriş yapın",
                Font = new Font("Segoe UI", 9),
                Location = new Point(90, yPos + 55),
                AutoSize = true
            };
            lnkLogin.Click += LnkLogin_Click;
            pnlForm.Controls.Add(lnkLogin);

            // Hata Label
            lblError = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(20, yPos + 85),
                Size = new Size(350, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlForm.Controls.Add(lblError);

            // Başarı Label
            lblSuccess = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(20, yPos + 85),
                Size = new Size(350, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlForm.Controls.Add(lblSuccess);

            this.AcceptButton = btnRegister;
        }

        private void CmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (ComboItem)cmbUserType.SelectedItem;
            bool isAgencyManager = selected.Value == UserType.AgencyManager;

            // Ajans panelini göster/gizle
            pnlAgency.Visible = isAgencyManager;

            // Form boyutunu ve buton pozisyonlarını ayarla
            int baseY = 380;

            if (isAgencyManager)
            {
                pnlAgency.Location = new Point(10, baseY);
                btnRegister.Location = new Point(20, baseY + 230);
                lnkLogin.Location = new Point(90, baseY + 285);
                lblError.Location = new Point(20, baseY + 315);
                lblSuccess.Location = new Point(20, baseY + 315);
                this.Size = new Size(480, 800);
            }
            else
            {
                btnRegister.Location = new Point(20, baseY);
                lnkLogin.Location = new Point(90, baseY + 55);
                lblError.Location = new Point(20, baseY + 85);
                lblSuccess.Location = new Point(20, baseY + 85);
                this.Size = new Size(480, 620);
            }

            // Header rengini değiştir
            if (isAgencyManager)
            {
                pnlHeader.BackColor = Color.FromArgb(41, 128, 185); // Mavi
                btnRegister.BackColor = Color.FromArgb(41, 128, 185);
            }
            else if (selected.Value == UserType.Company)
            {
                pnlHeader.BackColor = Color.FromArgb(155, 89, 182); // Mor
                btnRegister.BackColor = Color.FromArgb(155, 89, 182);
            }
            else
            {
                pnlHeader.BackColor = Color.FromArgb(46, 204, 113); // Yeşil
                btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void TogglePasswordVisibility(TextBox txt, Button btn)
        {
            bool isVisible = (bool)btn.Tag;

            if (isVisible)
            {
                txt.UseSystemPasswordChar = true;
                btn.Text = "👁";
                btn.Tag = false;
            }
            else
            {
                txt.UseSystemPasswordChar = false;
                btn.Text = "🔒";
                btn.Tag = true;
            }
            txt.Focus();
        }

        private void TxtNumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblSuccess.Text = "";

            var selectedType = (ComboItem)cmbUserType.SelectedItem;

            // Temel validasyonlar
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowError("Ad Soyad boş olamaz!", txtFullName);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowError("E-posta adresi boş olamaz!", txtEmail);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                ShowError("Geçerli bir e-posta adresi girin!", txtEmail);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Şifre boş olamaz!", txtPassword);
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowError("Şifre en az 6 karakter olmalıdır!", txtPassword);
                return;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                ShowError("Şifreler eşleşmiyor!", txtPasswordConfirm);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtTCNo.Text) && txtTCNo.Text.Length != 11)
            {
                ShowError("TC Kimlik No 11 haneli olmalıdır!", txtTCNo);
                return;
            }

            // Ajans yöneticisi için ek validasyonlar
            if (selectedType.Value == UserType.AgencyManager)
            {
                if (string.IsNullOrWhiteSpace(txtAgencyName.Text))
                {
                    ShowError("Ajans adı boş olamaz!", txtAgencyName);
                    return;
                }
            }

            btnRegister.Enabled = false;
            btnRegister.Text = "Kayıt yapılıyor...";

            try
            {
                var user = new User
                {
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    TCNo = txtTCNo.Text.Trim(),
                    UserType = selectedType.Value
                };

                bool result;

                if (selectedType.Value == UserType.AgencyManager)
                {
                    // Ajans yöneticisi + Ajans kaydı
                    var agencyType = (AgencyTypeItem)cmbAgencyType.SelectedItem;

                    result = _authService.RegisterAgencyManager(
                        user,
                        txtPassword.Text,
                        txtAgencyName.Text.Trim(),
                        agencyType.Value,
                        txtAgencyTaxNo.Text.Trim(),
                        txtAgencyPhone.Text.Trim(),
                        txtAgencyAddress.Text.Trim()
                    );
                }
                else
                {
                    // Normal kullanıcı kaydı
                    result = _authService.Register(user, txtPassword.Text);
                }

                if (result)
                {
                    lblSuccess.Text = "Kayıt başarılı! Giriş yapabilirsiniz.";
                    ClearForm();

                    var timer = new Timer { Interval = 2000 };
                    timer.Tick += (s, args) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        LnkLogin_Click(null, null);
                    };
                    timer.Start();
                }
                else
                {
                    lblError.Text = "Bu e-posta adresi zaten kayıtlı!";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Hata: " + ex.Message;
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "KAYIT OL";
            }
        }

        private void ShowError(string message, Control focusControl)
        {
            lblError.Text = message;
            focusControl.Focus();
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtTCNo.Clear();
            txtPassword.Clear();
            txtPasswordConfirm.Clear();
            txtAgencyName.Clear();
            txtAgencyTaxNo.Clear();
            txtAgencyPhone.Clear();
            txtAgencyAddress.Clear();
            cmbUserType.SelectedIndex = 0;
            cmbAgencyType.SelectedIndex = 0;
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void LnkLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new FrmLogin();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        // Yardımcı sınıflar
        private class ComboItem
        {
            public string Text { get; }
            public UserType Value { get; }

            public ComboItem(string text, UserType value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }

        private class AgencyTypeItem
        {
            public string Text { get; }
            public int Value { get; }

            public AgencyTypeItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}