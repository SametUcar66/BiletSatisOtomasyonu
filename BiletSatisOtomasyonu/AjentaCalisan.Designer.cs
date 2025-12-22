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
            this.lblBaslik = new System.Windows.Forms.Label();
            this.dgvSeferler = new System.Windows.Forms.DataGridView();
            this.grpSatis = new System.Windows.Forms.GroupBox();
            this.btnSatisYap = new System.Windows.Forms.Button();
            this.txtYolcuIsim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKoltukNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeferler)).BeginInit();
            this.grpSatis.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblBaslik.Location = new System.Drawing.Point(10, 10);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(201, 25);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "Acente Satış Terminali";
            // 
            // dgvSeferler
            // 
            this.dgvSeferler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeferler.Location = new System.Drawing.Point(15, 70);
            this.dgvSeferler.Name = "dgvSeferler";
            this.dgvSeferler.RowHeadersVisible = false;
            this.dgvSeferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeferler.Size = new System.Drawing.Size(550, 400);
            this.dgvSeferler.TabIndex = 1;
            this.dgvSeferler.SelectionChanged += new System.EventHandler(this.dgvSeferler_SelectionChanged);
            // 
            // grpSatis
            // 
            this.grpSatis.Controls.Add(this.btnSatisYap);
            this.grpSatis.Controls.Add(this.txtYolcuIsim);
            this.grpSatis.Controls.Add(this.label2);
            this.grpSatis.Controls.Add(this.txtKoltukNo);
            this.grpSatis.Controls.Add(this.label1);
            this.grpSatis.Location = new System.Drawing.Point(580, 70);
            this.grpSatis.Name = "grpSatis";
            this.grpSatis.Size = new System.Drawing.Size(250, 250);
            this.grpSatis.TabIndex = 2;
            this.grpSatis.TabStop = false;
            this.grpSatis.Text = "Hızlı Bilet Satışı";
            // 
            // btnSatisYap
            // 
            this.btnSatisYap.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSatisYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisYap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSatisYap.ForeColor = System.Drawing.Color.White;
            this.btnSatisYap.Location = new System.Drawing.Point(20, 130);
            this.btnSatisYap.Name = "btnSatisYap";
            this.btnSatisYap.Size = new System.Drawing.Size(210, 40);
            this.btnSatisYap.TabIndex = 4;
            this.btnSatisYap.Text = "SATIŞI ONAYLA";
            this.btnSatisYap.UseVisualStyleBackColor = false;
            this.btnSatisYap.Click += new System.EventHandler(this.btnSatisYap_Click);
            // 
            // txtYolcuIsim
            // 
            this.txtYolcuIsim.Location = new System.Drawing.Point(20, 90);
            this.txtYolcuIsim.Name = "txtYolcuIsim";
            this.txtYolcuIsim.Size = new System.Drawing.Size(210, 20);
            this.txtYolcuIsim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yolcu Ad Soyad:";
            // 
            // txtKoltukNo
            // 
            this.txtKoltukNo.Location = new System.Drawing.Point(20, 45);
            this.txtKoltukNo.Name = "txtKoltukNo";
            this.txtKoltukNo.Size = new System.Drawing.Size(100, 20);
            this.txtKoltukNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koltuk No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aktif Seferler (Listeden Seç)";
            // 
            // AjentaCalisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpSatis);
            this.Controls.Add(this.dgvSeferler);
            this.Controls.Add(this.lblBaslik);
            this.Name = "AjentaCalisan";
            this.Size = new System.Drawing.Size(850, 500);
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
        private System.Windows.Forms.Button btnSatisYap;
        private System.Windows.Forms.TextBox txtYolcuIsim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKoltukNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}