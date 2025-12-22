using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BiletSatisOtomasyonu
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            RolComboboxlariniDoldur();
            KullanicilariListele();
        }

        // Rolleri ComboBox'lara (Hem filtre hem düzenleme için) yükler
        private void RolComboboxlariniDoldur()
        {
            // Filtreleme için
            Dictionary<string, int> rollerFiltre = new Dictionary<string, int>();
            rollerFiltre.Add("Tümü", -1);
            rollerFiltre.Add("Admin", 0);
            rollerFiltre.Add("Acente Yöneticisi", 1);
            rollerFiltre.Add("Acente Çalışanı", 2);
            rollerFiltre.Add("Şoför", 3);
            rollerFiltre.Add("Kurumsal Müşteri", 4);
            rollerFiltre.Add("Müşteri", 5);

            cmbRolFiltre.DataSource = new BindingSource(rollerFiltre, null);
            cmbRolFiltre.DisplayMember = "Key";
            cmbRolFiltre.ValueMember = "Value";
            cmbRolFiltre.SelectedIndex = 0;

            // Düzenleme için (Tümü seçeneği hariç)
            Dictionary<string, int> rollerEdit = new Dictionary<string, int>();
            rollerEdit.Add("Admin", 0);
            rollerEdit.Add("Acente Yöneticisi", 1);
            rollerEdit.Add("Acente Çalışanı", 2);
            rollerEdit.Add("Şoför", 3);
            rollerEdit.Add("Kurumsal Müşteri", 4);
            rollerEdit.Add("Müşteri", 5);

            cmbEditRol.DataSource = new BindingSource(rollerEdit, null);
            cmbEditRol.DisplayMember = "Key";
            cmbEditRol.ValueMember = "Value";
        }

        // Ana Listeleme Fonksiyonu (Arama ve Filtre Parametreleri Alır)
        private void KullanicilariListele(string aramaMetni = "", int rolId = -1)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Dinamik SQL oluşturuyoruz
                    string sql = @"SELECT 
                                    Id, 
                                    FullName AS 'Ad Soyad', 
                                    Email, 
                                    Phone AS 'Telefon', 
                                    UserType AS 'YetkiKodu' 
                                   FROM Users WHERE 1=1";

                    if (!string.IsNullOrEmpty(aramaMetni))
                    {
                        sql += " AND (FullName LIKE @ara OR Email LIKE @ara)";
                    }

                    if (rolId != -1)
                    {
                        sql += " AND UserType = @rol";
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(aramaMetni))
                            cmd.Parameters.AddWithValue("@ara", "%" + aramaMetni + "%");

                        if (rolId != -1)
                            cmd.Parameters.AddWithValue("@rol", rolId);

                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKullanicilar.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        // Buton Olayları
        private void btnAra_Click(object sender, EventArgs e)
        {
            KullanicilariListele(txtArama.Text.Trim(), (int)cmbRolFiltre.SelectedValue);
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            KullanicilariListele(txtArama.Text.Trim(), (int)cmbRolFiltre.SelectedValue);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtArama.Clear();
            cmbRolFiltre.SelectedIndex = 0; // Tümü
            KullanicilariListele();
        }

        // Tablodan bir satıra tıklandığında verileri aşağıya doldur
        private void dgvKullanicilar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKullanicilar.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dgvKullanicilar.SelectedRows[0];

                lblId.Text = satir.Cells["Id"].Value.ToString();
                txtEditAd.Text = satir.Cells["Ad Soyad"].Value.ToString();
                txtEditEmail.Text = satir.Cells["Email"].Value.ToString();
                txtEditTel.Text = satir.Cells["Telefon"].Value != DBNull.Value ? satir.Cells["Telefon"].Value.ToString() : "";

                // Rolü Combobox'ta seç
                int yetkiKodu = Convert.ToInt32(satir.Cells["YetkiKodu"].Value);
                cmbEditRol.SelectedValue = yetkiKodu;
            }
        }

        // GÜNCELLEME İŞLEMİ
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "0" || string.IsNullOrWhiteSpace(txtEditAd.Text))
            {
                MessageBox.Show("Lütfen listeden düzenlenecek bir kullanıcı seçin.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE Users 
                                   SET FullName=@ad, Email=@mail, Phone=@tel, UserType=@rol 
                                   WHERE Id=@id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", txtEditAd.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEditEmail.Text);
                        cmd.Parameters.AddWithValue("@tel", txtEditTel.Text);
                        cmd.Parameters.AddWithValue("@rol", cmbEditRol.SelectedValue);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblId.Text));

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kullanıcı bilgileri güncellendi.");
                KullanicilariListele(txtArama.Text, (int)cmbRolFiltre.SelectedValue); // Listeyi yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        // SİLME İŞLEMİ
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lblId.Text == "0") return;

            DialogResult cevap = MessageBox.Show($"{txtEditAd.Text} isimli kullanıcı silinecek. Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("DELETE FROM Users WHERE Id=@id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lblId.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Silindi.");
                    KullanicilariListele();
                    // Kutuları temizle
                    lblId.Text = "0"; txtEditAd.Clear(); txtEditEmail.Clear(); txtEditTel.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}