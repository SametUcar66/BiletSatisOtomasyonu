using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;
using BiletSatis.Models;

namespace BiletSatis.Forms
{
    public partial class FrmMain : Form
    {
        // Ana kontroller
        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblWelcome;
        private Label lblUserRole;
        private Label lblAgencyName;
        private Label lblTitle;
        private Button btnLogout;
        private Label lblDateTime;

        // Tema renkleri (role göre değişecek)
        private Color ThemeColor = Color.FromArgb(46, 204, 113);
        private Color ThemeDarkColor = Color.FromArgb(35, 155, 86);

        public FrmMain()
        {
            SetThemeByRole();
            InitializeComponents();
            LoadDashboardByRole();
        }

        private void SetThemeByRole()
        {
            var role = SessionManager.CurrentUser?.UserType ?? UserType.Individual;

            switch (role)
            {
                case UserType.SuperAdmin:
                    ThemeColor = Color.FromArgb(142, 68, 173);      // Mor
                    ThemeDarkColor = Color.FromArgb(113, 54, 138);
                    break;
                case UserType.AgencyManager:
                    ThemeColor = Color.FromArgb(41, 128, 185);      // Mavi
                    ThemeDarkColor = Color.FromArgb(31, 97, 141);
                    break;
                case UserType.AgencyEmployee:
                    ThemeColor = Color.FromArgb(22, 160, 133);      // Yeşil-Mavi
                    ThemeDarkColor = Color.FromArgb(17, 122, 101);
                    break;
                case UserType.Driver:
                    ThemeColor = Color.FromArgb(230, 126, 34);      // Turuncu
                    ThemeDarkColor = Color.FromArgb(175, 96, 26);
                    break;
                case UserType.Company:
                    ThemeColor = Color.FromArgb(155, 89, 182);      // Açık Mor
                    ThemeDarkColor = Color.FromArgb(125, 60, 152);
                    break;
                case UserType.Individual:
                default:
                    ThemeColor = Color.FromArgb(46, 204, 113);      // Yeşil
                    ThemeDarkColor = Color.FromArgb(35, 155, 86);
                    break;
            }
        }

        private void InitializeComponents()
        {
            // Form ayarları
            this.Text = "VoyageHub - " + GetRoleTitle();
            this.Size = new Size(1250, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.MinimumSize = new Size(1100, 650);

            // Sidebar
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 240,
                BackColor = ThemeDarkColor
            };
            this.Controls.Add(pnlSidebar);

            // Logo/Başlık
            var lblLogo = new Label
            {
                Text = "✈ VoyageHub",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 20),
                AutoSize = true
            };
            pnlSidebar.Controls.Add(lblLogo);

            // Kullanıcı bilgisi
            lblWelcome = new Label
            {
                Text = SessionManager.CurrentUser?.FullName ?? "Kullanıcı",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 65),
                Size = new Size(190, 25)
            };
            pnlSidebar.Controls.Add(lblWelcome);

            lblUserRole = new Label
            {
                Text = GetRoleDisplayName(),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(200, 200, 200),
                Location = new Point(25, 90),
                AutoSize = true
            };
            pnlSidebar.Controls.Add(lblUserRole);

            // Ajans adı (varsa)
            lblAgencyName = new Label
            {
                Text = GetAgencyName(),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.FromArgb(180, 180, 180),
                Location = new Point(25, 110),
                Size = new Size(190, 20),
                Visible = SessionManager.CurrentAgencyId.HasValue
            };
            pnlSidebar.Controls.Add(lblAgencyName);

            // Ayırıcı çizgi - use semi-transparent white
            var separator = new Panel
            {
                BackColor = Color.FromArgb(30, Color.White),
                Location = new Point(20, 140),
                Size = new Size(200, 1)
            };
            pnlSidebar.Controls.Add(separator);

            // Menü butonlarını role göre ekle
            AddMenuButtonsByRole();

            // Çıkış butonu (en altta)
            btnLogout = CreateMenuButton("🚪  Çıkış Yap", 0);
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.Click += BtnLogout_Click;
            // set location after sidebar has its initial height
            btnLogout.Location = new Point(15, pnlSidebar.Height - 60);
            pnlSidebar.Controls.Add(btnLogout);

