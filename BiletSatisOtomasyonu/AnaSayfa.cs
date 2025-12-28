using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        private int _currentUserId;
        private UserRole _currentRole;
        private User _solMenuProfil;

        public AnaSayfa(UserRole role, int userId)
        {
            InitializeComponent();
            _currentRole = role;
            _currentUserId = userId;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
            pnlMenu.Visible = true;
            //pnlMenu.Dock = DockStyle.Left;
            //pnlMenu.Width = 320;

            pnlAnaIcerik.Visible = true;
            //pnlAnaIcerik.Dock = DockStyle.Fill;
            //pnlAnaIcerik.BringToFront();

            SolMenuyuDoldur();

            // ROLE GÖRE DOĞRU EKRANI YÜKLE
            EkraniYukle();
        }

        private void SolMenuyuDoldur()
        {
            pnlMenu.Controls.Clear();
            _solMenuProfil = new User();
            _solMenuProfil.CurrentUserId = _currentUserId;
            _solMenuProfil.CurrentUserRole = _currentRole;
            //_solMenuProfil.Dock = DockStyle.Fill;
            pnlMenu.Controls.Add(_solMenuProfil);
        }

        private void EkraniYukle()
        {
            pnlAnaIcerik.Controls.Clear();

            switch (_currentRole)
            {
                // 1. ADMİN
                case UserRole.Admin:
                    Admin adminEkrani = new Admin();
                    adminEkrani.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(adminEkrani);
                    break;

                // 2. ŞOFÖR (Artık UserControl olduğu için direkt ekliyoruz)
                case UserRole.Sofor:
                    Sofor soforEkrani = new Sofor(3);
                    soforEkrani.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(soforEkrani);
                    break;

                // 3. ACENTE YÖNETİCİSİ
                case UserRole.AjentaAdmin:
                    AjentaAdmin ajentaAdminEkrani = new AjentaAdmin();
                    ajentaAdminEkrani.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(ajentaAdminEkrani);
                    break;

                // 4. ACENTE ÇALIŞANI
                case UserRole.AjentaCalisan:
                    AjentaCalisan ajentaCalisanEkrani = new AjentaCalisan();
                    ajentaCalisanEkrani.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(ajentaCalisanEkrani);
                    break;

                // 5. MÜŞTERİLER
                case UserRole.KurumsalMusteri:
                case UserRole.Musteri:
                    musteri biletEkrani = new musteri();
                    biletEkrani.CurrentUserId = _currentUserId;
                    biletEkrani.CurrentUserRole = _currentRole;
                    biletEkrani.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(biletEkrani);
                    break;

                default:
                    MessageBox.Show("Rol tanımlanamadı! Müşteri ekranı açılıyor.");
                    musteri varsayilan = new musteri();
                    varsayilan.CurrentUserId = _currentUserId;
                    varsayilan.Dock = DockStyle.Fill;
                    pnlAnaIcerik.Controls.Add(varsayilan);
                    break;
            }
        }

        public void ListeyiYenile()
        {
            if (_solMenuProfil != null) _solMenuProfil.BiletleriGetir();
        }
        public void EkraniYenile()
        {
          
            MessageBox.Show("Ekran yenilendi."); // Temporary test line
        }

        [DllImport("user32.dll")]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnaSayfa_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}