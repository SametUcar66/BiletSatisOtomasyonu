using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms
{
    public class FrmAgencyEdit : Form
    {
        private int? agencyId;
        private TextBox txtName;
        private TextBox txtTaxNo;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private ComboBox cmbAgencyType;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;

        public FrmAgencyEdit(int? id = null)
        {
            agencyId = id;
            InitializeComponents();
            if (agencyId.HasValue)
                LoadAgency();
        }

        private void InitializeComponents()
        {
            this.Text = agencyId.HasValue ? "Ajans Düzenle" : "Yeni Ajans Ekle";
            this.Size = new Size(450, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            int y = 20;
            int spacing = 60;

            // Ajans Adı
            AddLabel("Ajans Adı *", 20, y);
            txtName = AddTextBox(20, y + 22, 390);
            y += spacing;

            // Ajans Tipi
            AddLabel("Ajans Tipi *", 20, y);
            cmbAgencyType = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbAgencyType.Items.Add("🚌 Otobüs Şirketi");
            cmbAgencyType.Items.Add("✈️ Havayolu Şirketi");
            cmbAgencyType.SelectedIndex = 0;
            this.Controls.Add(cmbAgencyType);

            // Aktif
            chkIsActive = new CheckBox
            {
                Text = "Aktif",
                Location = new Point(220, y + 24),
                Checked = true,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(chkIsActive);
            y += spacing;

            // Vergi No
            AddLabel("Vergi Numarası", 20, y);
            txtTaxNo = AddTextBox(20, y + 22, 180);
            txtTaxNo.MaxLength = 11;

            // Telefon
            AddLabel("Telefon", 220, y);
            txtPhone = AddTextBox(220, y + 22, 190);
            y += spacing;

            // E-posta
            AddLabel("E-posta", 20, y);
            txtEmail = AddTextBox(20, y + 22, 390);
            y += spacing;

            // Adres
            AddLabel("Adres", 20, y);
            txtAddress = AddTextBox(20, y + 22, 390);
            txtAddress.Height = 50;
            txtAddress.Multiline = true;
            y += 80;

            // Butonlar
            btnSave = new Button
            {
                Text = "💾 Kaydet",
                Location = new Point(200, y),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(310, y),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }

        private void AddLabel(string text, int x, int y)
        {
            var lbl = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            this.Controls.Add(lbl);
        }

        private TextBox AddTextBox(int x, int y, int width)
        {
            var txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 25),
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txt);
            return txt;
        }

        private void LoadAgency()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM Agencies WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", agencyId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtTaxNo.Text = reader["TaxNumber"]?.ToString();
                                txtPhone.Text = reader["Phone"]?.ToString();
                                txtEmail.Text = reader["Email"]?.ToString();
                                txtAddress.Text = reader["Address"]?.ToString();
                                cmbAgencyType.SelectedIndex = Convert.ToInt32(reader["AgencyType"]);
                                chkIsActive.Checked = Convert.ToInt32(reader["IsActive"]) == 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Ajans adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string sql;
                    if (agencyId.HasValue)
                    {
                        sql = @"UPDATE Agencies SET 
                                Name = @Name, TaxNumber = @TaxNumber, Phone = @Phone, 
                                Email = @Email, Address = @Address, AgencyType = @AgencyType, 
                                IsActive = @IsActive WHERE Id = @Id";
                    }
                    else
                    {
                        sql = @"INSERT INTO Agencies (Name, TaxNumber, Phone, Email, Address, AgencyType, IsActive, CreatedAt)
                                VALUES (@Name, @TaxNumber, @Phone, @Email, @Address, @AgencyType, @IsActive, @CreatedAt)";
                    }

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@TaxNumber", string.IsNullOrEmpty(txtTaxNo.Text) ? (object)DBNull.Value : txtTaxNo.Text);
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text);
                        cmd.Parameters.AddWithValue("@AgencyType", cmbAgencyType.SelectedIndex);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked ? 1 : 0);

                        if (agencyId.HasValue)
                            cmd.Parameters.AddWithValue("@Id", agencyId.Value);
                        else
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}