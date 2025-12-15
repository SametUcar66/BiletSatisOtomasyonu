using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlTripManagement : Panel
    {
        private DataGridView dgvTrips;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnCancel;
        private Button btnRefresh;
        private DateTimePicker dtpFilter;
        private Label lblCount;

        public PnlTripManagement()
        {
            InitializeComponents();
            LoadTrips();
        }

        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);

            var pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.White
            };
            this.Controls.Add(pnlToolbar);

            var lblDate = new Label
            {
                Text = "Tarih:",
                Location = new Point(15, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlToolbar.Controls.Add(lblDate);

            dtpFilter = new DateTimePicker
            {
                Location = new Point(60, 12),
                Size = new Size(120, 25),
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short
            };
            dtpFilter.ValueChanged += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(dtpFilter);

            btnRefresh = CreateButton("🔄 Yenile", 200, Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadTrips();
            pnlToolbar.Controls.Add(btnRefresh);

            btnAdd = CreateButton("➕ Sefer Ekle", 310, Color.FromArgb(46, 204, 113));
            btnAdd.Size = new Size(120, 30);
            btnAdd.Click += BtnAdd_Click;
            pnlToolbar.Controls.Add(btnAdd);

            btnEdit = CreateButton("✏️ Düzenle", 440, Color.FromArgb(241, 196, 15));
            btnEdit.Click += BtnEdit_Click;
            pnlToolbar.Controls.Add(btnEdit);

            btnCancel = CreateButton("❌ İptal Et", 550, Color.FromArgb(231, 76, 60));
            btnCancel.Click += BtnCancel_Click;
            pnlToolbar.Controls.Add(btnCancel);

            lblCount = new Label
            {
                Text = "0 sefer",
                Location = new Point(670, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            dgvTrips = new DataGridView
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
                Font = new Font("Segoe UI", 9)
            };
            dgvTrips.RowTemplate.Height = 40;
            this.Controls.Add(dgvTrips);
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

        private void LoadTrips()
        {
            if (!SessionManager.CurrentAgencyId.HasValue) return;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT t.Id, 
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   v.PlateNumber AS 'Araç',
                                   TIME(t.DepartureTime) AS 'Kalkış',
                                   TIME(t.ArrivalTime) AS 'Varış',
                                   t.Price AS 'Fiyat',
                                   t.AvailableSeats AS 'Boş Koltuk',
                                   CASE t.Status 
                                       WHEN 0 THEN '📅 Planlandı'
                                       WHEN 1 THEN '🚌 Yolda'
                                       WHEN 2 THEN '🚀 Kalktı'
                                       WHEN 3 THEN '✅ Tamamlandı'
                                       WHEN 4 THEN '❌ İptal'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum',
                                   t.Status AS StatusId
                                   FROM Trips t
                                   INNER JOIN Routes r ON t.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   INNER JOIN Vehicles v ON t.VehicleId = v.Id
                                   WHERE v.AgencyId = @AgencyId
                                   AND DATE(t.DepartureTime) = @Date
                                   ORDER BY t.DepartureTime";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AgencyId", SessionManager.CurrentAgencyId.Value);
                        cmd.Parameters.AddWithValue("@Date", dtpFilter.Value.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTrips.DataSource = dt;

                            if (dgvTrips.Columns.Contains("Id"))
                                dgvTrips.Columns["Id"].Visible = false;
                            if (dgvTrips.Columns.Contains("StatusId"))
                                dgvTrips.Columns["StatusId"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} sefer";
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
            using (var form = new FrmTripEdit(SessionManager.CurrentAgencyId.Value))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadTrips();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sefer seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["Id"].Value);
            using (var form = new FrmTripEdit(SessionManager.CurrentAgencyId.Value, tripId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadTrips();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sefer seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["Id"].Value);
            int status = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["StatusId"].Value);

            if (status == 4)
            {
                MessageBox.Show("Bu sefer zaten iptal edilmiş!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status == 3)
            {
                MessageBox.Show("Tamamlanmış sefer iptal edilemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bu seferi iptal etmek istediğinize emin misiniz?\n\nTüm biletler iptal edilecek ve yolculara bildirim gönderilecek.",
                "Sefer İptali",
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
                                // Seferi iptal et
                                string sql1 = "UPDATE Trips SET Status = 4 WHERE Id = @Id";
                                using (var cmd = new SQLiteCommand(sql1, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id", tripId);
                                    cmd.ExecuteNonQuery();
                                }

                                // İlgili biletleri iptal et
                                string sql2 = "UPDATE Tickets SET Status = 2, CancelReason = 'Sefer iptal edildi' WHERE TripId = @TripId AND Status IN (0, 1)";
                                using (var cmd = new SQLiteCommand(sql2, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@TripId", tripId);
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
                    MessageBox.Show("Sefer iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTrips();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}