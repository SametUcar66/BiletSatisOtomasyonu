namespace BiletSatisOtomasyonu
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbKayitTuru = new System.Windows.Forms.ComboBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnKayitTamamla = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // cmbKayitTuru (Kayıt Türü Seçimi)
            // 
            this.cmbKayitTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKayitTuru.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbKayitTuru.FormattingEnabled = true;
            this.cmbKayitTuru.Items.AddRange(new object[] {
    "Bireysel Müşteri",
    "Acente Yöneticisi",
    "Kurumsal Şirket"});
            this.cmbKayitTuru.Location = new System.Drawing.Point(50, 40);
            this.cmbKayitTuru.Name = "cmbKayitTuru";
            this.cmbKayitTuru.Size = new System.Drawing.Size(250, 28);
            this.cmbKayitTuru.TabIndex = 0;
            this.cmbKayitTuru.SelectedIndexChanged += new System.EventHandler(this.cmbKayitTuru_SelectedIndexChanged);

            // 
            // txtAdSoyad (Ad Soyad / Şirket Adı)
            // 
            this.txtAdSoyad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAdSoyad.ForeColor = System.Drawing.Color.Gray;
            this.txtAdSoyad.Location = new System.Drawing.Point(50, 90);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(250, 27);
            this.txtAdSoyad.TabIndex = 1;
            this.txtAdSoyad.Text = "Ad Soyad";
            this.txtAdSoyad.Enter += new System.EventHandler(this.txtAdSoyad_Enter);
            this.txtAdSoyad.Leave += new System.EventHandler(this.txtAdSoyad_Leave);

            // 
            // txtEmail (E-posta)
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEmail.Location = new System.Drawing.Point(50, 140);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 27);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "E-posta Adresi";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);

            // 
            // txtTelefon (Telefon)
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelefon.ForeColor = System.Drawing.Color.Gray;
            this.txtTelefon.Location = new System.Drawing.Point(50, 190);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(250, 27);
            this.txtTelefon.TabIndex = 3;
            this.txtTelefon.Text = "Telefon Numarası";
            this.txtTelefon.Enter += new System.EventHandler(this.txtTelefon_Enter);
            this.txtTelefon.Leave += new System.EventHandler(this.txtTelefon_Leave);

            // 
            // txtSifre (Şifre)
            // 
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSifre.ForeColor = System.Drawing.Color.Gray;
            this.txtSifre.Location = new System.Drawing.Point(50, 240);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(250, 27);
            this.txtSifre.TabIndex = 4;
            this.txtSifre.Text = "Şifre";
            this.txtSifre.Enter += new System.EventHandler(this.txtSifre_Enter);
            this.txtSifre.Leave += new System.EventHandler(this.txtSifre_Leave);

            // 
            // btnKayitTamamla (Buton)
            // 
            this.btnKayitTamamla.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnKayitTamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitTamamla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKayitTamamla.ForeColor = System.Drawing.Color.White;
            this.btnKayitTamamla.Location = new System.Drawing.Point(50, 300);
            this.btnKayitTamamla.Name = "btnKayitTamamla";
            this.btnKayitTamamla.Size = new System.Drawing.Size(250, 40);
            this.btnKayitTamamla.TabIndex = 5;
            this.btnKayitTamamla.Text = "KAYIT OL";
            this.btnKayitTamamla.UseVisualStyleBackColor = false;
            this.btnKayitTamamla.Click += new System.EventHandler(this.btnKayitTamamla_Click);

            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 400);
            this.Controls.Add(this.btnKayitTamamla);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.cmbKayitTuru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // BU KISIM DESIGNER DOSYASININ ALTINDA TANIMLI OLMALI
        private System.Windows.Forms.ComboBox cmbKayitTuru;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnKayitTamamla;

        #endregion
    }
}