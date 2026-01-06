using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.grpArama = new System.Windows.Forms.GroupBox();
            this.btnAra = new ReaLTaiizor.Controls.HopeButton();
            this.cmbNereye = new ReaLTaiizor.Controls.PoisonComboBox();
            this.cmbNereden = new ReaLTaiizor.Controls.PoisonComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpKoltuklar = new System.Windows.Forms.GroupBox();
            this.pnlKoltukDizilimi = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUyari = new System.Windows.Forms.Label();
            this.grpIslem = new System.Windows.Forms.GroupBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblSecilenKoltuk = new System.Windows.Forms.Label();
            this.btnSatinAl = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dtpTarih = new ReaLTaiizor.Controls.PoisonDateTime();
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
            this.dgvSeferler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvSeferler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSeferler.ColumnHeadersHeight = 40;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSeferler.EnableHeadersVisualStyles = false;
            this.dgvSeferler.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSeferler.Location = new System.Drawing.Point(26, 125);
            this.dgvSeferler.MultiSelect = false;
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.ReadOnly = true;
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSeferler.RowTemplate.Height = 40;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(540, 516);
            this.dgvSeferler.TabIndex = 4;
            this.dgvSeferler.Visible = true;
            this.dgvSeferler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeferler_CellClick);
            this.dgvSeferler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeferler_DataBindingComplete);
            // 
            // grpArama
            // 
            this.grpArama.Controls.Add(this.dtpTarih);
            this.grpArama.Controls.Add(this.btnAra);
            this.grpArama.Controls.Add(this.cmbNereye);
            this.grpArama.Controls.Add(this.cmbNereden);
            this.grpArama.Controls.Add(this.label3);
            this.grpArama.Controls.Add(this.label2);
            this.grpArama.Controls.Add(this.label1);
            this.grpArama.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpArama.ForeColor = System.Drawing.Color.White;
            this.grpArama.Location = new System.Drawing.Point(26, 20);
            this.grpArama.Name = "grpArama";
            this.grpArama.Size = new System.Drawing.Size(854, 93);
            this.grpArama.TabIndex = 0;
            this.grpArama.TabStop = false;
            this.grpArama.Text = "Sefer Arama";
            // 
            // btnAra
            // 
            this.btnAra.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnAra.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAra.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnAra.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.Black;
            this.btnAra.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnAra.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnAra.Location = new System.Drawing.Point(715, 33);
            this.btnAra.Name = "btnAra";
            this.btnAra.PrimaryColor = System.Drawing.Color.WhiteSmoke;
            this.btnAra.Size = new System.Drawing.Size(120, 29);
            this.btnAra.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnAra.TabIndex = 6;
            this.btnAra.Text = "Sefer Bul";
            this.btnAra.TextColor = System.Drawing.Color.Black;
            this.btnAra.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // cmbNereye
            // 
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.ItemHeight = 23;
            this.cmbNereye.Location = new System.Drawing.Point(327, 33);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(161, 29);
            this.cmbNereye.TabIndex = 6;
            this.cmbNereye.UseSelectable = true;
            // 
            // cmbNereden
            // 
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.ItemHeight = 23;
            this.cmbNereden.Location = new System.Drawing.Point(90, 33);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(161, 29);
            this.cmbNereden.TabIndex = 5;
            this.cmbNereden.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nereden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(500, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tarih:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(265, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nereye:";
            // 
            // grpKoltuklar
            // 
            this.grpKoltuklar.Controls.Add(this.pnlKoltukDizilimi);
            this.grpKoltuklar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpKoltuklar.ForeColor = System.Drawing.Color.White;
            this.grpKoltuklar.Location = new System.Drawing.Point(573, 119);
            this.grpKoltuklar.Name = "grpKoltuklar";
            this.grpKoltuklar.Size = new System.Drawing.Size(307, 346);
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
            this.pnlKoltukDizilimi.Size = new System.Drawing.Size(301, 327);
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
            this.grpIslem.Location = new System.Drawing.Point(573, 471);
            this.grpIslem.Name = "grpIslem";
            this.grpIslem.Size = new System.Drawing.Size(304, 170);
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
            this.btnSatinAl.Size = new System.Drawing.Size(268, 40);
            this.btnSatinAl.TabIndex = 6;
            this.btnSatinAl.Text = "Bileti Satın Al";
            this.btnSatinAl.UseVisualStyleBackColor = false;
            this.btnSatinAl.Click += new System.EventHandler(this.btnSatinAl_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(6, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(35, 13);
            this.lblBaslik.TabIndex = 4;
            this.lblBaslik.Text = "Başlık";
            this.lblBaslik.Visible = false;
            // 
            // dtpTarih
            // 
            this.dtpTarih.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTarih.Location = new System.Drawing.Point(547, 33);
            this.dtpTarih.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(161, 29);
            this.dtpTarih.TabIndex = 5;
            dtpTarih.Format = DateTimePickerFormat.Custom;
            dtpTarih.CustomFormat = "d.MM.yyyy"; // ekranda 9.01.2026

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
            this.Size = new System.Drawing.Size(908, 659);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpKoltuklar;
        private System.Windows.Forms.FlowLayoutPanel pnlKoltukDizilimi;
        private System.Windows.Forms.Label lblUyari;
        private System.Windows.Forms.GroupBox grpIslem;
        private System.Windows.Forms.Button btnSatinAl;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblSecilenKoltuk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBaslik;
        private ReaLTaiizor.Controls.PoisonComboBox cmbNereden;
        private ReaLTaiizor.Controls.PoisonComboBox cmbNereye;
        private ReaLTaiizor.Controls.HopeButton btnAra;
        private ReaLTaiizor.Controls.PoisonDateTime dtpTarih;
    }
}