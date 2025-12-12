namespace BiletSatisOtomasyonu
{
    partial class GirisControl
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lineEmailSeparator = new System.Windows.Forms.TextBox();
            this.linePasswordSeparator = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLogin.Font = new System.Drawing.Font("Gilroy-Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.Location = new System.Drawing.Point(3, 177);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(344, 51);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "GİRİŞ";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.Font = new System.Drawing.Font("Gilroy-Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblForgotPassword.LinkColor = System.Drawing.Color.White;
            this.lblForgotPassword.Location = new System.Drawing.Point(3, 115);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(104, 14);
            this.lblForgotPassword.TabIndex = 3;
            this.lblForgotPassword.TabStop = true;
            this.lblForgotPassword.Text = "Parolamı unuttum";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEmail.ForeColor = System.Drawing.Color.DarkGray;
            this.txtEmail.Location = new System.Drawing.Point(3, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(344, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lineEmailSeparator
            // 
            this.lineEmailSeparator.BackColor = System.Drawing.Color.White;
            this.lineEmailSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineEmailSeparator.Location = new System.Drawing.Point(3, 31);
            this.lineEmailSeparator.Multiline = true;
            this.lineEmailSeparator.Name = "lineEmailSeparator";
            this.lineEmailSeparator.ReadOnly = true;
            this.lineEmailSeparator.Size = new System.Drawing.Size(344, 1);
            this.lineEmailSeparator.TabIndex = 7;
            // 
            // linePasswordSeparator
            // 
            this.linePasswordSeparator.BackColor = System.Drawing.Color.White;
            this.linePasswordSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linePasswordSeparator.Location = new System.Drawing.Point(3, 89);
            this.linePasswordSeparator.Multiline = true;
            this.linePasswordSeparator.Name = "linePasswordSeparator";
            this.linePasswordSeparator.ReadOnly = true;
            this.linePasswordSeparator.Size = new System.Drawing.Size(344, 1);
            this.linePasswordSeparator.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Gilroy-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.Location = new System.Drawing.Point(3, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(344, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // GirisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.linePasswordSeparator);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lineEmailSeparator);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblForgotPassword);
            this.Controls.Add(this.btnLogin);
            this.Name = "GirisControl";
            this.Size = new System.Drawing.Size(350, 236);
            this.Load += new System.EventHandler(this.GirisControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lblForgotPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox lineEmailSeparator;
        private System.Windows.Forms.TextBox linePasswordSeparator;
        private System.Windows.Forms.TextBox txtPassword;
    }
}
