using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;

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
    }
}