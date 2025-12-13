using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        private int currentUserId;
        private int currentAgencyId;

        public AnaSayfa(int userId = 0, int agencyId = 0)
        {
            InitializeComponent();
            currentUserId = userId;
            currentAgencyId = agencyId;
        }

        #region Pencere Kontrolleri

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            string logoBase64 = GetLogoFromDatabase();

            if (!string.IsNullOrEmpty(logoBase64))
            {
                picProfilePhoto.Image = ConvertBase64ToImage(logoBase64);
            }
            else
            {
                LoadDefaultImage();
            }
        }

        private string GetLogoFromDatabase()
        {
            SQLiteConnection baglan = null;
            SQLiteCommand cmd = null;

            try
            {
                baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
                baglan.Open();

                string query = @"SELECT a.logo_url 
                                 FROM agencies a 
                                 INNER JOIN users u ON u.agency_id = a.agency_id 
                                 WHERE u.user_id = @userId";

                cmd = new SQLiteCommand(query, baglan);
                cmd.Parameters.AddWithValue("@userId", currentUserId);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logo yüklenirken hata: " + ex.Message);
            }
            finally
            {
                cmd?.Dispose();
                baglan?.Close();
                baglan?.Dispose();
            }

            return null;
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Base64 dönüştürme hatası: " + ex.Message);
                LoadDefaultImage();
                return null;
            }
        }

        private void LoadDefaultImage()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "images", "default.png");

            if (File.Exists(defaultImagePath))
            {
                picProfilePhoto.Image = Image.FromFile(defaultImagePath);
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
            pnlTicketContent.Controls.Add(new UcakBileti());
        }

        private void LoadBusTicketControl()
        {
            pnlTicketContent.Controls.Clear();
            pnlTicketContent.Controls.Add(new OtobusBileti());
        }

        #endregion

        #region Hesabım

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            Hesabim hesabimForm = new Hesabim(currentUserId);
            
            // Profil güncellendiğinde tetiklenecek event
            hesabimForm.ProfileUpdated += (s, args) =>
            {
                LoadProfilePhoto();
            };
            
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

            using (Pen pen = new Pen(Color.White, 2))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, picProfilePhoto.Width - 1, picProfilePhoto.Height - 1);
            }
        }

        private void pnlTicketContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
        }

        #endregion
    }
}
