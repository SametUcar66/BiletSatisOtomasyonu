namespace BiletSatisOtomasyonu
{
    partial class AjentaCalisan
    {
        private System.ComponentModel.IContainer components = null;

        // Temizleme işlemi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.grpSatis = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSatisYap = new ReaLTaiizor.Controls.HopeButton();
            this.txtKoltukNo = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtYolcuIsim = new ReaLTaiizor.Controls.DungeonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.grpSatis.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(39, 32);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(216, 22);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Acente Satış Terminali";
            // 
            // dgvSeferler
            // 
            this.dgvSeferler.AllowUserToAddRows = false;
            this.dgvSeferler.AllowUserToDeleteRows = false;
            this.dgvSeferler.AllowUserToOrderColumns = true;
            this.dgvSeferler.AllowUserToResizeColumns = false;
            this.dgvSeferler.AllowUserToResizeRows = false;
            this.dgvSeferler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeferler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.dgvSeferler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSeferler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvSeferler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSeferler.ColumnHeadersHeight = 40;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeferler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSeferler.EnableHeadersVisualStyles = false;
            this.dgvSeferler.Location = new System.Drawing.Point(44, 92);
            this.dgvSeferler.MultiSelect = false;
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.ReadOnly = true;
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.RowTemplate.Height = 40;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(550, 400);
            this.dgvSeferler.TabIndex = 0;
            this.dgvSeferler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeferler_DataBindingComplete);
            this.dgvSeferler.SelectionChanged += new System.EventHandler(this.dgvSeferler_SelectionChanged);
            // 
            // grpSatis
            // 
            this.grpSatis.Controls.Add(this.txtYolcuIsim);
            this.grpSatis.Controls.Add(this.txtKoltukNo);
            this.grpSatis.Controls.Add(this.btnSatisYap);
            this.grpSatis.Controls.Add(this.label2);
            this.grpSatis.Controls.Add(this.label1);
            this.grpSatis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSatis.ForeColor = System.Drawing.Color.White;
            this.grpSatis.Location = new System.Drawing.Point(609, 85);
            this.grpSatis.Name = "grpSatis";
            this.grpSatis.Size = new System.Drawing.Size(250, 221);
            this.grpSatis.TabIndex = 0;
            this.grpSatis.TabStop = false;
            this.grpSatis.Text = "Hızlı Bilet Satışı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(17, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Yolcu Ad Soyad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koltuk No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Aktif Seferler (Listeden Seç)";
            // 
            // btnSatisYap
            // 
            this.btnSatisYap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnSatisYap.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnSatisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatisYap.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnSatisYap.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSatisYap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisYap.ForeColor = System.Drawing.Color.Black;
            this.btnSatisYap.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnSatisYap.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnSatisYap.Location = new System.Drawing.Point(20, 161);
            this.btnSatisYap.Name = "btnSatisYap";
            this.btnSatisYap.PrimaryColor = System.Drawing.Color.ForestGreen;
            this.btnSatisYap.Size = new System.Drawing.Size(210, 40);
            this.btnSatisYap.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnSatisYap.TabIndex = 31;
            this.btnSatisYap.Text = "Satışı Onayla";
            this.btnSatisYap.TextColor = System.Drawing.Color.White;
            this.btnSatisYap.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnSatisYap.Click += new System.EventHandler(this.btnSatisYap_Click);
            // 
            // txtKoltukNo
            // 
            this.txtKoltukNo.BackColor = System.Drawing.Color.Transparent;
            this.txtKoltukNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtKoltukNo.EdgeColor = System.Drawing.Color.White;
            this.txtKoltukNo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtKoltukNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtKoltukNo.Location = new System.Drawing.Point(20, 50);
            this.txtKoltukNo.MaxLength = 32767;
            this.txtKoltukNo.Multiline = false;
            this.txtKoltukNo.Name = "txtKoltukNo";
            this.txtKoltukNo.ReadOnly = false;
            this.txtKoltukNo.Size = new System.Drawing.Size(210, 28);
            this.txtKoltukNo.TabIndex = 1;
            this.txtKoltukNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKoltukNo.UseSystemPasswordChar = false;
            // 
            // txtYolcuIsim
            // 
            this.txtYolcuIsim.BackColor = System.Drawing.Color.Transparent;
            this.txtYolcuIsim.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtYolcuIsim.EdgeColor = System.Drawing.Color.White;
            this.txtYolcuIsim.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtYolcuIsim.ForeColor = System.Drawing.Color.DimGray;
            this.txtYolcuIsim.Location = new System.Drawing.Point(20, 110);
            this.txtYolcuIsim.MaxLength = 32767;
            this.txtYolcuIsim.Multiline = false;
            this.txtYolcuIsim.Name = "txtYolcuIsim";
            this.txtYolcuIsim.ReadOnly = false;
            this.txtYolcuIsim.Size = new System.Drawing.Size(210, 28);
            this.txtYolcuIsim.TabIndex = 32;
            this.txtYolcuIsim.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtYolcuIsim.UseSystemPasswordChar = false;
            // 
            // AjentaCalisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpSatis);
            this.Controls.Add(this.dgvSeferler);
            this.Controls.Add(this.lblBaslik);
            this.Name = "AjentaCalisan";
            this.Size = new System.Drawing.Size(910, 506);
            this.Load += new System.EventHandler(this.AjentaCalisan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).EndInit();
            this.grpSatis.ResumeLayout(false);
            this.grpSatis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Değişken Tanımlamaları
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.DataGridView dgvSeferler;
        private System.Windows.Forms.GroupBox grpSatis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.HopeButton btnSatisYap;
        private ReaLTaiizor.Controls.DungeonTextBox txtYolcuIsim;
        private ReaLTaiizor.Controls.DungeonTextBox txtKoltukNo;
    }
}