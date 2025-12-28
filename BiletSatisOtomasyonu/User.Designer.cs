namespace BiletSatisOtomasyonu
{
    partial class User
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.pnlBilgi = new System.Windows.Forms.Panel();
            this.txtAdSoyad = new ReaLTaiizor.Controls.HopeTextBox();
            this.lblListeBaslik = new System.Windows.Forms.Label();
            this.dgvListe = new System.Windows.Forms.DataGridView();
            this.pnlListe = new System.Windows.Forms.Panel();
            this.txtEmail = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtTelefon = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtSifre = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnGuncelle = new ReaLTaiizor.Controls.HopeButton();
            this.btnCikis = new ReaLTaiizor.Controls.HopeButton();
            this.btnBiletIptal = new ReaLTaiizor.Controls.HopeButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).BeginInit();
            this.pnlListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(117, 32);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(90, 22);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Hesabım";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefon";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifre.ForeColor = System.Drawing.Color.White;
            this.lblSifre.Location = new System.Drawing.Point(10, 224);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 16);
            this.lblSifre.TabIndex = 7;
            this.lblSifre.Text = "Şifre";
            // 
            // pnlBilgi
            // 
            this.pnlBilgi.Controls.Add(this.btnCikis);
            this.pnlBilgi.Controls.Add(this.btnGuncelle);
            this.pnlBilgi.Controls.Add(this.txtSifre);
            this.pnlBilgi.Controls.Add(this.txtTelefon);
            this.pnlBilgi.Controls.Add(this.txtEmail);
            this.pnlBilgi.Controls.Add(this.txtAdSoyad);
            this.pnlBilgi.Controls.Add(this.label1);
            this.pnlBilgi.Controls.Add(this.label3);
            this.pnlBilgi.Controls.Add(this.label2);
            this.pnlBilgi.Controls.Add(this.lblSifre);
            this.pnlBilgi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlBilgi.Location = new System.Drawing.Point(3, 64);
            this.pnlBilgi.Name = "pnlBilgi";
            this.pnlBilgi.Size = new System.Drawing.Size(314, 380);
            this.pnlBilgi.TabIndex = 0;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.BackColor = System.Drawing.Color.White;
            this.txtAdSoyad.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtAdSoyad.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtAdSoyad.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtAdSoyad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAdSoyad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtAdSoyad.Hint = "";
            this.txtAdSoyad.Location = new System.Drawing.Point(13, 27);
            this.txtAdSoyad.MaxLength = 32767;
            this.txtAdSoyad.Multiline = false;
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.PasswordChar = '\0';
            this.txtAdSoyad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdSoyad.SelectedText = "";
            this.txtAdSoyad.SelectionLength = 0;
            this.txtAdSoyad.SelectionStart = 0;
            this.txtAdSoyad.Size = new System.Drawing.Size(287, 38);
            this.txtAdSoyad.TabIndex = 1;
            this.txtAdSoyad.TabStop = false;
            this.txtAdSoyad.UseSystemPasswordChar = false;
            // 
            // lblListeBaslik
            // 
            this.lblListeBaslik.AutoSize = true;
            this.lblListeBaslik.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblListeBaslik.ForeColor = System.Drawing.Color.White;
            this.lblListeBaslik.Location = new System.Drawing.Point(107, 8);
            this.lblListeBaslik.Name = "lblListeBaslik";
            this.lblListeBaslik.Size = new System.Drawing.Size(98, 16);
            this.lblListeBaslik.TabIndex = 1;
            this.lblListeBaslik.Text = "Son Biletlerim";
            // 
            // dgvListe
            // 
            this.dgvListe.AllowUserToAddRows = false;
            this.dgvListe.AllowUserToDeleteRows = false;
            this.dgvListe.AllowUserToResizeColumns = false;
            this.dgvListe.AllowUserToResizeRows = false;
            this.dgvListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.dgvListe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvListe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListe.EnableHeadersVisualStyles = false;
            this.dgvListe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvListe.Location = new System.Drawing.Point(13, 30);
            this.dgvListe.MultiSelect = false;
            this.dgvListe.Name = "dgvListe";
            this.dgvListe.ReadOnly = true;
            this.dgvListe.RowHeadersVisible = false;
            this.dgvListe.RowHeadersWidth = 40;
            this.dgvListe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvListe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListe.Size = new System.Drawing.Size(308, 67);
            this.dgvListe.TabIndex = 6;
            this.dgvListe.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvListe_DataBindingComplete);
            // 
            // pnlListe
            // 
            this.pnlListe.Controls.Add(this.panel1);
            this.pnlListe.Controls.Add(this.btnBiletIptal);
            this.pnlListe.Controls.Add(this.dgvListe);
            this.pnlListe.Controls.Add(this.lblListeBaslik);
            this.pnlListe.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlListe.Location = new System.Drawing.Point(3, 450);
            this.pnlListe.Name = "pnlListe";
            this.pnlListe.Size = new System.Drawing.Size(337, 144);
            this.pnlListe.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtEmail.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtEmail.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(13, 99);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(287, 38);
            this.txtEmail.TabIndex = 15;
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
            this.txtTelefon.Hint = "";
            this.txtTelefon.Location = new System.Drawing.Point(13, 171);
            this.txtTelefon.MaxLength = 32767;
            this.txtTelefon.Multiline = false;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.PasswordChar = '\0';
            this.txtTelefon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTelefon.SelectedText = "";
            this.txtTelefon.SelectionLength = 0;
            this.txtTelefon.SelectionStart = 0;
            this.txtTelefon.Size = new System.Drawing.Size(287, 38);
            this.txtTelefon.TabIndex = 16;
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
            this.txtSifre.Hint = "";
            this.txtSifre.Location = new System.Drawing.Point(13, 243);
            this.txtSifre.MaxLength = 32767;
            this.txtSifre.Multiline = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '\0';
            this.txtSifre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSifre.SelectedText = "";
            this.txtSifre.SelectionLength = 0;
            this.txtSifre.SelectionStart = 0;
            this.txtSifre.Size = new System.Drawing.Size(287, 38);
            this.txtSifre.TabIndex = 17;
            this.txtSifre.TabStop = false;
            this.txtSifre.UseSystemPasswordChar = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnGuncelle.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnGuncelle.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGuncelle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnGuncelle.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnGuncelle.Location = new System.Drawing.Point(13, 306);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnGuncelle.Size = new System.Drawing.Size(287, 30);
            this.btnGuncelle.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnGuncelle.TabIndex = 18;
            this.btnGuncelle.Text = "Bilgileri Güncelle";
            this.btnGuncelle.TextColor = System.Drawing.Color.White;
            this.btnGuncelle.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnCikis.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnCikis.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCikis.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnCikis.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnCikis.Location = new System.Drawing.Point(13, 342);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.PrimaryColor = System.Drawing.Color.IndianRed;
            this.btnCikis.Size = new System.Drawing.Size(287, 30);
            this.btnCikis.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnCikis.TabIndex = 19;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.TextColor = System.Drawing.Color.White;
            this.btnCikis.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnBiletIptal
            // 
            this.btnBiletIptal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnBiletIptal.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnBiletIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBiletIptal.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnBiletIptal.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBiletIptal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBiletIptal.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnBiletIptal.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnBiletIptal.Location = new System.Drawing.Point(13, 103);
            this.btnBiletIptal.Name = "btnBiletIptal";
            this.btnBiletIptal.PrimaryColor = System.Drawing.Color.IndianRed;
            this.btnBiletIptal.Size = new System.Drawing.Size(287, 30);
            this.btnBiletIptal.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnBiletIptal.TabIndex = 20;
            this.btnBiletIptal.Text = "Seçili Bileti İptal Et";
            this.btnBiletIptal.TextColor = System.Drawing.Color.White;
            this.btnBiletIptal.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnBiletIptal.Click += new System.EventHandler(this.btnBiletIptal_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(301, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 67);
            this.panel1.TabIndex = 21;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.pnlListe);
            this.Controls.Add(this.pnlBilgi);
            this.Controls.Add(this.lblBaslik);
            this.Name = "User";
            this.Size = new System.Drawing.Size(343, 613);
            this.Load += new System.EventHandler(this.User_Load);
            this.pnlBilgi.ResumeLayout(false);
            this.pnlBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).EndInit();
            this.pnlListe.ResumeLayout(false);
            this.pnlListe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // Değişkenler
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBilgi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblListeBaslik;
        private System.Windows.Forms.DataGridView dgvListe;
        private System.Windows.Forms.Panel pnlListe;
        private ReaLTaiizor.Controls.HopeTextBox txtAdSoyad;
        private ReaLTaiizor.Controls.HopeTextBox txtEmail;
        private ReaLTaiizor.Controls.HopeTextBox txtSifre;
        private ReaLTaiizor.Controls.HopeTextBox txtTelefon;
        private ReaLTaiizor.Controls.HopeButton btnGuncelle;
        private ReaLTaiizor.Controls.HopeButton btnCikis;
        private ReaLTaiizor.Controls.HopeButton btnBiletIptal;
        private System.Windows.Forms.Panel panel1;
    }
}