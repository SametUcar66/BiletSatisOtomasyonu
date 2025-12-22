namespace BiletSatisOtomasyonu
{
    partial class AjentaAdmin
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
            this.grpPersonel = new System.Windows.Forms.GroupBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.grpSatislar = new System.Windows.Forms.GroupBox();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.grpPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            this.grpSatislar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Location = new System.Drawing.Point(10, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(248, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Acente Yönetim Paneli";
            // 
            // grpPersonel
            // 
            this.grpPersonel.Controls.Add(this.btnSil);
            this.grpPersonel.Controls.Add(this.btnEkle);
            this.grpPersonel.Controls.Add(this.txtSifre);
            this.grpPersonel.Controls.Add(this.label3);
            this.grpPersonel.Controls.Add(this.txtEmail);
            this.grpPersonel.Controls.Add(this.label2);
            this.grpPersonel.Controls.Add(this.txtAd);
            this.grpPersonel.Controls.Add(this.label1);
            this.grpPersonel.Controls.Add(this.dgvPersonel);
            this.grpPersonel.Location = new System.Drawing.Point(15, 50);
            this.grpPersonel.Name = "grpPersonel";
            this.grpPersonel.Size = new System.Drawing.Size(400, 500);
            this.grpPersonel.TabIndex = 1;
            this.grpPersonel.TabStop = false;
            this.grpPersonel.Text = "Personel Yönetimi (Acente Çalışanları)";
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.IndianRed;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(280, 130);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 30);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Location = new System.Drawing.Point(80, 130);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(190, 30);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Yeni Çalışan Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(80, 95);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(190, 20);
            this.txtSifre.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Şifre:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(80, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(190, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-Mail:";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(80, 35);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(190, 20);
            this.txtAd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad Soyad:";
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonel.Location = new System.Drawing.Point(10, 180);
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.RowHeadersVisible = false;
            this.dgvPersonel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonel.Size = new System.Drawing.Size(380, 310);
            this.dgvPersonel.TabIndex = 0;
            // 
            // grpSatislar
            // 
            this.grpSatislar.Controls.Add(this.dgvSatislar);
            this.grpSatislar.Location = new System.Drawing.Point(430, 50);
            this.grpSatislar.Name = "grpSatislar";
            this.grpSatislar.Size = new System.Drawing.Size(450, 500);
            this.grpSatislar.TabIndex = 2;
            this.grpSatislar.TabStop = false;
            this.grpSatislar.Text = "Tüm Satış Raporları";
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatislar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSatislar.Location = new System.Drawing.Point(3, 16);
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.RowHeadersVisible = false;
            this.dgvSatislar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatislar.Size = new System.Drawing.Size(444, 481);
            this.dgvSatislar.TabIndex = 0;
            // 
            // AjentaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSatislar);
            this.Controls.Add(this.grpPersonel);
            this.Controls.Add(this.lblBaslik);
            this.Name = "AjentaAdmin";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.AjentaAdmin_Load);
            this.grpPersonel.ResumeLayout(false);
            this.grpPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            this.grpSatislar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox grpPersonel;
        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSatislar;
        private System.Windows.Forms.DataGridView dgvSatislar;
    }
}