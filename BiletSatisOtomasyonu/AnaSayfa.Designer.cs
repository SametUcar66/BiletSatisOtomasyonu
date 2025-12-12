namespace BiletSatisOtomasyonu
{
    partial class AnaSayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lineAccountSeparator = new System.Windows.Forms.TextBox();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lineTravelsSeparator = new System.Windows.Forms.TextBox();
            this.lineHelpSeparator = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMyTravels = new System.Windows.Forms.Button();
            this.btnMyAccount = new System.Windows.Forms.Button();
            this.picProfilePhoto = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTicketContent = new System.Windows.Forms.Panel();
            this.btnBusTicket = new System.Windows.Forms.Button();
            this.btnFlightTicket = new System.Windows.Forms.Button();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.btnSidebarBorder = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1024, 46);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimize.Location = new System.Drawing.Point(928, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(42, 41);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(987, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(37, 88);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(142, 40);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lineAccountSeparator
            // 
            this.lineAccountSeparator.BackColor = System.Drawing.Color.White;
            this.lineAccountSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineAccountSeparator.Location = new System.Drawing.Point(37, 364);
            this.lineAccountSeparator.Multiline = true;
            this.lineAccountSeparator.Name = "lineAccountSeparator";
            this.lineAccountSeparator.ReadOnly = true;
            this.lineAccountSeparator.Size = new System.Drawing.Size(142, 3);
            this.lineAccountSeparator.TabIndex = 7;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.lineTravelsSeparator);
            this.pnlSidebar.Controls.Add(this.lineHelpSeparator);
            this.pnlSidebar.Controls.Add(this.btnHelp);
            this.pnlSidebar.Controls.Add(this.btnMyTravels);
            this.pnlSidebar.Controls.Add(this.lineAccountSeparator);
            this.pnlSidebar.Controls.Add(this.btnMyAccount);
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.picProfilePhoto);
            this.pnlSidebar.Controls.Add(this.btnLogOut);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(224, 720);
            this.pnlSidebar.TabIndex = 8;
            // 
            // lineTravelsSeparator
            // 
            this.lineTravelsSeparator.BackColor = System.Drawing.Color.White;
            this.lineTravelsSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineTravelsSeparator.Location = new System.Drawing.Point(37, 415);
            this.lineTravelsSeparator.Multiline = true;
            this.lineTravelsSeparator.Name = "lineTravelsSeparator";
            this.lineTravelsSeparator.ReadOnly = true;
            this.lineTravelsSeparator.Size = new System.Drawing.Size(142, 3);
            this.lineTravelsSeparator.TabIndex = 9;
            // 
            // lineHelpSeparator
            // 
            this.lineHelpSeparator.BackColor = System.Drawing.Color.White;
            this.lineHelpSeparator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineHelpSeparator.Location = new System.Drawing.Point(37, 466);
            this.lineHelpSeparator.Multiline = true;
            this.lineHelpSeparator.Name = "lineHelpSeparator";
            this.lineHelpSeparator.ReadOnly = true;
            this.lineHelpSeparator.Size = new System.Drawing.Size(142, 3);
            this.lineHelpSeparator.TabIndex = 11;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(29, 432);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(142, 37);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Yardım";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnMyTravels
            // 
            this.btnMyTravels.FlatAppearance.BorderSize = 0;
            this.btnMyTravels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMyTravels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMyTravels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyTravels.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyTravels.ForeColor = System.Drawing.Color.White;
            this.btnMyTravels.Location = new System.Drawing.Point(29, 381);
            this.btnMyTravels.Name = "btnMyTravels";
            this.btnMyTravels.Size = new System.Drawing.Size(158, 37);
            this.btnMyTravels.TabIndex = 15;
            this.btnMyTravels.Text = "Seyahatlerim";
            this.btnMyTravels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyTravels.UseVisualStyleBackColor = true;
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.FlatAppearance.BorderSize = 0;
            this.btnMyAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMyAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyAccount.ForeColor = System.Drawing.Color.White;
            this.btnMyAccount.Location = new System.Drawing.Point(29, 330);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Size = new System.Drawing.Size(142, 37);
            this.btnMyAccount.TabIndex = 14;
            this.btnMyAccount.Text = "Hesabım";
            this.btnMyAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyAccount.UseVisualStyleBackColor = true;
            this.btnMyAccount.Click += new System.EventHandler(this.btnMyAccount_Click);
            // 
            // picProfilePhoto
            // 
            this.picProfilePhoto.Location = new System.Drawing.Point(37, 171);
            this.picProfilePhoto.Name = "picProfilePhoto";
            this.picProfilePhoto.Size = new System.Drawing.Size(142, 142);
            this.picProfilePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfilePhoto.TabIndex = 13;
            this.picProfilePhoto.TabStop = false;
            this.picProfilePhoto.Paint += new System.Windows.Forms.PaintEventHandler(this.picProfilePhoto_Paint);
            // 
            // btnLogOut
            // 
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.ForeColor = System.Drawing.Color.Maroon;
            this.btnLogOut.Location = new System.Drawing.Point(37, 670);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(150, 38);
            this.btnLogOut.TabIndex = 12;
            this.btnLogOut.Text = "ÇIKIŞ";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlTicketContent);
            this.pnlMain.Controls.Add(this.btnBusTicket);
            this.pnlMain.Controls.Add(this.btnFlightTicket);
            this.pnlMain.Controls.Add(this.lblSlogan);
            this.pnlMain.Controls.Add(this.btnSidebarBorder);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMain.Location = new System.Drawing.Point(224, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 720);
            this.pnlMain.TabIndex = 9;
            // 
            // pnlTicketContent
            // 
            this.pnlTicketContent.BackColor = System.Drawing.Color.White;
            this.pnlTicketContent.ForeColor = System.Drawing.Color.Black;
            this.pnlTicketContent.Location = new System.Drawing.Point(46, 276);
            this.pnlTicketContent.Name = "pnlTicketContent";
            this.pnlTicketContent.Size = new System.Drawing.Size(700, 269);
            this.pnlTicketContent.TabIndex = 1;
            this.pnlTicketContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTicketContent_Paint);
            // 
            // btnBusTicket
            // 
            this.btnBusTicket.BackColor = System.Drawing.Color.DarkGray;
            this.btnBusTicket.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBusTicket.FlatAppearance.BorderSize = 0;
            this.btnBusTicket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBusTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBusTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBusTicket.Location = new System.Drawing.Point(166, 241);
            this.btnBusTicket.Name = "btnBusTicket";
            this.btnBusTicket.Size = new System.Drawing.Size(120, 35);
            this.btnBusTicket.TabIndex = 4;
            this.btnBusTicket.Text = "Otobüs Bileti";
            this.btnBusTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusTicket.UseVisualStyleBackColor = false;
            this.btnBusTicket.Click += new System.EventHandler(this.btnBusTicket_Click);
            // 
            // btnFlightTicket
            // 
            this.btnFlightTicket.BackColor = System.Drawing.Color.White;
            this.btnFlightTicket.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFlightTicket.FlatAppearance.BorderSize = 0;
            this.btnFlightTicket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFlightTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnFlightTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlightTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFlightTicket.Location = new System.Drawing.Point(46, 241);
            this.btnFlightTicket.Name = "btnFlightTicket";
            this.btnFlightTicket.Size = new System.Drawing.Size(120, 35);
            this.btnFlightTicket.TabIndex = 3;
            this.btnFlightTicket.Text = "Uçak Bileti";
            this.btnFlightTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFlightTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFlightTicket.UseVisualStyleBackColor = false;
            this.btnFlightTicket.Click += new System.EventHandler(this.btnFlightTicket_Click);
            // 
            // lblSlogan
            // 
            this.lblSlogan.AutoSize = true;
            this.lblSlogan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSlogan.ForeColor = System.Drawing.Color.White;
            this.lblSlogan.Location = new System.Drawing.Point(142, 168);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(518, 31);
            this.lblSlogan.TabIndex = 2;
            this.lblSlogan.Text = "PIKAJET Aracılığıyla Uygun Fiyatlı Bilet Al";
            // 
            // btnSidebarBorder
            // 
            this.btnSidebarBorder.Enabled = false;
            this.btnSidebarBorder.Location = new System.Drawing.Point(1, 47);
            this.btnSidebarBorder.Name = "btnSidebarBorder";
            this.btnSidebarBorder.Size = new System.Drawing.Size(1, 673);
            this.btnSidebarBorder.TabIndex = 0;
            this.btnSidebarBorder.UseVisualStyleBackColor = true;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePhoto)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox lineAccountSeparator;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.TextBox lineTravelsSeparator;
        private System.Windows.Forms.TextBox lineHelpSeparator;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox picProfilePhoto;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSidebarBorder;
        private System.Windows.Forms.Panel pnlTicketContent;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Button btnFlightTicket;
        private System.Windows.Forms.Button btnBusTicket;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Button btnMyTravels;
        private System.Windows.Forms.Button btnHelp;
    }
}