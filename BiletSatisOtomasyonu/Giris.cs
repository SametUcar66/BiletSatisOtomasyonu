using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ShowControl(new GirisControl());
        }
        private void ShowControl(UserControl girisControl)
        {
            flowLayoutPanel1.Controls.Clear();
         
            flowLayoutPanel1.Controls.Add(girisControl);
        }

        private void ShowControl2(UserControl kayitControl)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(kayitControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShowControl2(new KayitKontrol());
            btnSLogin.ForeColor = Color.FromArgb(64,64,64);
            txtLine1.BackColor = Color.FromArgb(64, 64, 64);
            btnRegister.ForeColor = Color.White;
            txtLine2.BackColor = Color.White;

        }   

        private void btnSLogin_Click(object sender, EventArgs e)
        {
            ShowControl(new GirisControl());
            btnSLogin.ForeColor = Color.White;
            txtLine1.BackColor = Color.White;
            btnRegister.ForeColor = Color.FromArgb(64, 64, 64);
            txtLine2.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void signup_Click(object sender, EventArgs e)
        {
            //kullaniciKayit kForm= new kullaniciKayit();
            //kForm.Show();
            //SPManager spm = new SPManager();
            //spm.Show();
            AnaSayfa anaSayfa =new AnaSayfa();
            anaSayfa.Show();
        }
    }
}
