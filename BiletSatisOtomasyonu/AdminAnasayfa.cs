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
    public partial class AdminAnasayfa : Form
    {
        public AdminAnasayfa()
        {
            InitializeComponent();
        }

        private void AdminAnasayfa_Load(object sender, EventArgs e)
        {
            LoadSuperAdminEkleme();
            LoadSPManager();
        }

        private void LoadSuperAdminEkleme()
        {
            AdminEkleme.Controls.Clear();

            SuperAdminEkleme form = new SuperAdminEkleme();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            AdminEkleme.Controls.Add(form);
        }

        private void LoadSPManager()
        {
            SPManager.Controls.Clear();

            // SPManager formu (namespace ile belirtiyoruz)
            BiletSatisOtomasyonu.SPManager form = new BiletSatisOtomasyonu.SPManager();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            SPManager.Controls.Add(form);
        }
    }
}
