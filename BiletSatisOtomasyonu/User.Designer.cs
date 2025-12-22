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
            this.lblBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.pnlBilgi = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.dgvListe = new System.Windows.Forms.DataGridView();
            this.lblListeBaslik = new System.Windows.Forms.Label();
            this.pnlListe = new System.Windows.Forms.Panel();
            this.btnBiletIptal = new System.Windows.Forms.Button(); // YENİ BUTON
            this.pnlBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListe)).BeginInit();
            this.pnlListe.SuspendLayout();
            this.SuspendLayout();

            // lblBaslik
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblBaslik.ForeColor = System.Drawing.Color.DimGray;
            this.lblBaslik.Location = new System.Drawing.Point(10, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(83, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Hesabım";

            // label1
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad Soyad:";

            // txtAdSoyad
            this.txtAdSoyad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAdSoyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdSoyad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAdSoyad.Location = new System.Drawing.Point(13, 65);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(200, 20);
            this.txtAdSoyad.TabIndex = 2;

            // txtEmail
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Location = new System.Drawing.Point(13, 115);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 4;

            // label2
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(10, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";

            // txtTelefon
            this.txtTelefon.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTelefon.Location = new System.Drawing.Point(13, 165);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(200, 20);
            this.txtTelefon.TabIndex = 6;

            // label3
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(10, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefon:";

            // lblSifre
            this.lblSifre.AutoSize = true;
            this.lblSifre.ForeColor = System.Drawing.Color.Gray;
            this.lblSifre.Location = new System.Drawing.Point(10, 195);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(33, 15);
            this.lblSifre.TabIndex = 7;
            this.lblSifre.Text = "Şifre:";

            // txtSifre
            this.txtSifre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSifre.Location = new System.Drawing.Point(13, 215);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(200, 20);
            this.txtSifre.TabIndex = 8;

            // pnlBilgi
            this.pnlBilgi.Controls.Add(this.btnCikis);
            this.pnlBilgi.Controls.Add(this.btnGuncelle);
            this.pnlBilgi.Controls.Add(this.txtAdSoyad);
            this.pnlBilgi.Controls.Add(this.txtTelefon);
            this.pnlBilgi.Controls.Add(this.label1);
            this.pnlBilgi.Controls.Add(this.label3);
            this.pnlBilgi.Controls.Add(this.label2);
            this.pnlBilgi.Controls.Add(this.txtEmail);
            this.pnlBilgi.Controls.Add(this.lblSifre);
            this.pnlBilgi.Controls.Add(this.txtSifre);
            this.pnlBilgi.Location = new System.Drawing.Point(15, 50);
            this.pnlBilgi.Name = "pnlBilgi";
            this.pnlBilgi.Size = new System.Drawing.Size(250, 350);
            this.pnlBilgi.TabIndex = 7;

            // btnGuncelle
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(13, 260);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(200, 30);
            this.btnGuncelle.TabIndex = 9;
            this.btnGuncelle.Text = "Bilgileri Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);

            // btnCikis
            this.btnCikis.BackColor = System.Drawing.Color.IndianRed;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCikis.ForeColor = System.Drawing.Color.White;
            this.btnCikis.Location = new System.Drawing.Point(13, 300);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(200, 30);
            this.btnCikis.TabIndex = 10;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);

            // dgvListe
            this.dgvListe.Location = new System.Drawing.Point(0, 30);
            this.dgvListe.Name = "dgvListe";
            this.dgvListe.Size = new System.Drawing.Size(250, 120);
            this.dgvListe.TabIndex = 0;

            // lblListeBaslik
            this.lblListeBaslik.AutoSize = true;
            this.lblListeBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblListeBaslik.Location = new System.Drawing.Point(0, 5);
            this.lblListeBaslik.Name = "lblListeBaslik";
            this.lblListeBaslik.Size = new System.Drawing.Size(107, 19);
            this.lblListeBaslik.Text = "Son Biletlerim";

            // btnBiletIptal (YENİLENEN KISIM)
            this.btnBiletIptal.BackColor = System.Drawing.Color.OrangeRed;
            this.btnBiletIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBiletIptal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBiletIptal.ForeColor = System.Drawing.Color.White;
            this.btnBiletIptal.Location = new System.Drawing.Point(0, 160);
            this.btnBiletIptal.Name = "btnBiletIptal";
            this.btnBiletIptal.Size = new System.Drawing.Size(250, 30);
            this.btnBiletIptal.TabIndex = 11;
            this.btnBiletIptal.Text = "Seçili Bileti İptal Et";
            this.btnBiletIptal.UseVisualStyleBackColor = false;
            this.btnBiletIptal.Click += new System.EventHandler(this.btnBiletIptal_Click);

            // pnlListe
            this.pnlListe.Controls.Add(this.dgvListe);
            this.pnlListe.Controls.Add(this.lblListeBaslik);
            this.pnlListe.Controls.Add(this.btnBiletIptal); // Buton panele eklendi
            this.pnlListe.Location = new System.Drawing.Point(300, 50);
            this.pnlListe.Name = "pnlListe";
            this.pnlListe.Size = new System.Drawing.Size(250, 200);
            this.pnlListe.TabIndex = 10;
            this.pnlListe.Visible = false;

            // User Control
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.pnlListe);
            this.Controls.Add(this.pnlBilgi);
            this.Controls.Add(this.lblBaslik);
            this.Name = "User";
            this.Size = new System.Drawing.Size(600, 450);
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
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBilgi;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.DataGridView dgvListe;
        private System.Windows.Forms.Label lblListeBaslik;
        private System.Windows.Forms.Panel pnlListe;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button btnBiletIptal; // Yeni buton tanımı
    }
}