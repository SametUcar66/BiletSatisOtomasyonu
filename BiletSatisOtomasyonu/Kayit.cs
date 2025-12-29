using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
            RolleriYukle();
        }

        private void RolleriYukle()
        {
            Dictionary<string, int> roller = new Dictionary<string, int>();
            // Veritabanındaki UserType değerlerine göre:
            roller.Add("Bireysel Müşteri", 5);
            roller.Add("Kurumsal Müşteri", 4);
            roller.Add("Acente Yöneticisi", 1);

            cmbRol.DataSource = new BindingSource(roller, null);
            cmbRol.DisplayMember = "Key";
            cmbRol.ValueMember = "Value";
            cmbRol.SelectedIndex = 0;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz.");
                return;
            }

            int secilenRolId = (int)cmbRol.SelectedValue;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Email Kontrolü
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE Email=@email";
                    using (var cmdCheck = new SQLiteCommand(checkSql, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@email", txtEmail.Text);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Bu E-posta adresi zaten kayıtlı!");
                            return;
                        }
                    }

                    // === DÜZELTİLEN KISIM: NameSurname -> FullName ===
                    string sql = @"INSERT INTO Users (FullName, Email, Phone, PasswordHash, UserType) 
                                   VALUES (@ad, @email, @tel, @pass, @type)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@tel", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@pass", txtSifre.Text); // Şifreyi olduğu gibi kaydediyoruz
                        cmd.Parameters.AddWithValue("@type", secilenRolId);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt Başarılı! Giriş yapabilirsiniz.");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata: " + ex.Message);
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //string placeholder = "Ad Soyad...";
        //string placeholder2 = "E-Mail...";
        //string placeholder3 = "Telefon...";
        //string placeholder4 = "Şifre...";
        //private void txtAdSoyad_Enter(object sender, EventArgs e)
        //{
        //    if (txtAdSoyad.Text == placeholder)
        //    {
        //        txtAdSoyad.Text = "";
        //        txtAdSoyad.ForeColor = Color.White;
        //    }
        //}

        //private void txtAdSoyad_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
        //    {
        //        txtAdSoyad.Text = placeholder;
        //        txtAdSoyad.ForeColor = Color.White;
        //    }
        //}

        //private void txtEmail_Enter(object sender, EventArgs e)
        //{
        //    if (txtEmail.Text == placeholder2)
        //    {
        //        txtEmail.Text = "";
        //        txtEmail.ForeColor = Color.White;
        //    }
        //}

        //private void txtEmail_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtEmail.Text))
        //    {
        //        txtEmail.Text = placeholder2;
        //        txtEmail.ForeColor = Color.White;
        //    }
        //}

        //private void txtTelefon_Enter(object sender, EventArgs e)
        //{
        //    if (txtTelefon.Text == placeholder3)
        //    {
        //        txtTelefon.Text = "";
        //        txtTelefon.ForeColor = Color.White;
        //    }
        //}

        //private void txtTelefon_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtTelefon.Text))
        //    {
        //        txtTelefon.Text = placeholder3;
        //        txtTelefon.ForeColor = Color.White;
        //    }
        //}

        //private void txtSifre_Enter(object sender, EventArgs e)
        //{
        //    if (txtSifre.Text == placeholder4)
        //    {
        //        txtSifre.Text = "";
        //        txtSifre.ForeColor = Color.White;
        //    }
        //}

        //private void txtSifre_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtSifre.Text))
        //    {
        //        txtSifre.Text = placeholder4;
        //        txtSifre.ForeColor = Color.White;
        //    }
        //}

        private void Kayit_Load(object sender, EventArgs e)
        {
            //txtAdSoyad.Text = placeholder;
            //txtAdSoyad.ForeColor = Color.White;
            //txtEmail.Text = placeholder2;
            //txtEmail.ForeColor = Color.White;
            //txtTelefon.Text = placeholder3;
            //txtTelefon.ForeColor = Color.White;
            //txtSifre.Text = placeholder4;
            //txtSifre.ForeColor = Color.White;
        }

        private void Kayit_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
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

        private void sifreGoster_CheckedChanged(object sender, EventArgs e)
        {

            if (sifreGoster.Checked)
            {
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }
    }
}