using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlRouteManagement : Panel
    {
        private DataGridView dgvRoutes;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblCount;

        public PnlRouteManagement()
        {
            InitializeComponents();
            LoadRoutes();
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
                Text = "🛣️ Rota Yönetimi",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            btnAdd = CreateButton("➕ Yeni Rota", 250, Color.FromArgb(46, 204, 113));
            btnAdd.Click += BtnAdd_Click;
            pnlToolbar.Controls.Add(btnAdd);

            btnEdit = CreateButton("✏️ Düzenle", 370, Color.FromArgb(52, 152, 219));
            btnEdit.Click += BtnEdit_Click;
            pnlToolbar.Controls.Add(btnEdit);

            btnDelete = CreateButton("🗑️ Sil", 490, Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;
            pnlToolbar.Controls.Add(btnDelete);

            btnRefresh = CreateButton("🔄 Yenile", 610, Color.FromArgb(155, 89, 182));
            btnRefresh.Click += (s, e) => LoadRoutes();
            pnlToolbar.Controls.Add(btnRefresh);

            lblCount = new Label
            {
                Text = "0 rota",
                Location = new Point(730, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvRoutes = new DataGridView
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
            dgvRoutes.RowTemplate.Height = 35;
            dgvRoutes.CellDoubleClick += (s, e) => BtnEdit_Click(s, e);
            this.Controls.Add(dgvRoutes);
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

        private void LoadRoutes()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT r.Id, r.Name AS 'Rota Adı',
                                   s1.Name AS 'Kalkış',
                                   s2.Name AS 'Varış',
                                   r.Distance || ' km' AS 'Mesafe',
                                   (r.Duration / 60) || ' sa ' || (r.Duration % 60) || ' dk' AS 'Süre',
                                   '₺' || printf('%.2f', r.BasePrice) AS 'Taban Fiyat',
                                   CASE r.IsActive WHEN 1 THEN '✅ Aktif' ELSE '❌ Pasif' END AS 'Durum'
                                   FROM Routes r
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   WHERE r.AgencyId = @AgencyId
                                   ORDER BY r.Name";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId ?? 0);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvRoutes.DataSource = dt;

                            if (dgvRoutes.Columns.Contains("Id"))
                                dgvRoutes.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} rota";
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
            using (var form = new FrmRouteEdit(SessionManager.CurrentAgencyId ?? 0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadRoutes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlenecek rotayı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int routeId = Convert.ToInt32(dgvRoutes.SelectedRows[0].Cells["Id"].Value);
            using (var form = new FrmRouteEdit(SessionManager.CurrentAgencyId ?? 0, routeId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadRoutes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek rotayı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string routeName = dgvRoutes.SelectedRows[0].Cells["Rota Adı"].Value.ToString();
            var result = MessageBox.Show(
                $"'{routeName}' rotasını silmek istediğinize emin misiniz?\n\nBu rotaya ait seferler de etkilenecektir!",
                "Rota Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int routeId = Convert.ToInt32(dgvRoutes.SelectedRows[0].Cells["Id"].Value);
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string sql = "UPDATE Routes SET IsActive = 0 WHERE Id = @Id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", routeId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Rota başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoutes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}