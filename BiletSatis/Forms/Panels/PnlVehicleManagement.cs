using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlVehicleManagement : Panel
    {
        private DataGridView dgvVehicles;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblCount;

        public PnlVehicleManagement()
        {
            InitializeComponents();
            LoadVehicles();
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
            btnRefresh.Click += (s, e) => LoadVehicles();
            pnlToolbar.Controls.Add(btnRefresh);

            btnAdd = CreateButton("➕ Araç Ekle", 125, Color.FromArgb(46, 204, 113));
            btnAdd.Click += BtnAdd_Click;
            pnlToolbar.Controls.Add(btnAdd);

            btnEdit = CreateButton("✏️ Düzenle", 245, Color.FromArgb(241, 196, 15));
            btnEdit.Click += BtnEdit_Click;
            pnlToolbar.Controls.Add(btnEdit);

            btnDelete = CreateButton("🗑️ Sil", 355, Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;
            pnlToolbar.Controls.Add(btnDelete);

            lblCount = new Label
            {
                Text = "0 araç",
                Location = new Point(470, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvVehicles = new DataGridView
            {
                Location = new Point(15, 65),
                Size = new Size(this.Width - 30, this.Height - 80),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10)
            };
            dgvVehicles.RowTemplate.Height = 40;
            this.Controls.Add(dgvVehicles);
        }

        private Button CreateButton(string text, int x, Color color)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, 10),
                Size = new Size(110, 30),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadVehicles()
        {
            if (!SessionManager.CurrentAgencyId.HasValue) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT v.Id, v.PlateNumber AS 'Plaka', 
                                   v.Brand || ' ' || v.Model AS 'Marka/Model',
                                   CASE v.VehicleType WHEN 0 THEN '🚌 Otobüs' ELSE '✈️ Uçak' END AS 'Tip',
                                   v.Capacity AS 'Kapasite',
                                   v.Year AS 'Yıl',
                                   v.TotalKm AS 'Toplam KM',
                                   CASE v.Status 
                                       WHEN 0 THEN '✅ Aktif' 
                                       WHEN 1 THEN '🔧 Bakımda' 
                                       ELSE '❌ Devre Dışı' 
                                   END AS 'Durum'
                                   FROM Vehicles v
                                   WHERE v.AgencyId = @AgencyId
                                   ORDER BY v.PlateNumber";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId.Value);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvVehicles.DataSource = dt;

                            if (dgvVehicles.Columns.Contains("Id"))
                                dgvVehicles.Columns["Id"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} araç";
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
            using (var form = new FrmVehicleEdit(SessionManager.CurrentAgencyId.Value))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadVehicles();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir araç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vehicleId = Convert.ToInt32(dgvVehicles.SelectedRows[0].Cells["Id"].Value);
            using (var form = new FrmVehicleEdit(SessionManager.CurrentAgencyId.Value, vehicleId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadVehicles();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir araç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vehicleId = Convert.ToInt32(dgvVehicles.SelectedRows[0].Cells["Id"].Value);
            string plate = dgvVehicles.SelectedRows[0].Cells["Plaka"].Value.ToString();

            var result = MessageBox.Show(
                $"'{plate}' plakalı aracı silmek istediğinize emin misiniz?",
                "Araç Silme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM Vehicles WHERE Id = @Id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", vehicleId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Araç silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVehicles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}