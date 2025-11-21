using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BiletSatisOtomasyonu
{
    public partial class KayitKontrol : UserControl
    {
        public KayitKontrol()
        {
            InitializeComponent();
        }
        private void KayitKontrol_Load(object sender, EventArgs e)
        {
            txtEmail2.Text = "E-posta adresi";
            txtEmail2.ForeColor = Color.DarkGray;

            txtUsername2.Text = "Kullanıcı Adı";
            txtUsername2.ForeColor = Color.DarkGray;

            txtPassword2.Text = "Parola";
            txtPassword2.ForeColor = Color.DarkGray;
        }

        private void txtEmail2_Enter(object sender, EventArgs e)
        {
            if (txtEmail2.Text == "E-posta adresi")
            {
                txtEmail2.Text = "";
                txtEmail2.ForeColor = Color.White;
            }
        }
        private void txtEmail2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail2.Text))
            {
                txtEmail2.Text = "E-posta adresi";
                txtEmail2.ForeColor = Color.DarkGray;
            }
        }

        private void txtUsername2_Enter(object sender, EventArgs e)
        {
            if (txtUsername2.Text == "Kullanıcı Adı")
            {
                txtUsername2.Text = "";
                txtUsername2.ForeColor = Color.White;
            }
        }

        private void txtUsername2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername2.Text))
            {
                txtUsername2.Text = "Kullanıcı Adı";
                txtUsername2.ForeColor = Color.DarkGray;
            }
        }

        private void txtPassword2_Enter(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "Parola")
            {
                txtPassword2.Text = "";
                txtPassword2.ForeColor = Color.White;
            }
        }

        private void txtPassword2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword2.Text))
            {
                txtPassword2.Text = "Parola";
                txtPassword2.ForeColor = Color.DarkGray;
            }
        }


    }
}
