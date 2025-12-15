using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlDriverManagement : Panel
    {
        private DataGridView dgvDrivers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private ComboBox cmbStatus;
        private Label lblCount;

        public PnlDriverManagement()
        {
            InitializeComponents();
            LoadDrivers();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            // Araç çubuğu
            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            var lblTitle = new Label
            {
                Text = "👨‍✈️ Şoför Yönetimi",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            // Durum filtresi
            var lblFilter = new Label
            {
                Text = "Durum:",
                Location = new Point(200, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };
            pnlToolbar.Controls.Add(lblFilter);

            cmbStatus = new ComboBox
            {
                Location = new Point(250, 16),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Tümü", "✅ Müsait", "🚌 Seferde" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => LoadDrivers();
            pnlToolbar.Controls.Add(cmbStatus);

            btnAdd = CreateButton("➕ Yeni Şoför", 400, Color.FromArgb(46, 204, 113));
            btnAdd.Click += BtnAdd_Click;
            pnlToolbar.Controls.Add(btnAdd);

            btnEdit = CreateButton("✏️ Düzenle", 520, Color.FromArgb(52, 152, 219));
            btnEdit.Click += BtnEdit_Click;
            pnlToolbar.Controls.Add(btnEdit);

            btnDelete = CreateButton("🗑️ Sil", 640, Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;
            pnlToolbar.Controls.Add(btnDelete);

            btnRefresh = CreateButton("🔄", 760, Color.FromArgb(155, 89, 182));
            btnRefresh.Size = new Size(40, 35);
            btnRefresh.Click += (s, e) => LoadDrivers();
            pnlToolbar.Controls.Add(btnRefresh);

            lblCount = new Label
            {
                Text = "0 şoför",
                Location = new Point(820, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvDrivers = new DataGridView
            {
                Location = new Point(15, 75),
                Size = new Size(this.Width - 30, this.Height - 90),
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
            dgvDrivers.RowTemplate.Height = 40;
            dgvDrivers.CellDoubleClick += (s, e) => BtnEdit_Click(s, e);
            this.Controls.Add(dgvDrivers);
        }

        private Button CreateButton(string text, int x, Color color)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, 12),
                Size = new Size(110, 35),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadDrivers()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT d.Id, d.UserId,
                                   u.FullName AS 'Ad Soyad',
                                   u.Phone AS 'Telefon',
                                   d.LicenseNumber AS 'Ehliyet No',
                                   d.LicenseType AS 'Ehliyet Tipi',
                                   DATE(d.LicenseExpiry) AS 'Ehliyet Bitiş',
                                   d.SrcNumber AS 'SRC No',
                                   DATE(d.SrcExpiry) AS 'SRC Bitiş',
                                   CASE d.IsAvailable WHEN 1 THEN '✅ Müsait' ELSE '🚌 Seferde' END AS 'Durum'
                                   FROM Drivers d
                                   INNER JOIN Users u ON d.UserId = u.Id
                                   WHERE d.AgencyId = @AgencyId AND u.IsActive = 1";

                    // Durum filtresi
                    if (cmbStatus.SelectedIndex == 1)
                        sql += " AND d.IsAvailable = 1";
                    else if (cmbStatus.SelectedIndex == 2)
                        sql += " AND d.IsAvailable = 0";

                    sql += " ORDER BY u.FullName";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId ?? 0);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDrivers.DataSource = dt;

                            if (dgvDrivers.Columns.Contains("Id"))
                                dgvDrivers.Columns["Id"].Visible = false;
                            if (dgvDrivers.Columns.Contains("UserId"))
                                dgvDrivers.Columns["UserId"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} şoför";

                            // Ehliyet/SRC bitiş tarihlerine göre renklendirme
                            foreach (DataGridViewRow row in dgvDrivers.Rows)
                            {
                                CheckExpiryDate(row, "Ehliyet Bitiş");
                                CheckExpiryDate(row, "SRC Bitiş");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckExpiryDate(DataGridViewRow row, string columnName)
        {
            if (row.Cells[columnName].Value != null && row.Cells[columnName].Value != DBNull.Value)
            {
                if (DateTime.TryParse(row.Cells[columnName].Value.ToString(), out DateTime expiryDate))
                {
                    if (expiryDate < DateTime.Now)
                        row.Cells[columnName].Style.ForeColor = Color.Red;
                    else if (expiryDate < DateTime.Now.AddMonths(1))
                        row.Cells[columnName].Style.ForeColor = Color.Orange;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FrmDriverEdit(SessionManager.CurrentAgencyId ?? 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadDrivers();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlenecek şoförü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int driverId = Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["Id"].Value);
            using (var form = new FrmDriverEdit(SessionManager.CurrentAgencyId ?? 0, driverId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadDrivers();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek şoförü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string driverName = dgvDrivers.SelectedRows[0].Cells["Ad Soyad"].Value.ToString();
            var result = MessageBox.Show(
                $"'{driverName}' şoförünü silmek istediğinize emin misiniz?",
                "Şoför Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int userId = Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["UserId"].Value);
                    int driverId = Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["Id"].Value);

                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Şoför kaydını sil
                                string sqlDriver = "DELETE FROM Drivers WHERE Id = @Id";
                                using (var cmd = new SQLiteCommand(sqlDriver, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id", driverId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Kullanıcıyı pasif yap
                                string sqlUser = "UPDATE Users SET IsActive = 0 WHERE Id = @Id";
                                using (var cmd = new SQLiteCommand(sqlUser, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id", userId);
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
                    MessageBox.Show("Şoför başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDrivers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}