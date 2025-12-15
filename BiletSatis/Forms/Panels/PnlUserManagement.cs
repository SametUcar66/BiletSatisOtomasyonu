using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms.Panels
{
    public class PnlUserManagement : Panel
    {
        private DataGridView dgvUsers;
        private TextBox txtSearch;
        private ComboBox cmbUserType;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnToggleActive;
        private Label lblCount;

        public PnlUserManagement()
        {
            InitializeComponents();
            LoadUsers();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Araç çubuğu
            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            // Arama
            txtSearch = new TextBox
            {
                Location = new Point(15, 12),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtSearch.TextChanged += (s, e) => FilterUsers();
            pnlToolbar.Controls.Add(txtSearch);

            AddLabel(pnlToolbar, "🔍", 220, 14);

            // Kullanıcı tipi filtresi
            cmbUserType = new ComboBox
            {
                Location = new Point(260, 12),
                Size = new Size(180, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbUserType.Items.AddRange(new object[] {
                "Tüm Kullanıcılar",
                "👑 Super Admin",
                "🏢 Ajans Yöneticisi",
                "👤 Ajans Çalışanı",
                "🚌 Şoför",
                "🏭 Kurumsal",
                "👤 Bireysel"
            });
            cmbUserType.SelectedIndex = 0;
            cmbUserType.SelectedIndexChanged += (s, e) => FilterUsers();
            pnlToolbar.Controls.Add(cmbUserType);

            // Butonlar
            btnRefresh = CreateButton("🔄 Yenile", 460, Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadUsers();
            pnlToolbar.Controls.Add(btnRefresh);

            btnToggleActive = CreateButton("⏸️ Aktif/Pasif", 570, Color.FromArgb(241, 196, 15));
            btnToggleActive.Click += BtnToggleActive_Click;
            pnlToolbar.Controls.Add(btnToggleActive);

            btnDelete = CreateButton("🗑️ Sil", 690, Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;
            pnlToolbar.Controls.Add(btnDelete);

            // Kullanıcı sayısı
            lblCount = new Label
            {
                Text = "0 kullanıcı",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(800, 16),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvUsers = new DataGridView
            {
                Location = new Point(15, 65),
                Size = new Size(this.Width - 30, this.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 9)
            };
            dgvUsers.RowTemplate.Height = 35;
            this.Controls.Add(dgvUsers);
        }

        private void AddLabel(Panel parent, string text, int x, int y)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true
            });
        }

        private Button CreateButton(string text, int x, Color color)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, 10),
                Size = new Size(100, 30),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadUsers()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT u.Id, u.FullName AS 'Ad Soyad', u.Email AS 'E-posta',
                                   u.Phone AS 'Telefon',
                                   CASE u.UserType 
                                       WHEN 0 THEN '👑 Super Admin'
                                       WHEN 1 THEN '🏢 Ajans Yöneticisi'
                                       WHEN 2 THEN '👤 Ajans Çalışanı'
                                       WHEN 3 THEN '🚌 Şoför'
                                       WHEN 4 THEN '🏭 Kurumsal'
                                       ELSE '👤 Bireysel'
                                   END AS 'Rol',
                                   CASE u.IsActive WHEN 1 THEN '✅ Aktif' ELSE '❌ Pasif' END AS 'Durum',
                                   u.CreatedAt AS 'Kayıt Tarihi',
                                   u.LastLoginAt AS 'Son Giriş',
                                   u.UserType AS 'TypeId'
                                   FROM Users u
                                   ORDER BY u.UserType, u.FullName";

                    using (var adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUsers.DataSource = dt;

                        if (dgvUsers.Columns.Contains("Id"))
                            dgvUsers.Columns["Id"].Visible = false;
                        if (dgvUsers.Columns.Contains("TypeId"))
                            dgvUsers.Columns["TypeId"].Visible = false;

                        lblCount.Text = $"{dt.Rows.Count} kullanıcı";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterUsers()
        {
            if (dgvUsers.DataSource == null) return;
            var dt = dgvUsers.DataSource as DataTable;
            if (dt == null) return;

            string filter = "";

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string search = txtSearch.Text.Replace("'", "''");
                filter = $"([Ad Soyad] LIKE '%{search}%' OR [E-posta] LIKE '%{search}%' OR [Telefon] LIKE '%{search}%')";
            }

            if (cmbUserType.SelectedIndex > 0)
            {
                int typeId = cmbUserType.SelectedIndex - 1;
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"TypeId = {typeId}";
            }

            dt.DefaultView.RowFilter = filter;
            lblCount.Text = $"{dt.DefaultView.Count} kullanıcı";
        }

        private void BtnToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            string currentStatus = dgvUsers.SelectedRows[0].Cells["Durum"].Value.ToString();
            bool isActive = currentStatus.Contains("Aktif");

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Users SET IsActive = @IsActive WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IsActive", isActive ? 0 : 1);
                        cmd.Parameters.AddWithValue("@Id", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            string userName = dgvUsers.SelectedRows[0].Cells["Ad Soyad"].Value.ToString();
            int userType = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["TypeId"].Value);

            if (userType == 0)
            {
                MessageBox.Show("Super Admin silinemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{userName}' kullanıcısını silmek istediğinize emin misiniz?",
                "Kullanıcı Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Ajans çalışanı kaydını sil
                                ExecuteNonQuery("DELETE FROM AgencyEmployees WHERE UserId = @Id", conn, transaction, userId);
                                // Şoför kaydını sil
                                ExecuteNonQuery("DELETE FROM Drivers WHERE UserId = @Id", conn, transaction, userId);
                                // Kullanıcıyı sil
                                ExecuteNonQuery("DELETE FROM Users WHERE Id = @Id", conn, transaction, userId);

                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                    MessageBox.Show("Kullanıcı silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExecuteNonQuery(string sql, SQLiteConnection conn, SQLiteTransaction transaction, int id)
        {
            using (var cmd = new SQLiteCommand(sql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}