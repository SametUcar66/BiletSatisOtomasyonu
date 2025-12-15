using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlEmployeeManagement : Panel
    {
        private DataGridView dgvEmployees;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblCount;

        public PnlEmployeeManagement()
        {
            InitializeComponents();
            LoadEmployees();
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

            btnRefresh = CreateButton("🔄 Yenile", 15, Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadEmployees();
            pnlToolbar.Controls.Add(btnRefresh);

            btnAdd = CreateButton("➕ Çalışan Ekle", 125, Color.FromArgb(46, 204, 113));
            btnAdd.Size = new Size(130, 30);
            btnAdd.Click += BtnAdd_Click;
            pnlToolbar.Controls.Add(btnAdd);

            btnEdit = CreateButton("✏️ Düzenle", 265, Color.FromArgb(241, 196, 15));
            btnEdit.Click += BtnEdit_Click;
            pnlToolbar.Controls.Add(btnEdit);

            btnDelete = CreateButton("🗑️ Çıkar", 375, Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;
            pnlToolbar.Controls.Add(btnDelete);

            lblCount = new Label
            {
                Text = "0 çalışan",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(500, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvEmployees = new DataGridView
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
                Font = new Font("Segoe UI", 10)
            };
            dgvEmployees.RowTemplate.Height = 40;
            this.Controls.Add(dgvEmployees);
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

        private void LoadEmployees()
        {
            if (!SessionManager.CurrentAgencyId.HasValue) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT u.Id, u.FullName AS 'Ad Soyad', u.Email AS 'E-posta',
                                   u.Phone AS 'Telefon',
                                   CASE ae.Role WHEN 0 THEN '👑 Yönetici' ELSE '👤 Çalışan' END AS 'Rol',
                                   ae.HireDate AS 'İşe Giriş',
                                   CASE u.IsActive WHEN 1 THEN '✅ Aktif' ELSE '❌ Pasif' END AS 'Durum'
                                   FROM Users u
                                   INNER JOIN AgencyEmployees ae ON u.Id = ae.UserId
                                   WHERE ae.AgencyId = @AgencyId
                                   ORDER BY ae.Role, u.FullName";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId.Value);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvEmployees.DataSource = dt;

                            if (dgvEmployees.Columns.Contains("Id"))
                                dgvEmployees.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} çalışan";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!SessionManager.CurrentAgencyId.HasValue) return;

            using (var form = new FrmEmployeeAdd(SessionManager.CurrentAgencyId.Value, false))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Düzenleme özelliği yakında eklenecek.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir çalışan seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["Id"].Value);
            string userName = dgvEmployees.SelectedRows[0].Cells["Ad Soyad"].Value.ToString();

            // Kendini silemesin
            if (userId == SessionManager.CurrentUser.Id)
            {
                MessageBox.Show("Kendinizi çıkaramazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{userName}' çalışanını ajanstan çıkarmak istediğinize emin misiniz?",
                "Çalışan Çıkarma",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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
                                string sql1 = "DELETE FROM AgencyEmployees WHERE UserId = @UserId AND AgencyId = @AgencyId";
                                using (var cmd = new SQLiteCommand(sql1, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@UserId", userId);
                                    cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId.Value);
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
                    MessageBox.Show("Çalışan ajanstan çıkarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}