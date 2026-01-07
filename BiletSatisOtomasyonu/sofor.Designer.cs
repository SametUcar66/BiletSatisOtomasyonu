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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpSeferler = new System.Windows.Forms.GroupBox();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.lblSoforAdi = new System.Windows.Forms.Label();
            this.grpYolcular = new System.Windows.Forms.GroupBox();
            this.dgvYolcular = new System.Windows.Forms.DataGridView();
            this.pnlIslemler = new System.Windows.Forms.Panel();
            this.btnSeferBitir = new ReaLTaiizor.Controls.HopeButton();
            this.btnSeferBaslat = new ReaLTaiizor.Controls.HopeButton();
            this.lblSeciliSefer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpSeferler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.grpYolcular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYolcular)).BeginInit();
            this.pnlIslemler.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
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
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(944, 641);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpSeferler
            // 
            this.grpSeferler.Controls.Add(this.dgvSeferler);
            this.grpSeferler.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSeferler.ForeColor = System.Drawing.Color.White;
            this.grpSeferler.Location = new System.Drawing.Point(19, 65);
            this.grpSeferler.Name = "grpSeferler";
            this.grpSeferler.Size = new System.Drawing.Size(327, 540);
            this.grpSeferler.TabIndex = 1;
            this.grpSeferler.TabStop = false;
            this.grpSeferler.Text = "Atandığım Seferler";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeferler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeferler.ColumnHeadersHeight = 40;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeferler.EnableHeadersVisualStyles = false;
            this.dgvSeferler.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSeferler.Location = new System.Drawing.Point(6, 19);
            this.dgvSeferler.MultiSelect = false;
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.ReadOnly = true;
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.RowTemplate.Height = 40;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(315, 515);
            this.dgvSeferler.TabIndex = 0;
            this.dgvSeferler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeferler_DataBindingComplete);
            this.dgvSeferler.SelectionChanged += new System.EventHandler(this.dgvSeferler_SelectionChanged);
            // 
            // lblSoforAdi
            // 
            this.lblSoforAdi.AutoSize = true;
            this.lblSoforAdi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoforAdi.ForeColor = System.Drawing.Color.White;
            this.lblSoforAdi.Location = new System.Drawing.Point(17, 33);
            this.lblSoforAdi.Name = "lblSoforAdi";
            this.lblSoforAdi.Size = new System.Drawing.Size(116, 19);
            this.lblSoforAdi.TabIndex = 0;
            this.lblSoforAdi.Text = "Sürücü Paneli";
            // 
            // grpYolcular
            // 
            this.grpYolcular.Controls.Add(this.dgvYolcular);
            this.grpYolcular.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpYolcular.ForeColor = System.Drawing.Color.White;
            this.grpYolcular.Location = new System.Drawing.Point(21, 65);
            this.grpYolcular.Name = "grpYolcular";
            this.grpYolcular.Size = new System.Drawing.Size(500, 478);
            this.grpYolcular.TabIndex = 1;
            this.grpYolcular.TabStop = false;
            this.grpYolcular.Text = "Yolcu Manifestosu";
            // 
            // dgvYolcular
            // 
            this.dgvYolcular.AllowUserToAddRows = false;
            this.dgvYolcular.AllowUserToDeleteRows = false;
            this.dgvYolcular.AllowUserToResizeColumns = false;
            this.dgvYolcular.AllowUserToResizeRows = false;
            this.dgvYolcular.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYolcular.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvYolcular.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvYolcular.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvYolcular.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYolcular.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvYolcular.ColumnHeadersHeight = 40;
            this.dgvYolcular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvYolcular.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvYolcular.EnableHeadersVisualStyles = false;
            this.dgvYolcular.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvYolcular.Location = new System.Drawing.Point(6, 19);
            this.dgvYolcular.MultiSelect = false;
            this.dgvYolcular.Name = "dgvYolcular";
            this.dgvYolcular.ReadOnly = true;
            this.dgvYolcular.RowHeadersVisible = false;
            this.dgvYolcular.RowTemplate.Height = 40;
            this.dgvYolcular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYolcular.Size = new System.Drawing.Size(488, 441);
            this.dgvYolcular.TabIndex = 1;
            this.dgvYolcular.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvYolcular_DataBindingComplete);
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.Controls.Add(this.btnSeferBitir);
            this.pnlIslemler.Controls.Add(this.btnSeferBaslat);
            this.pnlIslemler.Location = new System.Drawing.Point(9, 549);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Size = new System.Drawing.Size(526, 63);
            this.pnlIslemler.TabIndex = 2;
            // 
            // btnSeferBitir
            // 
            this.btnSeferBitir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSeferBitir.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSeferBitir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeferBitir.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSeferBitir.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSeferBitir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSeferBitir.ForeColor = System.Drawing.Color.Black;
            this.btnSeferBitir.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSeferBitir.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSeferBitir.Location = new System.Drawing.Point(267, 11);
            this.btnSeferBitir.Name = "btnSeferBitir";
            this.btnSeferBitir.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnSeferBitir.Size = new System.Drawing.Size(245, 45);
            this.btnSeferBitir.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSeferBitir.TabIndex = 30;
            this.btnSeferBitir.Text = "Seferi Tamamla";
            this.btnSeferBitir.TextColor = System.Drawing.Color.White;
            this.btnSeferBitir.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSeferBitir.Click += new System.EventHandler(this.btnSeferBitir_Click);
            // 
            // btnSeferBaslat
            // 
            this.btnSeferBaslat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSeferBaslat.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSeferBaslat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeferBaslat.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSeferBaslat.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSeferBaslat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSeferBaslat.ForeColor = System.Drawing.Color.Black;
            this.btnSeferBaslat.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSeferBaslat.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSeferBaslat.Location = new System.Drawing.Point(16, 11);
            this.btnSeferBaslat.Name = "btnSeferBaslat";
            this.btnSeferBaslat.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnSeferBaslat.Size = new System.Drawing.Size(245, 45);
            this.btnSeferBaslat.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSeferBaslat.TabIndex = 29;
            this.btnSeferBaslat.Text = "Seferi Başlat";
            this.btnSeferBaslat.TextColor = System.Drawing.Color.White;
            this.btnSeferBaslat.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSeferBaslat.Click += new System.EventHandler(this.btnSeferBaslat_Click);
            // 
            // lblSeciliSefer
            // 
            this.lblSeciliSefer.AutoSize = true;
            this.lblSeciliSefer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeciliSefer.ForeColor = System.Drawing.Color.White;
            this.lblSeciliSefer.Location = new System.Drawing.Point(17, 33);
            this.lblSeciliSefer.Name = "lblSeciliSefer";
            this.lblSeciliSefer.Size = new System.Drawing.Size(177, 19);
            this.lblSeciliSefer.TabIndex = 0;
            this.lblSeciliSefer.Text = "Sefer Detayı ve Listesi";
            // 
            // Sofor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Sofor";
            this.Size = new System.Drawing.Size(944, 641);
            this.Load += new System.EventHandler(this.sofor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpSeferler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).EndInit();
            this.grpYolcular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYolcular)).EndInit();
            this.pnlIslemler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblSoforAdi;
        private System.Windows.Forms.GroupBox grpSeferler;
        private System.Windows.Forms.DataGridView dgvSeferler;
        private System.Windows.Forms.Panel pnlIslemler;
        private System.Windows.Forms.GroupBox grpYolcular;
        private System.Windows.Forms.DataGridView dgvYolcular;
        private System.Windows.Forms.Label lblSeciliSefer;
        private ReaLTaiizor.Controls.HopeButton btnSeferBaslat;
        private ReaLTaiizor.Controls.HopeButton btnSeferBitir;
    }
}