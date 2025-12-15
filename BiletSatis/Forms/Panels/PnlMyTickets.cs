using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlMyTickets : Panel
    {
        private DataGridView dgvTickets;
        private ComboBox cmbStatus;
        private Button btnRefresh;
        private Button btnCancel;
        private Button btnDetails;
        private Label lblCount;

        public PnlMyTickets()
        {
            InitializeComponents();
            LoadTickets();
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

            // Durum filtresi
            var lblFilter = new Label
            {
                Text = "Durum:",
                Location = new Point(15, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlToolbar.Controls.Add(lblFilter);

            cmbStatus = new ComboBox
            {
                Location = new Point(70, 12),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "Tümü", "✅ Aktif", "❌ İptal", "✔️ Kullanıldı" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += (s, e) => FilterTickets();
            pnlToolbar.Controls.Add(cmbStatus);

            btnRefresh = CreateButton("🔄 Yenile", 240, Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadTickets();
            pnlToolbar.Controls.Add(btnRefresh);

            btnDetails = CreateButton("📋 Detay", 350, Color.FromArgb(155, 89, 182));
            btnDetails.Click += BtnDetails_Click;
            pnlToolbar.Controls.Add(btnDetails);

            btnCancel = CreateButton("❌ İptal Et", 460, Color.FromArgb(231, 76, 60));
            btnCancel.Click += BtnCancel_Click;
            pnlToolbar.Controls.Add(btnCancel);

            lblCount = new Label
            {
                Text = "0 bilet",
                Location = new Point(580, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };
            pnlToolbar.Controls.Add(lblCount);

            // DataGridView
            dgvTickets = new DataGridView
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
            dgvTickets.RowTemplate.Height = 40;
            dgvTickets.CellDoubleClick += (s, e) => BtnDetails_Click(s, e);
            this.Controls.Add(dgvTickets);
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

        private void LoadTickets()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT t.Id, t.TicketNo AS 'Bilet No', 
                                   t.PassengerName AS 'Yolcu Adı',
                                   s1.Name || ' → ' || s2.Name AS 'Güzergah',
                                   tr.DepartureTime AS 'Kalkış',
                                   t.SeatNumber AS 'Koltuk',
                                   t.FinalPrice AS 'Ücret',
                                   CASE t.Status 
                                       WHEN 0 THEN '⏳ Rezerve'
                                       WHEN 1 THEN '✅ Aktif'
                                       WHEN 2 THEN '❌ İptal'
                                       WHEN 3 THEN '✔️ Kullanıldı'
                                       WHEN 4 THEN '💰 İade'
                                       ELSE 'Bilinmiyor'
                                   END AS 'Durum',
                                   t.PurchaseDate AS 'Satın Alma',
                                   t.Status AS StatusId
                                   FROM Tickets t
                                   INNER JOIN Trips tr ON t.TripId = tr.Id
                                   INNER JOIN Routes r ON tr.RouteId = r.Id
                                   INNER JOIN Stations s1 ON r.DepartureStationId = s1.Id
                                   INNER JOIN Stations s2 ON r.ArrivalStationId = s2.Id
                                   WHERE t.UserId = @UserId
                                   ORDER BY t.PurchaseDate DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            dgvTickets.DataSource = dt;

                            if (dgvTickets.Columns.Contains("Id"))
                                dgvTickets.Columns["Id"].Visible = false;
                            if (dgvTickets.Columns.Contains("StatusId"))
                                dgvTickets.Columns["StatusId"].Visible = false;

                            lblCount.Text = $"{dt.Rows.Count} bilet";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterTickets()
        {
            if (dgvTickets.DataSource == null) return;
            var dt = dgvTickets.DataSource as DataTable;
            if (dt == null) return;

            string filter = "";
            switch (cmbStatus.SelectedIndex)
            {
                case 1: filter = "StatusId = 1"; break; // Aktif
                case 2: filter = "StatusId = 2"; break; // İptal
                case 3: filter = "StatusId = 3"; break; // Kullanıldı
            }

            dt.DefaultView.RowFilter = filter;
            lblCount.Text = $"{dt.DefaultView.Count} bilet";
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir bilet seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvTickets.SelectedRows[0];
            string details = $"🎫 BİLET DETAYI\n" +
                           $"══════════════════════\n\n" +
                           $"Bilet No: {row.Cells["Bilet No"].Value}\n" +
                           $"Yolcu: {row.Cells["Yolcu Adı"].Value}\n" +
                           $"Güzergah: {row.Cells["Güzergah"].Value}\n" +
                           $"Kalkış: {row.Cells["Kalkış"].Value}\n" +
                           $"Koltuk: {row.Cells["Koltuk"].Value}\n" +
                           $"Ücret: ₺{row.Cells["Ücret"].Value}\n" +
                           $"Durum: {row.Cells["Durum"].Value}\n" +
                           $"Satın Alma: {row.Cells["Satın Alma"].Value}";

            MessageBox.Show(details, "Bilet Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek için bir bilet seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ticketId = Convert.ToInt32(dgvTickets.SelectedRows[0].Cells["Id"].Value);
            int status = Convert.ToInt32(dgvTickets.SelectedRows[0].Cells["StatusId"].Value);
            string ticketNo = dgvTickets.SelectedRows[0].Cells["Bilet No"].Value.ToString();

            if (status != 1)
            {
                MessageBox.Show("Sadece aktif biletler iptal edilebilir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"'{ticketNo}' numaralı bileti iptal etmek istediğinize emin misiniz?\n\nİade tutarı hesabınıza yatırılacaktır.",
                "Bilet İptali",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string sql = @"UPDATE Tickets SET Status = 2, CancelledAt = @CancelDate, 
                                       CancelReason = 'Kullanıcı tarafından iptal edildi' WHERE Id = @Id";
                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", ticketId);
                            cmd.Parameters.AddWithValue("@CancelDate", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Bilet başarıyla iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTickets();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}