namespace BiletSatisOtomasyonu
{
    partial class AdminAnasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdminEkleme = new System.Windows.Forms.Panel();
            this.SPManager = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // AdminEkleme
            // 
            this.AdminEkleme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminEkleme.Location = new System.Drawing.Point(12, 13);
            this.AdminEkleme.Name = "AdminEkleme";
            this.AdminEkleme.Size = new System.Drawing.Size(420, 430);
            this.AdminEkleme.TabIndex = 0;
            // 
            // SPManager
            // 
            this.SPManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SPManager.Location = new System.Drawing.Point(438, 13);
            this.SPManager.Name = "SPManager";
            this.SPManager.Size = new System.Drawing.Size(690, 430);
            this.SPManager.TabIndex = 1;
            // 
            // AdminAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 455);
            this.Controls.Add(this.SPManager);
            this.Controls.Add(this.AdminEkleme);
            this.Name = "AdminAnasayfa";
            this.Text = "Admin Anasayfa";
            this.Load += new System.EventHandler(this.AdminAnasayfa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AdminEkleme;
        private System.Windows.Forms.Panel SPManager;
    }
}