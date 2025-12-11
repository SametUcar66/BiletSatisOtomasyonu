namespace BiletSatisOtomasyonu
{
    partial class KayitKontrol
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtUsername2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(3, 89);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(344, 1);
            this.textBox2.TabIndex = 15;
            // 
            // txtUsername2
            // 
            this.txtUsername2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtUsername2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUsername2.ForeColor = System.Drawing.Color.DarkGray;
            this.txtUsername2.Location = new System.Drawing.Point(3, 61);
            this.txtUsername2.Name = "txtUsername2";
            this.txtUsername2.Size = new System.Drawing.Size(344, 19);
            this.txtUsername2.TabIndex = 14;
            this.txtUsername2.Enter += new System.EventHandler(this.txtUsername2_Enter);
            this.txtUsername2.Leave += new System.EventHandler(this.txtUsername2_Leave);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(3, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(344, 1);
            this.textBox1.TabIndex = 13;
            // 
            // txtEmail2
            // 
            this.txtEmail2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtEmail2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEmail2.ForeColor = System.Drawing.Color.DarkGray;
            this.txtEmail2.Location = new System.Drawing.Point(3, 3);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(344, 19);
            this.txtEmail2.TabIndex = 12;
            this.txtEmail2.Enter += new System.EventHandler(this.txtEmail2_Enter);
            this.txtEmail2.Leave += new System.EventHandler(this.txtEmail2_Leave);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRegister.Location = new System.Drawing.Point(3, 177);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(344, 51);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "KAYIT";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(3, 147);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(344, 1);
            this.textBox3.TabIndex = 17;
            // 
            // txtPassword2
            // 
            this.txtPassword2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtPassword2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword2.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword2.Location = new System.Drawing.Point(3, 119);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(344, 19);
            this.txtPassword2.TabIndex = 16;
            this.txtPassword2.Enter += new System.EventHandler(this.txtPassword2_Enter);
            this.txtPassword2.Leave += new System.EventHandler(this.txtPassword2_Leave);
            // 
            // KayitKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtUsername2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.btnRegister);
            this.Name = "KayitKontrol";
            this.Size = new System.Drawing.Size(350, 236);
            this.Load += new System.EventHandler(this.KayitKontrol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtUsername2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtPassword2;
    }
}
