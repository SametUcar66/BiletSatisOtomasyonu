using System;
using System.Data.SQLite;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BiletSatisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.AcceptButton = btnLogin; // Enter tuşu ile giriş
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPsw.Text))
            {
                MessageBox.Show("Lütfen bilgileri giriniz.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Şifreyi şimdilik hashlemeden kontrol ediyoruz çünkü veritabanındaki veriler düz metin veya manuel hash olabilir.
                    string sql = "SELECT * FROM Users WHERE Email=@email AND PasswordHash=@pass";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPsw.Text); // Veritabanındaki şifre neyse onu yazmalısın (Örn: hash123)

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // === DÜZELTİLEN KISIM ===
                                // Veritabanında sütun adı: FullName
                                int userId = Convert.ToInt32(dr["Id"]);

                                // Yetki ID'sini al (Örn: 1=Admin, 2=Müşteri)
                                int roleId = 5;
                                if (!dr.IsDBNull(dr.GetOrdinal("UserType")))
                                    roleId = Convert.ToInt32(dr["UserType"]);

                                UserRole role = (UserRole)roleId;

                                // 2. AnaSayfa'ya bu bilgileri göndererek aç
                                this.Hide();
                                AnaSayfa anaSayfa = new AnaSayfa(role, userId); // ARTIK PARANTEZ İÇİ DOLU
                                anaSayfa.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Hatalı E-posta veya Şifre!\n(Veritabanındaki 'hash123' gibi değerleri kontrol edin)");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kayit kayitFormu = new Kayit();
            kayitFormu.Owner = this;
            kayitFormu.StartPosition = FormStartPosition.CenterScreen;
            kayitFormu.ShowDialog();
            
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
       // string placeholder = "E-Mail...";
        // string placeholder2 = "Şifre...";
        //private void txtEmail_Enter(object sender, EventArgs e)
        //{
        //    if (txtEmail.Text == placeholder)
        //    {
        //        txtEmail.Text = "";
        //        txtEmail.ForeColor = Color.White;
        //    }
        //}

        //private void txtEmail_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtEmail.Text))
        //    {
        //        txtEmail.Text = placeholder;
        //        txtEmail.ForeColor = Color.White;
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtEmail.Text = placeholder;
            //txtEmail.ForeColor = Color.White;
            //txtPsw.Text = placeholder2;
            //txtPsw.ForeColor = Color.White;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            
        }

        //private void txtPsw_Enter(object sender, EventArgs e)
        //{
        //    if (txtPsw.Text == placeholder2)
        //    {
        //        txtPsw.Text = "";
        //        txtPsw.ForeColor = Color.White;
        //    }
        //}

        //private void txtPsw_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtPsw.Text))
        //    {
        //        txtPsw.Text = placeholder2;
        //        txtPsw.ForeColor = Color.White;
        //    }
        //}
        [DllImport("user32.dll")]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.CenterToScreen();
            }
        }

        private void sifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (sifreGoster.Checked)
            {
                txtPsw.PasswordChar = '\0';
            }
            else
            {
                txtPsw.PasswordChar = '*';
            }
        }
    }
}