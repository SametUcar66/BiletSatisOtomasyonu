namespace BiletSatisOtomasyonu
{
    partial class BiletArama
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlAracTipi = new System.Windows.Forms.Panel();
            this.rbTumu = new System.Windows.Forms.RadioButton();
            this.rbTren = new System.Windows.Forms.RadioButton();
            this.rbOtobus = new System.Windows.Forms.RadioButton();
            this.rbUcak = new System.Windows.Forms.RadioButton();
            this.pnlArama = new System.Windows.Forms.Panel();
            this.btnAra = new System.Windows.Forms.Button();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.cmbVaris = new System.Windows.Forms.ComboBox();
            this.cmbKalkis = new System.Windows.Forms.ComboBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblVaris = new System.Windows.Forms.Label();
            this.lblKalkis = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.pnlKoltuk = new System.Windows.Forms.Panel();
            this.lblKoltukSecimi = new System.Windows.Forms.Label();
            this.flpKoltuklar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSatinAl = new System.Windows.Forms.Panel();
            this.lblToplamFiyat = new System.Windows.Forms.Label();
            this.lblSecilenKoltuk = new System.Windows.Forms.Label();
            this.btnSatinAl = new System.Windows.Forms.Button();
            this.pnlAracTipi.SuspendLayout();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.pnlKoltuk.SuspendLayout();
            this.pnlSatinAl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAracTipi
            // 
            this.pnlAracTipi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.pnlAracTipi.Controls.Add(this.rbTumu);
            this.pnlAracTipi.Controls.Add(this.rbTren);
            this.pnlAracTipi.Controls.Add(this.rbOtobus);
            this.pnlAracTipi.Controls.Add(this.rbUcak);
            this.pnlAracTipi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAracTipi.Location = new System.Drawing.Point(0, 0);
            this.pnlAracTipi.Name = "pnlAracTipi";
            this.pnlAracTipi.Size = new System.Drawing.Size(900, 50);
            this.pnlAracTipi.TabIndex = 0;
            // 
            // rbTumu
            // 
            this.rbTumu.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.rbTumu.FlatAppearance.BorderSize = 0;
            this.rbTumu.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.rbTumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbTumu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbTumu.ForeColor = System.Drawing.Color.White;
            this.rbTumu.Location = new System.Drawing.Point(20, 8);
            this.rbTumu.Name = "rbTumu";
            this.rbTumu.Size = new System.Drawing.Size(120, 35);
            this.rbTumu.TabIndex = 0;
            this.rbTumu.TabStop = true;
            this.rbTumu.Text = "🎫 Tümü";
            this.rbTumu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTumu.UseVisualStyleBackColor = false;
            // 
            // rbUcak
            // 
            this.rbUcak.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbUcak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.rbUcak.FlatAppearance.BorderSize = 0;
            this.rbUcak.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.rbUcak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbUcak.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbUcak.ForeColor = System.Drawing.Color.White;
            this.rbUcak.Location = new System.Drawing.Point(150, 8);
            this.rbUcak.Name = "rbUcak";
            this.rbUcak.Size = new System.Drawing.Size(120, 35);
            this.rbUcak.TabIndex = 1;
            this.rbUcak.TabStop = true;
            this.rbUcak.Text = "✈ Uçak";
            this.rbUcak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbUcak.UseVisualStyleBackColor = false;
            // 
            // rbOtobus
            // 
            this.rbOtobus.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOtobus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.rbOtobus.FlatAppearance.BorderSize = 0;
            this.rbOtobus.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.rbOtobus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbOtobus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbOtobus.ForeColor = System.Drawing.Color.White;
            this.rbOtobus.Location = new System.Drawing.Point(280, 8);
            this.rbOtobus.Name = "rbOtobus";
            this.rbOtobus.Size = new System.Drawing.Size(120, 35);
            this.rbOtobus.TabIndex = 2;
            this.rbOtobus.TabStop = true;
            this.rbOtobus.Text = "🚌 Otobüs";
            this.rbOtobus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOtobus.UseVisualStyleBackColor = false;
            // 
            // rbTren
            // 
            this.rbTren.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTren.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.rbTren.FlatAppearance.BorderSize = 0;
            this.rbTren.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.rbTren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbTren.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.rbTren.ForeColor = System.Drawing.Color.White;
            this.rbTren.Location = new System.Drawing.Point(410, 8);
            this.rbTren.Name = "rbTren";
            this.rbTren.Size = new System.Drawing.Size(120, 35);
            this.rbTren.TabIndex = 3;
            this.rbTren.TabStop = true;
            this.rbTren.Text = "🚂 Tren";
            this.rbTren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTren.UseVisualStyleBackColor = false;
            // 
            // pnlArama
            // 
            this.pnlArama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlArama.Controls.Add(this.btnAra);
            this.pnlArama.Controls.Add(this.dtpTarih);
            this.pnlArama.Controls.Add(this.cmbVaris);
            this.pnlArama.Controls.Add(this.cmbKalkis);
            this.pnlArama.Controls.Add(this.lblTarih);
            this.pnlArama.Controls.Add(this.lblVaris);
            this.pnlArama.Controls.Add(this.lblKalkis);
            this.pnlArama.Controls.Add(this.lblBaslik);
            this.pnlArama.Location = new System.Drawing.Point(0, 50);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(900, 100);
            this.pnlArama.TabIndex = 1;
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAra.FlatAppearance.BorderSize = 0;
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.Location = new System.Drawing.Point(760, 45);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(120, 40);
            this.btnAra.TabIndex = 7;
            this.btnAra.Text = "🔍 Filtrele";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // dtpTarih
            // 
            this.dtpTarih.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(560, 50);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(160, 30);
            this.dtpTarih.TabIndex = 6;
            // 
            // cmbVaris
            // 
            this.cmbVaris.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaris.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbVaris.FormattingEnabled = true;
            this.cmbVaris.Location = new System.Drawing.Point(290, 50);
            this.cmbVaris.Name = "cmbVaris";
            this.cmbVaris.Size = new System.Drawing.Size(230, 31);
            this.cmbVaris.TabIndex = 5;
            // 
            // cmbKalkis
            // 
            this.cmbKalkis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKalkis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKalkis.FormattingEnabled = true;
            this.cmbKalkis.Location = new System.Drawing.Point(20, 50);
            this.cmbKalkis.Name = "cmbKalkis";
            this.cmbKalkis.Size = new System.Drawing.Size(230, 31);
            this.cmbKalkis.TabIndex = 4;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTarih.ForeColor = System.Drawing.Color.White;
            this.lblTarih.Location = new System.Drawing.Point(560, 25);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(47, 20);
            this.lblTarih.TabIndex = 3;
            this.lblTarih.Text = "Tarih";
            // 
            // lblVaris
            // 
            this.lblVaris.AutoSize = true;
            this.lblVaris.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVaris.ForeColor = System.Drawing.Color.White;
            this.lblVaris.Location = new System.Drawing.Point(290, 25);
            this.lblVaris.Name = "lblVaris";
            this.lblVaris.Size = new System.Drawing.Size(98, 20);
            this.lblVaris.TabIndex = 2;
            this.lblVaris.Text = "Varış Noktası";
            // 
            // lblKalkis
            // 
            this.lblKalkis.AutoSize = true;
            this.lblKalkis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKalkis.ForeColor = System.Drawing.Color.White;
            this.lblKalkis.Location = new System.Drawing.Point(20, 25);
            this.lblKalkis.Name = "lblKalkis";
            this.lblKalkis.Size = new System.Drawing.Size(106, 20);
            this.lblKalkis.TabIndex = 1;
            this.lblKalkis.Text = "Kalkış Noktası";
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblBaslik.Location = new System.Drawing.Point(10, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(150, 28);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🎫 Tüm Seferler";
            // 
            // dgvSeferler
            // 
            this.dgvSeferler.AllowUserToAddRows = false;
            this.dgvSeferler.AllowUserToDeleteRows = false;
            this.dgvSeferler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeferler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeferler.Location = new System.Drawing.Point(0, 150);
            this.dgvSeferler.MultiSelect = false;
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.ReadOnly = true;
            this.dgvSeferler.RowHeadersWidth = 51;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(900, 180);
            this.dgvSeferler.TabIndex = 2;
            this.dgvSeferler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeferler_CellClick);
            // 
            // pnlKoltuk
            // 
            this.pnlKoltuk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlKoltuk.Controls.Add(this.lblKoltukSecimi);
            this.pnlKoltuk.Controls.Add(this.flpKoltuklar);
            this.pnlKoltuk.Location = new System.Drawing.Point(0, 330);
            this.pnlKoltuk.Name = "pnlKoltuk";
            this.pnlKoltuk.Size = new System.Drawing.Size(900, 170);
            this.pnlKoltuk.TabIndex = 3;
            // 
            // lblKoltukSecimi
            // 
            this.lblKoltukSecimi.AutoSize = true;
            this.lblKoltukSecimi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblKoltukSecimi.ForeColor = System.Drawing.Color.White;
            this.lblKoltukSecimi.Location = new System.Drawing.Point(10, 8);
            this.lblKoltukSecimi.Name = "lblKoltukSecimi";
            this.lblKoltukSecimi.Size = new System.Drawing.Size(140, 25);
            this.lblKoltukSecimi.TabIndex = 0;
            this.lblKoltukSecimi.Text = "Koltuk Seçimi";
            // 
            // flpKoltuklar
            // 
            this.flpKoltuklar.AutoScroll = true;
            this.flpKoltuklar.Location = new System.Drawing.Point(10, 35);
            this.flpKoltuklar.Name = "flpKoltuklar";
            this.flpKoltuklar.Size = new System.Drawing.Size(880, 125);
            this.flpKoltuklar.TabIndex = 1;
            // 
            // pnlSatinAl
            // 
            this.pnlSatinAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlSatinAl.Controls.Add(this.lblToplamFiyat);
            this.pnlSatinAl.Controls.Add(this.lblSecilenKoltuk);
            this.pnlSatinAl.Controls.Add(this.btnSatinAl);
            this.pnlSatinAl.Location = new System.Drawing.Point(0, 500);
            this.pnlSatinAl.Name = "pnlSatinAl";
            this.pnlSatinAl.Size = new System.Drawing.Size(900, 80);
            this.pnlSatinAl.TabIndex = 4;
            // 
            // lblToplamFiyat
            // 
            this.lblToplamFiyat.AutoSize = true;
            this.lblToplamFiyat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamFiyat.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblToplamFiyat.Location = new System.Drawing.Point(400, 25);
            this.lblToplamFiyat.Name = "lblToplamFiyat";
            this.lblToplamFiyat.Size = new System.Drawing.Size(150, 28);
            this.lblToplamFiyat.TabIndex = 2;
            this.lblToplamFiyat.Text = "Toplam: 0.00 ₺";
            // 
            // lblSecilenKoltuk
            // 
            this.lblSecilenKoltuk.AutoSize = true;
            this.lblSecilenKoltuk.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSecilenKoltuk.ForeColor = System.Drawing.Color.White;
            this.lblSecilenKoltuk.Location = new System.Drawing.Point(20, 28);
            this.lblSecilenKoltuk.Name = "lblSecilenKoltuk";
            this.lblSecilenKoltuk.Size = new System.Drawing.Size(175, 23);
            this.lblSecilenKoltuk.TabIndex = 1;
            this.lblSecilenKoltuk.Text = "Seçilen Koltuk: Yok";
            // 
            // btnSatinAl
            // 
            this.btnSatinAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSatinAl.FlatAppearance.BorderSize = 0;
            this.btnSatinAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatinAl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSatinAl.ForeColor = System.Drawing.Color.White;
            this.btnSatinAl.Location = new System.Drawing.Point(720, 15);
            this.btnSatinAl.Name = "btnSatinAl";
            this.btnSatinAl.Size = new System.Drawing.Size(160, 50);
            this.btnSatinAl.TabIndex = 0;
            this.btnSatinAl.Text = "💳 Satın Al";
            this.btnSatinAl.UseVisualStyleBackColor = false;
            this.btnSatinAl.Click += new System.EventHandler(this.btnSatinAl_Click);
            // 
            // BiletArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.pnlSatinAl);
            this.Controls.Add(this.pnlKoltuk);
            this.Controls.Add(this.dgvSeferler);
            this.Controls.Add(this.pnlArama);
            this.Controls.Add(this.pnlAracTipi);
            this.Name = "BiletArama";
            this.Size = new System.Drawing.Size(900, 580);
            this.Load += new System.EventHandler(this.BiletArama_Load);
            this.pnlAracTipi.ResumeLayout(false);
            this.pnlArama.ResumeLayout(false);
            this.pnlArama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).EndInit();
            this.pnlKoltuk.ResumeLayout(false);
            this.pnlKoltuk.PerformLayout();
            this.pnlSatinAl.ResumeLayout(false);
            this.pnlSatinAl.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlAracTipi;
        private System.Windows.Forms.RadioButton rbTumu;
        private System.Windows.Forms.RadioButton rbTren;
        private System.Windows.Forms.RadioButton rbOtobus;
        private System.Windows.Forms.RadioButton rbUcak;
        private System.Windows.Forms.Panel pnlArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ComboBox cmbVaris;
        private System.Windows.Forms.ComboBox cmbKalkis;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblVaris;
        private System.Windows.Forms.Label lblKalkis;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.DataGridView dgvSeferler;
        private System.Windows.Forms.Panel pnlKoltuk;
        private System.Windows.Forms.Label lblKoltukSecimi;
        private System.Windows.Forms.FlowLayoutPanel flpKoltuklar;
        private System.Windows.Forms.Panel pnlSatinAl;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.Label lblSecilenKoltuk;
        private System.Windows.Forms.Button btnSatinAl;
    }
}