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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.grpPersonel = new System.Windows.Forms.GroupBox();
            this.txtSifre = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtEmail = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtAd = new ReaLTaiizor.Controls.DungeonTextBox();
            this.btnSil = new ReaLTaiizor.Controls.HopeButton();
            this.btnEkle = new ReaLTaiizor.Controls.HopeButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.grpSatislar = new System.Windows.Forms.GroupBox();
            this.rbSeferler = new System.Windows.Forms.RadioButton();
            this.rbSatislar = new System.Windows.Forms.RadioButton();
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.grpSeferEkle = new System.Windows.Forms.GroupBox();
            this.btnSeferKaydet = new ReaLTaiizor.Controls.HopeButton();
            this.txtSeferFiyat = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.cmbSofor = new System.Windows.Forms.ComboBox();
            this.cmbArac = new System.Windows.Forms.ComboBox();
            this.cmbGuzergah = new System.Windows.Forms.ComboBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblSofor = new System.Windows.Forms.Label();
            this.lblArac = new System.Windows.Forms.Label();
            this.lblGuzergah = new System.Windows.Forms.Label();
            this.grpPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            this.grpSatislar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            this.grpSeferEkle.SuspendLayout();
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
            this.grpPersonel.Text = "Personel Yönetimi";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonel.ColumnHeadersHeight = 40;
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonel.DefaultCellStyle = dataGridViewCellStyle2;
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
            // grpSatislar
            // 
            this.grpSatislar.Controls.Add(this.rbSeferler);
            this.grpSatislar.Controls.Add(this.rbSatislar);
            this.grpSatislar.Controls.Add(this.dgvSatislar);
            this.grpSatislar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSatislar.ForeColor = System.Drawing.Color.White;
            this.grpSatislar.Location = new System.Drawing.Point(430, 72);
            this.grpSatislar.Name = "grpSatislar";
            this.grpSatislar.Size = new System.Drawing.Size(450, 508);
            this.grpSatislar.TabIndex = 2;
            this.grpSatislar.TabStop = false;
            this.grpSatislar.Text = "Rapor ve Liste";
            // 
            // rbSeferler
            // 
            this.rbSeferler.AutoSize = true;
            this.rbSeferler.Location = new System.Drawing.Point(135, 23);
            this.rbSeferler.Name = "rbSeferler";
            this.rbSeferler.Size = new System.Drawing.Size(95, 18);
            this.rbSeferler.TabIndex = 2;
            this.rbSeferler.Text = "Sefer Listesi";
            this.rbSeferler.UseVisualStyleBackColor = true;
            this.rbSeferler.CheckedChanged += new System.EventHandler(this.rbSeferler_CheckedChanged);
            // 
            // rbSatislar
            // 
            this.rbSatislar.AutoSize = true;
            this.rbSatislar.Checked = true;
            this.rbSatislar.Location = new System.Drawing.Point(15, 23);
            this.rbSatislar.Name = "rbSatislar";
            this.rbSatislar.Size = new System.Drawing.Size(107, 18);
            this.rbSatislar.TabIndex = 1;
            this.rbSatislar.TabStop = true;
            this.rbSatislar.Text = "Satış Raporları";
            this.rbSatislar.UseVisualStyleBackColor = true;
            this.rbSatislar.CheckedChanged += new System.EventHandler(this.rbSatislar_CheckedChanged);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSatislar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSatislar.ColumnHeadersHeight = 40;
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSatislar.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSatislar.EnableHeadersVisualStyles = false;
            this.dgvSatislar.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSatislar.Location = new System.Drawing.Point(6, 50);
            this.dgvSatislar.MultiSelect = false;
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Empty;
            this.dgvSatislar.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSatislar.RowHeadersVisible = false;
            this.dgvSatislar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSatislar.RowTemplate.Height = 40;
            this.dgvSatislar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSatislar.Size = new System.Drawing.Size(438, 449);
            this.dgvSatislar.TabIndex = 0;
            this.dgvSatislar.TabStop = false;
            this.dgvSatislar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSatislar_DataBindingComplete);
            // 
            // grpSeferEkle
            // 
            this.grpSeferEkle.Controls.Add(this.btnSeferKaydet);
            this.grpSeferEkle.Controls.Add(this.txtSeferFiyat);
            this.grpSeferEkle.Controls.Add(this.dtpTarih);
            this.grpSeferEkle.Controls.Add(this.cmbSofor);
            this.grpSeferEkle.Controls.Add(this.cmbArac);
            this.grpSeferEkle.Controls.Add(this.cmbGuzergah);
            this.grpSeferEkle.Controls.Add(this.lblFiyat);
            this.grpSeferEkle.Controls.Add(this.lblTarih);
            this.grpSeferEkle.Controls.Add(this.lblSofor);
            this.grpSeferEkle.Controls.Add(this.lblArac);
            this.grpSeferEkle.Controls.Add(this.lblGuzergah);
            this.grpSeferEkle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpSeferEkle.ForeColor = System.Drawing.Color.White;
            this.grpSeferEkle.Location = new System.Drawing.Point(890, 72);
            this.grpSeferEkle.Name = "grpSeferEkle";
            this.grpSeferEkle.Size = new System.Drawing.Size(300, 508);
            this.grpSeferEkle.TabIndex = 3;
            this.grpSeferEkle.TabStop = false;
            this.grpSeferEkle.Text = "Yeni Sefer Planla";
            // 
            // btnSeferKaydet
            // 
            this.btnSeferKaydet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSeferKaydet.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSeferKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeferKaydet.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSeferKaydet.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSeferKaydet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeferKaydet.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSeferKaydet.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSeferKaydet.Location = new System.Drawing.Point(20, 310);
            this.btnSeferKaydet.Name = "btnSeferKaydet";
            this.btnSeferKaydet.PrimaryColor = System.Drawing.Color.SeaGreen;
            this.btnSeferKaydet.Size = new System.Drawing.Size(260, 40);
            this.btnSeferKaydet.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSeferKaydet.TabIndex = 10;
            this.btnSeferKaydet.Text = "SEFERİ OLUŞTUR";
            this.btnSeferKaydet.TextColor = System.Drawing.Color.White;
            this.btnSeferKaydet.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSeferKaydet.Click += new System.EventHandler(this.btnSeferKaydet_Click);
            // 
            // txtSeferFiyat
            // 
            this.txtSeferFiyat.Location = new System.Drawing.Point(20, 260);
            this.txtSeferFiyat.Name = "txtSeferFiyat";
            this.txtSeferFiyat.Size = new System.Drawing.Size(260, 20);
            this.txtSeferFiyat.TabIndex = 9;
            // 
            // dtpTarih
            // 
            this.dtpTarih.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarih.Location = new System.Drawing.Point(20, 210);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(260, 20);
            this.dtpTarih.TabIndex = 7;
            // 
            // cmbSofor
            // 
            this.cmbSofor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSofor.FormattingEnabled = true;
            this.cmbSofor.Location = new System.Drawing.Point(20, 160);
            this.cmbSofor.Name = "cmbSofor";
            this.cmbSofor.Size = new System.Drawing.Size(260, 22);
            this.cmbSofor.TabIndex = 5;
            // 
            // cmbArac
            // 
            this.cmbArac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArac.FormattingEnabled = true;
            this.cmbArac.Location = new System.Drawing.Point(20, 110);
            this.cmbArac.Name = "cmbArac";
            this.cmbArac.Size = new System.Drawing.Size(260, 22);
            this.cmbArac.TabIndex = 3;
            // 
            // cmbGuzergah
            // 
            this.cmbGuzergah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuzergah.FormattingEnabled = true;
            this.cmbGuzergah.Location = new System.Drawing.Point(20, 60);
            this.cmbGuzergah.Name = "cmbGuzergah";
            this.cmbGuzergah.Size = new System.Drawing.Size(260, 22);
            this.cmbGuzergah.TabIndex = 1;
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Location = new System.Drawing.Point(20, 240);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(89, 14);
            this.lblFiyat.TabIndex = 8;
            this.lblFiyat.Text = "Bilet Fiyatı (TL):";
            this.lblFiyat.ForeColor = System.Drawing.Color.White;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(20, 190);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(84, 14);
            this.lblTarih.TabIndex = 6;
            this.lblTarih.Text = "Kalkış Zamanı:";
            this.lblTarih.ForeColor = System.Drawing.Color.White;
            // 
            // lblSofor
            // 
            this.lblSofor.AutoSize = true;
            this.lblSofor.Location = new System.Drawing.Point(20, 140);
            this.lblSofor.Name = "lblSofor";
            this.lblSofor.Size = new System.Drawing.Size(48, 14);
            this.lblSofor.TabIndex = 4;
            this.lblSofor.Text = "Sürücü:";
            this.lblSofor.ForeColor = System.Drawing.Color.White;
            // 
            // lblArac
            // 
            this.lblArac.AutoSize = true;
            this.lblArac.Location = new System.Drawing.Point(20, 90);
            this.lblArac.Name = "lblArac";
            this.lblArac.Size = new System.Drawing.Size(35, 14);
            this.lblArac.TabIndex = 2;
            this.lblArac.Text = "Araç:";
            this.lblArac.ForeColor = System.Drawing.Color.White;
            // 
            // lblGuzergah
            // 
            this.lblGuzergah.AutoSize = true;
            this.lblGuzergah.Location = new System.Drawing.Point(20, 40);
            this.lblGuzergah.Name = "lblGuzergah";
            this.lblGuzergah.Size = new System.Drawing.Size(63, 14);
            this.lblGuzergah.TabIndex = 0;
            this.lblGuzergah.Text = "Güzergah:";
            this.lblGuzergah.ForeColor = System.Drawing.Color.White;
            // 
            // AjentaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.grpSeferEkle);
            this.Controls.Add(this.grpSatislar);
            this.Controls.Add(this.grpPersonel);
            this.Controls.Add(this.lblBaslik);
            this.Name = "AjentaAdmin";
            this.Size = new System.Drawing.Size(1250, 600);
            this.Load += new System.EventHandler(this.AjentaAdmin_Load);
            this.grpPersonel.ResumeLayout(false);
            this.grpPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            this.grpSatislar.ResumeLayout(false);
            this.grpSatislar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            this.grpSeferEkle.ResumeLayout(false);
            this.grpSeferEkle.PerformLayout();
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
        private System.Windows.Forms.RadioButton rbSeferler;
        private System.Windows.Forms.RadioButton rbSatislar;
        private System.Windows.Forms.GroupBox grpSeferEkle;
        private ReaLTaiizor.Controls.HopeButton btnSeferKaydet;
        private System.Windows.Forms.TextBox txtSeferFiyat;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ComboBox cmbSofor;
        private System.Windows.Forms.ComboBox cmbArac;
        private System.Windows.Forms.ComboBox cmbGuzergah;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblSofor;
        private System.Windows.Forms.Label lblArac;
        private System.Windows.Forms.Label lblGuzergah;
    }
}