using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            ShowLoginControl();
        }

        #region Kontrol Yükleme

        private void ShowLoginControl()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new GirisControl());
        }

        private void ShowRegisterControl()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new KayitKontrol());
        }

        #endregion

        #region Pencere Kontrolleri

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
                WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Tab Butonları

        private void btnSLogin_Click(object sender, EventArgs e)
        {
            ShowLoginControl();
            SetActiveTab(btnSLogin, txtLine1);
            SetInactiveTab(btnRegister, txtLine2);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShowRegisterControl();
            SetActiveTab(btnRegister, txtLine2);
            SetInactiveTab(btnSLogin, txtLine1);
        }

        #endregion

        #region Yardımcı Metodlar

        private void SetActiveTab(Button button, TextBox line)
        {
            button.ForeColor = Color.White;
            line.BackColor = Color.White;
        }

        private void SetInactiveTab(Button button, TextBox line)
        {
            button.ForeColor = Color.FromArgb(64, 64, 64);
            line.BackColor = Color.FromArgb(64, 64, 64);
        }

        #endregion

        #region Test Butonu

        private void signup_Click(object sender, EventArgs e)
        {
            // Test butonu - Ana sayfayı aç
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
        }

        #endregion
    }
}
