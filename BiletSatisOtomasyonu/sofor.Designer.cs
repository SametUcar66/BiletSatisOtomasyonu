namespace BiletSatisOtomasyonu
{
    partial class Sofor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblSoforAdi = new System.Windows.Forms.Label();
            this.grpSeferler = new System.Windows.Forms.GroupBox();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.pnlIslemler = new System.Windows.Forms.Panel();
            this.btnSeferBitir = new System.Windows.Forms.Button();
            this.btnSeferBaslat = new System.Windows.Forms.Button();
            this.grpYolcular = new System.Windows.Forms.GroupBox();
            this.dgvYolcular = new System.Windows.Forms.DataGridView();
            this.lblSeciliSefer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpSeferler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.pnlIslemler.SuspendLayout();
            this.grpYolcular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYolcular)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(900, 600);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSeferler);
            this.splitContainer1.Panel1.Controls.Add(this.lblSoforAdi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpYolcular);
            this.splitContainer1.Panel2.Controls.Add(this.pnlIslemler);
            this.splitContainer1.Panel2.Controls.Add(this.lblSeciliSefer);
            // 
            // lblSoforAdi
            // 
            this.lblSoforAdi.AutoSize = true;
            this.lblSoforAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoforAdi.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSoforAdi.Location = new System.Drawing.Point(10, 10);
            this.lblSoforAdi.Name = "lblSoforAdi";
            this.lblSoforAdi.Size = new System.Drawing.Size(115, 21);
            this.lblSoforAdi.TabIndex = 0;
            this.lblSoforAdi.Text = "Sürücü Paneli";
            // 
            // grpSeferler
            // 
            this.grpSeferler.Controls.Add(this.dgvSeferler);
            this.grpSeferler.Location = new System.Drawing.Point(10, 40);
            this.grpSeferler.Name = "grpSeferler";
            this.grpSeferler.Size = new System.Drawing.Size(330, 550);
            this.grpSeferler.TabIndex = 1;
            this.grpSeferler.TabStop = false;
            this.grpSeferler.Text = "Atandığım Seferler";
            // 
            // dgvSeferler
            // 
            this.dgvSeferler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeferler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeferler.Location = new System.Drawing.Point(3, 16);
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(324, 531);
            this.dgvSeferler.TabIndex = 0;
            this.dgvSeferler.SelectionChanged += new System.EventHandler(this.dgvSeferler_SelectionChanged);
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.Controls.Add(this.btnSeferBitir);
            this.pnlIslemler.Controls.Add(this.btnSeferBaslat);
            this.pnlIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIslemler.Location = new System.Drawing.Point(0, 500);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Size = new System.Drawing.Size(546, 100);
            this.pnlIslemler.TabIndex = 2;
            // 
            // btnSeferBitir
            // 
            this.btnSeferBitir.BackColor = System.Drawing.Color.IndianRed;
            this.btnSeferBitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeferBitir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSeferBitir.ForeColor = System.Drawing.Color.White;
            this.btnSeferBitir.Location = new System.Drawing.Point(180, 25);
            this.btnSeferBitir.Name = "btnSeferBitir";
            this.btnSeferBitir.Size = new System.Drawing.Size(150, 45);
            this.btnSeferBitir.TabIndex = 1;
            this.btnSeferBitir.Text = "Seferi Tamamla";
            this.btnSeferBitir.UseVisualStyleBackColor = false;
            this.btnSeferBitir.Click += new System.EventHandler(this.btnSeferBitir_Click);
            // 
            // btnSeferBaslat
            // 
            this.btnSeferBaslat.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSeferBaslat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeferBaslat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSeferBaslat.ForeColor = System.Drawing.Color.White;
            this.btnSeferBaslat.Location = new System.Drawing.Point(15, 25);
            this.btnSeferBaslat.Name = "btnSeferBaslat";
            this.btnSeferBaslat.Size = new System.Drawing.Size(150, 45);
            this.btnSeferBaslat.TabIndex = 0;
            this.btnSeferBaslat.Text = "Seferi Başlat";
            this.btnSeferBaslat.UseVisualStyleBackColor = false;
            this.btnSeferBaslat.Click += new System.EventHandler(this.btnSeferBaslat_Click);
            // 
            // grpYolcular
            // 
            this.grpYolcular.Controls.Add(this.dgvYolcular);
            this.grpYolcular.Location = new System.Drawing.Point(15, 50);
            this.grpYolcular.Name = "grpYolcular";
            this.grpYolcular.Size = new System.Drawing.Size(500, 440);
            this.grpYolcular.TabIndex = 1;
            this.grpYolcular.TabStop = false;
            this.grpYolcular.Text = "Yolcu Manifestosu";
            // 
            // dgvYolcular
            // 
            this.dgvYolcular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYolcular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYolcular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYolcular.Location = new System.Drawing.Point(3, 16);
            this.dgvYolcular.Name = "dgvYolcular";
            this.dgvYolcular.RowHeadersVisible = false;
            this.dgvYolcular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYolcular.Size = new System.Drawing.Size(494, 421);
            this.dgvYolcular.TabIndex = 0;
            // 
            // lblSeciliSefer
            // 
            this.lblSeciliSefer.AutoSize = true;
            this.lblSeciliSefer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSeciliSefer.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSeciliSefer.Location = new System.Drawing.Point(15, 10);
            this.lblSeciliSefer.Name = "lblSeciliSefer";
            this.lblSeciliSefer.Size = new System.Drawing.Size(181, 21);
            this.lblSeciliSefer.TabIndex = 0;
            this.lblSeciliSefer.Text = "Sefer Detayı ve Listesi";
            // 
            // sofor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "sofor";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.sofor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpSeferler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).EndInit();
            this.pnlIslemler.ResumeLayout(false);
            this.grpYolcular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYolcular)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblSoforAdi;
        private System.Windows.Forms.GroupBox grpSeferler;
        private System.Windows.Forms.DataGridView dgvSeferler;
        private System.Windows.Forms.Panel pnlIslemler;
        private System.Windows.Forms.Button btnSeferBitir;
        private System.Windows.Forms.Button btnSeferBaslat;
        private System.Windows.Forms.GroupBox grpYolcular;
        private System.Windows.Forms.DataGridView dgvYolcular;
        private System.Windows.Forms.Label lblSeciliSefer;
    }
}