            // Header
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White
            };
            this.Controls.Add(pnlHeader);

            lblTitle = new Label
            {
                Text = "Gösterge Paneli",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = ThemeColor,
                Location = new Point(260, 12),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitle);

            // Tarih/Saat
            lblDateTime = new Label
            {
                Text = DateTime.Now.ToString("dd MMMM yyyy, dddd"),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            pnlHeader.Controls.Add(lblDateTime);

            // adjust date label position on header resize and initial layout
            pnlHeader.Resize += (s, e) => PositionHeaderDateLabel();
            pnlHeader.PerformLayout();
            PositionHeaderDateLabel();

            // İçerik paneli
            pnlContent = new Panel
            {
                Location = new Point(240, 60),
                Size = new Size(this.ClientSize.Width - 240, this.ClientSize.Height - 60),
                BackColor = Color.FromArgb(245, 247, 250),
                AutoScroll = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            this.Controls.Add(pnlContent);

            // Ensure resize keeps layout correct
            this.Resize += (s, e) =>
            {
                pnlContent.Size = new Size(this.ClientSize.Width - 240, this.ClientSize.Height - 60);
                PositionHeaderDateLabel();
            };
        }

        private void PositionHeaderDateLabel()
        {
            if (pnlHeader == null || lblDateTime == null) return;
            // position 20px from right edge
            lblDateTime.Location = new Point(Math.Max(260, pnlHeader.ClientSize.Width - lblDateTime.Width - 20), 20);
        }

        private void AddMenuButtonsByRole()
        {
            int menuY = 160;
            int spacing = 45;

            var role = SessionManager.CurrentUser?.UserType ?? UserType.Individual;

            switch (role)
            {
                case UserType.SuperAdmin:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadSuperAdminDashboard()); menuY += spacing;
                    AddMenuButton("🏢  Ajans Yönetimi", menuY, () => LoadContent("Ajans Yönetimi")); menuY += spacing;
                    AddMenuButton("👥  Kullanıcı Yönetimi", menuY, () => LoadContent("Kullanıcı Yönetimi")); menuY += spacing;
                    AddMenuButton("🚌  Tüm Seferler", menuY, () => LoadContent("Tüm Seferler")); menuY += spacing;
                    AddMenuButton("🎫  Tüm Biletler", menuY, () => LoadContent("Tüm Biletler")); menuY += spacing;
                    AddMenuButton("📈  Raporlar", menuY, () => LoadContent("Raporlar")); menuY += spacing;
                    AddMenuButton("⚙️  Sistem Ayarları", menuY, () => LoadContent("Sistem Ayarları")); menuY += spacing;
                    break;

                case UserType.AgencyManager:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadAgencyManagerDashboard()); menuY += spacing;
                    AddMenuButton("👥  Çalışan Yönetimi", menuY, () => LoadContent("Çalışan Yönetimi")); menuY += spacing;
                    AddMenuButton("🚐  Araç Yönetimi", menuY, () => LoadContent("Araç Yönetimi")); menuY += spacing;
                    AddMenuButton("👨‍✈️  Şoför Yönetimi", menuY, () => LoadContent("Şoför Yönetimi")); menuY += spacing;
                    AddMenuButton("🛣️  Rota Yönetimi", menuY, () => LoadContent("Rota Yönetimi")); menuY += spacing;
                    AddMenuButton("🚌  Sefer Yönetimi", menuY, () => LoadContent("Sefer Yönetimi")); menuY += spacing;
                    AddMenuButton("🎫  Bilet Satışları", menuY, () => LoadContent("Bilet Satışları")); menuY += spacing;
                    AddMenuButton("⛽  Yakıt Takibi", menuY, () => LoadContent("Yakıt Takibi")); menuY += spacing;
                    AddMenuButton("📈  Raporlar", menuY, () => LoadContent("Raporlar")); menuY += spacing;
                    break;

                case UserType.AgencyEmployee:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadEmployeeDashboard()); menuY += spacing;
                    AddMenuButton("🎫  Bilet Satışı", menuY, () => LoadContent("Bilet Satışı")); menuY += spacing;
                    AddMenuButton("🔍  Sefer Ara", menuY, () => LoadContent("Sefer Ara")); menuY += spacing;
                    AddMenuButton("📋  Satışlarım", menuY, () => LoadContent("Satışlarım")); menuY += spacing;
                    AddMenuButton("👤  Profilim", menuY, () => LoadContent("Profilim")); menuY += spacing;
                    break;

                case UserType.Driver:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadDriverDashboard()); menuY += spacing;
                    AddMenuButton("🚌  Seferlerim", menuY, () => LoadContent("Seferlerim")); menuY += spacing;
                    AddMenuButton("⛽  Yakıt Girişi", menuY, () => LoadContent("Yakıt Girişi")); menuY += spacing;
                    AddMenuButton("📋  Yakıt Geçmişi", menuY, () => LoadContent("Yakıt Geçmişi")); menuY += spacing;
                    AddMenuButton("🚐  Aracım", menuY, () => LoadContent("Aracım")); menuY += spacing;
                    AddMenuButton("👤  Profilim", menuY, () => LoadContent("Profilim")); menuY += spacing;
                    break;

                case UserType.Company:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadCompanyDashboard()); menuY += spacing;
                    AddMenuButton("🔍  Sefer Ara", menuY, () => LoadContent("Sefer Ara")); menuY += spacing;
                    AddMenuButton("🎫  Toplu Bilet Al", menuY, () => LoadContent("Toplu Bilet Al")); menuY += spacing;
                    AddMenuButton("📋  Siparişlerim", menuY, () => LoadContent("Siparişlerim")); menuY += spacing;
                    AddMenuButton("🎟️  Biletlerim", menuY, () => LoadContent("Biletlerim")); menuY += spacing;
                    AddMenuButton("👤  Şirket Profili", menuY, () => LoadContent("Şirket Profili")); menuY += spacing;
                    break;

                case UserType.Individual:
                default:
                    AddMenuButton("📊  Gösterge Paneli", menuY, () => LoadIndividualDashboard()); menuY += spacing;
                    AddMenuButton("🔍  Sefer Ara", menuY, () => LoadContent("Sefer Ara")); menuY += spacing;
                    AddMenuButton("🎫  Bilet Al", menuY, () => LoadContent("Bilet Al")); menuY += spacing;
                    AddMenuButton("🎟️  Biletlerim", menuY, () => LoadContent("Biletlerim")); menuY += spacing;
                    AddMenuButton("👤  Profilim", menuY, () => LoadContent("Profilim")); menuY += spacing;
                    break;
            }
        }

        private void AddMenuButton(string text, int y, Action onClick)
        {
            var btn = CreateMenuButton(text, y);
            btn.Click += (s, e) => onClick();
            pnlSidebar.Controls.Add(btn);
        }

        private Button CreateMenuButton(string text, int y)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = ThemeDarkColor,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, y),
                Size = new Size(210, 40),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ThemeColor;
            btn.MouseLeave += (s, e) => btn.BackColor = ThemeDarkColor;
            return btn;
        }

        #region Dashboard Loaders

        private void LoadDashboardByRole()
        {
            var role = SessionManager.CurrentUser?.UserType ?? UserType.Individual;

            switch (role)
            {
                case UserType.SuperAdmin:
                    LoadSuperAdminDashboard();
                    break;
                case UserType.AgencyManager:
                    LoadAgencyManagerDashboard();
                    break;
                case UserType.AgencyEmployee:
                    LoadEmployeeDashboard();
                    break;
                case UserType.Driver:
                    LoadDriverDashboard();
                    break;
                case UserType.Company:
                    LoadCompanyDashboard();
                    break;
                case UserType.Individual:
                default:
                    LoadIndividualDashboard();
                    break;
            }
        }

        private void LoadSuperAdminDashboard()
        {
            lblTitle.Text = "👑 Super Admin Paneli";
            pnlContent.Controls.Clear();

            int x = 25, y = 25;

            CreateDashboardCard("Toplam Ajans", GetCount("Agencies"), "🏢", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Toplam Kullanıcı", GetCount("Users"), "👥", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Aktif Sefer", GetCount("Trips", "Status = 0"), "🚌", Color.FromArgb(155, 89, 182), x + 440, y);
            CreateDashboardCard("Bugünkü Satış", GetTodaySales(), "💰", Color.FromArgb(230, 126, 34), x + 660, y);

            y += 150;
            CreateDashboardCard("Toplam Araç", GetCount("Vehicles"), "🚐", Color.FromArgb(26, 188, 156), x, y);
            CreateDashboardCard("Toplam Şoför", GetCount("Drivers"), "👨‍✈️", Color.FromArgb(241, 196, 15), x + 220, y);
            CreateDashboardCard("Satılan Bilet", GetCount("Tickets", "Status = 1"), "🎫", Color.FromArgb(231, 76, 60), x + 440, y);
            CreateDashboardCard("Bekleyen Onay", GetCount("CompanyOrders", "Status = 0"), "⏳", Color.FromArgb(142, 68, 173), x + 660, y);
        }

        private void LoadAgencyManagerDashboard()
        {
            lblTitle.Text = "🏢 Ajans Yönetim Paneli";
            pnlContent.Controls.Clear();

            int agencyId = SessionManager.CurrentAgencyId ?? 0;
            int x = 25, y = 25;

            CreateDashboardCard("Çalışan Sayısı", GetAgencyCount("AgencyEmployees", agencyId), "👥", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Araç Sayısı", GetAgencyCount("Vehicles", agencyId), "🚐", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Aktif Sefer", GetAgencyTripCount(agencyId), "🚌", Color.FromArgb(155, 89, 182), x + 440, y);
            CreateDashboardCard("Bugünkü Satış", GetAgencyTodaySales(agencyId), "💰", Color.FromArgb(230, 126, 34), x + 660, y);

            y += 150;
            CreateDashboardCard("Şoför Sayısı", GetAgencyCount("Drivers", agencyId), "👨‍✈️", Color.FromArgb(241, 196, 15), x, y);
            CreateDashboardCard("Satılan Bilet", GetAgencyTicketCount(agencyId), "🎫", Color.FromArgb(231, 76, 60), x + 220, y);
            CreateDashboardCard("Toplam Yakıt (L)", GetAgencyFuelTotal(agencyId), "⛽", Color.FromArgb(26, 188, 156), x + 440, y);
            CreateDashboardCard("Rota Sayısı", GetAgencyCount("Routes", agencyId), "🛣️", Color.FromArgb(142, 68, 173), x + 660, y);
        }

        private void LoadEmployeeDashboard()
        {
            lblTitle.Text = "👤 Çalışan Paneli";
            pnlContent.Controls.Clear();

            int userId = SessionManager.CurrentUser?.Id ?? 0;
            int x = 25, y = 25;

            CreateDashboardCard("Bugün Sattığım", GetEmployeeTodaySales(userId), "🎫", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Bu Ay Sattığım", GetEmployeeMonthSales(userId), "📊", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Aktif Seferler", GetActiveTripCount(), "🚌", Color.FromArgb(155, 89, 182), x + 440, y);
            CreateDashboardCard("Bugünkü Gelir", GetEmployeeTodayRevenue(userId), "💰", Color.FromArgb(230, 126, 34), x + 660, y);

            // Hızlı işlem butonları
            y += 180;
            CreateQuickActionButton("🎫 Yeni Bilet Sat", x, y, () => LoadContent("Bilet Satışı"));
            CreateQuickActionButton("🔍 Sefer Ara", x + 200, y, () => LoadContent("Sefer Ara"));
        }

        private void LoadDriverDashboard()
        {
            lblTitle.Text = "🚌 Şoför Paneli";
            pnlContent.Controls.Clear();

            int userId = SessionManager.CurrentUser?.Id ?? 0;
            int x = 25, y = 25;

            CreateDashboardCard("Bugünkü Sefer", GetDriverTodayTrips(userId), "🚌", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Bu Ay Sefer", GetDriverMonthTrips(userId), "📅", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Toplam Yakıt (L)", GetDriverFuelTotal(userId), "⛽", Color.FromArgb(230, 126, 34), x + 440, y);
            CreateDashboardCard("Toplam KM", GetDriverTotalKm(userId), "📏", Color.FromArgb(155, 89, 182), x + 660, y);

            // Hızlı işlem butonları
            y += 180;
            CreateQuickActionButton("⛽ Yakıt Girişi Yap", x, y, () => LoadContent("Yakıt Girişi"));
            CreateQuickActionButton("🚌 Seferlerimi Gör", x + 200, y, () => LoadContent("Seferlerim"));
        }

        private void LoadCompanyDashboard()
        {
            lblTitle.Text = "🏭 Kurumsal Panel";
            pnlContent.Controls.Clear();

            int userId = SessionManager.CurrentUser?.Id ?? 0;
            int x = 25, y = 25;

            CreateDashboardCard("Toplam Sipariş", GetCompanyOrderCount(userId), "📦", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Aktif Bilet", GetCompanyActiveTickets(userId), "🎫", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Bekleyen Onay", GetCompanyPendingOrders(userId), "⏳", Color.FromArgb(230, 126, 34), x + 440, y);
            CreateDashboardCard("Toplam Harcama", GetCompanyTotalSpent(userId), "💰", Color.FromArgb(155, 89, 182), x + 660, y);

            // Bilgi notu
            y += 180;
            var lblNote = new Label
            {
                Text = "ℹ️ Kurumsal hesaplar minimum 5 bilet alımı yapabilir ve özel indirimlerden faydalanır.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(x, y),
                AutoSize = true
            };
            pnlContent.Controls.Add(lblNote);

            y += 40;
            CreateQuickActionButton("🎫 Toplu Bilet Al", x, y, () => LoadContent("Toplu Bilet Al"));
            CreateQuickActionButton("🔍 Sefer Ara", x + 200, y, () => LoadContent("Sefer Ara"));
        }

        private void LoadIndividualDashboard()
        {
            lblTitle.Text = "🎫 Hoş Geldiniz";
            pnlContent.Controls.Clear();

            int userId = SessionManager.CurrentUser?.Id ?? 0;
            int x = 25, y = 25;

            CreateDashboardCard("Aktif Biletlerim", GetUserActiveTickets(userId), "🎫", Color.FromArgb(52, 152, 219), x, y);
            CreateDashboardCard("Tamamlanan Yolculuk", GetUserCompletedTrips(userId), "✅", Color.FromArgb(46, 204, 113), x + 220, y);
            CreateDashboardCard("Yaklaşan Sefer", GetUserUpcomingTrips(userId), "📅", Color.FromArgb(230, 126, 34), x + 440, y);

            // Hızlı işlem butonları
            y += 180;
            CreateQuickActionButton("🔍 Sefer Ara", x, y, () => LoadContent("Sefer Ara"));
            CreateQuickActionButton("🎫 Bilet Al", x + 200, y, () => LoadContent("Bilet Al"));
            CreateQuickActionButton("🎟️ Biletlerim", x + 400, y, () => LoadContent("Biletlerim"));
        }

        #endregion

        #region UI Helpers

        private void CreateDashboardCard(string title, string value, string icon, Color color, int x, int y)
        {
            var card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(200, 120),
                BackColor = Color.White
            };
            pnlContent.Controls.Add(card);

            var colorBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(5, 120),
                BackColor = color
            };
            card.Controls.Add(colorBar);

            var iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 28),
                Location = new Point(15, 20),
                AutoSize = true
            };
            card.Controls.Add(iconLabel);

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(70, 25),
                Size = new Size(120, 20)
            };
            card.Controls.Add(titleLabel);

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(70, 50),
                Size = new Size(120, 35)
            };
            card.Controls.Add(valueLabel);
        }

        private void CreateQuickActionButton(string text, int x, int y, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 11),
                Location = new Point(x, y),
                Size = new Size(180, 50),
                BackColor = ThemeColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => onClick();
            pnlContent.Controls.Add(btn);
        }

        private void LoadContent(string contentName)
        {
            lblTitle.Text = contentName;
            pnlContent.Controls.Clear();

            Control panel = null;

            switch (contentName)
            {
                // Super Admin Modülleri
                case "Ajans Yönetimi":
                    panel = new Panels.PnlAgencyManagement();
                    break;

                case "Kullanıcı Yönetimi":
                    panel = new Panels.PnlUserManagement();
                    break;

                // Ajans Yöneticisi Modülleri
                case "Çalışan Yönetimi":
                    panel = new Panels.PnlEmployeeManagement();
                    break;

                case "Araç Yönetimi":
                    panel = new Panels.PnlVehicleManagement();
                    break;

                case "Sefer Yönetimi":
                    panel = new Panels.PnlTripManagement();
                    break;

                case "Rota Yönetimi":
                    panel = new Panels.PnlRouteManagement();
                    break;

                case "Şoför Yönetimi":
                    panel = new Panels.PnlDriverManagement();
                    break;

                // Ortak Modüller
                case "Sefer Ara":
                    panel = new Panels.PnlTripSearch();
                    break;

                case "Bilet Al":
                case "Bilet Satışı":
                    panel = new Panels.PnlTicketSale();
                    break;

                case "Biletlerim":
                    panel = new Panels.PnlMyTickets();
                    break;

                case "Profilim":
                case "Şirket Profili":
                    panel = new Panels.PnlProfile();
                    break;

                case "Yakıt Takibi":
                    panel = new Panels.PnlFuelManagement();
                    break;

                case "Yakıt Girişi":
                    panel = new Panels.PnlFuelEntry();
                    break;

                case "Yakıt Geçmişi":
                    panel = new Panels.PnlFuelHistory();
                    break;

                case "Seferlerim":
                    panel = new Panels.PnlMyTrips();
                    break;

                case "Satışlarım":
                    panel = new Panels.PnlMySales();
                    break;

                case "Aracım":
                    panel = new Panels.PnlMyVehicle();
                    break;

                case "Tüm Seferler":
                    panel = new Panels.PnlAllTrips();
                    break;

                case "Tüm Biletler":
                    panel = new Panels.PnlAllTickets();
                    break;

                case "Bilet Satışları":
                    panel = new Panels.PnlSalesManagement();
                    break;

                default:
                    var placeholder = new Label
                    {
                        Text = $"'{contentName}' modülü geliştiriliyor...",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        Location = new Point(50, 50),
                        AutoSize = true
                    };
                    pnlContent.Controls.Add(placeholder);
                    return;
            }

            if (panel != null)
            {
                panel.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(panel);
            }
        }

        #endregion

        #region Data Helpers

        private string GetCount(string table, string where = null)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = $"SELECT COUNT(*) FROM {table}" + (where != null ? $" WHERE {where}" : "");
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetAgencyCount(string table, int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = $"SELECT COUNT(*) FROM {table} WHERE AgencyId = @AgencyId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetTodaySales()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(SUM(FinalPrice), 0) FROM Tickets 
                                   WHERE DATE(PurchaseDate) = DATE('now') AND Status = 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return "₺" + result.ToString("N0");
                    }
                }
            }
            catch { return "₺0"; }
        }

        private string GetAgencyTodaySales(int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(SUM(t.FinalPrice), 0) FROM Tickets t
                                   INNER JOIN Trips tr ON t.TripId = tr.Id
                                   INNER JOIN Vehicles v ON tr.VehicleId = v.Id
                                   WHERE v.AgencyId = @AgencyId AND DATE(t.PurchaseDate) = DATE('now') AND t.Status = 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return "₺" + result.ToString("N0");
                    }
                }
            }
            catch { return "₺0"; }
        }

        private string GetAgencyTripCount(int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COUNT(*) FROM Trips t
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   WHERE v.AgencyId = @AgencyId AND t.Status = 0";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetAgencyTicketCount(int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COUNT(*) FROM Tickets t
                                   INNER JOIN Trips tr ON t.TripId = tr.Id
                                   INNER JOIN Vehicles v ON tr.VehicleId = v.Id
                                   WHERE v.AgencyId = @AgencyId AND t.Status = 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetAgencyFuelTotal(int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(SUM(f.Liters), 0) FROM FuelRecords f
                                   INNER JOIN Vehicles v ON f.VehicleId = v.Id
                                   WHERE v.AgencyId = @AgencyId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return result.ToString("N0");
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetEmployeeTodaySales(int userId) => GetCount("Tickets", $"SoldBy = {userId} AND DATE(PurchaseDate) = DATE('now')");
        private string GetEmployeeMonthSales(int userId) => GetCount("Tickets", $"SoldBy = {userId} AND strftime('%Y-%m', PurchaseDate) = strftime('%Y-%m', 'now')");
        private string GetActiveTripCount() => GetCount("Trips", "Status = 0 AND DepartureTime > datetime('now')");
        private string GetEmployeeTodayRevenue(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(SUM(FinalPrice), 0) FROM Tickets 
                                   WHERE SoldBy = @UserId AND DATE(PurchaseDate) = DATE('now') AND Status = 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return "₺" + result.ToString("N0");
                    }
                }
            }
            catch { return "₺0"; }
        }

        private string GetDriverTodayTrips(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COUNT(*) FROM Trips t
                                   INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                                   WHERE d.UserId = @UserId AND DATE(t.DepartureTime) = DATE('now')";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetDriverMonthTrips(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COUNT(*) FROM Trips t
                                   INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                                   WHERE d.UserId = @UserId AND strftime('%Y-%m', t.DepartureTime) = strftime('%Y-%m', 'now')";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetDriverFuelTotal(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(SUM(f.Liters), 0) FROM FuelRecords f
                                   INNER JOIN Drivers d ON f.DriverId = d.Id
                                   WHERE d.UserId = @UserId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return result.ToString("N0") + " L";
                    }
                }
            }
            catch { return "0 L"; }
        }

        private string GetDriverTotalKm(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT COALESCE(MAX(f.Odometer), 0) FROM FuelRecords f
                                   INNER JOIN Drivers d ON f.DriverId = d.Id
                                   WHERE d.UserId = @UserId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var result = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        return result.ToString("N0");
                    }
                }
            }
            catch { return "0"; }
        }

        private string GetCompanyOrderCount(int userId) => GetCount("CompanyOrders", $"CompanyUserId = {userId}");
        private string GetCompanyActiveTickets(int userId) => GetCount("Tickets", $"UserId = {userId} AND Status = 1");
        private string GetCompanyPendingOrders(int userId) => GetCount("CompanyOrders", $"CompanyUserId = {userId} AND Status = 0");
        private string GetCompanyTotalSpent(int userId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COALESCE(SUM(TotalPrice), 0) FROM CompanyOrders WHERE CompanyUserId = @UserId AND Status = 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        var result = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0m);
                        return "₺" + result.ToString("N0");
                    }
                }
            }
            catch { return "₺0"; }
        }

        private string GetUserActiveTickets(int userId) => GetCount("Tickets", $"UserId = {userId} AND Status = 1");
        private string GetUserCompletedTrips(int userId) => GetCount("Tickets", $"UserId = {userId} AND Status = 3");
        private string GetUserUpcomingTrips(int userId) => GetCount("Tickets", $"UserId = {userId} AND Status = 1");

        private string GetAgencyName()
        {
            if (!SessionManager.CurrentAgencyId.HasValue) return "";

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Name FROM Agencies WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", SessionManager.CurrentAgencyId.Value);
                        return Convert.ToString(cmd.ExecuteScalar()) ?? "";
                    }
                }
            }
            catch { return ""; }
        }

        #endregion

        #region Helper Methods

        private string GetRoleTitle()
        {
            var role = SessionManager.CurrentUser?.UserType ?? UserType.Individual;

            switch (role)
            {
                case UserType.SuperAdmin: return "Super Admin";
                case UserType.AgencyManager: return "Ajans Yönetimi";
                case UserType.AgencyEmployee: return "Çalışan Paneli";
                case UserType.Driver: return "Şoför Paneli";
                case UserType.Company: return "Kurumsal Panel";
                case UserType.Individual: return "Bireysel Panel";
                default: return "Ana Panel";
            }
        }

        private string GetRoleDisplayName()
        {
            var role = SessionManager.CurrentUser?.UserType ?? UserType.Individual;

            switch (role)
            {
                case UserType.SuperAdmin: return "👑 Süper Admin";
                case UserType.AgencyManager: return "🏢 Ajans Yöneticisi";
                case UserType.AgencyEmployee: return "👤 Ajans Çalışanı";
                case UserType.Driver: return "🚌 Şoför";
                case UserType.Company: return "🏭 Kurumsal Hesap";
                case UserType.Individual: return "👤 Bireysel Kullanıcı";
                default: return "Kullanıcı";
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Çıkış yapmak istediğinize emin misiniz?",
                "Çıkış",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Hide();
                var loginForm = new FrmLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        #endregion
    }
}