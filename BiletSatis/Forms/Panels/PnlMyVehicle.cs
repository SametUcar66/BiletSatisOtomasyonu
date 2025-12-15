using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms.Panels
{
    public class PnlMyVehicle : Panel
    {
        private Panel pnlCard;
        private Button btnRefresh;

        public PnlMyVehicle()
        {
            InitializeComponents();
            LoadVehicleInfo();
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
                Text = "🚐 Aracım",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlToolbar.Controls.Add(lblTitle);

            btnRefresh = new Button
            {
                Text = "🔄 Yenile",
                Location = new Point(150, 12),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => RefreshData();
            pnlToolbar.Controls.Add(btnRefresh);
        }

        public void RefreshData()
        {
            // Eski kartı temizle (olayları iptal et ve dispose et)
            if (pnlCard != null)
            {
                pnlCard.Paint -= PnlCard_Paint;
                this.Controls.Remove(pnlCard);
                pnlCard.Dispose();
                pnlCard = null;
            }

            // "Araç yok" mesajını temizle
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Label lbl && lbl.Name == "lblNoVehicle")
                {
                    this.Controls.Remove(lbl);
                    lbl.Dispose();
                }
            }

            LoadVehicleInfo();
        }

        private void LoadVehicleInfo()
        {
            // Oturum kontrolü
            if (SessionManager.CurrentUser == null)
            {
                ShowNoVehicleMessage("⚠️ Lütfen önce giriş yapın.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Şoförün atandığı aracı bul (en son sefer üzerinden)
                    string sql = @"SELECT v.*, a.Name AS AgencyName
                                   FROM Vehicles v
                                   INNER JOIN Trips t ON t.VehicleId = v.Id
                                   INNER JOIN Drivers d ON (t.DriverId = d.Id OR t.SecondDriverId = d.Id)
                                   INNER JOIN Agencies a ON v.AgencyId = a.Id
                                   WHERE d.UserId = @UserId
                                   ORDER BY t.DepartureTime DESC
                                   LIMIT 1";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CreateVehicleCard(reader);
                            }
                            else
                            {
                                ShowNoVehicleMessage();
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

        private void CreateVehicleCard(SQLiteDataReader reader)
        {
            // Eğer önceki kart varsa temizle
            if (pnlCard != null)
            {
                pnlCard.Paint -= PnlCard_Paint;
                this.Controls.Remove(pnlCard);
                pnlCard.Dispose();
                pnlCard = null;
            }

            // Ana kart
            pnlCard = new Panel
            {
                Location = new Point(30, 90),
                Size = new Size(550, 420),
                BackColor = Color.White
            };

            // Kart kenar yuvarlaklığı - olay işleyici metot kullanılıyor
            pnlCard.Paint += PnlCard_Paint;

            this.Controls.Add(pnlCard);

            // Başlık
            var lblTitle = new Label
            {
                Text = "🚐 Araç Bilgileri",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblTitle);

            int y = 60;
            int spacing = 45;

            // Plaka (büyük)
            string plateNumber = reader["PlateNumber"] != DBNull.Value ? reader["PlateNumber"].ToString() : "-";
            var lblPlate = new Label
            {
                Text = plateNumber,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185),
                Location = new Point(20, y),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblPlate);

            // Araç tipi ikonu
            int vehicleType = reader["VehicleType"] != DBNull.Value ? Convert.ToInt32(reader["VehicleType"]) : 0;
            var lblTypeIcon = new Label
            {
                Text = vehicleType == 0 ? "🚌" : "✈️",
                Font = new Font("Segoe UI", 36),
                Location = new Point(300, y - 10),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblTypeIcon);
            y += 70;

            // Marka - Model
            string brand = reader["Brand"] != DBNull.Value ? reader["Brand"].ToString() : "-";
            string model = reader["Model"] != DBNull.Value ? reader["Model"].ToString() : "-";
            CreateInfoRow(pnlCard, "Marka / Model:", $"{brand} {model}", y);
            y += spacing;

            // Yıl - Kapasite
            string year = reader["Year"] != DBNull.Value ? reader["Year"].ToString() : "-";
            string capacity = reader["Capacity"] != DBNull.Value ? $"{reader["Capacity"]} koltuk" : "-";
            CreateInfoRow(pnlCard, "Yıl:", year, y, 20);
            CreateInfoRow(pnlCard, "Kapasite:", capacity, y, 200);
            y += spacing;

            // Ajans
            string agencyName = reader["AgencyName"] != DBNull.Value ? reader["AgencyName"].ToString() : "-";
            CreateInfoRow(pnlCard, "Ajans:", agencyName, y);
            y += spacing;

            // Durum
            int status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0;
            string statusText = status == 0 ? "✅ Aktif" : status == 1 ? "🔧 Bakımda" : "❌ Devre Dışı";
            Color statusColor = status == 0 ? Color.FromArgb(39, 174, 96) : status == 1 ? Color.FromArgb(243, 156, 18) : Color.FromArgb(192, 57, 43);

            CreateInfoRow(pnlCard, "Durum:", statusText, y, 20, statusColor);
            y += spacing;

            // Toplam KM
            int totalKm = reader["TotalKm"] != DBNull.Value ? Convert.ToInt32(reader["TotalKm"]) : 0;
            CreateInfoRow(pnlCard, "Toplam KM:", $"{totalKm:N0} km", y);
            y += spacing;

            // Bakım bilgileri
            string lastMaintenance = reader["LastMaintenanceDate"] != DBNull.Value
                ? Convert.ToDateTime(reader["LastMaintenanceDate"]).ToString("dd.MM.yyyy")
                : "-";
            string nextMaintenance = reader["NextMaintenanceDate"] != DBNull.Value
                ? Convert.ToDateTime(reader["NextMaintenanceDate"]).ToString("dd.MM.yyyy")
                : "-";

            CreateInfoRow(pnlCard, "Son Bakım:", lastMaintenance, y, 20);
            CreateInfoRow(pnlCard, "Sonraki Bakım:", nextMaintenance, y, 200);
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            if (panel == null)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using (var path = GetRoundedRectPath(rect, 10))
            using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void CreateInfoRow(Panel parent, string label, string value, int y, int x = 20, Color? valueColor = null)
        {
            parent.Controls.Add(new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(x, y),
                AutoSize = true
            });

            parent.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = valueColor ?? Color.FromArgb(44, 62, 80),
                Location = new Point(x, y + 18),
                AutoSize = true
            });
        }

        private void ShowNoVehicleMessage(string message = null)
        {
            var lblNoVehicle = new Label
            {
                Name = "lblNoVehicle",
                Text = message ?? "🚐 Henüz bir araca atanmadınız.\n\nSefer ataması yapıldığında araç bilgileri burada görünecektir.",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Gray,
                Location = new Point(50, 110),
                AutoSize = true
            };
            this.Controls.Add(lblNoVehicle);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pnlCard != null)
                {
                    pnlCard.Paint -= PnlCard_Paint;
                    pnlCard.Dispose();
                    pnlCard = null;
                }
                btnRefresh?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}