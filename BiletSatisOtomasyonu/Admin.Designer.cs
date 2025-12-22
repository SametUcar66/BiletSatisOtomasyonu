namespace BiletSatisOtomasyonu
{
    partial class Admin
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
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.grpFiltre = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.cmbRolFiltre = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDuzenle = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.cmbEditRol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEditTel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEditEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditAd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.grpFiltre.SuspendLayout();
            this.grpDuzenle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.Location = new System.Drawing.Point(20, 100);
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKullanicilar.Size = new System.Drawing.Size(810, 300);
            this.dgvKullanicilar.TabIndex = 0;
            this.dgvKullanicilar.SelectionChanged += new System.EventHandler(this.dgvKullanicilar_SelectionChanged);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(15, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(242, 25);
            this.lblBaslik.TabIndex = 2;
            this.lblBaslik.Text = "Sistem Kullanıcı Yönetimi";
            // 
            // grpFiltre
            // 
            this.grpFiltre.Controls.Add(this.btnTemizle);
            this.grpFiltre.Controls.Add(this.btnFiltrele);
            this.grpFiltre.Controls.Add(this.cmbRolFiltre);
            this.grpFiltre.Controls.Add(this.label1);
            this.grpFiltre.Controls.Add(this.btnAra);
            this.grpFiltre.Controls.Add(this.txtArama);
            this.grpFiltre.Controls.Add(this.label2);
            this.grpFiltre.Location = new System.Drawing.Point(20, 40);
            this.grpFiltre.Name = "grpFiltre";
            this.grpFiltre.Size = new System.Drawing.Size(810, 55);
            this.grpFiltre.TabIndex = 3;
            this.grpFiltre.TabStop = false;
            this.grpFiltre.Text = "Arama ve Filtreleme";
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(700, 17);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(90, 25);
            this.btnTemizle.TabIndex = 6;
            this.btnTemizle.Text = "Sıfırla";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(580, 17);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(75, 25);
            this.btnFiltrele.TabIndex = 5;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // cmbRolFiltre
            // 
            this.cmbRolFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolFiltre.FormattingEnabled = true;
            this.cmbRolFiltre.Location = new System.Drawing.Point(430, 19);
            this.cmbRolFiltre.Name = "cmbRolFiltre";
            this.cmbRolFiltre.Size = new System.Drawing.Size(140, 21);
            this.cmbRolFiltre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rol Seçimi:";
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(230, 17);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(75, 25);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(70, 19);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(150, 20);
            this.txtArama.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ad/Email:";
            // 
            // grpDuzenle
            // 
            this.grpDuzenle.Controls.Add(this.lblId);
            this.grpDuzenle.Controls.Add(this.btnGuncelle);
            this.grpDuzenle.Controls.Add(this.btnSil);
            this.grpDuzenle.Controls.Add(this.cmbEditRol);
            this.grpDuzenle.Controls.Add(this.label6);
            this.grpDuzenle.Controls.Add(this.txtEditTel);
            this.grpDuzenle.Controls.Add(this.label5);
            this.grpDuzenle.Controls.Add(this.txtEditEmail);
            this.grpDuzenle.Controls.Add(this.label4);
            this.grpDuzenle.Controls.Add(this.txtEditAd);
            this.grpDuzenle.Controls.Add(this.label3);
            this.grpDuzenle.Location = new System.Drawing.Point(20, 410);
            this.grpDuzenle.Name = "grpDuzenle";
            this.grpDuzenle.Size = new System.Drawing.Size(810, 120);
            this.grpDuzenle.TabIndex = 4;
            this.grpDuzenle.TabStop = false;
            this.grpDuzenle.Text = "Seçili Kullanıcı İşlemleri";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.Red;
            this.lblId.Location = new System.Drawing.Point(750, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(13, 13);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(500, 30);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 40);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Bilgileri Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.IndianRed;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(630, 30);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 40);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // cmbEditRol
            // 
            this.cmbEditRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditRol.FormattingEnabled = true;
            this.cmbEditRol.Location = new System.Drawing.Point(300, 70);
            this.cmbEditRol.Name = "cmbEditRol";
            this.cmbEditRol.Size = new System.Drawing.Size(150, 21);
            this.cmbEditRol.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Yetki:";
            // 
            // txtEditTel
            // 
            this.txtEditTel.Location = new System.Drawing.Point(300, 30);
            this.txtEditTel.Name = "txtEditTel";
            this.txtEditTel.Size = new System.Drawing.Size(150, 20);
            this.txtEditTel.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefon:";
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.Location = new System.Drawing.Point(80, 70);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEditEmail.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "E-Mail:";
            // 
            // txtEditAd
            // 
            this.txtEditAd.Location = new System.Drawing.Point(80, 30);
            this.txtEditAd.Name = "txtEditAd";
            this.txtEditAd.Size = new System.Drawing.Size(150, 20);
            this.txtEditAd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ad Soyad:";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDuzenle);
            this.Controls.Add(this.grpFiltre);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.dgvKullanicilar);
            this.Name = "Admin";
            this.Size = new System.Drawing.Size(850, 550);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.grpFiltre.ResumeLayout(false);
            this.grpFiltre.PerformLayout();
            this.grpDuzenle.ResumeLayout(false);
            this.grpDuzenle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox grpFiltre;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRolFiltre;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.GroupBox grpDuzenle;
        private System.Windows.Forms.TextBox txtEditAd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEditEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEditRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblId;
    }
}