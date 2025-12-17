namespace BiletSatisOtomasyonu
{
    partial class adminPage
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
            this.flowLayoutPanelAdmin = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAdmin
            // 
            this.flowLayoutPanelAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAdmin.AutoScroll = true;
            this.flowLayoutPanelAdmin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelAdmin.Location = new System.Drawing.Point(15, 52);
            this.flowLayoutPanelAdmin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelAdmin.Name = "flowLayoutPanelAdmin";
            this.flowLayoutPanelAdmin.Size = new System.Drawing.Size(1270, 667);
            this.flowLayoutPanelAdmin.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(15, 13);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(197, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Sistem Yönetimi";
            // 
            // adminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1315, 732);
            this.Controls.Add(this.flowLayoutPanelAdmin);
            this.Controls.Add(this.lblHeader);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "adminPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Yöneticisi";
            this.Load += new System.EventHandler(this.adminPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAdmin;
        private System.Windows.Forms.Label lblHeader;
        // Eleman Tanımları
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabAgencies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalAgencies;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.DataGridView dgvAgencies;
        private System.Windows.Forms.GroupBox grpAddAgency;
        private System.Windows.Forms.Button btnAddAgency;
        private System.Windows.Forms.TextBox txtAgencyEmail;
        private System.Windows.Forms.Label lblAgEmail;
        private System.Windows.Forms.TextBox txtAgencyName;
        private System.Windows.Forms.Label lblAgName;
        private System.Windows.Forms.Button btnDeleteAgency;

        #endregion
    }
}