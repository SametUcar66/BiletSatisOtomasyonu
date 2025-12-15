using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;

namespace BiletSatis.Forms.Panels
{
    public class PnlAgencyManagement : Panel
    {
        private DataGridView dgvAgencies;
        private DataGridView dgvManagers;
        private Button btnAddAgency;
        private Button btnEditAgency;
        private Button btnDeleteAgency;
        private Button btnAddManager;
        private Button btnDeleteManager;
        private Button btnRefresh;
        private TextBox txtSearch;
        private ComboBox cmbAgencyType;
        private Label lblAgencyCount;
        private Label lblManagerCount;

        private int? selectedAgencyId = null;

        public PnlAgencyManagement()
        {
            InitializeComponents();
            LoadAgencies();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Padding = new Padding(20);

            // Üst araç çubuğu
            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            // Arama kutusu
            txtSearch = new TextBox
            {
                Location = new Point(10, 12),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10)
            };
            txtSearch.TextChanged += (s, e) => FilterAgencies();
            pnlToolbar.Controls.Add(txtSearch);

            var lblSearch = new Label
            {
                Text = "🔍",
                Location = new Point(215, 14),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblSearch);

            // Ajans tipi filtresi
            cmbAgencyType = new ComboBox
            {
                Location = new Point(260, 12),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbAgencyType.Items.Add("Tüm Ajanslar");
            cmbAgencyType.Items.Add("🚌 Otobüs");
            cmbAgencyType.Items.Add("✈️ Havayolu");
            cmbAgencyType.SelectedIndex = 0;
            cmbAgencyType.SelectedIndexChanged += (s, e) => FilterAgencies();
            pnlToolbar.Controls.Add(cmbAgencyType);

            // Butonlar
            btnRefresh = CreateToolButton("🔄 Yenile", 430);
            btnRefresh.Click += (s, e) => LoadAgencies();
            pnlToolbar.Controls.Add(btnRefresh);

            btnAddAgency = CreateToolButton("➕ Yeni Ajans", 530);
            btnAddAgency.BackColor = Color.FromArgb(46, 204, 113);
            btnAddAgency.Click += BtnAddAgency_Click;
            pnlToolbar.Controls.Add(btnAddAgency);

            btnEditAgency = CreateToolButton("✏️ Düzenle", 650);
            btnEditAgency.Click += BtnEditAgency_Click;
            pnlToolbar.Controls.Add(btnEditAgency);

            btnDeleteAgency = CreateToolButton("🗑️ Sil", 760);
            btnDeleteAgency.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteAgency.Click += BtnDeleteAgency_Click;
            pnlToolbar.Controls.Add(btnDeleteAgency);

            // Sol panel - Ajanslar
            var pnlLeft = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(480, 500),
                BackColor = Color.White
            };
            this.Controls.Add(pnlLeft);

