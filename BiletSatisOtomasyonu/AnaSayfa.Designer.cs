namespace BiletSatisOtomasyonu
{
    partial class AnaSayfa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // BURASI ÖNEMLİ: FlowLayoutPanel DEĞİL, Panel yapıldı.
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlAnaIcerik = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(320, 674);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlAnaIcerik
            // 
            this.pnlAnaIcerik.BackColor = System.Drawing.Color.White;
            this.pnlAnaIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnaIcerik.Location = new System.Drawing.Point(320, 0);
            this.pnlAnaIcerik.Name = "pnlAnaIcerik";
            this.pnlAnaIcerik.Size = new System.Drawing.Size(879, 674);
            this.pnlAnaIcerik.TabIndex = 1;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 674);
            this.Controls.Add(this.pnlAnaIcerik);
            this.Controls.Add(this.pnlMenu);
            this.Name = "AnaSayfa";
            this.Text = "Bilet Satış Otomasyonu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlAnaIcerik;
    }
}