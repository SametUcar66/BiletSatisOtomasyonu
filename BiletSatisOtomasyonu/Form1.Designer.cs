namespace BiletSatisOtomasyonu
{
    partial class Form1
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
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGirisYap = new System.Windows.Forms.Button();
            this.chkSifreGoster = new System.Windows.Forms.CheckBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.kayitol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMail
            // 
            this.txtMail.ForeColor = System.Drawing.Color.Gray;
            this.txtMail.Location = new System.Drawing.Point(216, 80);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(180, 20);
            this.txtMail.TabIndex = 0;
            this.txtMail.Text = "E-posta adresinizi girin";
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.Leave += new System.EventHandler(this.txtMail_Leave);
            // 
            // txtSifre
            // 
            this.txtSifre.ForeColor = System.Drawing.Color.Gray;
            this.txtSifre.Location = new System.Drawing.Point(216, 133);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(180, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.Text = "Şifrenizi girin";
            this.txtSifre.Enter += new System.EventHandler(this.txtSifre_Enter);
            this.txtSifre.Leave += new System.EventHandler(this.txtSifre_Leave);
            // 
            // btnGirisYap
            // 
            this.btnGirisYap.Location = new System.Drawing.Point(216, 182);
            this.btnGirisYap.Name = "btnGirisYap";
            this.btnGirisYap.Size = new System.Drawing.Size(180, 23);
            this.btnGirisYap.TabIndex = 2;
            this.btnGirisYap.Text = "Giriş Yap";
            this.btnGirisYap.UseVisualStyleBackColor = true;
            this.btnGirisYap.Click += new System.EventHandler(this.btnGirisYap_Click);
            // 
            // chkSifreGoster
            // 
            this.chkSifreGoster.AutoSize = true;
            this.chkSifreGoster.Location = new System.Drawing.Point(216, 159);
            this.chkSifreGoster.Name = "chkSifreGoster";
            this.chkSifreGoster.Size = new System.Drawing.Size(88, 17);
            this.chkSifreGoster.TabIndex = 3;
            this.chkSifreGoster.Text = "Şifreyi Göster";
            this.chkSifreGoster.UseVisualStyleBackColor = true;
            this.chkSifreGoster.CheckedChanged += new System.EventHandler(this.chkSifreGoster_CheckedChanged);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(216, 40);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(94, 24);
            this.lblBaslik.TabIndex = 4;
            this.lblBaslik.Text = "Giriş Yap";
            // 
            // kayitol
            // 
            this.kayitol.AutoSize = true;
            this.kayitol.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.kayitol.Location = new System.Drawing.Point(216, 228);
            this.kayitol.Name = "kayitol";
            this.kayitol.Size = new System.Drawing.Size(155, 13);
            this.kayitol.TabIndex = 5;
            this.kayitol.Text = "Hesabınız Yok mu ? Kayıt Olun.";
            this.kayitol.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kayitol);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.chkSifreGoster);
            this.Controls.Add(this.btnGirisYap);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtMail);
            this.Name = "Form1";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGirisYap;
        private System.Windows.Forms.CheckBox chkSifreGoster;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label kayitol;
    }
}