            var lblAgencies = new Label
            {
                Text = "🏢 Ajanslar",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            pnlLeft.Controls.Add(lblAgencies);

            lblAgencyCount = new Label
            {
                Text = "(0 ajans)",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(100, 14),
                AutoSize = true
            };
            pnlLeft.Controls.Add(lblAgencyCount);

            dgvAgencies = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(460, 450),
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
            dgvAgencies.SelectionChanged += DgvAgencies_SelectionChanged;
            dgvAgencies.CellDoubleClick += (s, e) => BtnEditAgency_Click(s, e);
            pnlLeft.Controls.Add(dgvAgencies);

            // Sağ panel - Yöneticiler
            var pnlRight = new Panel
            {
                Location = new Point(520, 70),
                Size = new Size(420, 500),
                BackColor = Color.White
            };
            this.Controls.Add(pnlRight);

            var lblManagers = new Label
            {
                Text = "👥 Ajans Yöneticileri",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            pnlRight.Controls.Add(lblManagers);

            lblManagerCount = new Label
            {
                Text = "(0 yönetici)",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(170, 14),
                AutoSize = true
            };
            pnlRight.Controls.Add(lblManagerCount);

            btnAddManager = new Button
            {
                Text = "➕ Yönetici Ekle",
                Font = new Font("Segoe UI", 9),
                Location = new Point(280, 8),
                Size = new Size(120, 28),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddManager.FlatAppearance.BorderSize = 0;
            btnAddManager.Click += BtnAddManager_Click;
            pnlRight.Controls.Add(btnAddManager);

            dgvManagers = new DataGridView
            {
                Location = new Point(10, 45),
                Size = new Size(400, 400),
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
            pnlRight.Controls.Add(dgvManagers);

            btnDeleteManager = new Button
            {
                Text = "🗑️ Yöneticiyi Kaldır",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 455),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDeleteManager.FlatAppearance.BorderSize = 0;
            btnDeleteManager.Click += BtnDeleteManager_Click;
            pnlRight.Controls.Add(btnDeleteManager);

            // Resize event
            this.Resize += (s, e) => AdjustLayout();
        }

        private Button CreateToolButton(string text, int x)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 9),
                Location = new Point(x, 10),
                Size = new Size(110, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void AdjustLayout()
        {
            // Responsive tasarım için
        }

        private void LoadAgencies()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT a.Id, a.Name AS 'Ajans Adı', 
                                   CASE a.AgencyType WHEN 0 THEN '🚌 Otobüs' ELSE '✈️ Havayolu' END AS 'Tip',
                                   a.Phone AS 'Telefon', 
                                   CASE a.IsActive WHEN 1 THEN '✅ Aktif' ELSE '❌ Pasif' END AS 'Durum',
                                   (SELECT COUNT(*) FROM Vehicles WHERE AgencyId = a.Id) AS 'Araç',
                                   (SELECT COUNT(*) FROM AgencyEmployees WHERE AgencyId = a.Id) AS 'Çalışan',
                                   a.CreatedAt AS 'Kayıt Tarihi'
                                   FROM Agencies a ORDER BY a.Name";

                    using (var adapter = new SQLiteDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAgencies.DataSource = dt;

                        if (dgvAgencies.Columns.Contains("Id"))
                            dgvAgencies.Columns["Id"].Visible = false;

                        lblAgencyCount.Text = $"({dt.Rows.Count} ajans)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadManagersForAgency(int agencyId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT u.Id, u.FullName AS 'Ad Soyad', u.Email AS 'E-posta', 
                                   u.Phone AS 'Telefon',
                                   CASE ae.Role WHEN 0 THEN '👑 Yönetici' ELSE '👤 Çalışan' END AS 'Rol',
                                   ae.HireDate AS 'İşe Giriş'
                                   FROM Users u
                                   INNER JOIN AgencyEmployees ae ON u.Id = ae.UserId
                                   WHERE ae.AgencyId = @AgencyId
                                   ORDER BY ae.Role, u.FullName";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvManagers.DataSource = dt;

                            if (dgvManagers.Columns.Contains("Id"))
                                dgvManagers.Columns["Id"].Visible = false;

                            lblManagerCount.Text = $"({dt.Rows.Count} kişi)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterAgencies()
        {
            if (dgvAgencies.DataSource == null) return;

            var dt = dgvAgencies.DataSource as DataTable;
            if (dt == null) return;

            string filter = "";
            
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                filter = $"[Ajans Adı] LIKE '%{txtSearch.Text}%' OR [Telefon] LIKE '%{txtSearch.Text}%'";
            }

            if (cmbAgencyType.SelectedIndex > 0)
            {
                string typeFilter = cmbAgencyType.SelectedIndex == 1 ? "🚌 Otobüs" : "✈️ Havayolu";
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                filter += $"[Tip] = '{typeFilter}'";
            }

            dt.DefaultView.RowFilter = filter;
        }

        private void DgvAgencies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgencies.SelectedRows.Count > 0)
            {
                selectedAgencyId = Convert.ToInt32(dgvAgencies.SelectedRows[0].Cells["Id"].Value);
                LoadManagersForAgency(selectedAgencyId.Value);
            }
            else
            {
                selectedAgencyId = null;
                dgvManagers.DataSource = null;
                lblManagerCount.Text = "(0 kişi)";
            }
        }

        private void BtnAddAgency_Click(object sender, EventArgs e)
        {
            using (var form = new FrmAgencyEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAgencies();
                }
            }
        }

