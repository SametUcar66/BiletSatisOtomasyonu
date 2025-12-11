using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace BiletSatisOtomasyonu
{
    public partial class SuperAdmin : Form
    {
        public SuperAdmin()
        {
            InitializeComponent();
            InitializeRadioButtons();
        }

        SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");
        SQLiteCommand cmd;
        DataTable dt;
        DataView dv;

        private void InitializeRadioButtons()
        {
            // RadioButton'lara rol isimlerini ata
            radioButton1.Text = "Super Admin";
            radioButton2.Text = "Acenta Yöneticisi";
            radioButton3.Text = "Şirket Hesabı";

            // Varsayılan olarak hiçbiri seçili olmasın
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            // RadioButton seçim değişikliğinde şirket adı alanını kontrol et
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Super Admin seçilirse şirket adı alanını devre dışı bırak
            if (radioButton1.Checked)
            {
                agency_name.Text = "";
                agency_name.Enabled = false;
            }
            else
            {
                agency_name.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(full_name.Text))
            {
                MessageBox.Show("Lütfen isim soyisim giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email.Text))
            {
                MessageBox.Show("Lütfen e-posta giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Lütfen şifre giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen rolü belirle
            string selectedRole = "";
            int roleId = 0;
            long agencyId = 0;

            if (radioButton1.Checked)
            {
                selectedRole = "Super Admin";
                roleId = 1; // SuperAdmin
                agencyId = 1; // Super Admin acentası
            }
            else if (radioButton2.Checked)
            {
                selectedRole = "Acenta Yöneticisi";
                roleId = 2; // AgencyAdmin

                if (string.IsNullOrWhiteSpace(agency_name.Text))
                {
                    MessageBox.Show("Lütfen acenta adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (radioButton3.Checked)
            {
                selectedRole = "Şirket Hesabı";
                roleId = 3; // Staff

                if (string.IsNullOrWhiteSpace(agency_name.Text))
                {
                    MessageBox.Show("Lütfen şirket adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir rol seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                baglan.Open();

                // Super Admin değilse yeni acenta/şirket ekle
                if (roleId != 1)
                {
                    string insertAgency = @"INSERT INTO agencies (agency_name, is_active, commission_rate) 
                                            VALUES (@agencyName, 1, 10.0)";
                    cmd = new SQLiteCommand(insertAgency, baglan);
                    cmd.Parameters.AddWithValue("@agencyName", agency_name.Text);
                    cmd.ExecuteNonQuery();

                    agencyId = baglan.LastInsertRowId;
                }

                // Kullanıcıyı ekle
                string insertUser = @"INSERT INTO users (role_id, agency_id, email, password, full_name, phone) 
                                      VALUES (@roleId, @agencyId, @email, @password, @fullName, @phone)";

                cmd = new SQLiteCommand(insertUser, baglan);
                cmd.Parameters.AddWithValue("@roleId", roleId);
                cmd.Parameters.AddWithValue("@agencyId", agencyId);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@fullName", full_name.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);

                cmd.ExecuteNonQuery();

                string message = roleId == 1
                    ? $"{selectedRole} başarıyla eklendi!\n\nYönetici: {full_name.Text}"
                    : $"{selectedRole} başarıyla eklendi!\n\nAcenta/Şirket: {agency_name.Text}\nYönetici: {full_name.Text}";

                MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        private void ClearForm()
        {
            full_name.Text = "";
            email.Text = "";
            password.Text = "";
            phone.Text = "";
            agency_name.Text = "";
            agency_name.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
    }
}