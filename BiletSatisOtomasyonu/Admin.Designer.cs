namespace BiletSatisOtomasyonu
{
    partial class Admin
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
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.grpFiltre = new System.Windows.Forms.GroupBox();
            this.btnTemizle = new ReaLTaiizor.Controls.DungeonButtonLeft();
            this.btnFiltrele = new ReaLTaiizor.Controls.DungeonButtonLeft();
            this.cmbRolFiltre = new ReaLTaiizor.Controls.PoisonComboBox();
            this.btnAra = new ReaLTaiizor.Controls.DungeonButtonLeft();
            this.txtArama = new ReaLTaiizor.Controls.DungeonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDuzenle = new System.Windows.Forms.GroupBox();
            this.cmbEditRol = new ReaLTaiizor.Controls.PoisonComboBox();
            this.txtEditEmail = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtEditTel = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtEditAd = new ReaLTaiizor.Controls.DungeonTextBox();
            this.btnSil = new ReaLTaiizor.Controls.HopeButton();
            this.btnGuncelle = new ReaLTaiizor.Controls.HopeButton();
            this.lblId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.grpFiltre.SuspendLayout();
            this.grpDuzenle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.AllowUserToAddRows = false;
            this.dgvKullanicilar.AllowUserToDeleteRows = false;
            this.dgvKullanicilar.AllowUserToResizeColumns = false;
            this.dgvKullanicilar.AllowUserToResizeRows = false;
            this.dgvKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKullanicilar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKullanicilar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvKullanicilar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKullanicilar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKullanicilar.ColumnHeadersHeight = 40;
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKullanicilar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKullanicilar.EnableHeadersVisualStyles = false;
            this.dgvKullanicilar.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKullanicilar.Location = new System.Drawing.Point(33, 144);
            this.dgvKullanicilar.MultiSelect = false;
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.ReadOnly = true;
            this.dgvKullanicilar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKullanicilar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKullanicilar.RowHeadersVisible = false;
            this.dgvKullanicilar.RowHeadersWidth = 40;
            this.dgvKullanicilar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvKullanicilar.RowTemplate.Height = 40;
            this.dgvKullanicilar.RowTemplate.ReadOnly = true;
            this.dgvKullanicilar.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKullanicilar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKullanicilar.Size = new System.Drawing.Size(831, 320);
            this.dgvKullanicilar.TabIndex = 5;
            this.dgvKullanicilar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvKullanicilar_DataBindingComplete);
            this.dgvKullanicilar.SelectionChanged += new System.EventHandler(this.dgvKullanicilar_SelectionChanged);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(29, 30);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(233, 25);
            this.lblBaslik.TabIndex = 2;
            this.lblBaslik.Text = "Sistem Kullanıcı Yönetimi";
            // 
            // grpFiltre
            // 
            this.grpFiltre.Controls.Add(this.btnTemizle);
            this.grpFiltre.Controls.Add(this.btnFiltrele);
            this.grpFiltre.Controls.Add(this.cmbRolFiltre);
            this.grpFiltre.Controls.Add(this.btnAra);
            this.grpFiltre.Controls.Add(this.txtArama);
            this.grpFiltre.Controls.Add(this.label1);
            this.grpFiltre.Controls.Add(this.label2);
            this.grpFiltre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpFiltre.ForeColor = System.Drawing.Color.White;
            this.grpFiltre.Location = new System.Drawing.Point(33, 58);
            this.grpFiltre.Name = "grpFiltre";
            this.grpFiltre.Size = new System.Drawing.Size(810, 66);
            this.grpFiltre.TabIndex = 3;
            this.grpFiltre.TabStop = false;
            this.grpFiltre.Text = "Arama ve Filtreleme";
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Transparent;
            this.btnTemizle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemizle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Image = null;
            this.btnTemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemizle.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnTemizle.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.btnTemizle.Location = new System.Drawing.Point(702, 21);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnTemizle.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnTemizle.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnTemizle.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnTemizle.Size = new System.Drawing.Size(90, 29);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "Sıfırla";
            this.btnTemizle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltrele.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnFiltrele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrele.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiltrele.Image = null;
            this.btnFiltrele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrele.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnFiltrele.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.btnFiltrele.Location = new System.Drawing.Point(576, 21);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnFiltrele.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnFiltrele.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnFiltrele.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnFiltrele.Size = new System.Drawing.Size(75, 29);
            this.btnFiltrele.TabIndex = 8;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // cmbRolFiltre
            // 
            this.cmbRolFiltre.FormattingEnabled = true;
            this.cmbRolFiltre.ItemHeight = 23;
            this.cmbRolFiltre.Location = new System.Drawing.Point(430, 21);
            this.cmbRolFiltre.Name = "cmbRolFiltre";
            this.cmbRolFiltre.Size = new System.Drawing.Size(140, 29);
            this.cmbRolFiltre.TabIndex = 7;
            this.cmbRolFiltre.UseSelectable = true;
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.Color.Transparent;
            this.btnAra.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAra.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Image = null;
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.InactiveColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnAra.InactiveColorB = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.btnAra.Location = new System.Drawing.Point(240, 22);
            this.btnAra.Name = "btnAra";
            this.btnAra.PressedColorA = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnAra.PressedColorB = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.btnAra.PressedContourColorA = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnAra.PressedContourColorB = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.btnAra.Size = new System.Drawing.Size(75, 28);
            this.btnAra.TabIndex = 7;
            this.btnAra.Text = "Ara";
            this.btnAra.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtArama
            // 
            this.txtArama.BackColor = System.Drawing.Color.Transparent;
            this.txtArama.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtArama.EdgeColor = System.Drawing.Color.White;
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.ForeColor = System.Drawing.Color.DimGray;
            this.txtArama.Location = new System.Drawing.Point(84, 22);
            this.txtArama.MaxLength = 32767;
            this.txtArama.Multiline = false;
            this.txtArama.Name = "txtArama";
            this.txtArama.ReadOnly = false;
            this.txtArama.Size = new System.Drawing.Size(150, 30);
            this.txtArama.TabIndex = 7;
            this.txtArama.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtArama.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rol Seçimi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ad/Email:";
            // 
            // grpDuzenle
            // 
            this.grpDuzenle.Controls.Add(this.cmbEditRol);
            this.grpDuzenle.Controls.Add(this.txtEditEmail);
            this.grpDuzenle.Controls.Add(this.txtEditTel);
            this.grpDuzenle.Controls.Add(this.txtEditAd);
            this.grpDuzenle.Controls.Add(this.btnSil);
            this.grpDuzenle.Controls.Add(this.btnGuncelle);
            this.grpDuzenle.Controls.Add(this.lblId);
            this.grpDuzenle.Controls.Add(this.label6);
            this.grpDuzenle.Controls.Add(this.label5);
            this.grpDuzenle.Controls.Add(this.label4);
            this.grpDuzenle.Controls.Add(this.label3);
            this.grpDuzenle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpDuzenle.ForeColor = System.Drawing.Color.White;
            this.grpDuzenle.Location = new System.Drawing.Point(33, 476);
            this.grpDuzenle.Name = "grpDuzenle";
            this.grpDuzenle.Size = new System.Drawing.Size(810, 120);
            this.grpDuzenle.TabIndex = 4;
            this.grpDuzenle.TabStop = false;
            this.grpDuzenle.Text = "Seçili Kullanıcı İşlemleri";
            // 
            // cmbEditRol
            // 
            this.cmbEditRol.FormattingEnabled = true;
            this.cmbEditRol.ItemHeight = 23;
            this.cmbEditRol.Location = new System.Drawing.Point(356, 71);
            this.cmbEditRol.Name = "cmbEditRol";
            this.cmbEditRol.Size = new System.Drawing.Size(150, 29);
            this.cmbEditRol.TabIndex = 10;
            this.cmbEditRol.UseSelectable = true;
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEditEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEditEmail.EdgeColor = System.Drawing.Color.White;
            this.txtEditEmail.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtEditEmail.ForeColor = System.Drawing.Color.DimGray;
            this.txtEditEmail.Location = new System.Drawing.Point(126, 72);
            this.txtEditEmail.MaxLength = 32767;
            this.txtEditEmail.Multiline = false;
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.ReadOnly = false;
            this.txtEditEmail.Size = new System.Drawing.Size(150, 28);
            this.txtEditEmail.TabIndex = 30;
            this.txtEditEmail.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEditEmail.UseSystemPasswordChar = false;
            // 
            // txtEditTel
            // 
            this.txtEditTel.BackColor = System.Drawing.Color.Transparent;
            this.txtEditTel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEditTel.EdgeColor = System.Drawing.Color.White;
            this.txtEditTel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtEditTel.ForeColor = System.Drawing.Color.DimGray;
            this.txtEditTel.Location = new System.Drawing.Point(356, 33);
            this.txtEditTel.MaxLength = 32767;
            this.txtEditTel.Multiline = false;
            this.txtEditTel.Name = "txtEditTel";
            this.txtEditTel.ReadOnly = false;
            this.txtEditTel.Size = new System.Drawing.Size(150, 28);
            this.txtEditTel.TabIndex = 31;
            this.txtEditTel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEditTel.UseSystemPasswordChar = false;
            // 
            // txtEditAd
            // 
            this.txtEditAd.BackColor = System.Drawing.Color.Transparent;
            this.txtEditAd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtEditAd.EdgeColor = System.Drawing.Color.White;
            this.txtEditAd.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtEditAd.ForeColor = System.Drawing.Color.DimGray;
            this.txtEditAd.Location = new System.Drawing.Point(126, 33);
            this.txtEditAd.MaxLength = 32767;
            this.txtEditAd.Multiline = false;
            this.txtEditAd.Name = "txtEditAd";
            this.txtEditAd.ReadOnly = false;
            this.txtEditAd.Size = new System.Drawing.Size(150, 28);
            this.txtEditAd.TabIndex = 10;
            this.txtEditAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEditAd.UseSystemPasswordChar = false;
            // 
            // btnSil
            // 
            this.btnSil.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSil.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSil.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSil.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSil.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSil.Location = new System.Drawing.Point(560, 67);
            this.btnSil.Name = "btnSil";
            this.btnSil.PrimaryColor = System.Drawing.Color.IndianRed;
            this.btnSil.Size = new System.Drawing.Size(187, 41);
            this.btnSil.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSil.TabIndex = 29;
            this.btnSil.Text = "Sil";
            this.btnSil.TextColor = System.Drawing.Color.White;
            this.btnSil.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnGuncelle.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuncelle.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnGuncelle.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGuncelle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnGuncelle.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnGuncelle.Location = new System.Drawing.Point(560, 20);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.PrimaryColor = System.Drawing.Color.LightSlateGray;
            this.btnGuncelle.Size = new System.Drawing.Size(187, 41);
            this.btnGuncelle.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnGuncelle.TabIndex = 28;
            this.btnGuncelle.Text = "Bilgileri Güncelle";
            this.btnGuncelle.TextColor = System.Drawing.Color.White;
            this.btnGuncelle.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.Red;
            this.lblId.Location = new System.Drawing.Point(758, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(14, 16);
            this.lblId.TabIndex = 10;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Yetki:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "E-Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ad Soyad:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(844, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 320);
            this.panel1.TabIndex = 6;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpDuzenle);
            this.Controls.Add(this.grpFiltre);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.dgvKullanicilar);
            this.Name = "Admin";
            this.Size = new System.Drawing.Size(878, 611);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.grpFiltre.ResumeLayout(false);
            this.grpFiltre.PerformLayout();
            this.grpDuzenle.ResumeLayout(false);
            this.grpDuzenle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox grpFiltre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDuzenle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.Panel panel1;
        private ReaLTaiizor.Controls.HopeButton btnGuncelle;
        private ReaLTaiizor.Controls.HopeButton btnSil;
        private ReaLTaiizor.Controls.DungeonTextBox txtArama;
        private ReaLTaiizor.Controls.DungeonButtonLeft btnAra;
        private ReaLTaiizor.Controls.PoisonComboBox cmbRolFiltre;
        private ReaLTaiizor.Controls.DungeonButtonLeft btnFiltrele;
        private ReaLTaiizor.Controls.DungeonButtonLeft btnTemizle;
        private ReaLTaiizor.Controls.DungeonTextBox txtEditAd;
        private ReaLTaiizor.Controls.DungeonTextBox txtEditEmail;
        private ReaLTaiizor.Controls.PoisonComboBox cmbEditRol;
        private ReaLTaiizor.Controls.DungeonTextBox txtEditTel;
    }
}