        private void BtnEditAgency_Click(object sender, EventArgs e)
        {
            if (!selectedAgencyId.HasValue)
            {
                MessageBox.Show("Lütfen düzenlemek için bir ajans seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FrmAgencyEdit(selectedAgencyId.Value))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAgencies();
                }
            }
        }

        private void BtnDeleteAgency_Click(object sender, EventArgs e)
        {
            if (!selectedAgencyId.HasValue)
            {
                MessageBox.Show("Lütfen silmek için bir ajans seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string agencyName = dgvAgencies.SelectedRows[0].Cells["Ajans Adı"].Value.ToString();

            var result = MessageBox.Show(
                $"'{agencyName}' ajansını ve tüm ilişkili verileri (çalışanlar, araçlar, seferler) silmek istediğinize emin misiniz?\n\nBu işlem geri alınamaz!",
                "⚠️ Ajans Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteAgency(selectedAgencyId.Value);
                    MessageBox.Show("Ajans başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAgencies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteAgency(int agencyId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Ajans çalışanlarının kullanıcı tipini güncelle
                        string updateUsersSql = @"UPDATE Users SET UserType = 5 
                                                  WHERE Id IN (SELECT UserId FROM AgencyEmployees WHERE AgencyId = @AgencyId)";
                        ExecuteNonQuery(updateUsersSql, conn, transaction, agencyId);

                        // 2. Ajans çalışanlarını sil
                        ExecuteNonQuery("DELETE FROM AgencyEmployees WHERE AgencyId = @AgencyId", conn, transaction, agencyId);

                        // 3. Şoförleri sil
                        ExecuteNonQuery("DELETE FROM Drivers WHERE AgencyId = @AgencyId", conn, transaction, agencyId);

                        // 4. Yakıt kayıtlarını sil (araçlara bağlı)
                        ExecuteNonQuery(@"DELETE FROM FuelRecords WHERE VehicleId IN 
                                         (SELECT Id FROM Vehicles WHERE AgencyId = @AgencyId)", conn, transaction, agencyId);

                        // 5. Araçları sil
                        ExecuteNonQuery("DELETE FROM Vehicles WHERE AgencyId = @AgencyId", conn, transaction, agencyId);

                        // 6. Rotaları sil
                        ExecuteNonQuery("DELETE FROM Routes WHERE AgencyId = @AgencyId", conn, transaction, agencyId);

                        // 7. Ajansı sil
                        ExecuteNonQuery("DELETE FROM Agencies WHERE Id = @AgencyId", conn, transaction, agencyId);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void ExecuteNonQuery(string sql, SQLiteConnection conn, SQLiteTransaction transaction, int agencyId)
        {
            using (var cmd = new SQLiteCommand(sql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@AgencyId", agencyId);
                cmd.ExecuteNonQuery();
            }
        }

        private void BtnAddManager_Click(object sender, EventArgs e)
        {
            if (!selectedAgencyId.HasValue)
            {
                MessageBox.Show("Lütfen önce bir ajans seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new FrmEmployeeAdd(selectedAgencyId.Value, true))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadManagersForAgency(selectedAgencyId.Value);
                }
            }
        }

        private void BtnDeleteManager_Click(object sender, EventArgs e)
        {
            if (dgvManagers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir yönetici seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvManagers.SelectedRows[0].Cells["Id"].Value);
            string userName = dgvManagers.SelectedRows[0].Cells["Ad Soyad"].Value.ToString();

            var result = MessageBox.Show(
                $"'{userName}' kullanıcısını bu ajanstan kaldırmak istediğinize emin misiniz?",
                "Yönetici Kaldırma",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    RemoveEmployeeFromAgency(userId);
                    MessageBox.Show("Yönetici ajanstan kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadManagersForAgency(selectedAgencyId.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveEmployeeFromAgency(int userId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Ajans çalışanı kaydını sil
                        string sql1 = "DELETE FROM AgencyEmployees WHERE UserId = @UserId";
                        using (var cmd = new SQLiteCommand(sql1, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Kullanıcı tipini bireysel yap
                        string sql2 = "UPDATE Users SET UserType = 5 WHERE Id = @UserId";
                        using (var cmd = new SQLiteCommand(sql2, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}