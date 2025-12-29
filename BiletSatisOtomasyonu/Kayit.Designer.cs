namespace BiletSatisOtomasyonu
{
    partial class Kayit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kayit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtAdSoyad = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtTelefon = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtSifre = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnKayitOl = new ReaLTaiizor.Controls.HopeButton();
            this.cmbRol = new ReaLTaiizor.Controls.PoisonComboBox();
            this.sifreGoster = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnCloseApp);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 45);
            this.panel1.TabIndex = 20;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "ABİLET";
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.Location = new System.Drawing.Point(268, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(43, 43);
            this.button6.TabIndex = 12;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.FlatAppearance.BorderSize = 0;
            this.btnCloseApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseApp.Image")));
            this.btnCloseApp.Location = new System.Drawing.Point(311, 0);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(43, 43);
            this.btnCloseApp.TabIndex = 11;
            this.btnCloseApp.TabStop = false;
            this.btnCloseApp.UseVisualStyleBackColor = true;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.Silver;
            this.button5.Location = new System.Drawing.Point(237, 397);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 24);
            this.button5.TabIndex = 21;
            this.button5.Text = "Giriş Yap";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.BackColor = System.Drawing.Color.White;
            this.txtAdSoyad.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtAdSoyad.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtAdSoyad.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtAdSoyad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAdSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtAdSoyad.Hint = "Ad Soyad";
            this.txtAdSoyad.Location = new System.Drawing.Point(56, 92);
            this.txtAdSoyad.MaxLength = 32767;
            this.txtAdSoyad.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtAdSoyad.Multiline = false;
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.PasswordChar = '\0';
            this.txtAdSoyad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdSoyad.SelectedText = "";
            this.txtAdSoyad.SelectionLength = 0;
            this.txtAdSoyad.SelectionStart = 0;
            this.txtAdSoyad.Size = new System.Drawing.Size(244, 38);
            this.txtAdSoyad.TabIndex = 22;
            this.txtAdSoyad.TabStop = false;
            this.txtAdSoyad.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtEmail.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtEmail.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtEmail.Hint = "E-Mail";
            this.txtEmail.Location = new System.Drawing.Point(56, 141);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(244, 38);
            this.txtEmail.TabIndex = 23;
            this.txtEmail.TabStop = false;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtTelefon
            // 
            this.txtTelefon.BackColor = System.Drawing.Color.White;
            this.txtTelefon.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtTelefon.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtTelefon.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtTelefon.Hint = "Telefon";
            this.txtTelefon.Location = new System.Drawing.Point(56, 190);
            this.txtTelefon.MaxLength = 32767;
            this.txtTelefon.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtTelefon.Multiline = false;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.PasswordChar = '\0';
            this.txtTelefon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTelefon.SelectedText = "";
            this.txtTelefon.SelectionLength = 0;
            this.txtTelefon.SelectionStart = 0;
            this.txtTelefon.Size = new System.Drawing.Size(244, 38);
            this.txtTelefon.TabIndex = 24;
            this.txtTelefon.TabStop = false;
            this.txtTelefon.UseSystemPasswordChar = false;
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.Color.White;
            this.txtSifre.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtSifre.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtSifre.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtSifre.Hint = "Şifre";
            this.txtSifre.Location = new System.Drawing.Point(56, 239);
            this.txtSifre.MaxLength = 32767;
            this.txtSifre.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtSifre.Multiline = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '\0';
            this.txtSifre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSifre.SelectedText = "";
            this.txtSifre.SelectionLength = 0;
            this.txtSifre.SelectionStart = 0;
            this.txtSifre.Size = new System.Drawing.Size(244, 38);
            this.txtSifre.TabIndex = 25;
            this.txtSifre.TabStop = false;
            this.txtSifre.UseSystemPasswordChar = false;
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnKayitOl.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitOl.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnKayitOl.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnKayitOl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitOl.ForeColor = System.Drawing.Color.Black;
            this.btnKayitOl.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnKayitOl.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnKayitOl.Location = new System.Drawing.Point(56, 351);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnKayitOl.Size = new System.Drawing.Size(244, 39);
            this.btnKayitOl.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnKayitOl.TabIndex = 27;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.TextColor = System.Drawing.Color.White;
            this.btnKayitOl.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.ItemHeight = 23;
            this.cmbRol.Location = new System.Drawing.Point(56, 305);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(244, 29);
            this.cmbRol.TabIndex = 28;
            this.cmbRol.UseSelectable = true;
            // 
            // sifreGoster
            // 
            this.sifreGoster.AutoSize = true;
            this.sifreGoster.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sifreGoster.Location = new System.Drawing.Point(56, 283);
            this.sifreGoster.Name = "sifreGoster";
            this.sifreGoster.Size = new System.Drawing.Size(81, 17);
            this.sifreGoster.TabIndex = 29;
            this.sifreGoster.Text = "Şifre Göster";
            this.sifreGoster.UseVisualStyleBackColor = true;
            this.sifreGoster.CheckedChanged += new System.EventHandler(this.sifreGoster_CheckedChanged);
            // 
            // Kayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(356, 440);
            this.Controls.Add(this.sifreGoster);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.btnKayitOl);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kullanıcı Kaydı";
            this.Load += new System.EventHandler(this.Kayit_Load);
            this.Shown += new System.EventHandler(this.Kayit_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnCloseApp;
        private ReaLTaiizor.Controls.HopeTextBox txtAdSoyad;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail;
        private ReaLTaiizor.Controls.HopeTextBox txtTelefon;
        private ReaLTaiizor.Controls.HopeTextBox txtSifre;
        private ReaLTaiizor.Controls.HopeButton btnKayitOl;
        private ReaLTaiizor.Controls.PoisonComboBox cmbRol;
        private System.Windows.Forms.CheckBox sifreGoster;
    }
}