namespace BiletSatisOtomasyonu
{
    partial class DashboardCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnManage = new System.Windows.Forms.Button();
            this.pnlColorStrip = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Location = new System.Drawing.Point(19, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 21);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Başlık";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(15, 32);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 45);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0";
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManage.FlatAppearance.BorderSize = 0;
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnManage.Location = new System.Drawing.Point(98, 65);
            this.btnManage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(75, 23);
            this.btnManage.TabIndex = 3;
            this.btnManage.Text = "Yönet >";
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // pnlColorStrip
            // 
            this.pnlColorStrip.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlColorStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColorStrip.Location = new System.Drawing.Point(0, 0);
            this.pnlColorStrip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlColorStrip.Name = "pnlColorStrip";
            this.pnlColorStrip.Size = new System.Drawing.Size(8, 349);
            this.pnlColorStrip.TabIndex = 0;
            // 
            // DashboardCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlColorStrip);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DashboardCard";
            this.Size = new System.Drawing.Size(510, 349);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Panel pnlColorStrip;

        #endregion
    }
}
