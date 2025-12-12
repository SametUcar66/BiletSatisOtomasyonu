namespace BiletSatisOtomasyonu
{
    partial class KayitKontrol
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        private void InitializeComponent()
        {
            this.lineUsernameSeparator = new System.Windows.Forms.TextBox();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.lineEmailSeparator = new System.Windows.Forms.TextBox();
            this.txtRegisterEmail = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.linePasswordSeparator = new System.Windows.Forms.TextBox();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.picProfilePhoto = new System.Windows.Forms.PictureBox();
            this.rbPersonal = new System.Windows.Forms.RadioButton();
            this.rbCompany = new System.Windows.Forms.RadioButton();
            this.rbAgency = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lineUsernameSeparator
            // 
            this.lineUsernameSeparator.BackColor = System.Drawing.Color.White;
            this.lineUsernameSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineUsernameSeparator.Location = new System.Drawing.Point(3, 89);
            this.lineUsernameSeparator.Multiline = true;
            this.lineUsernameSeparator.Name = "lineUsernameSeparator";
            this.lineUsernameSeparator.ReadOnly = true;
            this.lineUsernameSeparator.Size = new System.Drawing.Size(344, 1);
            this.lineUsernameSeparator.TabIndex = 15;
            // 
            // txtRegisterUsername
            // 
            this.txtRegisterUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtRegisterUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRegisterUsername.ForeColor = System.Drawing.Color.DarkGray;
            this.txtRegisterUsername.Location = new System.Drawing.Point(3, 61);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.Size = new System.Drawing.Size(344, 19);
            this.txtRegisterUsername.TabIndex = 14;
            this.txtRegisterUsername.Enter += new System.EventHandler(this.txtRegisterUsername_Enter);
            this.txtRegisterUsername.Leave += new System.EventHandler(this.txtRegisterUsername_Leave);
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
            this.lineEmailSeparator.TabIndex = 13;
            // 
            // txtRegisterEmail
            // 
            this.txtRegisterEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtRegisterEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRegisterEmail.ForeColor = System.Drawing.Color.DarkGray;
            this.txtRegisterEmail.Location = new System.Drawing.Point(3, 3);
            this.txtRegisterEmail.Name = "txtRegisterEmail";
            this.txtRegisterEmail.Size = new System.Drawing.Size(344, 19);
            this.txtRegisterEmail.TabIndex = 12;
            this.txtRegisterEmail.Enter += new System.EventHandler(this.txtRegisterEmail_Enter);
            this.txtRegisterEmail.Leave += new System.EventHandler(this.txtRegisterEmail_Leave);
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRegister.Location = new System.Drawing.Point(3, 177);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(344, 51);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "KAYIT OL";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // linePasswordSeparator
            // 
            this.linePasswordSeparator.BackColor = System.Drawing.Color.White;
            this.linePasswordSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linePasswordSeparator.Location = new System.Drawing.Point(3, 147);
            this.linePasswordSeparator.Multiline = true;
            this.linePasswordSeparator.Name = "linePasswordSeparator";
            this.linePasswordSeparator.ReadOnly = true;
            this.linePasswordSeparator.Size = new System.Drawing.Size(344, 1);
            this.linePasswordSeparator.TabIndex = 17;
            // 
            // txtRegisterPassword
            // 
            this.txtRegisterPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.txtRegisterPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegisterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRegisterPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtRegisterPassword.Location = new System.Drawing.Point(3, 119);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.Size = new System.Drawing.Size(344, 19);
            this.txtRegisterPassword.TabIndex = 16;
            this.txtRegisterPassword.Enter += new System.EventHandler(this.txtRegisterPassword_Enter);
            this.txtRegisterPassword.Leave += new System.EventHandler(this.txtRegisterPassword_Leave);
            // 
            // picProfilePhoto
            // 
            this.picProfilePhoto.BackColor = System.Drawing.Color.Gray;
            this.picProfilePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picProfilePhoto.Location = new System.Drawing.Point(3, 279);
            this.picProfilePhoto.Name = "picProfilePhoto";
            this.picProfilePhoto.Size = new System.Drawing.Size(100, 100);
            this.picProfilePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfilePhoto.TabIndex = 18;
            this.picProfilePhoto.TabStop = false;
            this.picProfilePhoto.Click += new System.EventHandler(this.picProfilePhoto_Click);
            // 
            // rbPersonal
            // 
            this.rbPersonal.AutoSize = true;
            this.rbPersonal.ForeColor = System.Drawing.Color.White;
            this.rbPersonal.Location = new System.Drawing.Point(3, 256);
            this.rbPersonal.Name = "rbPersonal";
            this.rbPersonal.Size = new System.Drawing.Size(54, 17);
            this.rbPersonal.TabIndex = 19;
            this.rbPersonal.TabStop = true;
            this.rbPersonal.Text = "Kişisel";
            this.rbPersonal.UseVisualStyleBackColor = true;
            this.rbPersonal.CheckedChanged += new System.EventHandler(this.rbAccountType_CheckedChanged);
            // 
            // rbCompany
            // 
            this.rbCompany.AutoSize = true;
            this.rbCompany.ForeColor = System.Drawing.Color.White;
            this.rbCompany.Location = new System.Drawing.Point(80, 256);
            this.rbCompany.Name = "rbCompany";
            this.rbCompany.Size = new System.Drawing.Size(52, 17);
            this.rbCompany.TabIndex = 20;
            this.rbCompany.TabStop = true;
            this.rbCompany.Text = "Şirket";
            this.rbCompany.UseVisualStyleBackColor = true;
            this.rbCompany.CheckedChanged += new System.EventHandler(this.rbAccountType_CheckedChanged);
            // 
            // rbAgency
            // 
            this.rbAgency.AutoSize = true;
            this.rbAgency.ForeColor = System.Drawing.Color.White;
            this.rbAgency.Location = new System.Drawing.Point(155, 256);
            this.rbAgency.Name = "rbAgency";
            this.rbAgency.Size = new System.Drawing.Size(59, 17);
            this.rbAgency.TabIndex = 21;
            this.rbAgency.TabStop = true;
            this.rbAgency.Text = "Acenta";
            this.rbAgency.UseVisualStyleBackColor = true;
            this.rbAgency.CheckedChanged += new System.EventHandler(this.rbAccountType_CheckedChanged);
            // 
            // KayitKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.rbAgency);
            this.Controls.Add(this.rbCompany);
            this.Controls.Add(this.rbPersonal);
            this.Controls.Add(this.picProfilePhoto);
            this.Controls.Add(this.linePasswordSeparator);
            this.Controls.Add(this.txtRegisterPassword);
            this.Controls.Add(this.lineUsernameSeparator);
            this.Controls.Add(this.txtRegisterUsername);
            this.Controls.Add(this.lineEmailSeparator);
            this.Controls.Add(this.txtRegisterEmail);
            this.Controls.Add(this.btnRegister);
            this.Name = "KayitKontrol";
            this.Size = new System.Drawing.Size(466, 400);
            this.Load += new System.EventHandler(this.KayitKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lineUsernameSeparator;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.TextBox lineEmailSeparator;
        private System.Windows.Forms.TextBox txtRegisterEmail;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox linePasswordSeparator;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.PictureBox picProfilePhoto;
        private System.Windows.Forms.RadioButton rbPersonal;
        private System.Windows.Forms.RadioButton rbCompany;
        private System.Windows.Forms.RadioButton rbAgency;
    }
}
