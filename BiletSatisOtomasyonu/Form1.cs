using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; // Enter tuşu ile giriş
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
            Kayit kayitFormu = new Kayit();
            kayitFormu.ShowDialog();
        }
    }
}