namespace BiletSatisOtomasyonu
{
    partial class SuperAdminEkleme
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAgencyName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.rbSuperAdmin = new System.Windows.Forms.RadioButton();
            this.rbAgencyAdmin = new System.Windows.Forms.RadioButton();
            this.rbStaff = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFullName  
            // 
            this.txtFullName.Location = new System.Drawing.Point(12, 60);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(168, 20);
            this.txtFullName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(105, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAgencyName
            // 
            this.txtAgencyName.Location = new System.Drawing.Point(15, 261);
            this.txtAgencyName.Name = "txtAgencyName";
            this.txtAgencyName.Size = new System.Drawing.Size(168, 20);
            this.txtAgencyName.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(12, 41);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(63, 13);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "İsim Soyisim";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Location = new System.Drawing.Point(16, 245);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(52, 13);
            this.lblAgencyName.TabIndex = 6;
            this.lblAgencyName.Text = "Şirket Adı";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 102);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 154);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(15, 206);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(168, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 83);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "E-Posta";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 138);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(28, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Şifre";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(15, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(43, 13);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Telefon";
            // 
            // rbSuperAdmin
            // 
            this.rbSuperAdmin.AutoSize = true;
            this.rbSuperAdmin.Location = new System.Drawing.Point(200, 60);
            this.rbSuperAdmin.Name = "rbSuperAdmin";
            this.rbSuperAdmin.Size = new System.Drawing.Size(85, 17);
            this.rbSuperAdmin.TabIndex = 15;
            this.rbSuperAdmin.TabStop = true;
            this.rbSuperAdmin.Text = "Super Admin";
            this.rbSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // rbAgencyAdmin
            // 
            this.rbAgencyAdmin.AutoSize = true;
            this.rbAgencyAdmin.Location = new System.Drawing.Point(291, 61);
            this.rbAgencyAdmin.Name = "rbAgencyAdmin";
            this.rbAgencyAdmin.Size = new System.Drawing.Size(85, 17);
            this.rbAgencyAdmin.TabIndex = 16;
            this.rbAgencyAdmin.TabStop = true;
            this.rbAgencyAdmin.Text = "Acenta Yöneticisi";
            this.rbAgencyAdmin.UseVisualStyleBackColor = true;
            // 
            // rbStaff
            // 
            this.rbStaff.AutoSize = true;
            this.rbStaff.Location = new System.Drawing.Point(200, 83);
            this.rbStaff.Name = "rbStaff";
            this.rbStaff.Size = new System.Drawing.Size(85, 17);
            this.rbStaff.TabIndex = 17;
            this.rbStaff.TabStop = true;
            this.rbStaff.Text = "Şirket Hesabı";
            this.rbStaff.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(68, 13);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "Kayıt Ekleme";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.picLogo.Location = new System.Drawing.Point(200, 138);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(188, 143);
            this.picLogo.TabIndex = 19;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(197, 122);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(31, 13);
            this.lblLogo.TabIndex = 20;
            this.lblLogo.Text = "Logo";
            // 
            // SuperAdminEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 424);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rbStaff);
            this.Controls.Add(this.rbAgencyAdmin);
            this.Controls.Add(this.rbSuperAdmin);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtAgencyName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFullName);
            this.Name = "SuperAdminEkleme";
            this.Text = "SuperAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAgencyName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblAgencyName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.RadioButton rbSuperAdmin;
        private System.Windows.Forms.RadioButton rbAgencyAdmin;
        private System.Windows.Forms.RadioButton rbStaff;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLogo;
    }
}