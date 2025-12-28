namespace BiletSatisOtomasyonu
{
    partial class musteri
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
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.grpArama = new System.Windows.Forms.GroupBox();
            this.cmbNereden = new System.Windows.Forms.ComboBox();
            this.cmbNereye = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpKoltuklar = new System.Windows.Forms.GroupBox();
            this.pnlKoltukDizilimi = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUyari = new System.Windows.Forms.Label();
            this.grpIslem = new System.Windows.Forms.GroupBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblSecilenKoltuk = new System.Windows.Forms.Label();
            this.btnSatinAl = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.grpArama.SuspendLayout();
            this.grpKoltuklar.SuspendLayout();
            this.pnlKoltukDizilimi.SuspendLayout();
            this.grpIslem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSeferler
            // 
            this.dgvSeferler.AllowUserToAddRows = false;
            this.dgvSeferler.AllowUserToDeleteRows = false;
            this.dgvSeferler.AllowUserToResizeColumns = false;
            this.dgvSeferler.AllowUserToResizeRows = false;
            this.dgvSeferler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeferler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvSeferler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeferler.EnableHeadersVisualStyles = false;
            this.dgvSeferler.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSeferler.Location = new System.Drawing.Point(37, 102);
            this.dgvSeferler.MultiSelect = false;
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.ReadOnly = true;
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(514, 516);
            this.dgvSeferler.TabIndex = 4;
            this.dgvSeferler.SelectionChanged += new System.EventHandler(this.dgvSeferler_SelectionChanged);
            // 
            // grpArama
            // 
            this.grpArama.Controls.Add(this.cmbNereden);
            this.grpArama.Controls.Add(this.cmbNereye);
            this.grpArama.Controls.Add(this.label3);
            this.grpArama.Controls.Add(this.dtpTarih);
            this.grpArama.Controls.Add(this.label2);
            this.grpArama.Controls.Add(this.btnAra);
            this.grpArama.Controls.Add(this.label1);
            this.grpArama.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpArama.ForeColor = System.Drawing.Color.White;
            this.grpArama.Location = new System.Drawing.Point(37, 20);
            this.grpArama.Name = "grpArama";
            this.grpArama.Size = new System.Drawing.Size(820, 70);
            this.grpArama.TabIndex = 0;
            this.grpArama.TabStop = false;
            this.grpArama.Text = "Sefer Arama";
            // 
            // cmbNereden
            // 
            this.cmbNereden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.Location = new System.Drawing.Point(70, 30);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(120, 22);
            this.cmbNereden.TabIndex = 0;
            // 
            // cmbNereye
            // 
            this.cmbNereye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.Location = new System.Drawing.Point(260, 30);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(120, 22);
            this.cmbNereye.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nereden:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(440, 30);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(100, 20);
            this.dtpTarih.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tarih:";
            // 
            // btnAra
            // 
            this.btnAra.ForeColor = System.Drawing.Color.Black;
            this.btnAra.Location = new System.Drawing.Point(560, 27);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(120, 25);
            this.btnAra.TabIndex = 3;
            this.btnAra.Text = "Sefer Bul";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nereye:";
            // 
            // grpKoltuklar
            // 
            this.grpKoltuklar.Controls.Add(this.pnlKoltukDizilimi);
            this.grpKoltuklar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpKoltuklar.ForeColor = System.Drawing.Color.White;
            this.grpKoltuklar.Location = new System.Drawing.Point(557, 96);
            this.grpKoltuklar.Name = "grpKoltuklar";
            this.grpKoltuklar.Size = new System.Drawing.Size(300, 346);
            this.grpKoltuklar.TabIndex = 2;
            this.grpKoltuklar.TabStop = false;
            this.grpKoltuklar.Text = "Koltuk Seçimi";
            // 
            // pnlKoltukDizilimi
            // 
            this.pnlKoltukDizilimi.AutoScroll = true;
            this.pnlKoltukDizilimi.Controls.Add(this.lblUyari);
            this.pnlKoltukDizilimi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKoltukDizilimi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pnlKoltukDizilimi.ForeColor = System.Drawing.Color.Black;
            this.pnlKoltukDizilimi.Location = new System.Drawing.Point(3, 16);
            this.pnlKoltukDizilimi.Name = "pnlKoltukDizilimi";
            this.pnlKoltukDizilimi.Padding = new System.Windows.Forms.Padding(10);
            this.pnlKoltukDizilimi.Size = new System.Drawing.Size(294, 327);
            this.pnlKoltukDizilimi.TabIndex = 5;
            // 
            // lblUyari
            // 
            this.lblUyari.ForeColor = System.Drawing.Color.Red;
            this.lblUyari.Location = new System.Drawing.Point(13, 10);
            this.lblUyari.Name = "lblUyari";
            this.lblUyari.Size = new System.Drawing.Size(260, 30);
            this.lblUyari.TabIndex = 1;
            this.lblUyari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUyari.Visible = false;
            // 
            // grpIslem
            // 
            this.grpIslem.Controls.Add(this.lblFiyat);
            this.grpIslem.Controls.Add(this.lblSecilenKoltuk);
            this.grpIslem.Controls.Add(this.btnSatinAl);
            this.grpIslem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpIslem.ForeColor = System.Drawing.Color.White;
            this.grpIslem.Location = new System.Drawing.Point(557, 448);
            this.grpIslem.Name = "grpIslem";
            this.grpIslem.Size = new System.Drawing.Size(300, 170);
            this.grpIslem.TabIndex = 3;
            this.grpIslem.TabStop = false;
            this.grpIslem.Text = "Ödeme ve Onay";
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiyat.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblFiyat.Location = new System.Drawing.Point(20, 53);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(103, 19);
            this.lblFiyat.TabIndex = 2;
            this.lblFiyat.Text = "Tutar: 0.00 ₺";
            // 
            // lblSecilenKoltuk
            // 
            this.lblSecilenKoltuk.AutoSize = true;
            this.lblSecilenKoltuk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecilenKoltuk.ForeColor = System.Drawing.Color.White;
            this.lblSecilenKoltuk.Location = new System.Drawing.Point(21, 28);
            this.lblSecilenKoltuk.Name = "lblSecilenKoltuk";
            this.lblSecilenKoltuk.Size = new System.Drawing.Size(129, 16);
            this.lblSecilenKoltuk.TabIndex = 1;
            this.lblSecilenKoltuk.Text = "Seçilen Koltuk: Yok";
            // 
            // btnSatinAl
            // 
            this.btnSatinAl.BackColor = System.Drawing.Color.SlateGray;
            this.btnSatinAl.Enabled = false;
            this.btnSatinAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatinAl.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatinAl.ForeColor = System.Drawing.Color.White;
            this.btnSatinAl.Location = new System.Drawing.Point(20, 118);
            this.btnSatinAl.Name = "btnSatinAl";
            this.btnSatinAl.Size = new System.Drawing.Size(260, 40);
            this.btnSatinAl.TabIndex = 6;
            this.btnSatinAl.Text = "Bileti Satın Al";
            this.btnSatinAl.UseVisualStyleBackColor = false;
            this.btnSatinAl.Click += new System.EventHandler(this.btnSatinAl_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(17, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(35, 13);
            this.lblBaslik.TabIndex = 4;
            this.lblBaslik.Text = "Başlık";
            this.lblBaslik.Visible = false;
            // 
            // musteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.grpIslem);
            this.Controls.Add(this.grpKoltuklar);
            this.Controls.Add(this.grpArama);
            this.Controls.Add(this.dgvSeferler);
            this.Name = "musteri";
            this.Size = new System.Drawing.Size(888, 625);
            this.Load += new System.EventHandler(this.musteri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).EndInit();
            this.grpArama.ResumeLayout(false);
            this.grpArama.PerformLayout();
            this.grpKoltuklar.ResumeLayout(false);
            this.pnlKoltukDizilimi.ResumeLayout(false);
            this.grpIslem.ResumeLayout(false);
            this.grpIslem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeferler;
        private System.Windows.Forms.GroupBox grpArama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpKoltuklar;
        private System.Windows.Forms.FlowLayoutPanel pnlKoltukDizilimi;
        private System.Windows.Forms.Label lblUyari;
        private System.Windows.Forms.GroupBox grpIslem;
        private System.Windows.Forms.Button btnSatinAl;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblSecilenKoltuk;
        private System.Windows.Forms.ComboBox cmbNereden;
        private System.Windows.Forms.ComboBox cmbNereye;   
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBaslik;
    }
}