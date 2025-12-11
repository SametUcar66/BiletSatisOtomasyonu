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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(email) || email == "E-posta adresi")
            {
                MessageBox.Show("Lütfen e-posta adresinizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password == "Parola")
            {
                MessageBox.Show("Lütfen parolanızı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3"))
                {
                    baglan.Open();
                    string query = @"SELECT u.*, r.role_name 
                                     FROM users u 
                                     LEFT JOIN roles r ON u.role_id = r.role_id 
                                     WHERE u.email = @email AND u.password = @password";
                    
                    using (SQLiteCommand cmd = new SQLiteCommand(query, baglan))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Login successful
                                string roleName = reader["role_name"] != DBNull.Value ? reader["role_name"].ToString() : "";

                                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Ana formu gizle
                                Form parentForm = this.FindForm();
                                if (parentForm != null)
                                {
                                    parentForm.Hide();
                                }

                                if (roleName == "SuperAdmin")
                                {
                                    SuperAdmin superAdminForm = new SuperAdmin();
                                    superAdminForm.StartPosition = FormStartPosition.CenterScreen;
                                    superAdminForm.FormClosed += (s, args) => parentForm?.Close();
                                    superAdminForm.Show();
                                }
                                else
                                {
                                    AnaSayfa anaSayfa = new AnaSayfa();
                                    anaSayfa.StartPosition = FormStartPosition.CenterScreen;
                                    anaSayfa.FormClosed += (s, args) => parentForm?.Close();
                                    anaSayfa.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("E-posta veya parola hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
