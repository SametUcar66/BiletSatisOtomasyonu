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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.grpPersonel = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.grpSatislar = new System.Windows.Forms.GroupBox();
            this.btnEkle = new ReaLTaiizor.Controls.HopeButton();
            this.btnSil = new ReaLTaiizor.Controls.HopeButton();
            this.txtAd = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtEmail = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtSifre = new ReaLTaiizor.Controls.DungeonTextBox();
            this.grpPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            this.grpSatislar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(11, 33);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(217, 22);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Acente Yönetim Paneli";
            // 
            // grpPersonel
            // 
            this.grpPersonel.Controls.Add(this.txtSifre);
            this.grpPersonel.Controls.Add(this.txtEmail);
            this.grpPersonel.Controls.Add(this.txtAd);
            this.grpPersonel.Controls.Add(this.btnSil);
            this.grpPersonel.Controls.Add(this.btnEkle);
            this.grpPersonel.Controls.Add(this.label3);
            this.grpPersonel.Controls.Add(this.label2);
            this.grpPersonel.Controls.Add(this.label1);
            this.grpPersonel.Controls.Add(this.dgvPersonel);
            this.grpPersonel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpPersonel.ForeColor = System.Drawing.Color.White;
            this.grpPersonel.Location = new System.Drawing.Point(15, 72);
            this.grpPersonel.Name = "grpPersonel";
            this.grpPersonel.Size = new System.Drawing.Size(409, 508);
            this.grpPersonel.TabIndex = 1;
            this.grpPersonel.TabStop = false;
            this.grpPersonel.Text = "Personel Yönetimi (Acente Çalışanları)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(55, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-Mail:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad Soyad:";
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.AllowUserToAddRows = false;
            this.dgvPersonel.AllowUserToDeleteRows = false;
            this.dgvPersonel.AllowUserToResizeColumns = false;
            this.dgvPersonel.AllowUserToResizeRows = false;
            this.dgvPersonel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvPersonel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersonel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvPersonel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvPersonel.ColumnHeadersHeight = 40;
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonel.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvPersonel.EnableHeadersVisualStyles = false;
            this.dgvPersonel.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPersonel.Location = new System.Drawing.Point(6, 219);
            this.dgvPersonel.MultiSelect = false;
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.ReadOnly = true;
            this.dgvPersonel.RowHeadersVisible = false;
            this.dgvPersonel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPersonel.RowTemplate.Height = 40;
            this.dgvPersonel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonel.Size = new System.Drawing.Size(396, 280);
            this.dgvPersonel.TabIndex = 0;
            this.dgvPersonel.TabStop = false;
            this.dgvPersonel.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPersonel_DataBindingComplete);
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.AllowUserToAddRows = false;
            this.dgvSatislar.AllowUserToDeleteRows = false;
            this.dgvSatislar.AllowUserToResizeColumns = false;
            this.dgvSatislar.AllowUserToResizeRows = false;
            this.dgvSatislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSatislar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvSatislar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSatislar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvSatislar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSatislar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvSatislar.ColumnHeadersHeight = 40;
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSatislar.DefaultCellStyle = dataGridViewCellStyle29;
            this.dgvSatislar.EnableHeadersVisualStyles = false;
            this.dgvSatislar.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSatislar.Location = new System.Drawing.Point(6, 19);
            this.dgvSatislar.MultiSelect = false;
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.ReadOnly = true;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Empty;
            this.dgvSatislar.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgvSatislar.RowHeadersVisible = false;
            this.dgvSatislar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSatislar.RowTemplate.Height = 40;
            this.dgvSatislar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatislar.Size = new System.Drawing.Size(438, 480);
            this.dgvSatislar.TabIndex = 0;
            this.dgvSatislar.TabStop = false;
            this.dgvSatislar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSatislar_DataBindingComplete);
            // 
            // grpSatislar
            // 
            this.grpSatislar.Controls.Add(this.dgvSatislar);
            this.grpSatislar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSatislar.ForeColor = System.Drawing.Color.White;
            this.grpSatislar.Location = new System.Drawing.Point(430, 72);
            this.grpSatislar.Name = "grpSatislar";
            this.grpSatislar.Size = new System.Drawing.Size(450, 508);
            this.grpSatislar.TabIndex = 2;
            this.grpSatislar.TabStop = false;
            this.grpSatislar.Text = "Tüm Satış Raporları";
            // 
            // btnEkle
            // 
            this.btnEkle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnEkle.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkle.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnEkle.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEkle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnEkle.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnEkle.Location = new System.Drawing.Point(102, 173);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnEkle.Size = new System.Drawing.Size(190, 30);
            this.btnEkle.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnEkle.TabIndex = 19;
            this.btnEkle.Text = "Yeni Çalışan Ekle";
            this.btnEkle.TextColor = System.Drawing.Color.White;
            this.btnEkle.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSil.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSil.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSil.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSil.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSil.Location = new System.Drawing.Point(298, 173);
            this.btnSil.Name = "btnSil";
            this.btnSil.PrimaryColor = System.Drawing.Color.IndianRed;
            this.btnSil.Size = new System.Drawing.Size(92, 30);
            this.btnSil.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSil.TabIndex = 20;
            this.btnSil.Text = "Seçileni Sil";
            this.btnSil.TextColor = System.Drawing.Color.White;
            this.btnSil.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtAd
            // 
            this.txtAd.BackColor = System.Drawing.Color.Transparent;
            this.txtAd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtAd.EdgeColor = System.Drawing.Color.White;
            this.txtAd.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtAd.ForeColor = System.Drawing.Color.DimGray;
            this.txtAd.Location = new System.Drawing.Point(102, 54);
            this.txtAd.MaxLength = 32767;
            this.txtAd.Multiline = false;
            this.txtAd.Name = "txtAd";
            this.txtAd.ReadOnly = false;
            this.txtAd.Size = new System.Drawing.Size(190, 28);
            this.txtAd.TabIndex = 21;
            this.txtAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAd.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEmail.EdgeColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEmail.Location = new System.Drawing.Point(102, 93);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(190, 28);
            this.txtEmail.TabIndex = 22;
            this.txtEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtSifre
            // 
            this.txtSifre.BackColor = System.Drawing.Color.Transparent;
            this.txtSifre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSifre.EdgeColor = System.Drawing.Color.White;
            this.txtSifre.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSifre.ForeColor = System.Drawing.Color.DimGray;
            this.txtSifre.Location = new System.Drawing.Point(102, 133);
            this.txtSifre.MaxLength = 32767;
            this.txtSifre.Multiline = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.ReadOnly = false;
            this.txtSifre.Size = new System.Drawing.Size(190, 28);
            this.txtSifre.TabIndex = 23;
            this.txtSifre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSifre.UseSystemPasswordChar = false;
            // 
            // AjentaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.grpSatislar);
            this.Controls.Add(this.grpPersonel);
            this.Controls.Add(this.lblBaslik);
            this.Name = "AjentaAdmin";
            this.Size = new System.Drawing.Size(900, 593);
            this.Load += new System.EventHandler(this.AjentaAdmin_Load);
            this.grpPersonel.ResumeLayout(false);
            this.grpPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            this.grpSatislar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox grpPersonel;
        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSatislar;
        private System.Windows.Forms.GroupBox grpSatislar;
        private ReaLTaiizor.Controls.HopeButton btnEkle;
        private ReaLTaiizor.Controls.HopeButton btnSil;
        private ReaLTaiizor.Controls.DungeonTextBox txtAd;
        private ReaLTaiizor.Controls.DungeonTextBox txtEmail;
        private ReaLTaiizor.Controls.DungeonTextBox txtSifre;
    }
}