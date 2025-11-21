using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class GirisControl : UserControl
    {
        public GirisControl()
        {
            InitializeComponent();
        }

        private void GirisControl_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "E-posta adresi";
            txtEmail.ForeColor = Color.DarkGray;
            txtPassword.Text = "Parola";
            txtPassword.ForeColor = Color.DarkGray;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "E-posta adresi")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "E-posta adresi";
                txtEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Parola")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Parola";
                txtPassword.ForeColor = Color.DarkGray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.StartPosition = FormStartPosition.CenterScreen;
            anaSayfa.ShowDialog();
            
        }
    }
}
