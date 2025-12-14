using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BiletSatisOtomasyonu.Helpers;
using BiletSatisOtomasyonu.Services;

namespace BiletSatisOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        private readonly int _currentUserId;
        private readonly int _currentAgencyId;

        public AnaSayfa(int userId = 0, int agencyId = 0)
        {
            InitializeComponent();
            _currentUserId = userId;
            _currentAgencyId = agencyId;
        }

        #region Pencere Kontrolleri

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void btnLogOut_Click(object sender, EventArgs e) => Close();

        #endregion

        #region Form Yükleme

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            LoadFlightTicketControl();
            LoadProfilePhoto();
        }

        #endregion

        #region Profil Fotoğrafı

        public void LoadProfilePhoto()
        {
            string logoBase64 = UserService.GetUserLogo(_currentUserId);

            if (!string.IsNullOrEmpty(logoBase64))
            {
                picProfilePhoto.Image = ImageHelper.ConvertBase64ToImage(logoBase64);
            }
            else
            {
                LoadDefaultImage();
            }
        }

        private void LoadDefaultImage()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "images", "default.png");
            var image = ImageHelper.LoadDefaultImage(defaultImagePath);

            if (image != null)
            {
                picProfilePhoto.Image = image;
            }
            else
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "images");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }
                picProfilePhoto.BackColor = Color.Gray;
            }
        }

        #endregion

        #region Bilet Kontrolleri

        private void btnFlightTicket_Click(object sender, EventArgs e)
        {
            LoadFlightTicketControl();
            btnBusTicket.BackColor = Color.DarkGray;
            btnFlightTicket.BackColor = Color.White;
        }

        private void btnBusTicket_Click(object sender, EventArgs e)
        {
            LoadBusTicketControl();
            btnBusTicket.BackColor = Color.White;
            btnFlightTicket.BackColor = Color.DarkGray;
        }

        private void LoadFlightTicketControl()
        {
            pnlTicketContent.Controls.Clear();
            var ucakBileti = new UcakBileti { Dock = DockStyle.Fill };
            pnlTicketContent.Controls.Add(ucakBileti);
        }

        private void LoadBusTicketControl()
        {
            pnlTicketContent.Controls.Clear();
            var otobusBileti = new OtobusBileti { Dock = DockStyle.Fill };
            pnlTicketContent.Controls.Add(otobusBileti);
        }

        #endregion

        #region Hesabım

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            var hesabimForm = new Hesabim(_currentUserId);
            hesabimForm.ProfileUpdated += (s, args) => LoadProfilePhoto();
            hesabimForm.ShowDialog();
        }

        #endregion

        #region Paint Eventleri

        private void picProfilePhoto_Paint(object sender, PaintEventArgs e)
        {
            if (picProfilePhoto.Image != null)
            {
                e.Graphics.DrawImage(picProfilePhoto.Image, 0, 0, picProfilePhoto.Width, picProfilePhoto.Height);
            }

            using (var pen = new Pen(Color.White, 2))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, picProfilePhoto.Width - 1, picProfilePhoto.Height - 1);
            }
        }

        private void pnlTicketContent_Paint(object sender, PaintEventArgs e) { }
        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }
}
