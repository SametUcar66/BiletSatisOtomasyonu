namespace BiletSatisOtomasyonu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtPsw = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnLogin = new ReaLTaiizor.Controls.HopeButton();
            this.sifreGoster = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BackColor = System.Drawing.Color.Transparent;
            this.btnKayitOl.FlatAppearance.BorderSize = 0;
            this.btnKayitOl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnKayitOl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnKayitOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitOl.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayitOl.ForeColor = System.Drawing.Color.Silver;
            this.btnKayitOl.Location = new System.Drawing.Point(245, 308);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(55, 24);
            this.btnKayitOl.TabIndex = 3;
            this.btnKayitOl.Text = "Kayıt Ol";
            this.btnKayitOl.UseVisualStyleBackColor = false;
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCloseApp);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 45);
            this.panel1.TabIndex = 0;
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
            this.label1.TabIndex = 8;
            this.label1.Text = "ABİLET";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(268, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 43);
            this.button1.TabIndex = 9;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.btnCloseApp.TabIndex = 8;
            this.btnCloseApp.TabStop = false;
            this.btnCloseApp.UseVisualStyleBackColor = true;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
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
            this.txtEmail.Location = new System.Drawing.Point(56, 146);
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
            this.txtEmail.TabIndex = 17;
            this.txtEmail.TabStop = false;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtPsw
            // 
            this.txtPsw.BackColor = System.Drawing.Color.White;
            this.txtPsw.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPsw.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtPsw.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtPsw.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPsw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtPsw.Hint = "Şifre";
            this.txtPsw.Location = new System.Drawing.Point(56, 195);
            this.txtPsw.MaxLength = 32767;
            this.txtPsw.MinimumSize = new System.Drawing.Size(0, 30);
            this.txtPsw.Multiline = false;
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.PasswordChar = '*';
            this.txtPsw.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPsw.SelectedText = "";
            this.txtPsw.SelectionLength = 0;
            this.txtPsw.SelectionStart = 0;
            this.txtPsw.Size = new System.Drawing.Size(244, 38);
            this.txtPsw.TabIndex = 18;
            this.txtPsw.TabStop = false;
            this.txtPsw.UseSystemPasswordChar = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnLogin.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnLogin.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnLogin.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnLogin.Location = new System.Drawing.Point(56, 263);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnLogin.Size = new System.Drawing.Size(244, 39);
            this.btnLogin.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // sifreGoster
            // 
            this.sifreGoster.AutoSize = true;
            this.sifreGoster.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sifreGoster.Location = new System.Drawing.Point(56, 240);
            this.sifreGoster.Name = "sifreGoster";
            this.sifreGoster.Size = new System.Drawing.Size(81, 17);
            this.sifreGoster.TabIndex = 20;
            this.sifreGoster.Text = "Şifre Göster";
            this.sifreGoster.UseVisualStyleBackColor = true;
            this.sifreGoster.CheckedChanged += new System.EventHandler(this.sifreGoster_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(356, 440);
            this.Controls.Add(this.sifreGoster);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKayitOl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sisteme Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnKayitOl; // Değişken tanımı
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail;
        private ReaLTaiizor.Controls.HopeTextBox txtPsw;
        private ReaLTaiizor.Controls.HopeButton btnLogin;
        private System.Windows.Forms.CheckBox sifreGoster;
    }
}